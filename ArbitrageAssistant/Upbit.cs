using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArbitrageAssistant.ArbitAssist;

namespace ArbitrageAssistant
{
    class Upbit
    {
        WebClient c = new WebClient();

        public List<UpbitModel> UpbitF()
        {
            try
            {
                string allMarketsString = c.DownloadString("https://api.upbit.com/v1/market/all");
                JArray allMarketsArray = JArray.Parse(allMarketsString);
                string pairsString = null;
                foreach (JToken item in allMarketsArray)
                {
                    UpbitPair pair = JsonConvert.DeserializeObject<UpbitPair>(item.ToString());
                    pairsString = pairsString + "," + pair.Market;
                }

                string allTickersString = c.DownloadString($"https://api.upbit.com/v1/ticker?markets= {pairsString.Substring(1)}");
                JArray allTickersArray = JArray.Parse(allTickersString); //Decimals in allTickersString are normal but they turn to scientific notation in allTickersArray over here.

                // !!! Pairs notation is reversed at Upbit API. e.g. BTC/KRW symbolized by KRW-BTC. 
                // But variable naming are not reversed below. e.g btcKrw for BTC/KRW.
                Ticker btcUsdt = JsonConvert.DeserializeObject<Ticker>(allTickersArray[75].ToString());
                decimal btcUsdtLastPrice = Convert.ToDecimal(btcUsdt.Trade_price, System.Globalization.CultureInfo.InvariantCulture);

                List<RatioModel> ratiosOverBTC = new List<RatioModel>();
                List<Ticker> ratiosOverUSDT = new List<Ticker>();

                foreach (var item in allTickersArray)
                {
                    Ticker ticker = JsonConvert.DeserializeObject<Ticker>(item.ToString());

                    if (ticker.Market.Substring(0, 3).Contains("BTC"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = ticker.Market,
                            LastPrice = decimal.Parse(ticker.Trade_price, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture).ToString(),
                            QuoteVolume = decimal.Parse(ticker.Acc_trade_price_24h, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture).ToString(),
                        };

                        ratiosOverBTC.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice);
                        ratioModel.Value1 = (ratioModelLastPrice * btcUsdtLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (ticker.Market.Substring(0, 4).Contains("USDT"))
                    {
                        ratiosOverUSDT.Add(ticker);
                    }
                }

                IEnumerable<RatioModel> ratiosOverBtcInOrder = ratiosOverBTC.OrderBy(ratioModel => decimal.Parse(ratioModel.QuoteVolume)).Reverse();

                IDictionary<string, RatioModel> btcDict = new Dictionary<string, RatioModel>();

                foreach (var item in ratiosOverBtcInOrder)
                {
                    btcDict.Add(item.Symbol.Substring(4), item);
                }

                foreach (var usdtItem in ratiosOverUSDT)
                {
                    if (btcDict.Keys.Contains(usdtItem.Market.Substring(5)))
                    {
                        btcDict[usdtItem.Market.Substring(5)].Value2 = usdtItem.Trade_price;
                    }
                }

                foreach (var ratioModel in ratiosOverBtcInOrder)
                {
                    if (Convert.ToDecimal(ratioModel.QuoteVolume, System.Globalization.CultureInfo.InvariantCulture) > 0)
                    {

                        decimal[] valuesInRow = { Convert.ToDecimal(ratioModel.Value1, System.Globalization.CultureInfo.InvariantCulture),
                                              Convert.ToDecimal(ratioModel.Value2, System.Globalization.CultureInfo.InvariantCulture) };

                        decimal[] valuesInRowNoZero = { };
                        int i = 0;

                        foreach (decimal value in valuesInRow)

                            if (value != 0)
                            {
                                Array.Resize(ref valuesInRowNoZero, i + 1);
                                valuesInRowNoZero[i] = value;
                                i++;
                            };

                        int indexOfMin = Array.IndexOf(valuesInRowNoZero, valuesInRowNoZero.Min());
                        int indexOfMax = Array.IndexOf(valuesInRowNoZero, valuesInRowNoZero.Max());
                        int[] rankOfIndex = { indexOfMin, indexOfMax };
                        decimal difference = valuesInRowNoZero[rankOfIndex.Min()] - valuesInRowNoZero[rankOfIndex.Max()];
                        ratioModel.Difference = difference.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.ResultValue = (difference / valuesInRowNoZero[rankOfIndex.Min()]).ToString("0.##########", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        ratioModel.ResultValue = "0";
                    }
                }

                var bRatiosOverBtcInOrderList = ratiosOverBtcInOrder.ToList();
                List<UpbitModel> finalList = new List<UpbitModel>();
                foreach (var item in bRatiosOverBtcInOrderList)
                {
                    UpbitModel upbitModel = new UpbitModel
                    {
                        Symbol = item.Symbol.Substring(4),
                        Value1 = item.Value1,
                        Value2 = item.Value2,
                        Difference = item.Difference,
                        ResultValue = item.ResultValue,
                        QuoteVolume = item.QuoteVolume
                    };

                    finalList.Add(upbitModel);
                }

                return finalList;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Bağlanamadı! İnternet bağlantınızı kontrol edip uygulamayı tekrar çalıştırmayı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<UpbitModel>();
            }

        }
    }
}

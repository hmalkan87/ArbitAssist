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
    public class Binance
    {
        WebClient c = new WebClient();

        public List<BinanceModel> BinanceF()
        {
            try
            {
                string allData = c.DownloadString("https://www.binance.com/api/v3/ticker/24hr");

                JArray allDataArray = JArray.Parse(allData);
                BRatio ethBtc = JsonConvert.DeserializeObject<BRatio>(allDataArray[0].ToString());
                decimal ethBtcLastPrice = Convert.ToDecimal(ethBtc.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                BRatio bnbEth = JsonConvert.DeserializeObject<BRatio>(allDataArray[10].ToString());
                decimal bnbEthLastPrice = Convert.ToDecimal(bnbEth.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                BRatio ethUsdt = JsonConvert.DeserializeObject<BRatio>(allDataArray[12].ToString());
                decimal ethUsdtLastPrice = Convert.ToDecimal(ethUsdt.LastPrice, System.Globalization.CultureInfo.InvariantCulture);


                List<RatioModel> bRatiosOverBTC = new List<RatioModel>();
                List<BRatio> bRatiosOverETH = new List<BRatio>();
                List<RatioModel> bRatiosOverBNB = new List<RatioModel>();
                List<RatioModel> bRatiosOverUSDT = new List<RatioModel>();
                foreach (var item in allDataArray)
                {
                    BRatio bRatio = JsonConvert.DeserializeObject<BRatio>(item.ToString());

                    if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("BTC"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = bRatio.Symbol,
                            LastPrice = bRatio.LastPrice,
                            QuoteVolume = bRatio.QuoteVolume
                        };

                        bRatiosOverBTC.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value1 = (ratioModelLastPrice / ethBtcLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("ETH"))
                    {
                        bRatiosOverETH.Add(bRatio);
                        //decimal ratioModelLastPrice = Convert.ToDecimal(bRatio.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("BNB"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = bRatio.Symbol,
                            LastPrice = bRatio.LastPrice,
                            QuoteVolume = bRatio.QuoteVolume
                        };
                        bRatiosOverBNB.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value3 = (ratioModelLastPrice * bnbEthLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 4).Contains("USDT"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = bRatio.Symbol,
                            LastPrice = bRatio.LastPrice,
                            QuoteVolume = bRatio.QuoteVolume
                        };
                        bRatiosOverUSDT.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value4 = (ratioModelLastPrice / ethUsdtLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }

                var bRatiosOverBtcInOrder = bRatiosOverBTC.OrderBy(ratioModel => decimal.Parse(ratioModel.QuoteVolume)).Reverse();

                IDictionary<string, RatioModel> btcDict = new Dictionary<string, RatioModel>();

                foreach (var item in bRatiosOverBtcInOrder)
                {
                    btcDict.Add(item.Symbol.Substring(0, item.Symbol.Length - 3), item);
                }

                foreach (var ethItem in bRatiosOverETH)
                {
                    if (btcDict.Keys.Contains(ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 3)))
                    {
                        btcDict[ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 3)].XxxEth = ethItem.LastPrice;
                    }
                }

                foreach (var bnbItem in bRatiosOverBNB)
                {
                    if (btcDict.Keys.Contains(bnbItem.Symbol.Substring(0, bnbItem.Symbol.Length - 3)))
                    {
                        btcDict[bnbItem.Symbol.Substring(0, bnbItem.Symbol.Length - 3)].Value3 = bnbItem.Value3;
                    }
                }

                foreach (var usdtItem in bRatiosOverUSDT)
                {
                    if (btcDict.Keys.Contains(usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 4)))
                    {
                        btcDict[usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 4)].Value4 = usdtItem.Value4;
                    }
                }

                foreach (var ratioModel in bRatiosOverBtcInOrder)
                {
                    if (Convert.ToDecimal(ratioModel.QuoteVolume, System.Globalization.CultureInfo.InvariantCulture) > 0)
                    {

                        decimal[] valuesInRow = { Convert.ToDecimal(ratioModel.Value1, System.Globalization.CultureInfo.InvariantCulture),
                                              Convert.ToDecimal(ratioModel.XxxEth, System.Globalization.CultureInfo.InvariantCulture),
                                              Convert.ToDecimal(ratioModel.Value3, System.Globalization.CultureInfo.InvariantCulture),
                                              Convert.ToDecimal(ratioModel.Value4, System.Globalization.CultureInfo.InvariantCulture) };

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

                var bRatiosOverBtcInOrderList = bRatiosOverBtcInOrder.ToList();
                List<BinanceModel> FinalList = new List<BinanceModel>();
                foreach (var item in bRatiosOverBtcInOrderList)
                {
                    BinanceModel rModel = new BinanceModel
                    {
                        Symbol = item.Symbol.Substring(0, item.Symbol.Length - 3),
                        Difference = item.Difference,
                        ResultValue = item.ResultValue,
                        Value1 = item.Value1,
                        Value3 = item.Value3,
                        Value4 = item.Value4,
                        XxxEth = item.XxxEth,
                        QuoteVolume = item.QuoteVolume
                    };

                    FinalList.Add(rModel);
                }

                return FinalList;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Bağlanamadı! İnternet bağlantınızı kontrol edip uygulamayı tekrar çalıştırmayı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BinanceModel>();
            }
        }
    }
}

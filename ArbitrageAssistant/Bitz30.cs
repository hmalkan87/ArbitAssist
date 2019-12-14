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
    class Bitz30
    {
        WebClient c = new WebClient();

        public List<BitzModel> Bitz30F()
        {
            try
            {
                string allData = c.DownloadString("https://api.bitzapi.com/Market/tickerall");

                JArray allDataArray = JArray.Parse("[" + allData + "]");
                BitZJson bitZJson = JsonConvert.DeserializeObject<BitZJson>(allDataArray[0].ToString());

                JArray dataArray = JArray.Parse("[" + bitZJson.data.ToString() + "]");
                Data data = JsonConvert.DeserializeObject<Data>(dataArray[0].ToString());

                List<Ratio> ratiosList = new List<Ratio>();

                foreach (KeyValuePair<string, JToken> item in (JObject)bitZJson.data)
                {
                    Ratio nesne = JsonConvert.DeserializeObject<Ratio>(item.Value.ToString());
                    ratiosList.Add(nesne);
                }
                // Information about the process above: https://www.newtonsoft.com/json/help/html/JObjectProperties.htm

                Ratio btcDkkt = ratiosList[3];
                decimal btcDkktLastPrice = Convert.ToDecimal(btcDkkt.Now, System.Globalization.CultureInfo.InvariantCulture);
                Ratio ethDkkt = ratiosList[4];
                decimal ethDkktLastPrice = Convert.ToDecimal(ethDkkt.Now, System.Globalization.CultureInfo.InvariantCulture);
                Ratio usdtDkkt = ratiosList[1];
                decimal usdtDkktLastPrice = Convert.ToDecimal(usdtDkkt.Now, System.Globalization.CultureInfo.InvariantCulture);



                List<RatioModel> ratiosOverBTC = new List<RatioModel>();
                List<RatioModel> ratiosOverETH = new List<RatioModel>();
                List<RatioModel> ratiosOverUSDT = new List<RatioModel>();
                List<Ratio> ratiosOverDKKT = new List<Ratio>();
                foreach (var ratio in ratiosList)
                {
                    //BRatio bRatio = JsonConvert.DeserializeObject<BRatio>(item.ToString());

                    if (ratio.Symbol.Substring(ratio.Symbol.Length - 3).Contains("btc"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = ratio.Symbol,
                            LastPrice = ratio.Now,
                            QuoteVolume = ratio.QuoteVolume
                        };

                        ratiosOverBTC.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value1 = (ratioModelLastPrice * btcDkktLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (ratio.Symbol.Substring(ratio.Symbol.Length - 3).Contains("eth"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = ratio.Symbol,
                            LastPrice = ratio.Now,
                            QuoteVolume = ratio.QuoteVolume
                        };
                        ratiosOverETH.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value2 = (ratioModelLastPrice * ethDkktLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (ratio.Symbol.Substring(ratio.Symbol.Length - 4).Contains("usdt"))
                    {
                        RatioModel ratioModel = new RatioModel
                        {
                            Symbol = ratio.Symbol,
                            LastPrice = ratio.Now,
                            QuoteVolume = ratio.QuoteVolume
                        };
                        ratiosOverUSDT.Add(ratioModel);
                        decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                        ratioModel.Value3 = (ratioModelLastPrice * usdtDkktLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    if (ratio.Symbol.Substring(ratio.Symbol.Length - 4).Contains("dkkt"))
                    {
                        ratiosOverDKKT.Add(ratio);
                        //decimal ratioModelLastPrice = Convert.ToDecimal(bRatio.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
                    }
                }

                IEnumerable<RatioModel> ratiosOverBtcInOrder = ratiosOverBTC.OrderBy(ratioModel => decimal.Parse(ratioModel.QuoteVolume)).Reverse();

                IDictionary<string, RatioModel> btcDict = new Dictionary<string, RatioModel>();

                foreach (var item in ratiosOverBtcInOrder)
                {
                    btcDict.Add(item.Symbol.Substring(0, item.Symbol.Length - 4), item);
                }

                foreach (var ethItem in ratiosOverETH)
                {
                    if (btcDict.Keys.Contains(ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 4)))
                    {
                        btcDict[ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 4)].Value2 = ethItem.Value2;
                    }
                }

                foreach (var usdtItem in ratiosOverUSDT)
                {
                    if (btcDict.Keys.Contains(usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 5)))
                    {
                        btcDict[usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 5)].Value3 = usdtItem.Value3;
                    }
                }

                foreach (var dkktItem in ratiosOverDKKT)
                {
                    if (btcDict.Keys.Contains(dkktItem.Symbol.Substring(0, dkktItem.Symbol.Length - 5)))
                    {
                        btcDict[dkktItem.Symbol.Substring(0, dkktItem.Symbol.Length - 5)].Value4 = dkktItem.Now;
                    }
                }

                foreach (var ratioModel in ratiosOverBtcInOrder)
                {
                    if (Convert.ToDecimal(ratioModel.QuoteVolume, System.Globalization.CultureInfo.InvariantCulture) > 0)
                    {

                        decimal[] valuesInRow = { Convert.ToDecimal(ratioModel.Value1, System.Globalization.CultureInfo.InvariantCulture),
                                              Convert.ToDecimal(ratioModel.Value2, System.Globalization.CultureInfo.InvariantCulture),
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

                IEnumerable<RatioModel> ratiosOverBtcOrderedByResultValue = ratiosOverBTC.OrderBy(ratioModel => decimal.Parse(ratioModel.ResultValue));
                IEnumerable<RatioModel> ratiosOverBtcOrderedByResultValueLast10 = ratiosOverBtcOrderedByResultValue.Take(30);
                IEnumerable<RatioModel> ratiosOverBtcOrderedByResultValueTop10 = ratiosOverBtcOrderedByResultValue.Reverse().Take(30);
                IEnumerable<RatioModel> ratiosOverBtcOrderedByResultValueTop10Last10 = ratiosOverBtcOrderedByResultValueTop10.Concat(ratiosOverBtcOrderedByResultValueLast10.Reverse());

                var ratiosOverBtcOrderedByResultValueTop10Last10List = ratiosOverBtcOrderedByResultValueTop10Last10.ToList();
                List<BitzModel> finalList = new List<BitzModel>();
                foreach (var item in ratiosOverBtcOrderedByResultValueTop10Last10List)
                {
                    BitzModel bitzModel = new BitzModel
                    {
                        Symbol = item.Symbol.Substring(0, item.Symbol.Length - 4).ToUpper(),
                        Difference = item.Difference,
                        ResultValue = item.ResultValue,
                        Value1 = item.Value1,
                        Value2 = item.Value2,
                        Value3 = item.Value3,
                        Value4 = item.Value4,
                        QuoteVolume = item.QuoteVolume
                    };

                    finalList.Add(bitzModel);
                }

                return finalList;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Bağlanamadı! İnternet bağlantınızı kontrol edip uygulamayı tekrar çalıştırmayı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BitzModel>();
            }
        }
    }
}

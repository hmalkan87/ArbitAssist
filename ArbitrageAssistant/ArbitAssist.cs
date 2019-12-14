using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbitrageAssistant
{
    public partial class ArbitAssist : Form
    {
        public ArbitAssist()
        {
            InitializeComponent();
        }

        ////WebClient c = new WebClient();



        //public class BzDkkt
        //{
        //    public string now { get; set; }
        //}

        //public void SetInfo()
        //{
        //    try
        //    {
        //        string allData = c.DownloadString("https://www.binance.com/api/v3/ticker/24hr");

        //        JArray allDataArray = JArray.Parse(allData);
        //        BRatio ethBtc = JsonConvert.DeserializeObject<BRatio>(allDataArray[0].ToString());
        //        decimal ethBtcLastPrice = Convert.ToDecimal(ethBtc.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //        BRatio bnbEth = JsonConvert.DeserializeObject<BRatio>(allDataArray[10].ToString());
        //        decimal bnbEthLastPrice = Convert.ToDecimal(bnbEth.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //        BRatio ethUsdt = JsonConvert.DeserializeObject<BRatio>(allDataArray[12].ToString());
        //        decimal ethUsdtLastPrice = Convert.ToDecimal(ethUsdt.LastPrice, System.Globalization.CultureInfo.InvariantCulture);


        //        List<RatioModel> bRatiosOverBTC = new List<RatioModel>();
        //        List<BRatio> bRatiosOverETH = new List<BRatio>();
        //        List<RatioModel> bRatiosOverBNB = new List<RatioModel>();
        //        List<RatioModel> bRatiosOverUSDT = new List<RatioModel>();
        //        foreach (var item in allDataArray)
        //        {
        //            BRatio bRatio = JsonConvert.DeserializeObject<BRatio>(item.ToString());

        //            if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("BTC"))
        //            {
        //                RatioModel ratioModel = new RatioModel
        //                {
        //                    Symbol = bRatio.Symbol,
        //                    LastPrice = bRatio.LastPrice,
        //                    QuoteVolume = bRatio.QuoteVolume
        //                };

        //                bRatiosOverBTC.Add(ratioModel);
        //                decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //                ratioModel.Value1 = (ratioModelLastPrice / ethBtcLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
        //            }

        //            if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("ETH"))
        //            {
        //                bRatiosOverETH.Add(bRatio);
        //                //decimal ratioModelLastPrice = Convert.ToDecimal(bRatio.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //            }

        //            if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 3).Contains("BNB"))
        //            {
        //                RatioModel ratioModel = new RatioModel
        //                {
        //                    Symbol = bRatio.Symbol,
        //                    LastPrice = bRatio.LastPrice,
        //                    QuoteVolume = bRatio.QuoteVolume
        //                };
        //                bRatiosOverBNB.Add(ratioModel);
        //                decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //                ratioModel.Value3 = (ratioModelLastPrice * bnbEthLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
        //            }

        //            if (bRatio.Symbol.Substring(bRatio.Symbol.Length - 4).Contains("USDT"))
        //            {
        //                RatioModel ratioModel = new RatioModel
        //                {
        //                    Symbol = bRatio.Symbol,
        //                    LastPrice = bRatio.LastPrice,
        //                    QuoteVolume = bRatio.QuoteVolume
        //                };
        //                bRatiosOverUSDT.Add(ratioModel);
        //                decimal ratioModelLastPrice = Convert.ToDecimal(ratioModel.LastPrice, System.Globalization.CultureInfo.InvariantCulture);
        //                ratioModel.Value4 = (ratioModelLastPrice / ethUsdtLastPrice).ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
        //            }
        //        }

        //        var bRatiosOverBtcInOrder = bRatiosOverBTC.OrderBy(ratioModel => decimal.Parse(ratioModel.QuoteVolume)).Reverse();

        //        IDictionary<string, RatioModel> btcDict = new Dictionary<string, RatioModel>();

        //        foreach (var item in bRatiosOverBtcInOrder)
        //        {
        //            btcDict.Add(item.Symbol.Substring(0, item.Symbol.Length - 3), item);
        //        }

        //        foreach (var ethItem in bRatiosOverETH)
        //        {
        //            if (btcDict.Keys.Contains(ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 3)))
        //            {
        //                btcDict[ethItem.Symbol.Substring(0, ethItem.Symbol.Length - 3)].XxxEth = ethItem.LastPrice;
        //            }
        //        }

        //        foreach (var bnbItem in bRatiosOverBNB)
        //        {
        //            if (btcDict.Keys.Contains(bnbItem.Symbol.Substring(0, bnbItem.Symbol.Length - 3)))
        //            {
        //                btcDict[bnbItem.Symbol.Substring(0, bnbItem.Symbol.Length - 3)].Value3 = bnbItem.Value3;
        //            }
        //        }

        //        foreach (var usdtItem in bRatiosOverUSDT)
        //        {
        //            if (btcDict.Keys.Contains(usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 4)))
        //            {
        //                btcDict[usdtItem.Symbol.Substring(0, usdtItem.Symbol.Length - 4)].Value4 = usdtItem.Value4;
        //            }
        //        }

        //        foreach (var ratioModel in bRatiosOverBtcInOrder)
        //        {
        //            if (Convert.ToDecimal(ratioModel.QuoteVolume, System.Globalization.CultureInfo.InvariantCulture) > 0)
        //            {

        //                decimal[] valuesInRow = { Convert.ToDecimal(ratioModel.Value1, System.Globalization.CultureInfo.InvariantCulture),
        //                                      Convert.ToDecimal(ratioModel.XxxEth, System.Globalization.CultureInfo.InvariantCulture),
        //                                      Convert.ToDecimal(ratioModel.Value3, System.Globalization.CultureInfo.InvariantCulture),
        //                                      Convert.ToDecimal(ratioModel.Value4, System.Globalization.CultureInfo.InvariantCulture) };

        //                decimal[] valuesInRowNoZero = { };
        //                int i = 0;

        //                foreach (decimal value in valuesInRow)

        //                    if (value != 0)
        //                    {
        //                        Array.Resize(ref valuesInRowNoZero, i + 1);
        //                        valuesInRowNoZero[i] = value;
        //                        i++;
        //                    };

        //                int indexOfMin = Array.IndexOf(valuesInRowNoZero, valuesInRowNoZero.Min());
        //                int indexOfMax = Array.IndexOf(valuesInRowNoZero, valuesInRowNoZero.Max());
        //                int[] rankOfIndex = { indexOfMin, indexOfMax };
        //                decimal difference = valuesInRowNoZero[rankOfIndex.Min()] - valuesInRowNoZero[rankOfIndex.Max()];
        //                ratioModel.Difference = difference.ToString(System.Globalization.CultureInfo.InvariantCulture);
        //                ratioModel.ResultValue = (difference / valuesInRowNoZero[rankOfIndex.Min()]).ToString("0.##########", System.Globalization.CultureInfo.InvariantCulture);
        //            }
        //            else
        //            {
        //                ratioModel.ResultValue = "0";
        //            }

        //        }

        //        var ft = bRatiosOverBtcInOrder.ToList();
        //        List<RModel> gg = new List<RModel>();
        //        foreach (var item in ft)
        //        {
        //            RModel rModel = new RModel
        //            {
        //                Symbol = item.Symbol.Substring(0, item.Symbol.Length - 3),
        //                Difference = item.Difference,
        //                ResultValue = item.ResultValue,
        //                Value1 = item.Value1,
        //                Value3 = item.Value3,
        //                Value4 = item.Value4,
        //                XxxEth = item.XxxEth,
        //                QuoteVolume = item.QuoteVolume
        //            };
        //            gg.Add(rModel);
        //        }
        //        dgvMain.DataSource = gg;
        //        dgvMain.Columns[0].HeaderText = "Sembol";
        //        dgvMain.Columns[1].HeaderText = "(XXX/BTC) / (ETH/BTC)";
        //        dgvMain.Columns[2].HeaderText = "(XXX/ETH)";
        //        dgvMain.Columns[3].HeaderText = "(XXX/BNB) × (BNB/ETH)";
        //        dgvMain.Columns[4].HeaderText = "(XXX/USDT) / (ETH/USDT)";
        //        dgvMain.Columns[5].HeaderText = "Fark";
        //        dgvMain.Columns[6].HeaderText = "Sonuç";
        //        dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
        //    }
        //    catch (Exception ee)
        //    {
        //        timer2.Stop();
        //        MessageBox.Show("Bağlanamadı! İnternet bağlantınızı kontrol edip uygulamayı tekrar çalıştırmayı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        public class BRatio
        {
            public string Symbol { get; set; }
            public string LastPrice { get; set; }
            public string QuoteVolume { get; set; }
        }

        public class RatioModel
        {
            public string Symbol { get; set; }
            public string LastPrice { get; set; }
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string XxxEth { get; set; }
            public string Value3 { get; set; }
            public string Value4 { get; set; }
            public string XxxUsdt { get; set; }
            public string XxxDkkt { get; set; }
            public string Difference { get; set; }
            public string ResultValue { get; set; }
            public string QuoteVolume { get; set; }
        }

        public class Data
        {
            public object bz_dkkt { get; set; }
            public object eth_btc { get; set; }
            public object eos_btc { get; set; }
            public object bchsv_btc { get; set; }
        }

        public class BitZJson
        {
            public string status { get; set; }
            public string msg { get; set; }
            public object data { get; set; }
        }

        public class Ratio
        {
            public string Symbol { get; set; }
            public string Now { get; set; }
            public string QuoteVolume { get; set; }
        }

        public class Ticker
        {
            public string Market { get; set; }
            public string Trade_price { get; set; }
            public string Acc_trade_price_24h { get; set; }
        }

        public class UpbitPair
        {
            public string Market { get; set; }
        }

        public class BinanceModel
        {
            public string Symbol { get; set; }
            public string Value1 { get; set; }
            public string XxxEth { get; set; }
            public string Value3 { get; set; }
            public string Value4 { get; set; }
            public string Difference { get; set; }
            public string ResultValue { get; set; }
            public string QuoteVolume { get; set; }
        }

        public class BitzModel
        {
            public string Symbol { get; set; }
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }
            public string Value4 { get; set; }
            public string Difference { get; set; }
            public string ResultValue { get; set; }
            public string QuoteVolume { get; set; }
        }

        public class UpbitModel
        {
            public string Symbol { get; set; }
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Difference { get; set; }
            public string ResultValue { get; set; }
            public string QuoteVolume { get; set; }
        }

        string market = null;
        Binance30 binance30 = new Binance30();
        Binance binance = new Binance();
        Bitz bitz = new Bitz();
        Bitz30 bitz30 = new Bitz30();
        Upbit30 upbit30 = new Upbit30();
        Upbit upbit = new Upbit();
        private void ArbitAssist_Load(object sender, EventArgs e)
        {
            foreach (var item in dgvMain.Rows)
            {
                //DataGridViewRow row = dgvMain.Rows;
                //item.
                //item.DefaultCellStyle.ForeColor = Color.PowderBlue;

                //if (true)
                //{
                //    row.
                //    row.DefaultCellStyle.ForeColor = Color.PowderBlue;
                //    row.DefaultCellStyle.SelectionForeColor = Color.CadetBlue;
                //}
            }
            timer2.Start();
        }

        //private void Select_Market(object sender, EventArgs e)
        //{
        //    switch (tspRefresh.Text)
        //    {
        //        case "Yenilemeyi Aç":
        //            timer2.Start();
        //            tspRefresh.Text = "Yenilemeyi Kapat";
        //            break;
        //        case "Yenilemeyi Kapat":
        //            timer2.Stop();
        //            tspRefresh.Text = "Yenilemeyi Aç";
        //            break;
        //    }
        //}


        private void Set_TimerInterval_3(object sender, EventArgs e)
        {
            timer2.Interval = 3000;
            tssl_Status.Text = "Yenileme Sıklığı: 3 saniye";
        }

        private void Set_TimerInterval_5(object sender, EventArgs e)
        {
            timer2.Interval = 5000;
            tssl_Status.Text = "Yenileme Sıklığı: 5 saniye";
        }

        private void Set_TimerInterval_10(object sender, EventArgs e)
        {
            timer2.Interval = 10000;
            tssl_Status.Text = "Yenileme Sıklığı: 10 saniye";
        }

        private void Set_TimerInterval_30(object sender, EventArgs e)
        {
            timer2.Interval = 30000;
            tssl_Status.Text = "Yenileme Sıklığı: 30 saniye";
        }

        private void Timer_Stop(object sender, EventArgs e)
        {

            switch (tspRefresh.Text)
            {
                case "Yenilemeyi Aç":
                    timer2.Start();
                    tspRefresh.Text = "Yenilemeyi Kapat";
                    break;
                case "Yenilemeyi Kapat":
                    timer2.Stop();
                    tspRefresh.Text = "Yenilemeyi Aç";
                    break;
            }
        }

        private void Binance_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Binance";
            //binance.BinanceF();
            List<BinanceModel> finalList = binance.BinanceF();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) / (ETH/BTC)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH)";
            dgvMain.Columns[3].HeaderText = "(XXX/BNB) × (BNB/ETH)";
            dgvMain.Columns[4].HeaderText = "(XXX/USDT) / (ETH/USDT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "Binance Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Binance30_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Binance30";
            rb_ResultValue.Checked = true;
            //binance30.Binance30F();
            List<BinanceModel> finalList = binance30.Binance30F();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) / (ETH/BTC)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH)";
            dgvMain.Columns[3].HeaderText = "(XXX/BNB) × (BNB/ETH)";
            dgvMain.Columns[4].HeaderText = "(XXX/USDT) / (ETH/USDT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "Binance Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }

        private void Bitz_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Bitz";
            //bitz.BitzF();
            List<BitzModel> finalList = bitz.BitzF();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) × (BTC/DKKT)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH) × (ETH/DKKT)";
            dgvMain.Columns[3].HeaderText = "(XXX/USDT) × (USDT/DKKT)";
            dgvMain.Columns[4].HeaderText = "(XXX/DKKT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "BitZ Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Bitz30_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Bitz30";
            //bitz.BitzF();
            List<BitzModel> finalList = bitz30.Bitz30F();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) × (BTC/DKKT)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH) × (ETH/DKKT)";
            dgvMain.Columns[3].HeaderText = "(XXX/USDT) × (USDT/DKKT)";
            dgvMain.Columns[4].HeaderText = "(XXX/DKKT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "BitZ Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }

        private void Upbit_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Upbit";
            List<UpbitModel> finalList = upbit.UpbitF();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC)×(BTC/USDT)";
            dgvMain.Columns[2].HeaderText = "(XXX/USDT)";
            dgvMain.Columns[3].HeaderText = "Fark";
            dgvMain.Columns[4].HeaderText = "Sonuç";
            dgvMain.Columns[5].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "Upbit Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Upbit30_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            market = "Upbit30";
            List<UpbitModel> finalList = upbit30.Upbit30F();
            dgvMain.DataSource = finalList;
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC)×(BTC/USDT)";
            dgvMain.Columns[2].HeaderText = "(XXX/USDT)";
            dgvMain.Columns[3].HeaderText = "Fark";
            dgvMain.Columns[4].HeaderText = "Sonuç";
            dgvMain.Columns[5].HeaderText = "BTC Piyasası İşlem Hacmi";
            lbl_Header.Text = "Upbit Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //SetInfo();
            //binance30.Binance30F();
            object finalList = null;
            //List<BitzModel> finalList = null;
            switch (market)
            {
                case "Binance":
                    finalList = binance.BinanceF();
                    break;
                case "Binance30":
                    finalList = binance30.Binance30F();
                    break;
                case "Bitz":
                    finalList = bitz.BitzF();
                    break;
                case "Bitz30":
                    finalList = bitz30.Bitz30F();
                    break;
                case "Upbit":
                    finalList = upbit.UpbitF();
                    break;
                case "Upbit30":
                    finalList = upbit30.Upbit30F();
                    break;
            }
            //List<RModel> finalList = binance30.Binance30F();
            dgvMain.DataSource = finalList;
        }

        //TODO: status strip'te yenileme kaç saniye onu göster


        //private void dgvMain_CellFormatting(object sender, EventArgs e)
        //{
        //    if (e.Value != null)
        //    {
        //        if (Convert.ToDecimal(e.Value, System.Globalization.CultureInfo.InvariantCulture) < 0)
        //        {
        //            e.CellStyle.BackColor = Color.Green;
        //            e.CellStyle.SelectionBackColor = Color.Green;
        //            e.CellStyle.SelectionForeColor = Color.Black;
        //        }
        //        else if (e.Value.Equals("HAYIR"))
        //        {
        //            e.CellStyle.BackColor = Color.Red;
        //            e.CellStyle.SelectionBackColor = Color.Red;
        //            e.CellStyle.SelectionForeColor = Color.White;
        //        }

        //        //if (Convert.ToDecimal(item.Difference, System.Globalization.CultureInfo.InvariantCulture) < 0)
        //        //{
        //        //            < p class="alert-danger">@Html.DisplayFor(modelItem => item.Difference)</p>
        //        //        }
        //        //        else
        //        //        {
        //        //            <p class="alert-success">@Html.DisplayFor(modelItem => item.Difference)</p>
        //        //        }
        //    }
        //}
    }
}

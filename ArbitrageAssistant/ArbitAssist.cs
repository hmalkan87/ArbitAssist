using ArbitrageAssistant.Entities;
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

        string market = null;

        Binance binance = new Binance();
        Binance30 binance30 = new Binance30();
        Bitz bitz = new Bitz();
        Bitz30 bitz30 = new Bitz30();
        Upbit upbit = new Upbit();
        Upbit30 upbit30 = new Upbit30();


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

        //public void St()
        //{
        //    timer2.Stop();
        //}

        private void Binance_Run(object sender, EventArgs e)
        {
            List<BinanceModel> finalList = null;
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Binance";
            finalList = binance.BinanceF();
            dgvMain.DataSource = finalList;

            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            else
            {
                timer2.Stop();
            }

            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) / (ETH/BTC)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH)";
            dgvMain.Columns[3].HeaderText = "(XXX/BNB) × (BNB/ETH)";
            dgvMain.Columns[4].HeaderText = "(XXX/USDT) / (ETH/USDT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["XxxEth"].DisplayIndex = 2;
            dgvMain.Columns["Value3"].DisplayIndex = 3;
            dgvMain.Columns["Value4"].DisplayIndex = 4;
            dgvMain.Columns["Difference"].DisplayIndex = 5;
            dgvMain.Columns["ResultValue"].DisplayIndex = 6;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 7;
            lbl_Header.Text = "Binance Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Binance30_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Binance30";
            rb_ResultValue.Checked = true;
            List<BinanceModel> finalList = binance30.Binance30F();
            dgvMain.DataSource = finalList;
            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) / (ETH/BTC)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH)";
            dgvMain.Columns[3].HeaderText = "(XXX/BNB) × (BNB/ETH)";
            dgvMain.Columns[4].HeaderText = "(XXX/USDT) / (ETH/USDT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["XxxEth"].DisplayIndex = 2;
            dgvMain.Columns["Value3"].DisplayIndex = 3;
            dgvMain.Columns["Value4"].DisplayIndex = 4;
            dgvMain.Columns["Difference"].DisplayIndex = 5;
            dgvMain.Columns["ResultValue"].DisplayIndex = 6;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 7;
            lbl_Header.Text = "Binance Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }

        private void Bitz_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Bitz";
            List<BitzModel> finalList = bitz.BitzF();
            dgvMain.DataSource = finalList;
            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) × (BTC/DKKT)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH) × (ETH/DKKT)";
            dgvMain.Columns[3].HeaderText = "(XXX/USDT) × (USDT/DKKT)";
            dgvMain.Columns[4].HeaderText = "(XXX/DKKT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["Value2"].DisplayIndex = 2;
            dgvMain.Columns["Value3"].DisplayIndex = 3;
            dgvMain.Columns["Value4"].DisplayIndex = 4;
            dgvMain.Columns["Difference"].DisplayIndex = 5;
            dgvMain.Columns["ResultValue"].DisplayIndex = 6;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 7;
            lbl_Header.Text = "BitZ Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Bitz30_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Bitz30";
            List<BitzModel> finalList = bitz30.Bitz30F();
            dgvMain.DataSource = finalList;
            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC) × (BTC/DKKT)";
            dgvMain.Columns[2].HeaderText = "(XXX/ETH) × (ETH/DKKT)";
            dgvMain.Columns[3].HeaderText = "(XXX/USDT) × (USDT/DKKT)";
            dgvMain.Columns[4].HeaderText = "(XXX/DKKT)";
            dgvMain.Columns[5].HeaderText = "Fark";
            dgvMain.Columns[6].HeaderText = "Sonuç";
            dgvMain.Columns[7].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["Value2"].DisplayIndex = 2;
            dgvMain.Columns["Value3"].DisplayIndex = 3;
            dgvMain.Columns["Value4"].DisplayIndex = 4;
            dgvMain.Columns["Difference"].DisplayIndex = 5;
            dgvMain.Columns["ResultValue"].DisplayIndex = 6;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 7;
            lbl_Header.Text = "BitZ Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }

        private void Upbit_Run(object sender, EventArgs e)
        {
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Upbit";
            List<UpbitModel> finalList = upbit.UpbitF();
            dgvMain.DataSource = finalList;
            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC)×(BTC/USDT)";
            dgvMain.Columns[2].HeaderText = "(XXX/USDT)";
            dgvMain.Columns[3].HeaderText = "Fark";
            dgvMain.Columns[4].HeaderText = "Sonuç";
            dgvMain.Columns[5].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["Value2"].DisplayIndex = 2;
            dgvMain.Columns["Difference"].DisplayIndex = 3;
            dgvMain.Columns["ResultValue"].DisplayIndex = 4;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 5;
            lbl_Header.Text = "Upbit Borsası";
            lbl_Subtitle.Text = "İşlem Hacmine Göre Sıralı";
        }

        private void Upbit30_Run(object sender, EventArgs e)
        {
            List<UpbitModel> finalList = null;
            lbl_Header.Text = "Yükleniyor..";
            lbl_Subtitle.Text = "Veriler alınıyor..";
            Application.DoEvents();

            market = "Upbit30";
            finalList = upbit30.Upbit30F();
            dgvMain.DataSource = finalList;
            if (finalList.Count != 0)
            {
                timer2.Start();
            }
            dgvMain.Columns[0].HeaderText = "Sembol";
            dgvMain.Columns[1].HeaderText = "(XXX/BTC)×(BTC/USDT)";
            dgvMain.Columns[2].HeaderText = "(XXX/USDT)";
            dgvMain.Columns[3].HeaderText = "Fark";
            dgvMain.Columns[4].HeaderText = "Sonuç";
            dgvMain.Columns[5].HeaderText = "BTC Piyasası İşlem Hacmi";
            dgvMain.Columns["Symbol"].DisplayIndex = 0;
            dgvMain.Columns["Value1"].DisplayIndex = 1;
            dgvMain.Columns["Value2"].DisplayIndex = 2;
            dgvMain.Columns["Difference"].DisplayIndex = 3;
            dgvMain.Columns["ResultValue"].DisplayIndex = 4;
            dgvMain.Columns["QuoteVolume"].DisplayIndex = 5;
            lbl_Header.Text = "Upbit Borsası";
            lbl_Subtitle.Text = "Sonuç Değerine Göre Sıralı";
        }


        private void ArbitAssist_Load(object sender, EventArgs e)
        {
            //foreach (var item in dgvMain.Rows)
            //{
            //    //DataGridViewRow row = dgvMain.Rows;
            //    //item.
            //    //item.DefaultCellStyle.ForeColor = Color.PowderBlue;

            //    //if (true)
            //    //{
            //    //    row.
            //    //    row.DefaultCellStyle.ForeColor = Color.PowderBlue;
            //    //    row.DefaultCellStyle.SelectionForeColor = Color.CadetBlue;
            //    //}
            //}
            //timer2.Start();
        }

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
        //public int timeronoff = 1;

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

                    List<BinanceModel> f1 = (List<BinanceModel>)finalList;
                    if (f1.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
                case "Binance30":
                    finalList = binance30.Binance30F();

                    List<BinanceModel> f2 = (List<BinanceModel>)finalList;
                    if (f2.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
                case "Bitz":
                    finalList = bitz.BitzF();

                    List<BitzModel> f3 = (List<BitzModel>)finalList;
                    if (f3.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
                case "Bitz30":
                    finalList = bitz30.Bitz30F();

                    List<BitzModel> f4 = (List<BitzModel>)finalList;
                    if (f4.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
                case "Upbit":
                    finalList = upbit.UpbitF();

                    List<UpbitModel> f5 = (List<UpbitModel>)finalList;
                    if (f5.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
                case "Upbit30":
                    finalList = upbit30.Upbit30F();

                    List<UpbitModel> f6 = (List<UpbitModel>)finalList;
                    if (f6.Count == 0)
                    {
                        timer2.Stop();
                    }

                    break;
            }
            //List<RModel> finalList = binance30.Binance30F();

            dgvMain.DataSource = finalList;
            
            

            //if (timeronoff == 1)
            //{

            //}
            //else
            //{

            //}


        }
    }
}

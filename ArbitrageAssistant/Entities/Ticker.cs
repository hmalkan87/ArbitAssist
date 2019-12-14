using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbitrageAssistant.Entities
{
    class Ticker
    {
        public string Market { get; set; }
        public string Trade_price { get; set; }
        public string Acc_trade_price_24h { get; set; }
    }
}

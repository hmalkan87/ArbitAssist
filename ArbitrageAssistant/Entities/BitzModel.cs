using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbitrageAssistant.Entities
{
    class BitzModel
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AssetsInfo
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public double supply { get; set; }
        public double maxSuply { get; set; }
        public double marketCapUsd { get; set; }
        public double volumeUsd24Hr { get; set; }
        public double priceUsd { get; set; }
        public double changePercent24Hr { get; set; }
        public double vwap24Hr { get; set; }
    }
}

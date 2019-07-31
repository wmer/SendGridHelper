using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Models {
    public class Stats {
        public string date { get; set; }
        public List<Stat> stats { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Models {
    public class Stat {
        public string type { get; set; }
        public string name { get; set; }
        public Metrics metrics { get; set; }
    }
}

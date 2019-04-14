using System;

namespace SogaIntegratorWebApi.Models
{
    public class PTU
    {
        public int ID_LOK { get; set; } // 0
        public int ID_DOK { get; set; } // 1
        public int ID_VAT { get; set; } // 2
        public decimal VAT_P { get; set; } // 3
        public decimal WART_N { get; set; } // 4
        public decimal WART_V { get; set; } // 5
        public decimal WART_B { get; set; } // 6
        public DateTime DAKT { get; set; } // 7
    }
}
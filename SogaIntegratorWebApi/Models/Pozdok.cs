using System;

namespace SogaIntegratorWebApi.Models
{
    public class Pozdok
    {
        public int ID_LOK { get; set; } // 0
        public int ID_POZDOK { get; set; } // 1
        public int ID_DOK { get; set; } // 2
        public int NR_POZ { get; set; } // 3
        public int ID_POZDOK_KOR { get; set; } // 4
        public int ID_TW { get; set; } // 5
        public decimal ILOSC { get; set; } // 6
        public decimal WART_JN { get; set; } // 7
        public decimal WART_JB { get; set; } // 8
        public int ID_VAT { get; set; } // 9
        public decimal VAT_P { get; set; } // 10
        public decimal UPUST_P { get; set; } // 11
        public decimal WART_NU { get; set; } // 12
        public decimal WART_BU { get; set; } // 13
        public decimal WART_VU { get; set; } // 14
        public string UWAGI_POZ { get; set; } // 15
        public string F { get; set; } // 16
        public decimal UPUST_KW { get; set; } // 17
        public decimal KOSZT { get; set; } // 18
        public decimal ZAWARTOSC { get; set; } // 19
        public decimal ILOSC_MAG { get; set; } // 20
        public int ID_POCHOD { get; set; } // 25
        public DateTime DAKT { get; set; } // 26
    }
}
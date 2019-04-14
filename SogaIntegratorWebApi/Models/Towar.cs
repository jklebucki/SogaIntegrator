using System;

namespace SogaIntegratorWebApi.Models
{
    public class Towar
    {
        public int ID_TW { get; set; } // 0
        public string TYP_TW { get; set; } // 1
        public string KOD_TW { get; set; } // 2
        public string NAZWA_TW { get; set; } // 3
        public string SWW_TW { get; set; } // 4
        public string JED_TW { get; set; } // 5
        public decimal CENA_ZAK_N { get; set; } // 6
        public decimal CENA_ZAK_B { get; set; } // 7
        public int ID_VAT { get; set; } // 8
        public decimal VAT_P { get; set; } // 9
        public decimal STAN_TW { get; set; } // 10
        public int ID_GR { get; set; } // 11
        public string UWAGI { get; set; } // 12
        public int PRIORYTET { get; set; } // 13
        public int PLU { get; set; } // 14
        public int ID_DR { get; set; } // 15
        public string KOD_KR { get; set; } // 16
        public decimal CENA_SP_N_1 { get; set; } // 17
        public decimal CENA_SP_B_1 { get; set; } // 18
        public decimal CENA_SP_N_2 { get; set; } // 19
        public decimal CENA_SP_B_2 { get; set; } // 20
        public decimal CENA_SP_N_3 { get; set; } // 21
        public decimal CENA_SP_B_3 { get; set; } // 22
        public decimal CENA_SP_N_4 { get; set; } // 23
        public decimal CENA_SP_B_4 { get; set; } // 24
        public decimal CENA_SP_N_5 { get; set; } // 25
        public decimal CENA_SP_B_5 { get; set; } // 26
        public int MAX_RABAT { get; set; } // 27
        public int ZN_WAGA { get; set; } // 28
        public int ZN_CENA { get; set; } // 29
        public int FISK { get; set; } // 30
        public int POCKET { get; set; } // 31
        public int WWW { get; set; } // 32
        public int ID_GRZA { get; set; } // 33
        public int DEL { get; set; } // 34
        public int CZAS_STAN { get; set; } // 35
        public int CZAS_OS { get; set; } // 36
        public int ILOSC_OS { get; set; } // 37
        public int KOLOR_TW { get; set; } // 38
        public decimal KALORIE { get; set; } // 39
        public int PKT { get; set; } // 40
        public int NR_DF { get; set; } // 41
        public int FA_USLUGA { get; set; } // 42
        public DateTime DAKT { get; set; } // 43
        public int ID_DR_2 { get; set; } // 44
        public int WAGA_AUTO { get; set; } // 45
    }
}
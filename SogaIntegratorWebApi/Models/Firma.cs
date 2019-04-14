using System;

namespace SogaIntegratorWebApi.Models
{
    public class Firma
    {
        public int ID_FI { get; set; } // 0
        public string KOD_FI { get; set; } // 1
        public string NAZWA_FI_1 { get; set; } // 2
        public string NAZWA_FI_2 { get; set; } // 3
        public string K_P_FI { get; set; } // 4
        public string MIASTO_FI { get; set; } // 5
        public string ULICA_FI { get; set; } // 6
        public string NR_FI { get; set; } // 7
        public string NR_L_FI { get; set; } // 8
        public string NIP_FI { get; set; } // 9
        public string TEL_FI { get; set; } // 10
        public string FAX_FI { get; set; } // 11
        public string UWAGI_FI { get; set; } // 12
        public string KONTO { get; set; } // 13
        public string BANK { get; set; } // 14
        public string MAIL_FI { get; set; } // 15
        public string WWW { get; set; } // 16
        public int RR { get; set; } // 17
        public string NR_DOW { get; set; } // 18
        public string WYDAWCA_DOW { get; set; } // 19
        public string ANALITYKA { get; set; } // 20
        public int ID_KR { get; set; } // 21
        public int DEL { get; set; } // 22
        public DateTime DAKT { get; set; } // 23
        public DateTime DATA_INS { get; set; } // 24
        public int ID_UZ_INS { get; set; } // 25
        public int ID_ZR { get; set; } // 26
    }
}
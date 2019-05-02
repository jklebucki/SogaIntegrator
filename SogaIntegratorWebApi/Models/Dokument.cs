using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SogaIntegratorWebApi.Models
{
    public class Dokument
    {
        public int ID_LOK { get; set; } // 0				
        public int ID_DOK { get; set; } // 1				
        public string TYP_DOK { get; set; } // 2				
        public int ID_KOR { get; set; } // 3				
        public int ID_FI { get; set; } // 4				
        public int ID_FI_2 { get; set; } // 5				
        public DateTime DATA_WST { get; set; } // 6				
        public DateTime DATA_SPR { get; set; } // 7				
        public DateTime DATA_VAT { get; set; } // 8				
        public int NR { get; set; } // 9				
        public string CALY_NR { get; set; } // 10				
        public string CENA_WST { get; set; } // 11				
        public decimal WART_NU { get; set; } // 12				
        public decimal WART_BU { get; set; } // 13				
        public decimal WART_VU { get; set; } // 14				
        public string ODB { get; set; } // 15				
        public int ID_FO_DOZAP { get; set; } // 16				
        public string NR_ORYGIN { get; set; } // 17				
        public string STATUS { get; set; } // 18				
        public decimal EURO { get; set; } // 19				
        public decimal DOZAP { get; set; } // 20				
        public decimal UPUST_P { get; set; } // 21				
        public decimal UPUST_KW { get; set; } // 22				
        public decimal KOSZT { get; set; } // 23				
        public int ID_MA { get; set; } // 24				
        public int ID_KATDOK { get; set; } // 25				
        public int ID_POCHOD { get; set; } // 26				
        public decimal TAKSA_KL { get; set; } // 27				
        public string UWAGI { get; set; } // 28				
        public int ID_UZ { get; set; } // 29				
        public DateTime GODZ_WST { get; set; } // 30				
        public string DF { get; set; } // 31				
        public string PROG { get; set; } // 32				
        public string KOMP { get; set; } // 33				
        public int VAT_AUTO { get; set; } // 34				
        public int FUPR { get; set; } // 35				
        public int ID_PV { get; set; } // 36				
        public DateTime DAKT { get; set; } // 37				
        public string APL { get; set; } // 38				
        public decimal PRZEDPLATA { get; set; } // 39				
        public int DETAL { get; set; } // 40				
        public int ID_PKOR { get; set; } // 41				
    }
}

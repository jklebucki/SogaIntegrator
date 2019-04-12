using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SogaIntegratorWebApi.Models
{
    public class Dokument
    {
        public int ID_LOK { get; set; } //Identyfikator lokalizacji (klucz obcy)
        public int ID_DOK { get; set; } //Unikatowy identyfikator dokumentu
        public string TYP_DOK { get; set; } //Typ dokumentu
        public int ID_KOR { get; set; } //Identyfikator dokumentu korygowanego
        public int ID_FI { get; set; } //Identyfikator firmy (klucz obcy)
        public int ID_FI_2 { get; set; } //Identyfikator firmy (klucz obcy)
        public DateTime DATA_WST { get; set; } //Data wystawienia
        public DateTime DATA_SPR { get; set; } //Data sprzedaży
        public DateTime DATA_VAT { get; set; } //Data VAT
        public int NR { get; set; } //Numer dokumentu
        public string CALY_NR { get; set; } //Pełny numer dokumentu
        public string CENA_WST { get; set; } //Sposób wystawienia dokumentu (N-wg cen netto, B-wg cen brutto)
        public decimal WART_NU { get; set; } //Wartość netto dokumentu
        public decimal WART_BU { get; set; } //Wartość brutto dokumentu
        public decimal WART_VU { get; set; } //Wartość VAT dokumentu
        public string ODB { get; set; } //Osoba odbierająca dokument
        public int ID_FO_DOZAP { get; set; } //Identyfikator formy dla kwoty pozostającej do zapłaty (klucz obcy)
        public string NR_ORYGIN { get; set; } //Nr dokumentu dostawcy
        public string STATUS { get; set; } //Status dokumentu: N-normalny, Z-zaliczkowy, P-pochodny, F-proforma
        public decimal EURO { get; set; } //Kurs EURO
        public decimal PRZEDPLATA { get; set; } //Kwota przedpłacona
        public decimal DOZAP { get; set; } //Kwota pozostająca do zapłaty
        public decimal UPUST_P { get; set; } //Wartość procentowa upustu
        public decimal UPUST_KW { get; set; } //Upust kwotowy
        public decimal KOSZT { get; set; } //Koszt dokumentu
        public int ID_MA { get; set; } //Identyfikator magazynu (klucz obcy)
        public int ID_KATDOK { get; set; } //Identyfikator kategorii dokumentu (klucz obcy)
        public int ID_POCHOD { get; set; } //Identyfikator dokumentu pochodnego
        public decimal TAKSA_KL { get; set; } //Wartość taksy klimatycznej
        public string UWAGI { get; set; } //Uwagi do dokumentu
        public int ID_UZ { get; set; } //Identyfikator użytkownika (klucz obcy)
        public DateTime GODZ_WST { get; set; } //Godzina wystawienia
        public string DF { get; set; } //Znacznik fiskalizacji dokumentu
        public string PROG { get; set; } //Znacznik grupy programów, z której pochodzi dokument
        public int VAT_AUTO { get; set; } //Automatyczne przeliczanie VAT
        public string KOMP { get; set; } //Nazwa komputera, na którym dokument był ostatnio modyfikowany
        public int FUPR { get; set; } //Faktura uproszczona /1-tak, 0-nie/
        public int ID_PV { get; set; } //Identyfikator rodzaju przeznaczenia VAT (klucz obcy)
        public string APL { get; set; } //Znacznik programu, z którego pochodzi dokument
    }
}

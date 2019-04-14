using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SogaIntegratorWebApi.Configurations;
using SogaIntegratorWebApi.Models;

namespace SogaIntegratorWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GoodsController : ControllerBase
    {
        private IOptions<FirebaseConfig> firebaseConfig { get; set; }

        public GoodsController(IOptions<FirebaseConfig> firebaseConfig)
        {
            this.firebaseConfig = firebaseConfig;
        }
        // GET api/values/5
        [HttpGet]
        public IActionResult Get()
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Towar> list = new List<Towar>();

            try
            {
                fbConnection.Open();
                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                        "select ID_TW, TYP_TW, KOD_TW, NAZWA_TW, SWW_TW, JED_TW, CENA_ZAK_N, CENA_ZAK_B, " +
                        "ID_VAT, VAT_P, STAN_TW, ID_GR, UWAGI, PRIORYTET, PLU, ID_DR, KOD_KR, " +
                        "CENA_SP_N_1, CENA_SP_B_1, CENA_SP_N_2, CENA_SP_B_2, CENA_SP_N_3, CENA_SP_B_3, " +
                        "CENA_SP_N_4, CENA_SP_B_4, CENA_SP_N_5, CENA_SP_B_5, MAX_RABAT, ZN_WAGA, " +
                        "ZN_CENA, FISK, POCKET, WWW, ID_GRZA, DEL, CZAS_STAN, CZAS_OS, ILOSC_OS, KOLOR_TW, " +
                        "KALORIE, PKT, NR_DF, FA_USLUGA, DAKT, ID_DR_2, WAGA_AUTO " +
                        "from towary";

                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Towar
                    {
                        ID_TW = reader.GetInt32(0), //ID_TW
                        TYP_TW = reader.GetString(1), //TYP_TW
                        KOD_TW = reader.GetString(2), //KOD_TW
                        NAZWA_TW = reader.GetString(3), //NAZWA_TW
                        SWW_TW = reader.GetString(4), //SWW_TW
                        JED_TW = reader.GetString(5), //JED_TW
                        CENA_ZAK_N = reader.GetDecimal(6), //CENA_ZAK_N
                        CENA_ZAK_B = reader.GetDecimal(7), //CENA_ZAK_B
                        ID_VAT = reader.GetInt32(8), //ID_VAT
                        VAT_P = reader.GetDecimal(9), //VAT_P
                        STAN_TW = reader.GetDecimal(10), //STAN_TW
                        ID_GR = reader.GetInt32(11), //ID_GR
                        UWAGI = reader?.GetString(12), //UWAGI
                        PRIORYTET = reader.GetInt32(13), //PRIORYTET
                        PLU = !reader.IsDBNull(14) ? reader.GetInt32(14) : 0, //PLU
                        ID_DR = reader.GetInt32(15), //ID_DR
                        KOD_KR = reader?.GetString(16), //KOD_KR
                        CENA_SP_N_1 = reader.GetDecimal(17), //CENA_SP_N_1
                        CENA_SP_B_1 = reader.GetDecimal(18), //CENA_SP_B_1
                        CENA_SP_N_2 = reader.GetDecimal(19), //CENA_SP_N_2
                        CENA_SP_B_2 = reader.GetDecimal(20), //CENA_SP_B_2
                        CENA_SP_N_3 = reader.GetDecimal(21), //CENA_SP_N_3
                        CENA_SP_B_3 = reader.GetDecimal(22), //CENA_SP_B_3
                        CENA_SP_N_4 = reader.GetDecimal(23), //CENA_SP_N_4
                        CENA_SP_B_4 = reader.GetDecimal(24), //CENA_SP_B_4
                        CENA_SP_N_5 = reader.GetDecimal(25), //CENA_SP_N_5
                        CENA_SP_B_5 = reader.GetDecimal(26), //CENA_SP_B_5
                        MAX_RABAT = reader.GetInt32(27), //MAX_RABAT
                        ZN_WAGA = reader.GetInt32(28), //ZN_WAGA
                        ZN_CENA = reader.GetInt32(29), //ZN_CENA
                        FISK = reader.GetInt32(30), //FISK
                        POCKET = reader.GetInt32(31), //POCKET
                        WWW = reader.GetInt32(32), //WWW
                        ID_GRZA = reader.GetInt32(33), //ID_GRZA
                        DEL = reader.GetInt32(34), //DEL
                        CZAS_STAN = reader.GetInt32(35), //CZAS_STAN
                        CZAS_OS = reader.GetInt32(36), //CZAS_OS
                        ILOSC_OS = reader.GetInt32(37), //ILOSC_OS
                        KOLOR_TW = reader.GetInt32(38), //KOLOR_TW
                        KALORIE = reader.GetDecimal(39), //KALORIE
                        PKT = reader.GetInt32(40), //PKT
                        NR_DF = reader.GetInt32(41), //NR_DF
                        FA_USLUGA = reader.GetInt32(42), //FA_USLUGA
                        DAKT = reader.GetDateTime(43), //DAKT
                        ID_DR_2 = reader.GetInt32(44), //ID_DR_2
                        WAGA_AUTO = reader.GetInt32(45), //WAGA_AUTO
                    });
                }

                fbConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            JsonSerializerSettings responseJson = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };
            return new JsonResult(list, responseJson);
        }
        // GET api/values/5
        [HttpGet("{ids}")]
        public IActionResult Get(string ids)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Towar> list = new List<Towar>();

            try
            {
                fbConnection.Open();
                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                        "select ID_TW, TYP_TW, KOD_TW, NAZWA_TW, SWW_TW, JED_TW, CENA_ZAK_N, CENA_ZAK_B, " +
                        "ID_VAT, VAT_P, STAN_TW, ID_GR, UWAGI, PRIORYTET, PLU, ID_DR, KOD_KR, " +
                        "CENA_SP_N_1, CENA_SP_B_1, CENA_SP_N_2, CENA_SP_B_2, CENA_SP_N_3, CENA_SP_B_3, " +
                        "CENA_SP_N_4, CENA_SP_B_4, CENA_SP_N_5, CENA_SP_B_5, MAX_RABAT, ZN_WAGA, " +
                        "ZN_CENA, FISK, POCKET, WWW, ID_GRZA, DEL, CZAS_STAN, CZAS_OS, ILOSC_OS, KOLOR_TW, " +
                        "KALORIE, PKT, NR_DF, FA_USLUGA, DAKT, ID_DR_2, WAGA_AUTO " +
                        "from towary where ID_TW in (" + ids + ")";

                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Towar
                    {
                        ID_TW = reader.GetInt32(0), //ID_TW
                        TYP_TW = reader.GetString(1), //TYP_TW
                        KOD_TW = reader.GetString(2), //KOD_TW
                        NAZWA_TW = reader.GetString(3), //NAZWA_TW
                        SWW_TW = reader.GetString(4), //SWW_TW
                        JED_TW = reader.GetString(5), //JED_TW
                        CENA_ZAK_N = reader.GetDecimal(6), //CENA_ZAK_N
                        CENA_ZAK_B = reader.GetDecimal(7), //CENA_ZAK_B
                        ID_VAT = reader.GetInt32(8), //ID_VAT
                        VAT_P = reader.GetDecimal(9), //VAT_P
                        STAN_TW = reader.GetDecimal(10), //STAN_TW
                        ID_GR = reader.GetInt32(11), //ID_GR
                        UWAGI = reader?.GetString(12), //UWAGI
                        PRIORYTET = reader.GetInt32(13), //PRIORYTET
                        PLU = !reader.IsDBNull(14) ? reader.GetInt32(14) : 0, //PLU
                        ID_DR = reader.GetInt32(15), //ID_DR
                        KOD_KR = reader?.GetString(16), //KOD_KR
                        CENA_SP_N_1 = reader.GetDecimal(17), //CENA_SP_N_1
                        CENA_SP_B_1 = reader.GetDecimal(18), //CENA_SP_B_1
                        CENA_SP_N_2 = reader.GetDecimal(19), //CENA_SP_N_2
                        CENA_SP_B_2 = reader.GetDecimal(20), //CENA_SP_B_2
                        CENA_SP_N_3 = reader.GetDecimal(21), //CENA_SP_N_3
                        CENA_SP_B_3 = reader.GetDecimal(22), //CENA_SP_B_3
                        CENA_SP_N_4 = reader.GetDecimal(23), //CENA_SP_N_4
                        CENA_SP_B_4 = reader.GetDecimal(24), //CENA_SP_B_4
                        CENA_SP_N_5 = reader.GetDecimal(25), //CENA_SP_N_5
                        CENA_SP_B_5 = reader.GetDecimal(26), //CENA_SP_B_5
                        MAX_RABAT = reader.GetInt32(27), //MAX_RABAT
                        ZN_WAGA = reader.GetInt32(28), //ZN_WAGA
                        ZN_CENA = reader.GetInt32(29), //ZN_CENA
                        FISK = reader.GetInt32(30), //FISK
                        POCKET = reader.GetInt32(31), //POCKET
                        WWW = reader.GetInt32(32), //WWW
                        ID_GRZA = reader.GetInt32(33), //ID_GRZA
                        DEL = reader.GetInt32(34), //DEL
                        CZAS_STAN = reader.GetInt32(35), //CZAS_STAN
                        CZAS_OS = reader.GetInt32(36), //CZAS_OS
                        ILOSC_OS = reader.GetInt32(37), //ILOSC_OS
                        KOLOR_TW = reader.GetInt32(38), //KOLOR_TW
                        KALORIE = reader.GetDecimal(39), //KALORIE
                        PKT = reader.GetInt32(40), //PKT
                        NR_DF = reader.GetInt32(41), //NR_DF
                        FA_USLUGA = reader.GetInt32(42), //FA_USLUGA
                        DAKT = reader.GetDateTime(43), //DAKT
                        ID_DR_2 = reader.GetInt32(44), //ID_DR_2
                        WAGA_AUTO = reader.GetInt32(45), //WAGA_AUTO
                    });
                }

                fbConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            JsonSerializerSettings responseJson = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };
            return new JsonResult(list, responseJson);
        }
    }
}
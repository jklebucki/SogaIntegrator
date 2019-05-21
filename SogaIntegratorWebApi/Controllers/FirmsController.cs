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
    public class FirmsController : ControllerBase
    {
        private IOptions<FirebaseConfig> firebaseConfig { get; set; }
        private string test;

        public FirmsController(IOptions<FirebaseConfig> firebaseConfig)
        {
            this.firebaseConfig = firebaseConfig;
        }

        [HttpGet]
        [HttpGet("{ids}")]
        public IActionResult Get(string ids)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Firma> list = new List<Firma>();
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest();
            }
            try
            {
                fbConnection.Open();

                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                "select  ID_FI, KOD_FI, NAZWA_FI_1, NAZWA_FI_2, K_P_FI, MIASTO_FI, ULICA_FI, NR_FI, NR_L_FI, " +
                "NIP_FI, TEL_FI, FAX_FI, UWAGI_FI, KONTO, BANK, MAIL_FI, WWW, RR, NR_DOW, WYDAWCA_DOW, ANALITYKA, " +
                "ID_KR, DEL, DAKT, DATA_INS, ID_UZ_INS, ID_ZR " +
                "from firmy where " +
                "ID_FI IN (" + ids + ")";
                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Firma
                    {
                        ID_FI = reader.GetInt32(0), //ID_FI
                        KOD_FI = reader.GetString(1), //KOD_FI
                        NAZWA_FI_1 = reader.GetString(2), //NAZWA_FI_1
                        NAZWA_FI_2 = reader.GetString(3), //NAZWA_FI_2
                        K_P_FI = reader.GetString(4), //K_P_FI
                        MIASTO_FI = reader.GetString(5), //MIASTO_FI
                        ULICA_FI = reader.GetString(6), //ULICA_FI
                        NR_FI = reader.GetString(7), //NR_FI
                        NR_L_FI = reader.GetString(8), //NR_L_FI
                        NIP_FI = reader.GetString(9), //NIP_FI
                        TEL_FI = reader.GetString(10), //TEL_FI
                        FAX_FI = reader.GetString(11), //FAX_FI
                        UWAGI_FI = reader.GetString(12), //UWAGI_FI
                        KONTO = reader.GetString(13), //KONTO
                        BANK = reader.GetString(14), //BANK
                        MAIL_FI = reader.GetString(15), //MAIL_FI
                        WWW = reader.GetString(16), //WWW
                        RR = reader.GetInt32(17), //RR
                        NR_DOW = reader.GetString(18), //NR_DOW
                        WYDAWCA_DOW = reader.GetString(19), //WYDAWCA_DOW
                        ANALITYKA = reader.GetString(20), //ANALITYKA
                        ID_KR = reader.GetInt32(21), //ID_KR
                        DEL = reader.GetInt32(22), //DEL
                        DAKT = reader.GetDateTime(23), //DAKT
                        DATA_INS = reader.GetDateTime(24), //DATA_INS
                        ID_UZ_INS = reader.GetInt32(25), //ID_UZ_INS
                        ID_ZR = reader.GetInt32(26), //ID_ZR
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
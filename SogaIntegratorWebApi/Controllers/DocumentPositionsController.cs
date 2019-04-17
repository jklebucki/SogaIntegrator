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
    public class DocumentPositionsController : ControllerBase
    {
        private IOptions<FirebaseConfig> firebaseConfig { get; set; }

        public DocumentPositionsController(IOptions<FirebaseConfig> firebaseConfig)
        {
            this.firebaseConfig = firebaseConfig;
        }

        [HttpGet("{ids}")]
        public IActionResult Get(string ids)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Pozdok> list = new List<Pozdok>();
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest();
            }
            try
            {
                fbConnection.Open();
                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                "select ID_LOK, ID_POZDOK, ID_DOK, NR_POZ, ID_POZDOK_KOR, ID_TW, ILOSC, WART_JN, WART_JB, ID_VAT, " +
                "VAT_P, UPUST_P, WART_NU, WART_BU, WART_VU, UWAGI_POZ, F, UPUST_KW, KOSZT, ZAWARTOSC, ILOSC_MAG, " +
                "ID_POCHOD, DAKT from POZDOK where ID_DOK IN (" + ids + ")";
                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Pozdok
                    {
                        ID_LOK = reader.GetInt32(0), //ID_LOK
                        ID_POZDOK = reader.GetInt32(1), //ID_POZDOK
                        ID_DOK = reader.GetInt32(2), //ID_DOK
                        NR_POZ = reader.GetInt32(3), //NR_POZ
                        ID_POZDOK_KOR = reader.GetInt32(4), //ID_POZDOK_KOR
                        ID_TW = reader.GetInt32(5), //ID_TW
                        ILOSC = reader.GetDecimal(6), //ILOSC
                        WART_JN = reader.GetDecimal(7), //WART_JN
                        WART_JB = reader.GetDecimal(8), //WART_JB
                        ID_VAT = reader.GetInt32(9), //ID_VAT
                        VAT_P = reader.GetDecimal(10), //VAT_P
                        UPUST_P = reader.GetDecimal(11), //UPUST_P
                        WART_NU = reader.GetDecimal(12), //WART_NU
                        WART_BU = reader.GetDecimal(13), //WART_BU
                        WART_VU = reader.GetDecimal(14), //WART_VU
                        UWAGI_POZ = reader.GetString(15), //UWAGI_POZ
                        F = reader.GetString(16), //F
                        UPUST_KW = reader.GetDecimal(17), //UPUST_KW
                        KOSZT = reader.GetDecimal(18), //KOSZT
                        ZAWARTOSC = reader.GetDecimal(19), //ZAWARTOSC
                        ILOSC_MAG = reader.GetDecimal(20), //ILOSC_MAG
                        ID_POCHOD = reader.GetInt32(21), //ID_POCHOD
                        DAKT = reader.GetDateTime(22), //DAKT
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
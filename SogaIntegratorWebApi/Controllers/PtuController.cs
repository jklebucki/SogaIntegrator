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
    public class PtuController : ControllerBase
    {
        private IOptions<FirebaseConfig> firebaseConfig { get; set; }

        public PtuController(IOptions<FirebaseConfig> firebaseConfig)
        {
            this.firebaseConfig = firebaseConfig;
        }

        [HttpGet("{ids}")]
        public ActionResult<List<PTU>> Get(string ids)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<PTU> list = new List<PTU>();
            if (string.IsNullOrEmpty(ids))
            {
                return BadRequest();
            }


            
            try
            {
                fbConnection.Open();

                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                "select ID_LOK, ID_DOK, ID_VAT, VAT_P, WART_N, WART_V, WART_B, DAKT from PTU where ID_DOK IN (" + ids + ")";
                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PTU
                    {
                        ID_LOK = reader.GetInt32(0), //ID_LOK
                        ID_DOK = reader.GetInt32(1), //ID_DOK
                        ID_VAT = reader.GetInt32(2), //ID_VAT
                        VAT_P = reader.GetDecimal(3), //VAT_P
                        WART_N = reader.GetDecimal(4), //WART_N
                        WART_V = reader.GetDecimal(5), //WART_V
                        WART_B = reader.GetDecimal(6), //WART_B
                        DAKT = reader.GetDateTime(7), //DAKT
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
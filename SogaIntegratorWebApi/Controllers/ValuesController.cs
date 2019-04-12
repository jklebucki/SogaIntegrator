using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SogaIntegratorWebApi.Models;

namespace SogaIntegratorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [HttpGet("{from}/{to}")]
        public JsonResult Get(string from, string to)
        {
            // Set the ServerType to 1 for connect to the embedded server
            string[] messages = new string[10];
            string connectionString =
            "User=SYSDBA;" +
            "Password=masterkey;" +
            "Database=C:\\Program Files\\Novitus\\SOGA\\Baza\\GASTRO.fdb;" +
            "DataSource=192.168.45.68;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=UTF8;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=false;"; //+
            // "MinPoolSize=0;" +
            // "MaxPoolSize=50;" +
            // "Packet Size=8192;" +
            // "ServerType=0";

            FbConnection myConnection1 = new FbConnection(connectionString);
            // FbConnection myConnection2 = new FbConnection(connectionString);
            // FbConnection myConnection3 = new FbConnection(connectionString);
            List<Dokument> list = new List<Dokument>();
            try
            {
                myConnection1.Open();

                FbCommand myCommand = new FbCommand();

                myCommand.CommandText =
                "select * from dokumenty where DATA_WST between cast('" + from + "' as date) and cast('" + to + "' as date) and TYP_DOK='PZ'";
                myCommand.Connection = myConnection1;
                var reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Dokument {
                        ID_LOK = reader.GetInt32(0),
                        ID_DOK = reader.GetInt32(1),
                        TYP_DOK = reader.GetString(2),
                        ID_KOR = reader.GetInt32(3),
                        ID_FI = reader.GetInt32(4),
                        ID_FI_2 = reader.GetInt32(5),
                        DATA_WST = reader.GetDateTime(6),
                        DATA_SPR = reader.GetDateTime(7),
                        DATA_VAT = reader.GetDateTime(8),
                        NR = reader.GetInt32(9),
                        CALY_NR = reader.GetString(10),
                        CENA_WST = reader.GetString(11),
                        WART_NU = reader.GetDecimal(12),
                        WART_BU = reader.GetDecimal(13),
                        WART_VU = reader.GetDecimal(14),
                        ODB = reader.GetString(15),
                        ID_FO_DOZAP = reader.GetInt32(16),
                        NR_ORYGIN = reader.GetString(17),
                        STATUS = reader.GetString(18),
                        EURO = reader.GetDecimal(19),
                        PRZEDPLATA = reader.GetDecimal(20),
                        DOZAP = reader.GetDecimal(21),
                        UPUST_P = reader.GetDecimal(22),
                        UPUST_KW = reader.GetDecimal(23),
                        KOSZT = reader.GetDecimal(24)
                        //reader.GetValue(25).ToString(),
                        //reader.GetValue(26).ToString(),
                        //reader.GetValue(27).ToString(),
                        //reader.GetValue(28).ToString(),
                        //reader.GetValue(29).ToString(),
                        //reader.GetDateTime(30).ToString()
                    });
                }

                myConnection1.Close();

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
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

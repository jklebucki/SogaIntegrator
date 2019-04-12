using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            "Charset=NONE;" +
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
            List<IEnumerable<string>> list = new List<IEnumerable<string>>();
            try
            {
                myConnection1.Open();

                FbCommand myCommand = new FbCommand();

                myCommand.CommandText =
                "select * from dokumenty where DATA_WST between cast('" + from + "' as date) and cast('" + to + "' as date)";
                myCommand.Connection = myConnection1;
                var reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new string[] {
                        reader.GetValue(0).ToString(),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(3).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString(),
                        reader.GetName(6),
                        reader.GetDateTime(6).ToString("yyyy-MM-dd"),
                        reader.GetName(7),
                        reader.GetDateTime(7).ToString("yyyy-MM-dd"),
                        reader.GetName(8),
                        reader.GetDateTime(8).ToString("yyyy-MM-dd"),
                        reader.GetValue(9).ToString(),
                        reader.GetValue(10).ToString(),
                        reader.GetValue(11).ToString(),
                        reader.GetValue(12).ToString(),
                        reader.GetValue(13).ToString(),
                        reader.GetValue(14).ToString(),
                        reader.GetValue(15).ToString(),
                        reader.GetValue(16).ToString()
                    });
                }

                myConnection1.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            JsonSerializerSettings responseJson = new JsonSerializerSettings();
            responseJson.Formatting = Formatting.Indented;
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

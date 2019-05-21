using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DocumentsController : ControllerBase
    {
        private IOptions<FirebaseConfig> firebaseConfig { get; set; }
        private string test;

        public DocumentsController(IOptions<FirebaseConfig> firebaseConfig)
        {
            this.firebaseConfig = firebaseConfig;
        }

        [HttpGet]
        [HttpGet("{docType}/{from}/{to}")]
        public IActionResult Get(string docType, string from, string to)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Dokument> list = new List<Dokument>();
            if (string.IsNullOrEmpty(docType) && string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                return BadRequest();
            }
            var docTypeList = docType.Split(',');
            string docTypeQueryParameter = "";
            for (int i = 0; i < docTypeList.Length; i++)
            {
                docTypeQueryParameter += "'" + docTypeList[i].ToUpper() + "',";
            }
            docTypeQueryParameter = docTypeQueryParameter.TrimEnd(',');
            try
            {
                fbConnection.Open();

                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                "select ID_LOK, ID_DOK, TYP_DOK, ID_KOR, ID_FI, ID_FI_2, DATA_WST, DATA_SPR, DATA_VAT, " +
                "NR, CALY_NR, CENA_WST, WART_NU, WART_BU, WART_VU, ODB, ID_FO_DOZAP, NR_ORYGIN, STATUS, 0 AS EURO, " +
                "DOZAP, UPUST_P, UPUST_KW, KOSZT, ID_MA, ID_KATDOK, ID_POCHOD, TAKSA_KL, UWAGI, ID_UZ, GODZ_WST, " +
                "DF, PROG, KOMP, VAT_AUTO, FUPR, ID_PV, DAKT, APL, PRZEDPLATA, DETAL, ID_PKOR " +
                "from dokumenty where " +
                "TYP_DOK IN(" + docTypeQueryParameter + ")" +
                "AND DATA_WST between cast('" + from + "' as date) and cast('" + to + "' as date)";
                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                list = CreateDocumentsList(reader);
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

        [HttpGet]
        [HttpGet("{from}/{to}")]
        public IActionResult Get(string from, string to)
        {
            string connectionString = firebaseConfig.Value.ConnectionString();

            FbConnection fbConnection = new FbConnection(connectionString);
            List<Dokument> list = new List<Dokument>();
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                return BadRequest();
            }
            try
            {
                fbConnection.Open();

                FbCommand fbCommand = new FbCommand();

                fbCommand.CommandText =
                "select ID_LOK, ID_DOK, TYP_DOK, ID_KOR, ID_FI, ID_FI_2, DATA_WST, DATA_SPR, DATA_VAT, " +
                "NR, CALY_NR, CENA_WST, WART_NU, WART_BU, WART_VU, ODB, ID_FO_DOZAP, NR_ORYGIN, STATUS, 0 AS EURO, " +
                "DOZAP, UPUST_P, UPUST_KW, KOSZT, ID_MA, ID_KATDOK, ID_POCHOD, TAKSA_KL, UWAGI, ID_UZ, GODZ_WST, " +
                "DF, PROG, KOMP, VAT_AUTO, FUPR, ID_PV, DAKT, APL, PRZEDPLATA, DETAL, ID_PKOR " +
                "from dokumenty where " +
                "DATA_WST between cast('" + from + "' as date) and cast('" + to + "' as date)";
                fbCommand.Connection = fbConnection;
                var reader = fbCommand.ExecuteReader();
                list = CreateDocumentsList(reader);

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

        private List<Dokument> CreateDocumentsList(FbDataReader reader)
        {
            List<Dokument> list = new List<Dokument>();
            while (reader.Read())
            {
                list.Add(new Dokument
                {
                    ID_LOK = reader.GetInt32(0), //ID_LOK
                    ID_DOK = reader.GetInt32(1), //ID_DOK
                    TYP_DOK = reader.GetString(2), //TYP_DOK
                    ID_KOR = reader.GetInt32(3), //ID_KOR
                    ID_FI = reader.GetInt32(4), //ID_FI
                    ID_FI_2 = reader.GetInt32(5), //ID_FI_2
                    DATA_WST = reader.GetDateTime(6), //DATA_WST
                    DATA_SPR = reader.GetDateTime(7), //DATA_SPR
                    DATA_VAT = reader.GetDateTime(8), //DATA_VAT
                    NR = reader.GetInt32(9), //NR
                    CALY_NR = reader.GetString(10), //CALY_NR
                    CENA_WST = reader.GetString(11), //CENA_WST
                    WART_NU = reader.GetDecimal(12), //WART_NU
                    WART_BU = reader.GetDecimal(13), //WART_BU
                    WART_VU = reader.GetDecimal(14), //WART_VU
                    ODB = reader.GetString(15), //ODB
                    ID_FO_DOZAP = reader.GetInt32(16), //ID_FO_DOZAP
                    NR_ORYGIN = reader.GetString(17), //NR_ORYGIN
                    STATUS = reader.GetString(18), //STATUS
                    EURO = reader.GetDecimal(19), //EURO
                    DOZAP = reader.GetDecimal(20), //DOZAP
                    UPUST_P = reader.GetDecimal(21), //UPUST_P
                    UPUST_KW = reader.GetDecimal(22), //UPUST_KW
                    KOSZT = reader.GetDecimal(23), //KOSZT
                    ID_MA = reader.GetInt32(24), //ID_MA
                    ID_KATDOK = reader.GetInt32(25), //ID_KATDOK
                    ID_POCHOD = reader.GetInt32(26), //ID_POCHOD
                    TAKSA_KL = reader.GetDecimal(27), //TAKSA_KL
                    UWAGI = reader.GetString(28), //UWAGI
                    ID_UZ = reader.GetInt32(29), //ID_UZ
                    GODZ_WST = reader.GetDateTime(30), //GODZ_WST
                    DF = reader.GetString(31), //DF
                    PROG = reader.GetString(32), //PROG
                    KOMP = reader.GetString(33), //KOMP
                    VAT_AUTO = reader.GetInt32(34), //VAT_AUTO
                    FUPR = reader.GetInt32(35), //FUPR
                    ID_PV = reader.GetInt32(36), //ID_PV
                    DAKT = reader.GetDateTime(37), //DAKT
                    APL = reader.GetString(38), //APL
                    PRZEDPLATA = reader.GetDecimal(39), //PRZEDPLATA
                    DETAL = reader.GetInt32(40), //DETAL
                    ID_PKOR = reader.GetInt32(41), //ID_PKOR
                });
            }
            return list;
        }
    }
}

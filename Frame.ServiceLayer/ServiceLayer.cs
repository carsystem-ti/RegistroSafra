using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using Frame.ServiceLayer.Modelos;

namespace WS.ServiceLayer
{
    public class ServiceLayer
    {
        private string url = string.Empty;
        private static CookieCollection cookieData = new CookieCollection();

        public ServiceLayer()
        {
            string sevicelayer = ConfigurationManager.AppSettings["ServiceLayer"].ToString();
            this.url = sevicelayer;

        }

        private static bool RemoteSSLTLSCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            //accept
            return true;
        }

        public Retorno LoginSite(string Usuario, string Senha)
        {
            string login = string.Format("{3}\"CompanyDB\": \"{0}\", \"UserName\": \"{1}\", \"Password\": \"{2}\"{4}"
                        , ConfigurationManager.AppSettings["CompanyDB"]
                        , Usuario
                        , Senha, "{", "}");

            var result = this.Interact((url + "Login"), "POST", login, false);

            if (result.Sucesso)
            {
                var results = Login();

                if (!result.Sucesso)
                    result = results;
            }

            return result;
        }

        public Retorno Login()
        {
            string login = string.Format("{3}\"CompanyDB\": \"{0}\", \"UserName\": \"{1}\", \"Password\": \"{2}\"{4}"
                        , ConfigurationManager.AppSettings["CompanyDB"]
                        , ConfigurationManager.AppSettings["UserName"]
                        , ConfigurationManager.AppSettings["Password"], "{", "}");

            var result = this.Interact((url + "Login"), "POST", login, true);

            CriacaoCampo();

            return result;
        }

        public Retorno Add(string endPoint, string data)
        {
            var result = this.Interact((url + endPoint), "POST", data);
            return result;
        }
        public Retorno Update(string endPoint, string data)
        {
            var result = this.Interact((url + endPoint), "PATCH", data);
            return result;
        }
        public Retorno Get(string endPoint)
        {
            var result = this.Interact((url + endPoint), "GET");
            return result;
        }

        public Retorno Delete(string endPoint)
        {
            var result = this.Interact((url + endPoint), "DELETE");
            return result;
        }

        public Retorno Logout()
        {
            var result = this.Interact((url + "Logout"), "POST");
            return result;
        }

        public Retorno Interact(string url, string method, string body = "", bool saveCookie = false)
        {
            Retorno Ret = new Retorno();

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method.ToUpper();
            httpRequest.ServicePoint.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback += RemoteSSLTLSCertificateValidate;
            httpRequest.CookieContainer = new CookieContainer();

            if (cookieData.Count > 0)
            {
                foreach (Cookie cookie in cookieData)
                {
                    httpRequest.CookieContainer.Add(new Uri(url), new Cookie(cookie.Name, cookie.Value));

                }
            }

            if (!string.IsNullOrEmpty(body))
            {
                using (var requestStream = httpRequest.GetRequestStream())
                {
                    var writer = new StreamWriter(requestStream);
                    writer.Write(body);
                    writer.Close();
                }
            }

            try
            {
                var webResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var response = new StreamReader(webResponse.GetResponseStream()))
                {
                    string text = response.ReadToEnd();
                    Ret.Sucesso = true;
                    Ret.Documento = text;
                }
                if (saveCookie)
                    cookieData = webResponse.Cookies;
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();

                        Erros GetObjPN = JsonConvert.DeserializeObject<Erros>(text, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                        if (GetObjPN.error.code.Equals(301))
                        {
                            Login();
                            Ret = Interact(url, method, body, saveCookie);
                        }
                        else
                        {
                            Ret.Sucesso = false;
                            Ret.Documento = text;
                        }
                    }
                }
            }
            return Ret;
        }

        private void CriacaoCampo()
        {
            //NEO_dtsol     Data Solicitação    Data
            //NEO_Sol       Solicitante         Alfanumérico(60)
            //NEO_NJob      Nome do Job         Alfanumérico(64)
            //NEO_AG        Agencia             Alfanumérico(64)
            //NEO_Cl        Cliente             Alfanumérico(64)
            //NEO_NResp     Nome Resp           Alfanumérico(64)
            //NEO_Ct        Contratante         Alfanumérico(64)
            //NEO_DTIn      Data Inicio         Data
            //NEO_DtFim     Data Fim            Data

            //var Campo = "{\"TableName\": \"ORDR\",\"Name\": \"NEO_dtsol\",\"Description\": \"Data Solicitação\",\"Type\": \"db_Date\",\"SubType\": \"st_None\",\"EditSize\": \"10\"}";
            //var RetCampo = Add($"UserFieldsMD", Campo);

            //Campo = "{\"TableName\": \"ORDR\",\"Name\": \"NEO_Sol\",\"Description\": \"Solicitante\",\"Type\": \"db_Alpha\",\"SubType\": \"st_None\",\"EditSize\": \"60\"}";
            //RetCampo = Add($"UserFieldsMD",Campo);

        }
    }
}

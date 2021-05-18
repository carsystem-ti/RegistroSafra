using log4net;
using Newtonsoft.Json;
using Pulling.dao;
using Pulling.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Pulling
{
    public class PullingService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int sleepTime;
        public string BaseUrl = "https://api-hml.safranegocios.com.br/gateway";
        private bool _isProducao = true;
        public HttpContextBase HttpContext { get; }



        public PullingService()
        {
            sleepTime = Convert.ToInt32(ConfigurationManager.AppSettings["SleepTime"]);
        }
        
        public void Run()
        {
            try
            {
                log.Info("=============================================================================");
                log.Info("=============================================================================");

                log.Info("start service");

                var taskOrder = new Task(() =>
                {
                    while (true)
                    {
                        if (_isProducao == true) {
                            RegistroProducao();
                        }
                        else {
                            RegistroTeste();
                        }
                        Thread.Sleep(new TimeSpan(0, 0, 0));

                    }
                });
                taskOrder.Start();
            }
            catch (Exception ex)
            {

                log.Fatal("Fatal Error order message = " + ex.Message);
            }
        }
        public Auth GeraTokenTeste()
        {

            var client = new RestClient("https://api-hml.safranegocios.com.br/gateway/v1/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "0cd0fd82f7dbd34e6c96f3c29191fd3f=49880c4264efea8864abb1219fbe3ec3; dd9dd9b9dd896500e69271a40d51dea9=8354992a3664efd4ed28c932e1becb30");
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", "6075e2dd29f277000fe96b60");
            request.AddParameter("username", "CAR SYST");
            request.AddParameter("password", "irJUE8jmcsrEP4");
            request.AddParameter("grant_type", "password");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            IRestResponse response = client.Execute(request);
            var odosRecord = JsonConvert.DeserializeObject<Auth>(response.Content);


            Console.WriteLine(response.Content);
            return odosRecord;
        }
        public Auth GeraTokenProducao()
        {

            var client = new RestClient("https://api.safranegocios.com.br/gateway/v1/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "0cd0fd82f7dbd34e6c96f3c29191fd3f=49880c4264efea8864abb1219fbe3ec3; dd9dd9b9dd896500e69271a40d51dea9=8354992a3664efd4ed28c932e1becb30");
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", "6075e2dd29f277000fe96b60");
            request.AddParameter("username", "CAR SYST");
            request.AddParameter("password", "irJUE8jmcsrEP4");
            request.AddParameter("grant_type", "password");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            IRestResponse response = client.Execute(request);
            var odosRecord = JsonConvert.DeserializeObject<Auth>(response.Content);


            Console.WriteLine(response.Content);
            return odosRecord;
        }

        public void RegistroProducao()
        {
            try
            {
                Auth Token = GeraTokenProducao();
                dadoCliente dao = new dadoCliente();

                DataTable dt = dao.getBuscaCR();
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dw in dt.Rows)
                    {
                        string agencia = "02800";
                        string conta = "303327";
                        string dt_vencimento = dw[3].ToString();
                        float valor = float.Parse(dw[4].ToString().Replace(".", ","));

                        string nomecliente = dw[0].ToString();
                        string tp_pessoa = dw[11].ToString();
                        string email = dw[5].ToString();
                        string nr_documento = dw[6].ToString();
                        string bairro = dw[8].ToString();
                        string cidade = dw[9].ToString();
                        string endereco = dw[7].ToString();
                        string uf = dw[12].ToString();
                        string cep = dw[10].ToString();
                        Random random = new Random();
                        int numero = Convert.ToInt32(dw[1].ToString());
                        int numeroCliente = Convert.ToInt32(dw[1].ToString());

                        var client = new RestClient("https://api.safranegocios.com.br/gateway/cobrancas/v1/boletos");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Safra-Correlation-ID", "175fafc2-0e4a-4a88-a5aa-4b4a72423499");
                        request.AddHeader("Safra-Client-ID", "6075e2dd29f277000fe96b60");
                        request.AddHeader("Authorization", "Bearer " + Token.access_token);
                        request.AddHeader("Cookie", "b0c2cb1a9ae71cfe5f71fbec4b0e7b3f=ed4806811d706ed0a32c12b625e06196");
                        request.AddParameter("application/json", "{\r\n   \"agencia\":\"" + agencia + "\",\r\n   \"conta\":\"" + conta + "\",\r\n   \"fidc\":0.0,\r\n   \"danfe\":null,\r\n   \"documento\":{\r\n      \"numero\":\"" + numero + "\",\r\n      \"numeroCliente\":\"" + numeroCliente + "\",\r\n      \"diasDevolucao\":0,\r\n      \"especie\":\"09\",\r\n      \"dataVencimento\":\"" + dt_vencimento + "\",\r\n      \"valor\":" + valor.ToString().Replace(",", ".") + ",\r\n      \"codigoMoeda\":\"9\",\r\n      \"quantidadeDiasProtesto\":0,\r\n      \"identificacaoAceite\":null,\r\n      \"campoLivre\":null,\r\n      \"desconto\":null,\r\n      \"multa\":null,\r\n      \"pagamentoParcial\":null,\r\n      \"pagador\":{\r\n         \"nome\":\"" + nomecliente + "\",\r\n         \"tipoPessoa\":\"" + tp_pessoa + "\",\r\n         \"email\":\"" + email + "\",\r\n         \"numeroDocumento\":\"" + nr_documento + "\",\r\n         \"endereco\":{\r\n            \"logradouro\":\"" + endereco + "\",\r\n            \"bairro\":\"" + bairro + "\",\r\n            \"cidade\":\"" + cidade + "\",\r\n            \"uf\":\"" + uf + "\",\r\n            \"cep\":\"" + cep + "\"\r\n         }\r\n      },\r\n      \"beneficiario\":{\r\n         \"nome\":\"CARSYSTEM ALARMES TDA\",\r\n         \"tipoPessoa\":\"J\",\r\n         \"email\":\"usuario@carsystem.com\",\r\n         \"numeroDocumento\":\"04401579000155\",\r\n         \"endereco\":{\r\n            \"logradouro\":\"AV ALFREDO EGIDIO, 45\",\r\n            \"bairro\":\"VILA CRUZ\",\r\n            \"cidade\":\"São Paulo\",\r\n            \"uf\":\"SP\",\r\n            \"cep\":\"04726170\"\r\n         }\r\n      },\r\n      \"mensagens\":null\r\n   }\r\n}", ParameterType.RequestBody);

                        IRestResponse response = client.Execute(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            Console.WriteLine(response.Content);
                            var Ret_CodigoBarra = JsonConvert.DeserializeObject<Registro>(response.Content);
                            dao.set_Registro(Ret_CodigoBarra.data.numeroCliente, Ret_CodigoBarra.data.numero, Ret_CodigoBarra.data.codigoBarras);
                        }
                        else
                        {
                            
                            var erro = JsonConvert.DeserializeObject<Erros>(response.Content);
                            dao.set_Registro(numeroCliente, erro.code.ToString() + "-" + erro.message.ToString());

                        }
                    }
                }

            }
            catch (Exception ex)
            {

                ex.ToString();
            }


        }




        public void RegistroTeste()
        {
            try
            {
                Auth Token = GeraTokenTeste();
                dadoCliente dao = new dadoCliente();

                DataTable dt = dao.getBuscaCR();
                if (dt.Rows.Count > 0)
                {

                    foreach ( DataRow dw in dt.Rows)
                    {
                        int agencia = 12400;
                        int conta = 8554440;
                        string dt_vencimento = dw[3].ToString();
                        float valor = float.Parse(dw[4].ToString().Replace(".",","));
                     
                        string nomecliente = dw[0].ToString();
                        string tp_pessoa = dw[11].ToString();
                        string email = dw[5].ToString();
                        string nr_documento = dw[6].ToString();
                        string bairro = dw[8].ToString();
                        string cidade = dw[9].ToString();
                        string endereco = dw[7].ToString();
                        string uf = dw[12].ToString();
                        string cep = dw[10].ToString();
                        Random random = new Random();
                        int numero = Convert.ToInt32(dw[1].ToString());
                        int numeroCliente = Convert.ToInt32(dw[1].ToString());

                        var client = new RestClient("https://api-hml.safranegocios.com.br/gateway/cobrancas/v1/boletos");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Safra-Correlation-ID", "175fafc2-0e4a-4a88-a5aa-4b4a72423499");
                        request.AddHeader("Safra-Client-ID", "6075e2dd29f277000fe96b60");
                        request.AddHeader("Authorization", "Bearer " + Token.access_token);
                        request.AddHeader("Cookie", "b0c2cb1a9ae71cfe5f71fbec4b0e7b3f=ed4806811d706ed0a32c12b625e06196");
                        request.AddParameter("application/json", "{\r\n   \"agencia\":\"" + agencia + "\",\r\n   \"conta\":\"" + conta + "\",\r\n   \"fidc\":0.0,\r\n   \"danfe\":null,\r\n   \"documento\":{\r\n      \"numero\":\"" + numero + "\",\r\n      \"numeroCliente\":\"" + numeroCliente + "\",\r\n      \"diasDevolucao\":0,\r\n      \"especie\":\"09\",\r\n      \"dataVencimento\":\"" + dt_vencimento + "\",\r\n      \"valor\":" + valor.ToString().Replace(",",".") + ",\r\n      \"codigoMoeda\":\"9\",\r\n      \"quantidadeDiasProtesto\":0,\r\n      \"identificacaoAceite\":null,\r\n      \"campoLivre\":null,\r\n      \"desconto\":null,\r\n      \"multa\":null,\r\n      \"pagamentoParcial\":null,\r\n      \"pagador\":{\r\n         \"nome\":\"" + nomecliente + "\",\r\n         \"tipoPessoa\":\"" + tp_pessoa + "\",\r\n         \"email\":\"" + email + "\",\r\n         \"numeroDocumento\":\"" + nr_documento + "\",\r\n         \"endereco\":{\r\n            \"logradouro\":\"" + endereco + "\",\r\n            \"bairro\":\"" + bairro + "\",\r\n            \"cidade\":\"" + cidade + "\",\r\n            \"uf\":\"" + uf + "\",\r\n            \"cep\":\"" + cep + "\"\r\n         }\r\n      },\r\n      \"beneficiario\":{\r\n         \"nome\":\"CARSYSTEM ALARMES TDA\",\r\n         \"tipoPessoa\":\"J\",\r\n         \"email\":\"usuario@carsystem.com\",\r\n         \"numeroDocumento\":\"04401579000155\",\r\n         \"endereco\":{\r\n            \"logradouro\":\"AV ALFREDO EGIDIO, 45\",\r\n            \"bairro\":\"VILA CRUZ\",\r\n            \"cidade\":\"São Paulo\",\r\n            \"uf\":\"SP\",\r\n            \"cep\":\"04726170\"\r\n         }\r\n      },\r\n      \"mensagens\":null\r\n   }\r\n}", ParameterType.RequestBody);

                        IRestResponse response = client.Execute(request);
                        Console.WriteLine(response.Content);
                        var Ret_CodigoBarra = JsonConvert.DeserializeObject<Registro>(response.Content);
                        dao.set_Registro(Ret_CodigoBarra.data.numeroCliente, Ret_CodigoBarra.data.numero, Ret_CodigoBarra.data.codigoBarras);
                    
                    }
                 

                }
            
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
          

        }
      //  public object getDocumento(string documento,string nr_documento)
      //  {
      //      ServicoConsultaDocumento doc = new ServicoConsultaDocumento();
            
      //      email mail = new email();
      //      telefone telefone = new telefone();
      //      endereco endereco = new endereco();
      //      List<email> ListMail = new List<email>();
      //      List<telefone> ListTelefones = new List<telefone>();
      //      List<endereco> ListEnderecos = new List<endereco>();
      //      dao.dadoCliente _model = new dao.dadoCliente();


      //      try
      //      {


      //          using (ServiceConsultaDocumento.intouchwsSoapClient busca = new ServiceConsultaDocumento.intouchwsSoapClient("intouchwsSoap12"))
      //          {

      //              var dados = busca.GerarToken("CARSYSTEMALARMES", "2jF$qcwg", "carsystemalarmes ");
      //              var retorno = busca.LocalizaPessoasTk(documento, dados.ToString(), documento.Length >= 14 ? "PJ" : "PF");
      //              XmlDocument xm = new XmlDocument();
      //              xm.LoadXml(retorno);
      //              //string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xm);
      //              //var cliente = JsonConvert.DeserializeObject<Unitofour>(json);
      //              XmlNodeList parentNode = xm.GetElementsByTagName("CADASTROUNIT");
      //              //foreach (XmlNode childrenNode in parentNode)
      //              //{
      //              //    var documento = childrenNode.SelectSingleNode("DOCUMENTO").InnerText;
      //              //    var Nome = childrenNode.SelectSingleNode("NOME").InnerText;
      //              //}
      //              if (parentNode.Count > 0)
      //              {
      //                  XmlNodeList parentNodeDoc = xm.GetElementsByTagName("DADOS_CADASTRAIS");
      //                  XmlNodeList parentNodeDoceMAIL = xm.GetElementsByTagName("EMAILS");
      //                  foreach (XmlNode childrenNodeDOCEmail in parentNodeDoceMAIL)
      //                  {
      //                      mail = new email()
      //                      {
      //                          EMAIL = childrenNodeDOCEmail.SelectSingleNode("EMAIL").InnerText,

      //                  };
      //                      ListMail.Add(mail);
      //                  }

      //                  if (ListMail.Count > 0)
      //                  {
      //                      foreach (var item in ListMail)
      //                      {
      //                          _model.set_Email(nr_documento, item.EMAIL);

      //                      }
      //                  }
                        
                        


      //                  //HttpContext.Session["Lista"] = ListMail;
      //                  XmlNodeList parentNodeDocTelefone = xm.GetElementsByTagName("TELEFONES");
      //                  foreach (XmlNode childrenNodeDOCTelefone in parentNodeDocTelefone)
      //                  {
      //                      telefone = new telefone()
      //                      {
      //                          TELEFONE = childrenNodeDOCTelefone.SelectSingleNode("TELEFONE").InnerText,
      //                          ///OPERADORA = childrenNodeDOCTelefone.SelectSingleNode("OPERADORA").InnerText,
      //                      };
      //                      ListTelefones.Add(telefone);
      //                      // _model.set_PedidoEmail(id_pedido, mail.EMAIL);
      //                  }
      //                  if (ListTelefones.Count > 0)
      //                  {
      //                      foreach (var itemTel  in ListTelefones)
      //                      {
      //                          _model.set_Telefone(nr_documento, itemTel.TELEFONE.Substring(0, 2), itemTel.TELEFONE.Substring(2, itemTel.TELEFONE.Length - 2));

      //                      }
      //                  }

      //                  //HttpContext.Session["ListaTelefone"] = ListTelefones;

      //                  XmlNodeList parentNodeDocEndereco = xm.GetElementsByTagName("ENDERECOS");
      //                  foreach (XmlNode childrenNodeDOCEndereco in parentNodeDocEndereco)
      //                  {
      //                      endereco = new endereco()
      //                      {
      //                          LOGRADOURO = childrenNodeDOCEndereco.SelectSingleNode("LOGRADOURO").InnerText,
      //                          NUMERO = childrenNodeDOCEndereco.SelectSingleNode("NUMERO").InnerText,
      //                          COMPLEMENTO = childrenNodeDOCEndereco.SelectSingleNode("COMPLEMENTO").InnerText,
      //                          BAIRRO = childrenNodeDOCEndereco.SelectSingleNode("BAIRRO").InnerText,
      //                          CEP = childrenNodeDOCEndereco.SelectSingleNode("CEP").InnerText,
      //                          CIDADE = childrenNodeDOCEndereco.SelectSingleNode("CIDADE").InnerText,
      //                          UF = childrenNodeDOCEndereco.SelectSingleNode("UF").InnerText,

      //                      };
      //                      ListEnderecos.Add(endereco);
      //                      // _model.set_PedidoEmail(id_pedido, mail.EMAIL);
      //                  }
      //                  //HttpContext.Session["ListaEndereco"] = ListEnderecos;

      //                  if (ListEnderecos.Count > 0)
      //                  {
      //                      foreach (var itemEndereco in ListEnderecos)
      //                      {
      //                          _model.set_Endereco(nr_documento, itemEndereco.LOGRADOURO, itemEndereco.NUMERO, itemEndereco.COMPLEMENTO, itemEndereco.BAIRRO, itemEndereco.CIDADE, itemEndereco.UF);

      //                      }
      //                  }



      //                  XmlSerializer serializer = new XmlSerializer(typeof(List<EMAILS>), new XmlRootAttribute("EMAILS"));

      //                  foreach (XmlNode childrenNodeDOC in parentNodeDoc)
      //                  {

      //                      if (documento.Length >= 14)
      //                      {
      //                          doc = new ServicoConsultaDocumento()
      //                          {
      //                              nr_documento = childrenNodeDOC.SelectSingleNode("CNPJ").InnerText,
      //                              ds_nome = childrenNodeDOC.SelectSingleNode("RAZAO").InnerText.ToString(),
      //                              InscricaoEstadual = childrenNodeDOC.SelectSingleNode("COD_CNAE").InnerText.ToString(),
      //                          };
      //                      }
      //                      else
      //                      {
      //                          doc = new ServicoConsultaDocumento()
      //                          {
      //                              nr_documento = childrenNodeDOC.SelectSingleNode("CPF").InnerText,
      //                              ds_nome = childrenNodeDOC.SelectSingleNode("NOME").InnerText.ToString(),
      //                              DataNascimento = childrenNodeDOC.SelectSingleNode("DATANASC").InnerText.ToString(),
      //                          };

      //                      }


      //                  }
      //                  if (doc != null)
      //                  {
                            
      //                          int processo = _model.set_Documento(nr_documento, doc.ds_nome,doc.DataNascimento, null, "processado com sucesso");

                            
      //                  }



      //              }

      //          }
      //      }
      //      catch (Exception ex)
      //      {
      //          return "Unitfour Fora de operação   /  " + ex.Message.ToString();

      //      }
      //      return doc;
      //  }
      //public  class ServicoConsultaDocumento
      //  {
      //      public string nr_documento { get; set; }
      //      public string ds_nome { get; set; }

      //      public string InscricaoEstadual { get; set; }
      //      public string DataNascimento { get; set; }


      //  }
      //  public class ServicoConsultaDocumentoGeral
      //  {
      //      public string nr_documento { get; set; }
      //      public string ds_nome { get; set; }

      //      public string InscricaoEstadual { get; set; }

      //      public string DATANASC { get; set; }

      //      public string SITUACAO_RECEITA { get; set; }

      //      public string SEXO { get; set; }



      //  }
      //  public class email
      //  {
      //      public string RANKING { get; set; }
      //      public string EMAIL { get; set; }
      //      public string PARTICULAR { get; set; }
      //  }
      //  public class telefone
      //  {
      //      public string RANKING { get; set; }

      //      public string TELEFONE { get; set; }
      //      public string TELEFONE_VALIDO { get; set; }
      //      public string ORIGEM { get; set; }

      //      public string PERMISSAO_MARKET { get; set; }

      //      public string ASSINANTE { get; set; }
      //      public string OPERADORA { get; set; }
      //      public string TIPO { get; set; }



      //  }
      //  public class endereco
      //  {
      //      public string RANKING { get; set; }

      //      public string LOGRADOURO { get; set; }
      //      public string NUMERO { get; set; }
      //      public string COMPLEMENTO { get; set; }

      //      public string BAIRRO { get; set; }

      //      public string CEP { get; set; }
      //      public string CIDADE { get; set; }
      //      public string UF { get; set; }



      //  }



    }
}

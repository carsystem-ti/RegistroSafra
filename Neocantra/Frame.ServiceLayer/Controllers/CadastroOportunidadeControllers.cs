using Frame.ServiceLayer.Modelos;
using Frame.ServiceLayer.Modelos.Oportunidade;
using log4net;
using Newtonsoft.Json;
using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frame.ServiceLayer.Controllers
{
    public class CadastroOportunidadeControllers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Retorno InsereAtualizaOportunidade(CadastroOportunidade Oportunidade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Retorno _Retorno = new Retorno();

            try
            {
                if (!string.IsNullOrEmpty(Oportunidade.CardName))
                    Oportunidade.CardName = null;

                if (Oportunidade.SequentialNo == null)
                {
                    #region Insere Oportunidade

                    var Json = JsonConvert.SerializeObject(Oportunidade, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Add("SalesOpportunities", Json);

                    #endregion
                }
                else
                {
                    #region Atualiza Oportunidade


                    if (Oportunidade.SalesOpportunitiesInterests != null)
                    {
                        Oportunidade.SalesOpportunitiesInterests[0].SequenceNo = Oportunidade.SequentialNo;
                    }

                    if (Oportunidade.SalesOpportunitiesLines != null)
                    {
                        int count = 0;
                        foreach (var item in Oportunidade.SalesOpportunitiesLines)
                        {
                            item.LineNum = count;
                            count++;
                        }
                    }

                    var Json = Newtonsoft.Json.JsonConvert.SerializeObject(Oportunidade, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Update($"SalesOpportunities({Oportunidade.SequentialNo})", Json);

                    #endregion
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }
        public CadastroOportunidades ConsultaOportunidade(CadastroOportunidade Oportunidade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroOportunidades _Retorno = new CadastroOportunidades();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaOportunidadee, Schema, Oportunidade.CardCode, Oportunidade.CardName, Oportunidade.SequentialNo);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                var Count = productInfoReader.GetString(2);
                                var DocEntry = productInfoReader.GetString(0);
                                var CardName = productInfoReader.GetString(1);

                                var GetPN = Service.Get($"SalesOpportunities({DocEntry})");
                                var _RetornoOportunidade = JsonConvert.DeserializeObject<CadastroOportunidade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                _RetornoOportunidade.CardName = CardName;

                                _Retorno.value = new CadastroOportunidade[int.Parse(Count)];
                                _Retorno.value[0] = new CadastroOportunidade();
                                _Retorno.value[0] = _RetornoOportunidade;

                                int i = 1;

                                while (productInfoReader.Read())
                                {
                                    _Retorno.value[i] = new CadastroOportunidade();

                                    DocEntry = productInfoReader.GetString(0);
                                    CardName = productInfoReader.GetString(1);

                                    GetPN = Service.Get($"SalesOpportunities({DocEntry})");
                                    _RetornoOportunidade = JsonConvert.DeserializeObject<CadastroOportunidade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                    _RetornoOportunidade.CardName = CardName;

                                    _Retorno.value[i] = _RetornoOportunidade;

                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }
        public CadastroOportunidade ConsultaPrimeiroOportunidade()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroOportunidade _Retorno = new CadastroOportunidade();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaPrimeiroOportunidade, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var DocEntry = productInfoReader.GetString(0);
                                var CardName = productInfoReader.GetString(1);

                                var GetPN = Service.Get($"SalesOpportunities({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                _Retorno.CardName = CardName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }
        public CadastroOportunidade ConsultaAnteriorOportunidade(CadastroOportunidade Oportunidade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroOportunidade _Retorno = new CadastroOportunidade();

            try
            {
                if (Oportunidade.SequentialNo == null || Oportunidade.SequentialNo.Equals(0))
                {
                    _Retorno = ConsultaPrimeiroOportunidade();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaAnteriorOportunidade, Schema, Oportunidade.SequentialNo);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var DocEntry = productInfoReader.GetString(0);
                                    var CardName = productInfoReader.GetString(1);

                                    var GetPN = Service.Get($"SalesOpportunities({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                    _Retorno.CardName = CardName;
                                }
                            }
                        }
                    }
                    if (_Retorno.CardCode == null)
                    {
                        using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                        {
                            conn.Open();

                            var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                            string Sql = string.Format(Properties.Resources.ConsultaUltimoOportunidade, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var DocEntry = productInfoReader.GetString(0);
                                        var CardName = productInfoReader.GetString(1);

                                        var GetOportunidade = Service.Get($"SalesOpportunities({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetOportunidade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                        _Retorno.CardName = CardName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }
        public CadastroOportunidade ConsultaProximoOportunidade(CadastroOportunidade Oportunidade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroOportunidade _Retorno = new CadastroOportunidade();

            try
            {
                if (Oportunidade.SequentialNo == null || Oportunidade.SequentialNo.Equals(0))
                {
                    _Retorno = ConsultaUltimoOportunidade();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaProximoOportunidade, Schema, Oportunidade.SequentialNo);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var DocEntry = productInfoReader.GetString(0);
                                    var CardName = productInfoReader.GetString(1);

                                    var GetOportunidade = Service.Get($"SalesOpportunities({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetOportunidade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                    _Retorno.CardName = CardName;

                                }
                            }
                        }
                    }

                    if (_Retorno.CardCode == null)
                    {
                        using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                        {
                            conn.Open();

                            var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                            string Sql = string.Format(Properties.Resources.ConsultaPrimeiroOportunidade, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var DocEntry = productInfoReader.GetString(0);
                                        var CardName = productInfoReader.GetString(1);

                                        var GetOportunidade = Service.Get($"SalesOpportunities({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetOportunidade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                        _Retorno.CardName = CardName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }
        public CadastroOportunidade ConsultaUltimoOportunidade()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroOportunidade _Retorno = new CadastroOportunidade();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaUltimoOportunidade, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var DocEntry = productInfoReader.GetString(0);
                                var CardName = productInfoReader.GetString(1);

                                var GetOportunidade = Service.Get($"SalesOpportunities({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroOportunidade>(GetOportunidade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                _Retorno.CardName = CardName;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                //Service.Logout();
            }

            return _Retorno;
        }

        public Nivelinteresses ConsultaNivelInteresse()
        {
            Nivelinteresses _Retorno = new Nivelinteresses();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaNivelInteresse, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                string Code = productInfoReader.GetString(0);
                                string Name = productInfoReader.GetString(1);
                                string Count = productInfoReader.GetString(2);

                                _Retorno.value = new Nivelinteresse[int.Parse(Count)];
                                _Retorno.value[0] = new Nivelinteresse();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Nivelinteresse();
                                    _Retorno.value[i].Code = Code;
                                    _Retorno.value[i].Name = Name;

                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
            }

            return _Retorno;
        }
        public Descricoes ConsultaDescricao()
        {
            Descricoes _Retorno = new Descricoes();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaDescricao, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                string Code = productInfoReader.GetString(0);
                                string Name = productInfoReader.GetString(1);
                                string Count = productInfoReader.GetString(2);

                                _Retorno.value = new Descricao[int.Parse(Count)];
                                _Retorno.value[0] = new Descricao();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Descricao();
                                    _Retorno.value[i].Code = Code;
                                    _Retorno.value[i].Name = Name;

                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
            }

            return _Retorno;
        }
        public Etapas ConsultaEtapa()
        {
            Etapas _Retorno = new Etapas();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaEtapa, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                string Code = productInfoReader.GetString(0);
                                string Name = productInfoReader.GetString(1);
                                string Count = productInfoReader.GetString(2);

                                _Retorno.value = new Etapa[int.Parse(Count)];
                                _Retorno.value[0] = new Etapa();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Etapa();
                                    _Retorno.value[i].Code = Code;
                                    _Retorno.value[i].Name = Name;

                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
            }

            return _Retorno;
        }
        public Porcentagem ConsultaPorcentagem(string etapa)
        {
            Porcentagem _Retorno = new Porcentagem();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaPorcentagem, Schema, etapa);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                string valor = productInfoReader.GetString(0);

                                _Retorno.Valor = valor;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
            }

            return _Retorno;
        }
        public Titulares ConsultaTitular()
        {
            Titulares _Retorno = new Titulares();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaTitular, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                string Code = productInfoReader.GetString(0);
                                string Name = productInfoReader.GetString(1);
                                string Count = productInfoReader.GetString(2);

                                _Retorno.value = new Titular[int.Parse(Count)];
                                _Retorno.value[0] = new Titular();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Titular();
                                    _Retorno.value[i].Code = Code;
                                    _Retorno.value[i].Name = Name;

                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
            }

            return _Retorno;
        }
    }
}

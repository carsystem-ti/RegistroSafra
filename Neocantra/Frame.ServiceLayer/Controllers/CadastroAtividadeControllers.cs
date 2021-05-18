using Frame.ServiceLayer.Modelos;
using Frame.ServiceLayer.Modelos.Atividade;
using Frame.ServiceLayer.Modelos.PN;
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
    public class CadastroAtividadeControllers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Retorno InsereAtualizaAtividade(CadastroAtividade Atividade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Retorno _Retorno = new Retorno();

            try
            {
                if (!string.IsNullOrEmpty(Atividade.CardName))
                    Atividade.CardName = null;

                if (Atividade.ActivityCode == null)
                {
                    #region Insere Atividade

                    var Json = JsonConvert.SerializeObject(Atividade, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Add("Activities", Json);

                    #endregion
                }
                else
                {
                    #region Atualiza Atividade

                    var Json = Newtonsoft.Json.JsonConvert.SerializeObject(Atividade, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Update($"Activities({Atividade.ActivityCode})", Json);

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
        public CadastroAtividades ConsultaAtividade(CadastroAtividade atividade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroAtividades _Retorno = new CadastroAtividades();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaAtividade, Schema, atividade.CardCode, atividade.CardName, atividade.ActivityCode);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                var DocEntry = productInfoReader.GetString(0);
                                var CardName = productInfoReader.GetString(1);
                                var Count = productInfoReader.GetString(2);

                                var GetPN = Service.Get($"Activities({DocEntry})");
                                var _RetornoAtividade = JsonConvert.DeserializeObject<CadastroAtividade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                _RetornoAtividade.CardName = CardName;

                                _Retorno.value = new CadastroAtividade[int.Parse(Count)];
                                _Retorno.value[0] = new CadastroAtividade();
                                _Retorno.value[0] = _RetornoAtividade;

                                int i = 1;

                                while (productInfoReader.Read())
                                {
                                    _Retorno.value[i] = new CadastroAtividade();

                                    DocEntry = productInfoReader.GetString(0);
                                    CardName = productInfoReader.GetString(1);

                                    GetPN = Service.Get($"Activities({DocEntry})");
                                    _RetornoAtividade = JsonConvert.DeserializeObject<CadastroAtividade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                    _RetornoAtividade.CardName = CardName;

                                    _Retorno.value[i] = _RetornoAtividade;

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
        public CadastroAtividade ConsultaPrimeiroAtividade()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroAtividade _Retorno = new CadastroAtividade();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaPrimeiroAtividade, Schema);

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

                                var GetPN = Service.Get($"Activities({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
        public CadastroAtividade ConsultaAnteriorAtividade(CadastroAtividade Atividade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroAtividade _Retorno = new CadastroAtividade();

            try
            {
                if (Atividade.ActivityCode == null || Atividade.ActivityCode.Equals(0))
                {
                    _Retorno = ConsultaPrimeiroAtividade();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaAnteriorAtividade, Schema, Atividade.ActivityCode);

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

                                    var GetPN = Service.Get($"Activities({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
                            string Sql = string.Format(Properties.Resources.ConsultaUltimoAtividade, Schema);

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

                                        var GetAtividade = Service.Get($"Activities({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetAtividade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
        public CadastroAtividade ConsultaProximoAtividade(CadastroAtividade Atividade)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroAtividade _Retorno = new CadastroAtividade();

            try
            {
                if (Atividade.ActivityCode == null || Atividade.ActivityCode.Equals(0))
                {
                    _Retorno = ConsultaUltimoAtividade();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaProximoAtividade, Schema, Atividade.ActivityCode);

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

                                    var GetAtividade = Service.Get($"Activities({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetAtividade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
                            string Sql = string.Format(Properties.Resources.ConsultaPrimeiroAtividade, Schema);

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

                                        var GetAtividade = Service.Get($"Activities({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetAtividade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
        public CadastroAtividade ConsultaUltimoAtividade()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroAtividade _Retorno = new CadastroAtividade();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaUltimoAtividade, Schema);

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

                                var GetAtividade = Service.Get($"Activities({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroAtividade>(GetAtividade.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
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
        public Tipos ConsultaTipoAtividade()
        {
            Tipos _Retorno = new Tipos();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaTipoAtividade, Schema);

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

                                _Retorno.value = new Tipo[int.Parse(Count)];
                                _Retorno.value[0] = new Tipo();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Tipo();
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
        public Assuntos ConsultaAssuntoAtividade(string Tipo)
        {
            Assuntos _Retorno = new Assuntos();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaAssuntoAtividade, Schema, Tipo);

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

                                _Retorno.value = new Assunto[int.Parse(Count)];
                                _Retorno.value[0] = new Assunto();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Assunto();
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
        public Usuarios ConsultaUsuarioAtividade()
        {
            Usuarios _Retorno = new Usuarios();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaUsuarioAtividade, Schema);

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

                                _Retorno.value = new Usuario[int.Parse(Count)];
                                _Retorno.value[0] = new Usuario();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Usuario();
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
        public Locais ConsultaLocalAtividade()
        {
            Locais _Retorno = new Locais();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaLocalAtividade, Schema);

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

                                _Retorno.value = new Local[int.Parse(Count)];
                                _Retorno.value[0] = new Local();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Local();
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

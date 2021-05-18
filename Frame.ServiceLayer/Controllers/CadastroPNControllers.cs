using Frame.ServiceLayer.Modelos;
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
    public class CadastroPNControllers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Retorno InsereAtualizaPN(CadastroPN PN)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Retorno _Retorno = new Retorno();

            try
            {
                //var RetLogin = Service.Login();
                //if (!RetLogin.Sucesso)
                //{
                //    Log.Error("Erro do Login SL");
                //    return RetLogin;
                //}

                var GetPN = Service.Get($"BusinessPartners('{PN.CardCode}')");

                if (!GetPN.Sucesso)
                {
                    #region Insere PN

                    //if (!PN.Series.Equals(73))
                    //{
                    //    PN.CardCode = null;
                    //}

                    var Json = JsonConvert.SerializeObject(PN, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Add("BusinessPartners", Json);

                    #endregion
                }
                else
                {
                    #region Atualiza PN

                    CadastroPN GetObjPN = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    #region Atualiza Endereço PN

                    if (PN.BPAddresses != null)
                    {
                        if (GetObjPN.BPAddresses != null)
                        {
                            foreach (var GetEndereco in GetObjPN.BPAddresses)
                            {
                                foreach (var Endereco in PN.BPAddresses)
                                {
                                    if (GetEndereco.AddressName == Endereco.AddressName && GetEndereco.AddressType == Endereco.AddressType)
                                    {
                                        Endereco.RowNum = GetEndereco.RowNum;
                                        Endereco.BPCode = GetEndereco.BPCode;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                    #region Atualiza Contato PN

                    if (PN.ContactEmployees != null)
                    {
                        if (GetObjPN.ContactEmployees != null)
                        {
                            foreach (var GetContato in GetObjPN.ContactEmployees)
                            {
                                foreach (var Contato in PN.ContactEmployees)
                                {
                                    if (GetContato.Name == Contato.Name)
                                    {
                                        Contato.CardCode = GetContato.CardCode;
                                        Contato.InternalCode = GetContato.InternalCode;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                    #region Atualiza Fiscal PN

                    if (PN.BPFiscalTaxIDCollection != null)
                    {
                        foreach (var Fiscal in PN.BPFiscalTaxIDCollection)
                        {
                            Fiscal.BPCode = PN.CardCode;
                        }
                    }

                    #endregion

                    var Json = Newtonsoft.Json.JsonConvert.SerializeObject(PN, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Update($"BusinessPartners('{PN.CardCode}')", Json);

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
        public CadastrosPNs ConsultaPN(CadastroPN PN)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastrosPNs _Retorno = new CadastrosPNs();

            try
            {
                //var RetLogin = Service.Login();
                //if (!RetLogin.Sucesso)
                //{
                //    Log.Error("Erro do Login SL");
                //}

                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string CNPJ = string.Empty;
                    string CPF = string.Empty;

                    if (PN.BPFiscalTaxIDCollection != null)
                    {
                        CNPJ = PN.BPFiscalTaxIDCollection[0].TaxId0;
                        CPF = PN.BPFiscalTaxIDCollection[0].TaxId4;
                    }

                    string Sql = string.Format(Properties.Resources.ConsultaPN, Schema, PN.CardCode, PN.CardName, CNPJ, CPF);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                var Count = productInfoReader.GetString(1);
                                var CardCode = productInfoReader.GetString(0);

                                var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                var _RetornoPN = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                _Retorno.value = new CadastroPN[int.Parse(Count)];
                                _Retorno.value[0] = new CadastroPN();
                                _Retorno.value[0] = _RetornoPN;

                                int i = 1;

                                while (productInfoReader.Read())
                                {
                                    _Retorno.value[i] = new CadastroPN();

                                    CardCode = productInfoReader.GetString(0);

                                    GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                    _RetornoPN = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                    _Retorno.value[i] = _RetornoPN;

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
        public CadastroPN ConsultaPrimeiroPN()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPN _Retorno = new CadastroPN();

            try
            {
                //var RetLogin = Service.Login();
                //if (!RetLogin.Sucesso)
                //{
                //    Log.Error("Erro do Login SL");
                //}

                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaPrimeiroPN, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var CardCode = productInfoReader.GetString(0);

                                var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public CadastroPN ConsultaAnteriorPN(CadastroPN PN)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPN _Retorno = new CadastroPN();

            try
            {
                if (string.IsNullOrEmpty(PN.CardCode))
                {
                    _Retorno = ConsultaPrimeiroPN();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaAnteriorPN, Schema, PN.CardCode);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var CardCode = productInfoReader.GetString(0);

                                    var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
                            string Sql = string.Format(Properties.Resources.ConsultaUltimoPN, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var CardCode = productInfoReader.GetString(0);

                                        var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public CadastroPN ConsultaProximoPN(CadastroPN PN)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPN _Retorno = new CadastroPN();

            try
            {
                if (string.IsNullOrEmpty(PN.CardCode))
                {
                    _Retorno = ConsultaUltimoPN();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaProximoPN, Schema, PN.CardCode);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var CardCode = productInfoReader.GetString(0);

                                    var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
                            string Sql = string.Format(Properties.Resources.ConsultaPrimeiroPN, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var CardCode = productInfoReader.GetString(0);

                                        var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public CadastroPN ConsultaUltimoPN()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPN _Retorno = new CadastroPN();

            try
            {
                //var RetLogin = Service.Login();
                //if (!RetLogin.Sucesso)
                //{
                //    Log.Error("Erro do Login SL");
                //}

                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaUltimoPN, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var CardCode = productInfoReader.GetString(0);

                                var GetPN = Service.Get($"BusinessPartners('{CardCode}')");
                                _Retorno = JsonConvert.DeserializeObject<CadastroPN>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public Estados ConsultaEstadoPN()
        {
            Estados _Retorno = new Estados();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaEstadoPN, Schema);

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

                                _Retorno.value = new Estado[int.Parse(Count)];
                                _Retorno.value[0] = new Estado();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Estado();
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
        public Municipios ConsultaMunicipioPN(string Municipio)
        {
            Municipios _Retorno = new Municipios();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaMunicipioPN, Schema, Municipio);

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

                                _Retorno.value = new Municipio[int.Parse(Count)];
                                _Retorno.value[0] = new Municipio();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Municipio();
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
        public Paises ConsultaPaisPN()
        {
            Paises _Retorno = new Paises();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaPaisPN, Schema);

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

                                _Retorno.value = new Pais[int.Parse(Count)];
                                _Retorno.value[0] = new Pais();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Pais();
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
        public UsoPrincipais ConsultaUsoPrincipaPN()
        {
            UsoPrincipais _Retorno = new UsoPrincipais();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaUsoPrincipalPN, Schema);

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

                                _Retorno.value = new UsoPrincipal[int.Parse(Count)];
                                _Retorno.value[0] = new UsoPrincipal();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new UsoPrincipal();
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
        public Vendedores ConsultaVendedorPN()
        {
            Vendedores _Retorno = new Vendedores();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaVendedorPN, Schema);

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

                                _Retorno.value = new Vendedor[int.Parse(Count)];
                                _Retorno.value[0] = new Vendedor();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Vendedor();
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
        public Projetos ConsultaProjetoPN()
        {
            Projetos _Retorno = new Projetos();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaProjetoPN, Schema);

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

                                _Retorno.value = new Projeto[int.Parse(Count)];
                                _Retorno.value[0] = new Projeto();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Projeto();
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
        public Grupos ConsultaGrupoPN(string Tipo)
        {
            Grupos _Retorno = new Grupos();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaGrupoPN, Schema, Tipo);

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

                                _Retorno.value = new Grupo[int.Parse(Count)];
                                _Retorno.value[0] = new Grupo();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Grupo();
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
        public Series ConsultaSeriePN(string Tipo)
        {
            Series _Retorno = new Series();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaSeriePN, Schema, Tipo);

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

                                _Retorno.value = new Serie[int.Parse(Count)];
                                _Retorno.value[0] = new Serie();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Serie();
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
        public string ConsultaCardCodePN(string Tipo, string Serie)
        {
            string _Retorno = string.Empty;

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaCardCodePN, Schema, Tipo, Serie);

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

                                _Retorno = Code;
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

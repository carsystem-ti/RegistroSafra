using Frame.ServiceLayer.Modelos;
using Frame.ServiceLayer.Modelos.Pedido;
using Frame.ServiceLayer.Modelos.PN;
using Frame.ServiceLayer.Modelos.Pre_LCM;
using Frame.ServiceLayer.Modelos.Projetos_Gerenciais;
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
    public class CadastroPedidoControllers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public object InseriAdiantamento(CadastroPedido Adiantamento)
        {
             WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            var RetLogin = Service.Login();
            CadastroPedido pedido = new CadastroPedido();
            var Retorno = new CadastroPedido();
            try
            {

                if (Adiantamento.CardCode != null)
                {
                    #region Insere Pedido

                    //var ObjJob = Pedido.CadastroJob;
                    //Pedido.CadastroJob = null;

                    var Json = JsonConvert.SerializeObject(Adiantamento, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    var ret = Service.Add("PurchaseDownPayments", Json);

                     Retorno = JsonConvert.DeserializeObject<CadastroPedido>(ret.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    return Retorno;



                    #endregion
                }
                else
                {
                    return Retorno;
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
            return Retorno;

        }


        public Retorno InsereAtualizaPedido(CadastroPedido Pedido)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Retorno _Retorno = new Retorno();

            try
            {

                if (Pedido.DocEntry == null)
                {
                    #region Insere Pedido

                    //var ObjJob = Pedido.CadastroJob;
                    //Pedido.CadastroJob = null;

                    var Json = JsonConvert.SerializeObject(Pedido, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Add("Orders", Json);

                    #endregion

                    #region Insere Projeto Gerencial

                    if (_Retorno.Sucesso)
                    {
                        ProjetoGerencial projetoGerencial = new ProjetoGerencial();

                        projetoGerencial.ProjectName = Pedido.DocumentLines[0].ProjectCode;
                        projetoGerencial.StartDate = Pedido.DocDate;
                        projetoGerencial.DueDate = Pedido.DocDueDate;
                        projetoGerencial.BusinessPartner = Pedido.CardCode;
                        projetoGerencial.BusinessPartnerName = Pedido.CardName;
                        projetoGerencial.SalesEmployee = Pedido.SalesPersonCode;
                        projetoGerencial.FinancialProject = Pedido.DocumentLines[0].ProjectCode;

                        Json = JsonConvert.SerializeObject(projetoGerencial, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                        var _RetornoProjeto = Service.Add("ProjectManagements", Json);

                        if (!_RetornoProjeto.Sucesso)
                        {
                            Log.Error("Erro ao Gerar Projeto Gerencial: " + _RetornoProjeto.Documento);
                        }
                    }

                    #endregion

                    #region Insere Pré LCM

                    if (_Retorno.Sucesso)
                    {
                        Modelos.Pedido.CadastroPedido GetObjPedido = JsonConvert.DeserializeObject<Modelos.Pedido.CadastroPedido>(_Retorno.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                        foreach (var item in GetObjPedido.DocumentLines)
                        {
                            string U_NEO_Dt_Inicio = item.U_NEO_Dt_Inicio;
                            float? valor = item.UnitPrice;
                            float? valorTotal = 0;
                            string U_NEO_RecReceita = item.U_NEO_RecReceita;
                            string ItemCode = item.ItemCode;
                            string CardCode = GetObjPedido.CardCode;
                            string Projeto = item.ProjectCode;
                            int? DocNum = GetObjPedido.DocNum;
                            string Conta = string.Empty;
                            int? Filial = GetObjPedido.BPL_IDAssignedToInvoice;

                            if (!string.IsNullOrEmpty(U_NEO_Dt_Inicio))
                            {
                                if (!string.IsNullOrEmpty(U_NEO_RecReceita))
                                {
                                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                                    {
                                        conn.Open();

                                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                                        string Sql = string.Format(Properties.Resources.ConsultaGrupoItem, Schema, ItemCode);

                                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                                        {
                                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                            {
                                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                                if (productInfoReader.HasRows)
                                                {
                                                    productInfoReader.Read();

                                                    string GrupoItem = productInfoReader.GetString(0);

                                                    if (GrupoItem.Equals("107"))
                                                        Conta = "3010201010098";
                                                    else
                                                        Conta = "3010201010099";

                                                    //3010201010098 - DIFERIMENTO - PRODUÇÃO - 107
                                                    //3010201010099 - DIFERIMENTO - MYND - 105

                                                    DateTime Data = new DateTime();
                                                    Data = DateTime.Parse(U_NEO_Dt_Inicio);
                                                    int TotalDias = 0;
                                                    DateTime ultimoDiaDoMes = new DateTime();
                                                    for (int i = 0; i < int.Parse(U_NEO_RecReceita); i++)
                                                    {
                                                        ultimoDiaDoMes = new DateTime(Data.Year, Data.Month, DateTime.DaysInMonth(Data.Year, Data.Month));

                                                        var qtddias = ultimoDiaDoMes.Day;
                                                        var diaAtual = Data.Day;
                                                        var restoDias = qtddias - diaAtual + 1;

                                                        TotalDias = TotalDias + qtddias - diaAtual + 1;

                                                        //Data = Data.AddDays(restoDias - 1);
                                                        Data = Data.AddDays(restoDias);

                                                    }

                                                    PreLCM preLCM = new PreLCM();
                                                    preLCM.JournalVoucher = new Journalvoucher();
                                                    preLCM.JournalVoucher.JournalEntry = new Journalentry();

                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines = new Journalentryline[int.Parse(U_NEO_RecReceita)+1];
                                                    preLCM.JournalVoucher.JournalEntry.ReferenceDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                    preLCM.JournalVoucher.JournalEntry.Memo = "Pré Lançamento gerado pelo Site Pedido: " + DocNum;

                                                    Data = DateTime.Parse(U_NEO_Dt_Inicio);
                                                    for (int i = 0; i < int.Parse(U_NEO_RecReceita); i++)
                                                    {
                                                        ultimoDiaDoMes = new DateTime(Data.Year, Data.Month, DateTime.DaysInMonth(Data.Year, Data.Month));
                                                        var qtddias = ultimoDiaDoMes.Day;
                                                        var diaAtual = Data.Day;
                                                        var restoDias = qtddias - diaAtual + 1;


                                                        var ValorLCM = (valor / TotalDias) * restoDias;
                                                        valorTotal = valorTotal + ValorLCM;

                                                        preLCM.JournalVoucher.JournalEntry.DueDate = ultimoDiaDoMes.ToString("yyyy-MM-dd");
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i] = new Journalentryline();

                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].AccountCode = Conta;
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].Credit = ValorLCM;
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].Debit = 0;
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].BPLID = Filial;
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].DueDate = ultimoDiaDoMes.ToString("yyyy-MM-dd");
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].LineMemo = "Pré Lançamento gerado pelo Site Pedido: " + DocNum;
                                                        preLCM.JournalVoucher.JournalEntry.JournalEntryLines[i].ProjectCode = Projeto;

                                                        Data = Data.AddDays(restoDias);

                                                    }

                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)] = new Journalentryline();
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].AccountCode = "1010201010001";
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].Credit = 0;
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].Debit = valorTotal;
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].BPLID = Filial;
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].ShortName = CardCode;
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].DueDate = ultimoDiaDoMes.ToString("yyyy-MM-dd");
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].LineMemo = "Pré Lançamento gerado pelo Site Pedido: " + DocNum;
                                                    preLCM.JournalVoucher.JournalEntry.JournalEntryLines[int.Parse(U_NEO_RecReceita)].ProjectCode = Projeto;

                                                    var JsonLCM = JsonConvert.SerializeObject(preLCM, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                                                    var _RetornoLCM = Service.Add("JournalVouchersService_Add", JsonLCM);

                                                    if (!_RetornoLCM.Sucesso)
                                                    {
                                                        Log.Error("Erro ao Gerar Pré LCM: " + _RetornoLCM.Documento);
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region Insere Job

                    //if (_Retorno.Sucesso)
                    //{
                    //    foreach (var itemJobb in ObjJob)
                    //    {
                    //        var RetObjPedido = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroPedido>(_Retorno.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    //        itemJobb.U_NEO_DocEntry = RetObjPedido.DocEntry.ToString();
                    //        itemJobb.U_NEO_DocType = "17";

                    //        var JsonJob = Newtonsoft.Json.JsonConvert.SerializeObject(itemJobb, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    //        var _RetornoJob = Service.Add("JOB", JsonJob);

                    //        if (!_RetornoJob.Sucesso)
                    //        {

                    //        }

                    //    }
                    //}

                    #endregion

                }
                else
                {
                    #region Atualiza Pedido

                    //var ObjJob = Pedido.CadastroJob;
                    //Pedido.CadastroJob = null;

                    var Json = Newtonsoft.Json.JsonConvert.SerializeObject(Pedido, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    _Retorno = Service.Update($"Orders({Pedido.DocEntry})", Json);

                    #endregion

                    #region Insere Job

                    //if (_Retorno.Sucesso)
                    //{
                    //    var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{Pedido.DocEntry}'");
                    //    var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    //    if (RetObjJob.value.ToList().Count > 0)
                    //    {
                    //        foreach (var item in RetObjJob.value)
                    //        {
                    //            var _RetornoJob = Service.Delete($"JOB({item.DocEntry})");

                    //            if (!_RetornoJob.Sucesso)
                    //            {

                    //            }
                    //        }
                    //        foreach (var itemJobb in ObjJob)
                    //        {
                    //            itemJobb.U_NEO_DocEntry = Pedido.DocEntry.ToString();
                    //            itemJobb.U_NEO_DocType = "17";

                    //            var JsonJob = Newtonsoft.Json.JsonConvert.SerializeObject(itemJobb, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    //            var _RetornoJob = Service.Add("JOB", JsonJob);

                    //            if (!_RetornoJob.Sucesso)
                    //            {

                    //            }

                    //        }
                    //    }
                    //    else
                    //    {
                    //        foreach (var item in ObjJob)
                    //        {
                    //            item.U_NEO_DocEntry = Pedido.DocEntry.ToString();
                    //            item.U_NEO_DocType = "17";

                    //            var JsonJob = Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    //            var _RetornoJob = Service.Add("JOB", JsonJob);

                    //            if (!_RetornoJob.Sucesso)
                    //            {

                    //            }
                    //        }
                    //    }
                    //}

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
        public CadastrosPedidos ConsultaPedido(CadastroPedido Pedido)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastrosPedidos _Retorno = new CadastrosPedidos();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaPedido, Schema, Pedido.CardCode, Pedido.CardName, Pedido.DocNum);

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
                                var DocEntry = productInfoReader.GetString(0);

                                var GetPN = Service.Get($"Orders({DocEntry})");
                                var _RetornoPedido = JsonConvert.DeserializeObject<CadastroPedido>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                //var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //if (RetObjJob.value.ToList().Count > 0)
                                //{
                                //    _RetornoPedido.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                //    _RetornoPedido.CadastroJob = RetObjJob.value;
                                //}

                                _Retorno.value = new CadastroPedido[int.Parse(Count)];
                                _Retorno.value[0] = new CadastroPedido();
                                _Retorno.value[0] = _RetornoPedido;

                                int i = 1;

                                while (productInfoReader.Read())
                                {
                                    _Retorno.value[i] = new CadastroPedido();

                                    DocEntry = productInfoReader.GetString(0);

                                    GetPN = Service.Get($"Orders({DocEntry})");
                                    _RetornoPedido = JsonConvert.DeserializeObject<CadastroPedido>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                    //RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //if (RetObjJob.value.ToList().Count > 0)
                                    //{
                                    //    _RetornoPedido.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                    //    _RetornoPedido.CadastroJob = RetObjJob.value;
                                    //}

                                    _Retorno.value[i] = _RetornoPedido;

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
        public CadastroPedido ConsultaPrimeiroPedido()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPedido _Retorno = new CadastroPedido();

            try
            {

                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaPrimeiroPedido, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var DocEntry = productInfoReader.GetString(0);

                                var GetPN = Service.Get($"Orders({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                //var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //if (RetObjJob.value.ToList().Count > 0)
                                //{
                                //    _Retorno.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                //    _Retorno.CadastroJob = RetObjJob.value;
                                //}

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
        public CadastroPedido ConsultaAnteriorPedido(CadastroPedido Pedido)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPedido _Retorno = new CadastroPedido();

            try
            {
                if (Pedido.DocEntry == null || Pedido.DocEntry.Equals(0))
                {
                    _Retorno = ConsultaPrimeiroPedido();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaAnteriorPedido, Schema, Pedido.DocEntry);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var DocEntry = productInfoReader.GetString(0);

                                    var GetPN = Service.Get($"Orders({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPN.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                    //var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //if (RetObjJob.value.ToList().Count > 0)
                                    //{
                                    //    _Retorno.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                    //    _Retorno.CadastroJob = RetObjJob.value;
                                    //}
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
                            string Sql = string.Format(Properties.Resources.ConsultaUltimoPedido, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var DocEntry = productInfoReader.GetString(0);

                                        var GetPedido = Service.Get($"Orders({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPedido.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public CadastroPedido ConsultaProximoPedido(CadastroPedido Pedido)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPedido _Retorno = new CadastroPedido();

            try
            {
                if (Pedido.DocEntry == null || Pedido.DocEntry.Equals(0))
                {
                    _Retorno = ConsultaUltimoPedido();
                }
                else
                {
                    using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                    {
                        conn.Open();

                        var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                        string Sql = string.Format(Properties.Resources.ConsultaProximoPedido, Schema, Pedido.DocEntry);

                        using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                        {
                            using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                            {
                                HanaCommand cmd = new HanaCommand(Sql, conn);
                                HanaDataReader productInfoReader = cmd.ExecuteReader();

                                while (productInfoReader.Read())
                                {
                                    var DocEntry = productInfoReader.GetString(0);

                                    var GetPedido = Service.Get($"Orders({DocEntry})");
                                    _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPedido.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                    //var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                    //if (RetObjJob.value.ToList().Count > 0)
                                    //{
                                    //    _Retorno.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                    //    _Retorno.CadastroJob = RetObjJob.value;
                                    //}
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
                            string Sql = string.Format(Properties.Resources.ConsultaPrimeiroPedido, Schema);

                            using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                            {
                                using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                                {
                                    HanaCommand cmd = new HanaCommand(Sql, conn);
                                    HanaDataReader productInfoReader = cmd.ExecuteReader();

                                    while (productInfoReader.Read())
                                    {
                                        var DocEntry = productInfoReader.GetString(0);

                                        var GetPedido = Service.Get($"Orders({DocEntry})");
                                        _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPedido.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

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
        public CadastroPedido ConsultaUltimoPedido()
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            CadastroPedido _Retorno = new CadastroPedido();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];
                    string Sql = string.Format(Properties.Resources.ConsultaUltimoPedido, Schema);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            while (productInfoReader.Read())
                            {
                                var DocEntry = productInfoReader.GetString(0);

                                var GetPedido = Service.Get($"Orders({DocEntry})");
                                _Retorno = JsonConvert.DeserializeObject<CadastroPedido>(GetPedido.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //var GetJob = Service.Get($"JOB?$select=*&$filter=U_NEO_DocEntry eq '{DocEntry}'");
                                //var RetObjJob = Newtonsoft.Json.JsonConvert.DeserializeObject<CadastroJobs>(GetJob.Documento, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                                //if (RetObjJob.value.ToList().Count > 0)
                                //{
                                //    _Retorno.CadastroJob = new CadastroJob[RetObjJob.value.ToList().Count];
                                //    _Retorno.CadastroJob = RetObjJob.value;
                                //}
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
        public Itens ConsultaItensPedido(string ItemCode, string ItemName)
        {
            Itens _Retorno = new Itens();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaItensPedido, Schema, ItemCode, ItemName);

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

                                _Retorno.value = new Iten[int.Parse(Count)];
                                _Retorno.value[0] = new Iten();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Iten();
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
        public Filiais ConsultaFilialPedido()
        {
            Filiais _Retorno = new Filiais();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaFilialPedido, Schema);

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

                                _Retorno.value = new Filial[int.Parse(Count)];
                                _Retorno.value[0] = new Filial();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Filial();
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
        public Utilizacoes ConsultaUtilizacaoPedido()
        {
            Utilizacoes _Retorno = new Utilizacoes();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    string Sql = string.Format(Properties.Resources.ConsultaUtilizacaoPedido, Schema);

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

                                _Retorno.value = new Utilizacao[int.Parse(Count)];
                                _Retorno.value[0] = new Utilizacao();
                                _Retorno.value[0].Code = Code;
                                _Retorno.value[0].Name = Name;

                                int i = 1;
                                while (productInfoReader.Read())
                                {
                                    Code = productInfoReader.GetString(0);
                                    Name = productInfoReader.GetString(1);

                                    _Retorno.value[i] = new Utilizacao();
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
        public Vendedores ConsultaVendedorPedido()
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

    }
}

using Frame.ServiceLayer.Modelos;
using Frame.ServiceLayer.Modelos.ContasReceber;
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
    public class CadastroContasReceber
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ContasReceber ConsultaContasReceber(string NomeCliente, string DataVencimentoDe, string DataVencimentoAte, string DataPagamentoDe, string DataPagamentoAte, string Projeto, string Status)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            ContasReceber _Retorno = new ContasReceber();

            try
            {
                using (HanaConnection conn = new HanaConnection(ConfigurationManager.ConnectionStrings["Hana"].ConnectionString))
                {
                    conn.Open();

                    var Schema = ConfigurationManager.AppSettings["CompanyDB"];

                    if (string.IsNullOrEmpty(Status))
                    {
                        Status = "Todos";
                    }

                    string Sql = string.Format(Properties.Resources.ConsultaContasReceber, Schema, NomeCliente, DataVencimentoDe, DataVencimentoAte, DataPagamentoDe, DataPagamentoAte, Projeto, Status);

                    using (HanaCommand cmd3 = new HanaCommand(Sql, conn))
                    {
                        using (HanaDataReader productInfoReader3 = cmd3.ExecuteReader())
                        {
                            HanaCommand cmd = new HanaCommand(Sql, conn);
                            HanaDataReader productInfoReader = cmd.ExecuteReader();

                            if (productInfoReader.HasRows)
                            {
                                productInfoReader.Read();

                                var pNomeCliente = productInfoReader.GetString(0);
                                var pParcela = productInfoReader.GetString(1);
                                var pValorParcela = productInfoReader.GetString(2);
                                var pNumeroNota = productInfoReader.GetString(3);
                                var pDataVencimento = productInfoReader.GetString(4);
                                var pDataPagamento = productInfoReader.GetString(5);
                                var pProjeto = productInfoReader.GetString(6);
                                var pStatus = productInfoReader.GetString(7);
                                var Count = productInfoReader.GetString(8);


                                _Retorno.value = new ContaReceber[int.Parse(Count)];
                                _Retorno.value[0] = new ContaReceber();
                                _Retorno.value[0].NomeCliente = pNomeCliente;
                                _Retorno.value[0].Parcela = pParcela;
                                _Retorno.value[0].ValorParcela = pValorParcela;
                                _Retorno.value[0].NumeroNota = pNumeroNota;
                                _Retorno.value[0].DataVencimento = pDataVencimento;
                                _Retorno.value[0].DataPagamento = pDataPagamento;
                                _Retorno.value[0].Projeto = pProjeto;
                                _Retorno.value[0].Status = pStatus;

                                int i = 1;

                                while (productInfoReader.Read())
                                {
                                    _Retorno.value[i] = new ContaReceber();

                                    pNomeCliente = productInfoReader.GetString(0);
                                    pParcela = productInfoReader.GetString(1);
                                    pValorParcela = productInfoReader.GetString(2);
                                    pNumeroNota = productInfoReader.GetString(3);
                                    pDataVencimento = productInfoReader.GetString(4);
                                    pDataPagamento = productInfoReader.GetString(5);
                                    pProjeto = productInfoReader.GetString(6);
                                    pStatus = productInfoReader.GetString(7);
                                    Count = productInfoReader.GetString(8);

                                    _Retorno.value[i].NomeCliente = pNomeCliente;
                                    _Retorno.value[i].Parcela = pParcela;
                                    _Retorno.value[i].ValorParcela = pValorParcela;
                                    _Retorno.value[i].NumeroNota = pNumeroNota;
                                    _Retorno.value[i].DataVencimento = pDataVencimento;
                                    _Retorno.value[i].DataPagamento = pDataPagamento;
                                    _Retorno.value[i].Projeto = pProjeto;
                                    _Retorno.value[i].Status = pStatus;

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
    }
}

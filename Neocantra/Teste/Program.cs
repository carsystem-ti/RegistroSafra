using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            // Login do Site
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Service.LoginSite("manager", "B1Admin@2");

            #region CONTASRECEBER

            ConsultaContasReceber();

            #endregion

            #region PROJETO

            InsereProjeto();

            #endregion

            #region OPORTUNIDADE

            InsereAtualizaOportunidade();
            ConsultaOportunidade();
            ConsultaPrimeiroOportunidade();
            ConsultaAnteriorOportunidade();
            ConsultaProximoOportunidade();
            ConsultaUltimoOportunidade();

            ConsultaNivelInteresse();
            ConsultaDescricao();
            ConsultaEtapa();
            ConsultaPorcentagem();
            ConsultaTitular();

            #endregion

            #region ATIVIDADE

            InsereAtualizaAtividade();
            ConsultaAtividade();
            ConsultaPrimeiroAtividade();
            ConsultaAnteriorAtividade();
            ConsultaProximoAtividade();
            ConsultaUltimoAtividade();
            ConsultaTipoAtividade();
            ConsultaAssuntoAtividade();
            ConsultaUsuarioAtividade();
            ConsultaLocalAtividade();

            #endregion

            #region PEDIDO

            InsereAtualizaPedido();
            ConsultaPedido();
            ConsultaPrimeiroPedido();
            ConsultaAnteriorPedido();
            ConsultaProximoPedido();
            ConsultaUltimoPedido();
            ConsultaItensPedido();
            ConsultaFilialPedido();
            ConsultaUtilizacaoPedido();
            ConsultaVendedorPedido();
            ConsultaProjetoPedido();

            #endregion

            #region PN

            //Combo CardType Fixo os Valores 
            //C - Cleinte
            //S - Fornecedor
            //L - Cliente potencial

            InsereAtualizaPN();
            ConsultaPN();
            ConsultaPrimeiroPN();
            ConsultaAnteriorPN();
            ConsultaProximoPN();
            ConsultaUltimoPN();
            ConsultaEstadoPN();
            ConsultaMunicipioPN();
            ConsultaPaisPN();
            ConsultaUsoPrincipalPN();
            ConsultaVendedorPN();
            ConsultaProjetoPN();
            ConsultaGrupoPN();
            ConsultaSeriePN();
            ConsultaCardCodePN();

            #endregion
        }

        #region CONTASRECEBER

        private static void ConsultaContasReceber()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroContasReceber cadastroContasReceber = new Frame.ServiceLayer.Controllers.CadastroContasReceber();

                //Filtros do Form de Consulta Contas a Receber.

                // Nome Cliente = Campo Texto
                string NomeCliente = "";

                // Data de Vencimento De = Campo Tipo Data com o Formato 2019-01-04 (yyyy-MM-dd)
                string DataVencimentoDe = "";

                // Data de Vencimento Até = Campo Tipo Data com o Formato 2019-01-04 (yyyy-MM-dd)
                string DataVencimentoAte = "";

                // Data de Pagamento De = Campo Tipo Data com o Formato 2019-01-04 (yyyy-MM-dd)
                string DataPagamentoDe = "";

                // Data de Pagamento Até = Campo Tipo Data com o Formato 2019-01-04 (yyyy-MM-dd)
                string DataPagamentoAte = "";

                //Projeto = Campo Tipo Combo com os Projeto Metodo (ConsultaProjetoPN)
                string Projeto = "";

                //Status = Campo Tipo Combo com Valores Fixo:
                //Recebido - Recebido
                //Receber - Receber
                //Todos - Todos
                string Status = "";

                var RetObjContasReceber = cadastroContasReceber.ConsultaContasReceber(NomeCliente, DataVencimentoDe, DataVencimentoAte, DataPagamentoDe, DataPagamentoAte, Projeto, Status);
                //Campos de Retorno da Consulta
                //NomeCliente = Nome do Cliente
                //Parcela = Parcela
                //ValorParcela = Valor da Parcela
                //NumeroNota = Numero da Nota
                //DataVencimento = Data de Vencimento
                //DataPagamento = Data de Pagamento
                //Projeto = Projeto
                //Status = Status


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region PROJETO

        private static void InsereProjeto()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroProjetoControllers cadastroProjetoControllers = new Frame.ServiceLayer.Controllers.CadastroProjetoControllers();

                Frame.ServiceLayer.Modelos.Projeto.CadastroProjeto cadastroProjeto = new Frame.ServiceLayer.Modelos.Projeto.CadastroProjeto();

                //Código do projeto
                cadastroProjeto.Code = "Projeto1";

                //Nome do projeto
                cadastroProjeto.Name = "Projeto1";

                //Válido desde
                cadastroProjeto.ValidFrom = "2019-01-01";

                //Válido até
                cadastroProjeto.ValidTo = "2019-12-31";

                //Ativo - Sempre mandar tYES
                cadastroProjeto.Active = "tYES";

                var RetObjProjeto = cadastroProjetoControllers.InsereProjeto(cadastroProjeto);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region OPORTUNIDADE

        private static void InsereAtualizaOportunidade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade cadastroOportunidade = new Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade();

                //Nº da oportunidade
                //Funciona Igual ao Pdido de Venda se existir o Numero manda que vai atualizar null vai inserir
                cadastroOportunidade.SequentialNo = 5;

                //Código do PN - Abre o Form Lista de Cliente para Selecionar
                cadastroOportunidade.CardCode = "C0000004";

                //Vendedor - Combo Igual ao do Pedido de Venda
                cadastroOportunidade.SalesPerson = 1;

                //Nome da oportunidade - Capo Texto tamanho 100
                cadastroOportunidade.OpportunityName = "Nome da oportunidade";

                //Data início - Campo do Tipo Data
                cadastroOportunidade.StartDate = "2019-09-24";

                //Previsão de encerramento - Campo do Tipo Data
                cadastroOportunidade.PredictedClosingDate = "2019-10-28";

                //Valor potencial - Campo do Tipo Valor
                cadastroOportunidade.MaxLocalTotal = float.Parse("200.99");

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////
                //NOVOS CAMPOS

                //Status - Combo com Valor Fixo
                //Aberto - sos_Open
                //Venceu - sos_Sold
                //Perdeu - sos_Missed
                cadastroOportunidade.Status = "sos_Open";

                //Nível de Interesse - Combo com valores pegando do metodo ConsultaNivelInteresse()
                cadastroOportunidade.InterestLevel = "-1";

                //Descrição
                cadastroOportunidade.SalesOpportunitiesInterests = new Frame.ServiceLayer.Modelos.Oportunidade.Salesopportunitiesinterest[1];
                cadastroOportunidade.SalesOpportunitiesInterests[0] = new Frame.ServiceLayer.Modelos.Oportunidade.Salesopportunitiesinterest();
                //Descrição - Combo com valores pegando do metodo ConsultaDescricao()
                cadastroOportunidade.SalesOpportunitiesInterests[0].InterestId = 1;
                //Sempre 0 valor Fixo
                cadastroOportunidade.SalesOpportunitiesInterests[0].RowNo = 0;
                //Sempre tYES valor Fixo
                cadastroOportunidade.SalesOpportunitiesInterests[0].PrimaryInterest = "tYES";

                cadastroOportunidade.SalesOpportunitiesLines = new Frame.ServiceLayer.Modelos.Oportunidade.Salesopportunitiesline[1];
                cadastroOportunidade.SalesOpportunitiesLines[0] = new Frame.ServiceLayer.Modelos.Oportunidade.Salesopportunitiesline();

             
                //Data início
                cadastroOportunidade.SalesOpportunitiesLines[0].StartDate = "2019-09-27";
                //Data de encerramento
                cadastroOportunidade.SalesOpportunitiesLines[0].ClosingDate = "2019-09-27";
                //Vendedor - Combo Igual ao do Pedido de Venda
                cadastroOportunidade.SalesOpportunitiesLines[0].SalesPerson = -1;
                //Etapa - Combo com valores pegando do metodo ConsultaEtapa
                cadastroOportunidade.SalesOpportunitiesLines[0].StageKey = 1;
                //% - Campo Sempre fechado pegando pegando o Valor no Meotodo ConsultaPorcentagem passando como parametro a Etapa
                cadastroOportunidade.SalesOpportunitiesLines[0].PercentageRate = float.Parse("0.0");
                //Valor potencial - Campo do Tipo Valor
                cadastroOportunidade.SalesOpportunitiesLines[0].MaxLocalTotal = float.Parse("1500.990");
                //Titular - Combo com valores pegando do metodo ConsultaTitular se não existir mandar null
                cadastroOportunidade.SalesOpportunitiesLines[0].DataOwnershipfield = null;

                ///////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////

                var RetObjOportunidade = cadastroOportunidadeControllers.InsereAtualizaOportunidade(cadastroOportunidade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaOportunidade()
        {
            try
            {
                //Consulta de Oportunidade Pelo
                //CardCode = Codigo do PN
                //CardName = Nome do PN
                //DocNum = Numero da Oportunidade

                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade cadastroOportunidade = new Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade();
                cadastroOportunidade.CardCode = "";
                cadastroOportunidade.CardName = "";
                cadastroOportunidade.SequentialNo = null;

                var RetObjOportunidade = cadastroOportunidadeControllers.ConsultaOportunidade(cadastroOportunidade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPrimeiroOportunidade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetObjOportunidade = cadastroOportunidadeControllers.ConsultaPrimeiroOportunidade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAnteriorOportunidade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade cadastroOportunidade = new Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade();
                cadastroOportunidade.SequentialNo = 27;

                var RetObjOportunidade = cadastroOportunidadeControllers.ConsultaAnteriorOportunidade(cadastroOportunidade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProximoOportunidade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade cadastroOportunidade = new Frame.ServiceLayer.Modelos.Oportunidade.CadastroOportunidade();
                cadastroOportunidade.SequentialNo = 5;

                var RetObjOportunidade = cadastroOportunidadeControllers.ConsultaProximoOportunidade(cadastroOportunidade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUltimoOportunidade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetObjOportunidade = cadastroOportunidadeControllers.ConsultaUltimoOportunidade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private static void ConsultaNivelInteresse()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetNivelInteresse = cadastroOportunidadeControllers.ConsultaNivelInteresse();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaDescricao()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetDescricao = cadastroOportunidadeControllers.ConsultaDescricao();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaEtapa()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetEtapa= cadastroOportunidadeControllers.ConsultaEtapa();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPorcentagem()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                //Passa como parâmetro a Etapa selecionada na Combo para pegar o valor da %
                var RetPorcentagem = cadastroOportunidadeControllers.ConsultaPorcentagem("5");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaTitular()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers cadastroOportunidadeControllers = new Frame.ServiceLayer.Controllers.CadastroOportunidadeControllers();

                var RetTitular = cadastroOportunidadeControllers.ConsultaTitular();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        #endregion

        #region ATIVIDADE

        private static void InsereAtualizaAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade cadastroAtividade = new Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade();

                //Númenro
                //Funciona Igual ao Pdido de Venda se existir o Numero manda que vai atualizar null vai inserir
                cadastroAtividade.ActivityCode = 5;

                //Atividade - Combo com valores Fixos
                //Telefone = cn_Conversation
                //Reunião = cn_Meeting
                //Tarefa = cn_Task
                //Nota = cn_Note
                //Campanha = cn_Campaign
                //Outros = cn_Other
                cadastroAtividade.Activity = "cn_Conversation";

                //Tipo - Combo com valores pegando do metodo ConsultaTipoAtividade()
                cadastroAtividade.ActivityType = -1;

                //Assunto - Combo com valores pegando do metodo ConsultaAssuntoAtividade()
                cadastroAtividade.Subject = -1;

                //Atribuído a - Combo com valores pegando do metodo ConsultaUsuarioAtividade()
                cadastroAtividade.HandledBy = 31;

                //Código do PN - Abre o Form Lista de Cliente para Selecionar
                cadastroAtividade.CardCode = "C0000003";

                //Nº de telefone - Capo Texto tamanho 50
                cadastroAtividade.Phone = "94761-4761";

                //Observações - Capo Texto tamanho 100
                cadastroAtividade.Details = "Observações";

                //Hora de início
                cadastroAtividade.StartDate = "2019-10-13";
                cadastroAtividade.StartTime = "07:31:00";

                //Hora de término
                cadastroAtividade.EndDueDate = "2019-10-13";
                cadastroAtividade.EndTime = "08:11:00";

                //Prioridade - Combo com valores Fixos
                //Baixo = pr_Low
                //Normal = pr_Normal
                //Elevado = pr_High
                cadastroAtividade.Priority = "pr_Low";

                //Local da reunião - Combo com valores pegando do metodo ConsultaLocalAtividade()
                cadastroAtividade.Location = -1;

                //Fechado - Check Box
                //Quando Estiver marcado é Fechado o Valor = tYES
                //Qunado nãoE stiver marcado é aberta o Valor é = tNO
                cadastroAtividade.Closed = "tNO";

                //Inativo - Check Box
                //Quando Estiver marcado é Inativa o Valor = tYES
                //Qunado não Estiver marcado é Ativa o Valor é = tNO
                cadastroAtividade.InactiveFlag = "tNO";

                var RetAtividade = cadastroAtividadeControllers.InsereAtualizaAtividade(cadastroAtividade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAtividade()
        {
            try
            {
                //Consulta de Atilidade Pelo
                //CardCode = Codigo do PN
                //CardName = Nome do PN
                //DocNum = Numero da Atividade

                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade cadastroAtividade = new Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade();
                cadastroAtividade.CardCode = "";
                cadastroAtividade.CardName = "";
                cadastroAtividade.ActivityCode = null;

                var RetAtividade = cadastroAtividadeControllers.ConsultaAtividade(cadastroAtividade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPrimeiroAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                var RetObjAtividade = cadastroAtividadeControllers.ConsultaPrimeiroAtividade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAnteriorAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade cadastroAtividade = new Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade();
                cadastroAtividade.ActivityCode = 27;

                var RetObjAtividade = cadastroAtividadeControllers.ConsultaAnteriorAtividade(cadastroAtividade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProximoAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade cadastroAtividade = new Frame.ServiceLayer.Modelos.Atividade.CadastroAtividade();
                cadastroAtividade.ActivityCode = 1;

                var RetObjAtividade = cadastroAtividadeControllers.ConsultaProximoAtividade(cadastroAtividade);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUltimoAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                var RetObjAtividade = cadastroAtividadeControllers.ConsultaUltimoAtividade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private static void ConsultaTipoAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                var RetTipoAtividade = cadastroAtividadeControllers.ConsultaTipoAtividade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAssuntoAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();
               
                //Tem que passar como paremetro qual é o Tipo (ID da COmbo TIpo)
                var RetAssuntoAtividade = cadastroAtividadeControllers.ConsultaAssuntoAtividade("-1");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUsuarioAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                var RetUsuarioAtividade = cadastroAtividadeControllers.ConsultaUsuarioAtividade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaLocalAtividade()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroAtividadeControllers cadastroAtividadeControllers = new Frame.ServiceLayer.Controllers.CadastroAtividadeControllers();

                var RetLocalAtividade = cadastroAtividadeControllers.ConsultaLocalAtividade();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region PN

        private static void InsereAtualizaPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                Frame.ServiceLayer.Modelos.PN.CadastroPN cadastroPN = new Frame.ServiceLayer.Modelos.PN.CadastroPN();
                cadastroPN.Series = 73;
                cadastroPN.CardCode = "C010892";
                cadastroPN.CardName = "Nome";
                cadastroPN.CardForeignName = "Nome estrangeiro";
                cadastroPN.GroupCode = 100;

                cadastroPN.Phone1 = "Telefone";
                cadastroPN.Phone2 = "DDD";
                cadastroPN.Fax = "Fax";
                cadastroPN.MailAddress = "E-mail";
                cadastroPN.Website = "Web site";

                //cadastroPN.ProjectCode = "Projeto PN";
                cadastroPN.AliasName = "Nome Fantasia";

                //Ativo = tYES
                cadastroPN.Valid = "tYES";
                //Inativo = tNO
                cadastroPN.Valid = "tNO";

                cadastroPN.Notes = "Observações";
                //Vendedor
                cadastroPN.SalesPersonCode = "-1";


                //Contato
                cadastroPN.ContactEmployees = new Frame.ServiceLayer.Modelos.PN.Contactemployee[1];
                cadastroPN.ContactEmployees[0] = new Frame.ServiceLayer.Modelos.PN.Contactemployee();

                cadastroPN.ContactEmployees[0].Name = "ID do contato";
                cadastroPN.ContactEmployees[0].FirstName = "Primeiro nome";
                cadastroPN.ContactEmployees[0].MiddleName = "Segundo nome";
                cadastroPN.ContactEmployees[0].LastName = "Sobrenome";
                cadastroPN.ContactEmployees[0].Title = "Título";
                cadastroPN.ContactEmployees[0].Position = "Posição";
                cadastroPN.ContactEmployees[0].Address = "Endereço";
                cadastroPN.ContactEmployees[0].Phone1 = "Telefone";
                cadastroPN.ContactEmployees[0].Phone2 = "Telefone 2";
                cadastroPN.ContactEmployees[0].MobilePhone = "Tel.celular";
                cadastroPN.ContactEmployees[0].Fax = "Fax";
                cadastroPN.ContactEmployees[0].E_Mail = "E-mail";
                cadastroPN.ContactEmployees[0].Remarks1 = "Observações 1";
                cadastroPN.ContactEmployees[0].Remarks2 = "Observações 2";

                //Endereço
                cadastroPN.BPAddresses = new Frame.ServiceLayer.Modelos.PN.Bpaddress[2];
                //Endereço de Cobrança
                cadastroPN.BPAddresses[0] = new Frame.ServiceLayer.Modelos.PN.Bpaddress();
                cadastroPN.BPAddresses[0].AddressName = "ID do endereço";
                cadastroPN.BPAddresses[0].AddressName2 = "Endereço nome 2";
                cadastroPN.BPAddresses[0].AddressName3 = "Endereço nome 3";
                cadastroPN.BPAddresses[0].TypeOfAddress = "Tipo de logradouro";
                cadastroPN.BPAddresses[0].Street = "Rua/caixa postal";
                cadastroPN.BPAddresses[0].StreetNo = "Rua nº";
                cadastroPN.BPAddresses[0].BuildingFloorRoom = "Complemento";
                cadastroPN.BPAddresses[0].ZipCode = "CEP";
                cadastroPN.BPAddresses[0].Block = "Bairro";
                cadastroPN.BPAddresses[0].City = "Cidade";
                cadastroPN.BPAddresses[0].State = "SP";
                cadastroPN.BPAddresses[0].County = "5125";
                cadastroPN.BPAddresses[0].Country = "BR";
                cadastroPN.BPAddresses[0].AddressType = "bo_BillTo";
                //Endereço de Entrega
                cadastroPN.BPAddresses[1] = new Frame.ServiceLayer.Modelos.PN.Bpaddress();
                cadastroPN.BPAddresses[1].AddressName = "ID do endereço";
                cadastroPN.BPAddresses[1].AddressName2 = "Endereço nome 2";
                cadastroPN.BPAddresses[1].AddressName3 = "Endereço nome 3";
                cadastroPN.BPAddresses[1].TypeOfAddress = "Tipo de logradouro";
                cadastroPN.BPAddresses[1].Street = "Rua/caixa postal";
                cadastroPN.BPAddresses[1].StreetNo = "Rua nº";
                cadastroPN.BPAddresses[1].BuildingFloorRoom = "Complemento";
                cadastroPN.BPAddresses[1].ZipCode = "CEP";
                cadastroPN.BPAddresses[1].Block = "Bairro";
                cadastroPN.BPAddresses[1].City = "Cidade";
                cadastroPN.BPAddresses[1].State = "SP";
                cadastroPN.BPAddresses[1].County = "5125";
                cadastroPN.BPAddresses[1].Country = "BR";
                cadastroPN.BPAddresses[1].AddressType = "bo_ShipTo";

                //Fisxal CNPJ/CPF
                cadastroPN.BPFiscalTaxIDCollection = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection[3];
                //Fisxal de Cobrança
                cadastroPN.BPFiscalTaxIDCollection[0] = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection();
                cadastroPN.BPFiscalTaxIDCollection[0].Address = "ID do endereço";
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId0 = "CNPJ";
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId1 = "Inscrição Estadual";
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId2 = "Ins.Est.Substituto Tributário";
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId3 = "Inscrição Municipal";
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId4 = "CPF";
                cadastroPN.BPFiscalTaxIDCollection[0].AddrType = "bo_BillTo";
                //Fisxal de Entrega
                cadastroPN.BPFiscalTaxIDCollection[1] = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection();
                cadastroPN.BPFiscalTaxIDCollection[1].Address = "ID do endereço";
                cadastroPN.BPFiscalTaxIDCollection[1].TaxId0 = "CNPJ";
                cadastroPN.BPFiscalTaxIDCollection[1].TaxId1 = "Inscrição Estadual";
                cadastroPN.BPFiscalTaxIDCollection[1].TaxId2 = "Ins.Est.Substituto Tributário";
                cadastroPN.BPFiscalTaxIDCollection[1].TaxId3 = "Inscrição Municipal";
                cadastroPN.BPFiscalTaxIDCollection[1].TaxId4 = "CPF";
                cadastroPN.BPFiscalTaxIDCollection[1].AddrType = "bo_ShipTo";
                //Fisxal de Contabilidade
                cadastroPN.BPFiscalTaxIDCollection[2] = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection();
                cadastroPN.BPFiscalTaxIDCollection[2].Address = "";
                cadastroPN.BPFiscalTaxIDCollection[2].TaxId0 = "CNPJ";
                cadastroPN.BPFiscalTaxIDCollection[2].TaxId1 = "Inscrição Estadual";
                cadastroPN.BPFiscalTaxIDCollection[2].TaxId2 = "Ins.Est.Substituto Tributário";
                cadastroPN.BPFiscalTaxIDCollection[2].TaxId3 = "Inscrição Municipal";
                cadastroPN.BPFiscalTaxIDCollection[2].TaxId4 = "CPF";
                cadastroPN.BPFiscalTaxIDCollection[2].AddrType = "bo_ShipTo";

                // Aba Observações
                cadastroPN.FreeText = "O&bservações";


                var RetPN = cadastroPNControllers.InsereAtualizaPN(cadastroPN);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                Frame.ServiceLayer.Modelos.PN.CadastroPN cadastroPN = new Frame.ServiceLayer.Modelos.PN.CadastroPN();
                cadastroPN.CardCode = "C9";
                cadastroPN.CardName = "";

                cadastroPN.BPFiscalTaxIDCollection = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection[1];
                cadastroPN.BPFiscalTaxIDCollection[0] = new Frame.ServiceLayer.Modelos.PN.Bpfiscaltaxidcollection();
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId0 = "";  //CNPN
                cadastroPN.BPFiscalTaxIDCollection[0].TaxId4 = "";  //CPF

                //Coloquei para Retornar no Maximo 50
                var RetPN = cadastroPNControllers.ConsultaPN(cadastroPN);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPrimeiroPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetObjPN = cadastroPNControllers.ConsultaPrimeiroPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAnteriorPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                Frame.ServiceLayer.Modelos.PN.CadastroPN cadastroPN = new Frame.ServiceLayer.Modelos.PN.CadastroPN();
                cadastroPN.CardCode = "F010892";

                var RetPN = cadastroPNControllers.ConsultaAnteriorPN(cadastroPN);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProximoPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                Frame.ServiceLayer.Modelos.PN.CadastroPN cadastroPN = new Frame.ServiceLayer.Modelos.PN.CadastroPN();
                //cadastroPN.CardCode = "F010892";

                var RetPN = cadastroPNControllers.ConsultaProximoPN(cadastroPN);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUltimoPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetObjPN = cadastroPNControllers.ConsultaUltimoPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaEstadoPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetEstadosPN = cadastroPNControllers.ConsultaEstadoPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaMunicipioPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetMunicipiosPN = cadastroPNControllers.ConsultaMunicipioPN("SP");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPaisPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetEstadosPN = cadastroPNControllers.ConsultaPaisPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUsoPrincipalPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetEstadosPN = cadastroPNControllers.ConsultaUsoPrincipaPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaVendedorPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetEstadosPN = cadastroPNControllers.ConsultaVendedorPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProjetoPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetEstadosPN = cadastroPNControllers.ConsultaProjetoPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaGrupoPN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                // C - Cliente
                // S - Fornecedor
                var RetEstadosPN = cadastroPNControllers.ConsultaGrupoPN("C");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaSeriePN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                // C - Cliente
                // S - Fornecedor
                var RetSeriePN = cadastroPNControllers.ConsultaSeriePN("C");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaCardCodePN()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                // C - Cliente
                // S - Fornecedor
                // Serie
                var RetCardCodePN = cadastroPNControllers.ConsultaCardCodePN("C","73");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        #endregion

        #region Pedido

        private static void InsereAtualizaPedido()
        {
            try
            {
                //Falta colocar a data de Entrega
                //Retirar o Titular
                //Retirar o Uso Principal
                //Retirar Desconto

                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                Frame.ServiceLayer.Modelos.Pedido.CadastroPedido cadastroPedido = new Frame.ServiceLayer.Modelos.Pedido.CadastroPedido();

                #region Pedido de Venda

                //DocEntry é o ID Interno do SAP é ele que tem que mandar para atulizar o Pedido
                //DocNum é o Numero do Pedido que aparece na Tela do Pedido

                //DocEntry
                //cadastroPedido.DocEntry = 10;

                //Cliente
                cadastroPedido.CardCode = "C0000006";
                //Nome
                //cadastroPedido.CardName = "O BOTICARIO FRANCHISING SA";
                //Nº de ref. do cliente
                //cadastroPedido.NumAtCard = "CERVEJARIA PETRAPOLIS S.A.";
                //Filial
                cadastroPedido.BPL_IDAssignedToInvoice = 1;
                //Data de lançamento
                cadastroPedido.DocDate = "2019-10-29";
                //Data de entrega
                cadastroPedido.DocDueDate = "2019-10-29";
                //Data do documento
                cadastroPedido.TaxDate = "2019-10-29";
                //Vendedor
                cadastroPedido.SalesPersonCode = "1";
                //Observações
                cadastroPedido.Comments = "Observações";

                //Linhas do Pedido
                cadastroPedido.DocumentLines = new Frame.ServiceLayer.Modelos.Pedido.Documentline[2];

                cadastroPedido.DocumentLines[0] = new Frame.ServiceLayer.Modelos.Pedido.Documentline();
                //Numero do Item
                cadastroPedido.DocumentLines[0].ItemCode = "SRV000002";
                //Descrição do Item
                //cadastroPedido.DocumentLines[0].ItemDescription = "STORIES - PRETA GIL";
                //Quantidade
                cadastroPedido.DocumentLines[0].Quantity = 1;
                //Preço Unitario
                cadastroPedido.DocumentLines[0].UnitPrice = float.Parse("1200.00");
                //% de Desconto
                //cadastroPedido.DocumentLines[0].DiscountPercent = 10;
                //Utilização
                cadastroPedido.DocumentLines[0].Usage = 14;
                //Projeto
                cadastroPedido.DocumentLines[0].ProjectCode = "CERV2019";
                //Rec. Receita
                cadastroPedido.DocumentLines[0].U_NEO_RecReceita = "3";
                cadastroPedido.DocumentLines[0].U_NEO_Dt_Inicio = "2019-10-29";

                //cadastroPedido.DocumentLines[1] = new Frame.ServiceLayer.Modelos.Pedido.Documentline();
                //cadastroPedido.DocumentLines[1].ItemCode = "SRV000004";
                //cadastroPedido.DocumentLines[1].Quantity = 1;
                //cadastroPedido.DocumentLines[1].UnitPrice = float.Parse("2000.99");
                //cadastroPedido.DocumentLines[1].DiscountPercent = 10;
                //cadastroPedido.DocumentLines[1].Usage = 14;
                //cadastroPedido.DocumentLines[1].ProjectCode = "BOT19A";
                //cadastroPedido.DocumentLines[1].U_NEO_RecReceita = "2";
                //cadastroPedido.DocumentLines[1].U_NEO_Dt_Inicio = "2019-10-27";


                //cadastroPedido.DocumentLines[1] = new Frame.ServiceLayer.Modelos.Pedido.Documentline();
                //cadastroPedido.DocumentLines[1].ItemCode = "ITEM_VENDA_BL";
                //cadastroPedido.DocumentLines[1].ItemDescription = "Descrição do Item";
                //cadastroPedido.DocumentLines[1].Quantity = 5;
                //cadastroPedido.DocumentLines[1].UnitPrice = float.Parse("199,99");
                //cadastroPedido.DocumentLines[1].DiscountPercent = 10;
                //cadastroPedido.DocumentLines[1].Usage = 10;

                #endregion

                #region JOBJS

                //JOBS

                //Data Solicitação
                cadastroPedido.U_NEO_DtSol = "2019-10-07";
                //Solicitante
                cadastroPedido.U_NEO_Solic = "Solicitante";
                //Nome do Job
                cadastroPedido.U_NEO_Job = "Nome do Job";
                //Agência
                cadastroPedido.U_NEO_Ag = "Agência";
                //Cliente - Lista de PN
                cadastroPedido.U_NEO_Cliente = "Cliente";
                //Responsável Campanha
                cadastroPedido.U_NEO_RespCamp = "Responsável Campanha";
                //Contratante
                cadastroPedido.U_NEO_Contrat = "Contratante";
                //CNPJ Contratante
                cadastroPedido.U_NEO_CnpjC = "CNPJ Contratante";
                //E-mail Financeiro
                cadastroPedido.U_NEO_EmailF = "E-mail Financeiro";
                //Data Início
                cadastroPedido.U_NEO_DtI = "2019-10-07";
                //Data Fim
                cadastroPedido.U_NEO_DtF = "2019-10-07";
                //Custo do Projeto/repasse
                cadastroPedido.U_NEO_CP = float.Parse("11,11");
                //Comiissão Mynd/Music
                cadastroPedido.U_NEO_CO = float.Parse("22,22");
                //Marca/Produto Anunciado
                cadastroPedido.U_NEO_Marca = "Marca/Produto Anunciado";
                //Segmento Mercado
                cadastroPedido.U_NEO_Seg = "Segmento Mercado";
                //Nome Campanha
                cadastroPedido.U_NEO_NC = "Nome Campanha";
                //Exclusividade Artista
                cadastroPedido.U_NEO_Excl = "Exclusividade Artista";
                //Custo Logistica
                cadastroPedido.U_NEO_Log = "Custo Logistica";
                //Responsável Logistica - Combo com dois Valor(Mynd - Cliente)
                cadastroPedido.U_NEO_LogResp = "Mynd";
                //Despesas Inclusas - Combo com dois Valor(Sim - Não)
                cadastroPedido.U_NEO_LOG1 = "Sim";
                //Despesas Eventuais
                cadastroPedido.U_NEO_DespEv = "2";
                //Despesas Eventuais - Combo com dois Valor(Mynd - Cliente)
                cadastroPedido.U_NEO_DE1 = "Mynd";
                //Redes Sociais
                cadastroPedido.U_NEO_Post = "Redes Sociais";
                //Tipo Post - Combo com dois Valor(Feed - Stories)
                cadastroPedido.U_NEO_PostTip = "Stories";
                //Prazo Mínimo Manut.
                cadastroPedido.U_NEO_PzPost = "1";
                //Repost Contratante
                cadastroPedido.U_NEO_RePost = "Respost";
                //Responsável Produção - Combo com dois Valor(Mynd - Cliente)
                cadastroPedido.U_NEO_AVF = "Mynd";
                //Diárias Captações
                cadastroPedido.U_NEO_Capt = "Diárias Captações";
                //Tempo Captação
                cadastroPedido.U_NEO_TCapt = "2";
                //Diária Extra
                cadastroPedido.U_NEO_DE = float.Parse("33,33");
                //Refações
                cadastroPedido.U_NEO_Ref = "Refações";
                //Valor Refações
                cadastroPedido.U_NEO_RefV = "10";
                //Descrição da Produção
                cadastroPedido.U_NEO_DescP = "Descrição da Produção";
                //Composição Fonograma
                cadastroPedido.U_NEO_CF = "Composição Fonograma";
                //Editaora
                cadastroPedido.U_NEO_CFEd = "Editaora";
                //Responsabilidade CF - Combo com dois Valor(Mynd - Cliente)
                cadastroPedido.U_NEO_CFResp = "Cliente";
                //Veiculação Internet
                cadastroPedido.U_NEO_VeicInter = "Veiculação Internet";
                //Veiculação TV
                cadastroPedido.U_NEO_VeicTv = "Veiculação TV";
                //Veiculação OOH
                cadastroPedido.U_NEO_VeicOOH = "Veiculação OOH";
                //Veiculação PDV
                cadastroPedido.U_NEO_VeicPDV = "Veiculação PDV";
                //Veiculação Prazo
                cadastroPedido.U_NEO_VeicPz = "Veiculação Prazo";
                //Território - Combo com dois Valor(Brasil - Worldwide)
                cadastroPedido.U_NEO_VeicTer = "Brasil";
                //Observações
                cadastroPedido.U_NEO_Obs = "Observações";

                #endregion


                var RetPedido = cadastroPedidoControllers.InsereAtualizaPedido(cadastroPedido);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPedido()
        {
            try
            {
                //Consulta de Pedido Pelo
                //CardCode = Codigo do PN
                //CardName = Nome do PN
                //DocNum = Numero do Pedio que aparece na Tela não é o DocEntry

                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                Frame.ServiceLayer.Modelos.Pedido.CadastroPedido cadastroPN = new Frame.ServiceLayer.Modelos.Pedido.CadastroPedido();
                cadastroPN.CardCode = "C";
                cadastroPN.CardName = "";
                cadastroPN.DocNum = null;

                //Coloquei para Retornar no Maximo 50
                var RetPedido = cadastroPedidoControllers.ConsultaPedido(cadastroPN);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaPrimeiroPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                var RetObjPedido = cadastroPedidoControllers.ConsultaPrimeiroPedido();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaAnteriorPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                Frame.ServiceLayer.Modelos.Pedido.CadastroPedido cadastroPedido = new Frame.ServiceLayer.Modelos.Pedido.CadastroPedido();
                //cadastroPedido.DocEntry = 1;

                var RetPedido = cadastroPedidoControllers.ConsultaAnteriorPedido(cadastroPedido);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProximoPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                Frame.ServiceLayer.Modelos.Pedido.CadastroPedido cadastroPedido = new Frame.ServiceLayer.Modelos.Pedido.CadastroPedido();
                //cadastroPedido.DocEntry = 40;

                var RetPedido = cadastroPedidoControllers.ConsultaProximoPedido(cadastroPedido);

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUltimoPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                var RetObjPedido = cadastroPedidoControllers.ConsultaUltimoPedido();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaItensPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                // A Procura do Item será feita por
                //ItemCode = Codigo do Item ou
                //ItemName = Nome do Item

                var RetItensPedido = cadastroPedidoControllers.ConsultaItensPedido("", "");

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaFilialPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                var RetFilialPedido = cadastroPedidoControllers.ConsultaFilialPedido();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaUtilizacaoPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                var RetUtilizacaoPedido = cadastroPedidoControllers.ConsultaUtilizacaoPedido();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaVendedorPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPedidoControllers cadastroPedidoControllers = new Frame.ServiceLayer.Controllers.CadastroPedidoControllers();

                var RetVendedorPedido = cadastroPedidoControllers.ConsultaVendedorPedido();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private static void ConsultaProjetoPedido()
        {
            try
            {
                Frame.ServiceLayer.Controllers.CadastroPNControllers cadastroPNControllers = new Frame.ServiceLayer.Controllers.CadastroPNControllers();

                var RetProjetoPedido = cadastroPNControllers.ConsultaProjetoPN();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion
    }
}

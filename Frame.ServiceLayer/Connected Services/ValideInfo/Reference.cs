﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Frame.ServiceLayer.ValideInfo {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ValideInfo.WsSoap")]
    public interface WsSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GerarToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GerarToken(int codigoEmpresa, string usuario, string senha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Localiza", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode Localiza(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadastroSimplesPF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CadastroSimplesPF(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadastroSimplesPJ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CadastroSimplesPJ(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadastroSintetico", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CadastroSintetico(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadastroCompletoPF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CadastroCompletoPF(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CadastroCompletoPJ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CadastroCompletoPJ(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PessoasLigadas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode PessoasLigadas(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaFederalPFOnline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaFederalPFOnline(string token, string documento, string dataNascimento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaFederalPFBD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaFederalPFBD(string token, string documento, string dataNascimento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaFederalPJOnline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaFederalPJOnline(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaFederalPJBD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaFederalPJBD(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaSintegraOnline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaSintegraOnline(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SintegraOnline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode SintegraOnline(string token, string documento, string uf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidacaoFiscal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ValidacaoFiscal(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Veiculo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode Veiculo(string token, string placa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VeiculoSimples", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode VeiculoSimples(string token, string placa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObitoSimples", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ObitoSimples(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GroupPJ", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GroupPJ(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SimplesNacional", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode SimplesNacional(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Protesto", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode Protesto(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/QSA", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode QSA(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscaCEP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode BuscaCEP(string token, string cep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscaCepPorLogradouro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode BuscaCepPorLogradouro(string token, string estado, string cidade, string logradouro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RestricaoS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode RestricaoS(string token, string documento);
        
        // CODEGEN: O parâmetro 'dataInicio' requer informações adicionais de esquema que não podem ser capturadas usando o modo do parâmetro. O atributo específico é 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Relatorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Frame.ServiceLayer.ValideInfo.RelatorioResponse Relatorio(Frame.ServiceLayer.ValideInfo.RelatorioRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ANP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ANP(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConsultaFGTSEmpregador", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ConsultaFGTSEmpregador(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Score", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode Score(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRPF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode IRPF(string token, string documento, int exercicio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CARF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CARF(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConsultaTSE", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ConsultaTSE(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CCF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CCF(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ReceitaFederalComCaptcha", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ReceitaFederalComCaptcha(string token, string cpf, string dataNascimento, string captcha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MandadoPrisao", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode MandadoPrisao(string token, string nome, string dataNascimento, string nomeMae);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PEP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode PEP(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AcoesJudiciais", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode AcoesJudiciais(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SugereGEO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode SugereGEO(string token, string documento, string cep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AcoesJudiciaisPrimeiraSegundaInstancia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode AcoesJudiciaisPrimeiraSegundaInstancia(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BACEN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode BACEN(string token, string cnpj, string unidade, string dependencia, string operador, string mes, string ano, string senha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CEPIM", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CEPIM(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CEIS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CEIS(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CNEP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CNEP(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PETI", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode PETI(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AcordoLeniencia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode AcordoLeniencia(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CEAF", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CEAF(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DividaAtivaSP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode DividaAtivaSP(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KYC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode KYC(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MidiasNegativas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode MidiasNegativas(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PoliciaFederalProdutosQuimicos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode PoliciaFederalProdutosQuimicos(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Decisor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode Decisor(string token, string documento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListaDecisor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode ListaDecisor(string token);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Relatorio", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RelatorioRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> dataInicio;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> dataFinal;
        
        public RelatorioRequest() {
        }
        
        public RelatorioRequest(string token, System.Nullable<System.DateTime> dataInicio, System.Nullable<System.DateTime> dataFinal) {
            this.token = token;
            this.dataInicio = dataInicio;
            this.dataFinal = dataFinal;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RelatorioResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RelatorioResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Xml.XmlNode RelatorioResult;
        
        public RelatorioResponse() {
        }
        
        public RelatorioResponse(System.Xml.XmlNode RelatorioResult) {
            this.RelatorioResult = RelatorioResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WsSoapChannel : Frame.ServiceLayer.ValideInfo.WsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsSoapClient : System.ServiceModel.ClientBase<Frame.ServiceLayer.ValideInfo.WsSoap>, Frame.ServiceLayer.ValideInfo.WsSoap {
        
        public WsSoapClient() {
        }
        
        public WsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.XmlNode GerarToken(int codigoEmpresa, string usuario, string senha) {
            return base.Channel.GerarToken(codigoEmpresa, usuario, senha);
        }
        
        public System.Xml.XmlNode Localiza(string token, string documento) {
            return base.Channel.Localiza(token, documento);
        }
        
        public System.Xml.XmlNode CadastroSimplesPF(string token, string documento) {
            return base.Channel.CadastroSimplesPF(token, documento);
        }
        
        public System.Xml.XmlNode CadastroSimplesPJ(string token, string documento) {
            return base.Channel.CadastroSimplesPJ(token, documento);
        }
        
        public System.Xml.XmlNode CadastroSintetico(string token, string documento) {
            return base.Channel.CadastroSintetico(token, documento);
        }
        
        public System.Xml.XmlNode CadastroCompletoPF(string token, string documento) {
            return base.Channel.CadastroCompletoPF(token, documento);
        }
        
        public System.Xml.XmlNode CadastroCompletoPJ(string token, string documento) {
            return base.Channel.CadastroCompletoPJ(token, documento);
        }
        
        public System.Xml.XmlNode PessoasLigadas(string token, string documento) {
            return base.Channel.PessoasLigadas(token, documento);
        }
        
        public System.Xml.XmlNode ReceitaFederalPFOnline(string token, string documento, string dataNascimento) {
            return base.Channel.ReceitaFederalPFOnline(token, documento, dataNascimento);
        }
        
        public System.Xml.XmlNode ReceitaFederalPFBD(string token, string documento, string dataNascimento) {
            return base.Channel.ReceitaFederalPFBD(token, documento, dataNascimento);
        }
        
        public System.Xml.XmlNode ReceitaFederalPJOnline(string token, string documento) {
            return base.Channel.ReceitaFederalPJOnline(token, documento);
        }
        
        public System.Xml.XmlNode ReceitaFederalPJBD(string token, string documento) {
            return base.Channel.ReceitaFederalPJBD(token, documento);
        }
        
        public System.Xml.XmlNode ReceitaSintegraOnline(string token, string documento) {
            return base.Channel.ReceitaSintegraOnline(token, documento);
        }
        
        public System.Xml.XmlNode SintegraOnline(string token, string documento, string uf) {
            return base.Channel.SintegraOnline(token, documento, uf);
        }
        
        public System.Xml.XmlNode ValidacaoFiscal(string token, string documento) {
            return base.Channel.ValidacaoFiscal(token, documento);
        }
        
        public System.Xml.XmlNode Veiculo(string token, string placa) {
            return base.Channel.Veiculo(token, placa);
        }
        
        public System.Xml.XmlNode VeiculoSimples(string token, string placa) {
            return base.Channel.VeiculoSimples(token, placa);
        }
        
        public System.Xml.XmlNode ObitoSimples(string token, string documento) {
            return base.Channel.ObitoSimples(token, documento);
        }
        
        public System.Xml.XmlNode GroupPJ(string token, string documento) {
            return base.Channel.GroupPJ(token, documento);
        }
        
        public System.Xml.XmlNode SimplesNacional(string token, string documento) {
            return base.Channel.SimplesNacional(token, documento);
        }
        
        public System.Xml.XmlNode Protesto(string token, string documento) {
            return base.Channel.Protesto(token, documento);
        }
        
        public System.Xml.XmlNode QSA(string token, string documento) {
            return base.Channel.QSA(token, documento);
        }
        
        public System.Xml.XmlNode BuscaCEP(string token, string cep) {
            return base.Channel.BuscaCEP(token, cep);
        }
        
        public System.Xml.XmlNode BuscaCepPorLogradouro(string token, string estado, string cidade, string logradouro) {
            return base.Channel.BuscaCepPorLogradouro(token, estado, cidade, logradouro);
        }
        
        public System.Xml.XmlNode RestricaoS(string token, string documento) {
            return base.Channel.RestricaoS(token, documento);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Frame.ServiceLayer.ValideInfo.RelatorioResponse Frame.ServiceLayer.ValideInfo.WsSoap.Relatorio(Frame.ServiceLayer.ValideInfo.RelatorioRequest request) {
            return base.Channel.Relatorio(request);
        }
        
        public System.Xml.XmlNode Relatorio(string token, System.Nullable<System.DateTime> dataInicio, System.Nullable<System.DateTime> dataFinal) {
            Frame.ServiceLayer.ValideInfo.RelatorioRequest inValue = new Frame.ServiceLayer.ValideInfo.RelatorioRequest();
            inValue.token = token;
            inValue.dataInicio = dataInicio;
            inValue.dataFinal = dataFinal;
            Frame.ServiceLayer.ValideInfo.RelatorioResponse retVal = ((Frame.ServiceLayer.ValideInfo.WsSoap)(this)).Relatorio(inValue);
            return retVal.RelatorioResult;
        }
        
        public System.Xml.XmlNode ANP(string token, string documento) {
            return base.Channel.ANP(token, documento);
        }
        
        public System.Xml.XmlNode ConsultaFGTSEmpregador(string token, string documento) {
            return base.Channel.ConsultaFGTSEmpregador(token, documento);
        }
        
        public System.Xml.XmlNode Score(string token, string documento) {
            return base.Channel.Score(token, documento);
        }
        
        public System.Xml.XmlNode IRPF(string token, string documento, int exercicio) {
            return base.Channel.IRPF(token, documento, exercicio);
        }
        
        public System.Xml.XmlNode CARF(string token, string documento) {
            return base.Channel.CARF(token, documento);
        }
        
        public System.Xml.XmlNode ConsultaTSE(string token, string documento) {
            return base.Channel.ConsultaTSE(token, documento);
        }
        
        public System.Xml.XmlNode CCF(string token, string documento) {
            return base.Channel.CCF(token, documento);
        }
        
        public System.Xml.XmlNode ReceitaFederalComCaptcha(string token, string cpf, string dataNascimento, string captcha) {
            return base.Channel.ReceitaFederalComCaptcha(token, cpf, dataNascimento, captcha);
        }
        
        public System.Xml.XmlNode MandadoPrisao(string token, string nome, string dataNascimento, string nomeMae) {
            return base.Channel.MandadoPrisao(token, nome, dataNascimento, nomeMae);
        }
        
        public System.Xml.XmlNode PEP(string token, string documento) {
            return base.Channel.PEP(token, documento);
        }
        
        public System.Xml.XmlNode AcoesJudiciais(string token, string documento) {
            return base.Channel.AcoesJudiciais(token, documento);
        }
        
        public System.Xml.XmlNode SugereGEO(string token, string documento, string cep) {
            return base.Channel.SugereGEO(token, documento, cep);
        }
        
        public System.Xml.XmlNode AcoesJudiciaisPrimeiraSegundaInstancia(string token, string documento) {
            return base.Channel.AcoesJudiciaisPrimeiraSegundaInstancia(token, documento);
        }
        
        public System.Xml.XmlNode BACEN(string token, string cnpj, string unidade, string dependencia, string operador, string mes, string ano, string senha) {
            return base.Channel.BACEN(token, cnpj, unidade, dependencia, operador, mes, ano, senha);
        }
        
        public System.Xml.XmlNode CEPIM(string token, string documento) {
            return base.Channel.CEPIM(token, documento);
        }
        
        public System.Xml.XmlNode CEIS(string token, string documento) {
            return base.Channel.CEIS(token, documento);
        }
        
        public System.Xml.XmlNode CNEP(string token, string documento) {
            return base.Channel.CNEP(token, documento);
        }
        
        public System.Xml.XmlNode PETI(string token, string documento) {
            return base.Channel.PETI(token, documento);
        }
        
        public System.Xml.XmlNode AcordoLeniencia(string token, string documento) {
            return base.Channel.AcordoLeniencia(token, documento);
        }
        
        public System.Xml.XmlNode CEAF(string token, string documento) {
            return base.Channel.CEAF(token, documento);
        }
        
        public System.Xml.XmlNode DividaAtivaSP(string token, string documento) {
            return base.Channel.DividaAtivaSP(token, documento);
        }
        
        public System.Xml.XmlNode KYC(string token, string documento) {
            return base.Channel.KYC(token, documento);
        }
        
        public System.Xml.XmlNode MidiasNegativas(string token, string documento) {
            return base.Channel.MidiasNegativas(token, documento);
        }
        
        public System.Xml.XmlNode PoliciaFederalProdutosQuimicos(string token, string documento) {
            return base.Channel.PoliciaFederalProdutosQuimicos(token, documento);
        }
        
        public System.Xml.XmlNode Decisor(string token, string documento) {
            return base.Channel.Decisor(token, documento);
        }
        
        public System.Xml.XmlNode ListaDecisor(string token) {
            return base.Channel.ListaDecisor(token);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulling.Model
{
    public class Unitofour
    {
      


            public class CADASTROUNIT
            {
                public string DOCUMENTO { get; set; }
                public string NOME { get; set; }
                public string ID_UNIT { get; set; }
            }

            public class DADOSCADASTRAIS
            {
                public string CPF { get; set; }
                public string NOME { get; set; }
                public string NOME_ULTIMO { get; set; }
                public string SEXO { get; set; }
                public string NOME_MAE { get; set; }
                public string DATANASC { get; set; }
                public string IDADE { get; set; }
                public string SIGNO { get; set; }
                public string SITUACAO_RECEITA { get; set; }
            }

            public class TELEFONES
            {
                public string RANKING { get; set; }
                public string TELEFONE { get; set; }
                public string TELEFONE_VALIDO { get; set; }
                public string ORIGEM { get; set; }
                public string PERMISSAO_MARKET { get; set; }
                public string ASSINANTE { get; set; }
                public string OPERADORA { get; set; }
                public string TIPO { get; set; }
            }

            public class ENDERECOS
            {
                public string RANKING { get; set; }
                public string LOGRADOURO { get; set; }
                public string NUMERO { get; set; }
                public object COMPLEMENTO { get; set; }
                public string BAIRRO { get; set; }
                public string CEP { get; set; }
                public string CIDADE { get; set; }
                public string UF { get; set; }
            }

            public class EMAILS
            {
                public string RANKING { get; set; }
                public string EMAIL { get; set; }
                public string PARTICULAR { get; set; }
            }

            public class CONSULTAPF
            {
                public CADASTROUNIT CADASTROUNIT { get; set; }
                public DADOSCADASTRAIS DADOS_CADASTRAIS { get; set; }
                public List<TELEFONES> TELEFONES { get; set; }
                public ENDERECOS ENDERECOS { get; set; }
                public EMAILS EMAILS { get; set; }

                public List<EMAILS> EMAIL { get; set; }
            }


        
    }
}

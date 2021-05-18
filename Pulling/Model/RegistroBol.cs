using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulling.Model
{
    public class RegistroBol
    {
        public int agencia { get; set; }
        public int conta { get; set; }
        public float? fidc { get; set; }
        public string danfe { get; set; }
        public Documento documento { get; set; }


        public class Documento
        {
            public string numero { get; set; }
            public string numeroCliente { get; set; }
            public int diasDevolucao { get; set; }
            public string especie { get; set; }
            public string dataVencimento { get; set; }
            public int valor { get; set; }
            public int codigoMoeda { get; set; }
            public int quantidadeDiasProtesto { get; set; }
            public string identificacaoAceite { get; set; }
            public string campoLivre { get; set; }
            public int valorAbatimento { get; set; }
            public Desconto desconto { get; set; }
            public Multa multa { get; set; }
            public Pagamentoparcial pagamentoParcial { get; set; }
            public Pagador pagador { get; set; }
            public Beneficiario[] beneficiario { get; set; }
            public Mensagen[] mensagens { get; set; }
        }

        public class Desconto
        {
            public string data { get; set; }
            public int valor { get; set; }
            public string data2 { get; set; }
            public int valor2 { get; set; }
            public string data3 { get; set; }
            public int valor3 { get; set; }
            public string tipoDesconto { get; set; }
        }

        public class Multa
        {
            public string dataMulta { get; set; }
            public string dataJuros { get; set; }
            public float taxaJuros { get; set; }
            public float taxaMulta { get; set; }
        }

        public class Pagamentoparcial
        {
            public int valorMaximo { get; set; }
            public int valorMinimo { get; set; }
            public int quantidadeParcelas { get; set; }
            public int tipoPagamento { get; set; }
            public int tipoValor { get; set; }
        }

        public class Pagador
        {
            public string nome { get; set; }
            public string tipoPessoa { get; set; }
            public string numeroDocumento { get; set; }
            public Endereco endereco { get; set; }
        }

        public class Endereco
        {
            public string logradouro { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string cep { get; set; }
        }

        public class Beneficiario
        {
            public string nome { get; set; }
            public string tipoPessoa { get; set; }
            public string email { get; set; }
            public string numeroDocumento { get; set; }
            public Endereco1 endereco { get; set; }
        }

        public class Endereco1
        {
            public string logradouro { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string cep { get; set; }
        }

        public class Mensagen
        {
            public string posicao { get; set; }
            public string descricao { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.ContasReceber
{
    public class ContasReceber
    {
        public ContaReceber[] value { get; set; }
    }
    public class ContaReceber
    {
        public string NomeCliente { get; set; }
        public string Parcela { get; set; }
        public string ValorParcela { get; set; }
        public string NumeroNota { get; set; }
        public string DataVencimento { get; set; }
        public string DataVencimentoFim { get; set; }
        public string DataPagamento { get; set; }
        public string DataPagamentoFim { get; set; }
        public string Projeto { get; set; }
        public string Status { get; set; }

    }
}

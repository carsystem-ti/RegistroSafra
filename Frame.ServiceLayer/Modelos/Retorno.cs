using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Frame.ServiceLayer.Modelos
{
    public class Retorno
    {
        public bool Sucesso { get; set; }
        public int CodRetorno { get; set; }
        public string DescRetorno { get; set; }
        public string NumDocumento { get; set; }
        public string Documento { get; set; }
    }
    public class RetornoAssinatura
    {
        public Retorno RetornoLogin = new Retorno();
        public Retorno RetornoBusinessPartners = new Retorno();
        public List<Retorno> RetornoCustomerEquipmentCards = new List<Retorno>();
        public Retorno RetornoServiceContracts = new Retorno();
    }

    public class Erros
    {
        public Error error { get; set; }
        public bool Sucesso { get; set; }
    }
    public class Error
    {
        public int code { get; set; }
        public Message message { get; set; }
    }
    public class Message
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

}
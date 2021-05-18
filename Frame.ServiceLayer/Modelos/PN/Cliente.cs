using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frame.ServiceLayer.Modelos.PN
{
    public class Cliente
    {
        public string id_pedido { get; set; }

        public string dt_pedido { get; set; }

        public string dt_confirmacao { get; set; }


        public string dt_renovacao { get; set; }
        public string st_pedido { get; set; }
        public string nr_cpfCnpj { get; set; }
        public string nr_rg { get; set; }
        public string nr_evento { get; set; }
        public string cd_vendedor { get; set; }
        public string cd_supervisor { get; set; }
        public string cd_setor { get; set; }
        public string cd_midia { get; set; }
        public string ds_cliente { get; set; }
        public string ds_email { get; set; }
        public string nr_cep { get; set; }
        public string ds_endereco { get; set; }
        public string nr_endereco { get; set; }
        public string ds_complemento { get; set; }
        public string ds_bairro { get; set; }
        public string ds_cidade { get; set; }
        public string ds_uf { get; set; }
        public string nr_dddTel { get; set; }
        public string nr_telefone { get; set; }
        public string nr_dddCel { get; set; }
        public string nr_celular { get; set; }
        public string nr_dddCom { get; set; }
        public string nr_comercial { get; set; }
        public string ds_usuConfirmacao { get; set; }

        public string ds_tipoEndereco { get; set; }
        public string id_Municipiosap { get; set; }


        public string ds_regime { get; set; }


        public string nr_inscricaoEstadual { get; set; }


        // public List<PedidoItem> Itens { get; set; }
        public List<Cliente> Clientes { get; set; }

        //public List<PedidoVeiculo> Veiculos { get; set; }
    }
}

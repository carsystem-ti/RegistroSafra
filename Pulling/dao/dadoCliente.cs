using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Pulling.dao
{
   public  class dadoCliente
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxSistema"] as ConnectionStringSettings;

        public DataTable getBuscaCR()
        {
            DataTable dt_Cliente = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("[webApi].[pro_getCR]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt_Cliente);
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return dt_Cliente;
        }
        public int set_Registro(int numerocliente, int id_parcela,string cd_barra)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("SGB.[Registro].[pro_setRegistroSafra]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoParcela", id_parcela);
                        cmd.Parameters.AddWithValue("@cd_barra", cd_barra);
                        cmd.Parameters.AddWithValue("@nr_cliente",numerocliente);
                      

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }
        public int set_Registro(int id_parcela,string ds_mensagem)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("SGB.[Registro].[pro_setRegistroSafra_LogErro]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoParcela", id_parcela);
                        cmd.Parameters.AddWithValue("@ds_mensagem", ds_mensagem);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }
        public int set_Erro(int id_parcela, string erro)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("SGB.[Registro].[pro_setErro]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoParcela", id_parcela);
                        cmd.Parameters.AddWithValue("@tipoSolicitacao", 1);
                        cmd.Parameters.AddWithValue("@p_descricaoErro", erro);
                         SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }
        public int set_Email(string documento ,string email)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("[Cliente].[pro_setEmail]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@numerodocumento", documento);
                        cmd.Parameters.AddWithValue("@ds_email", email);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo =  cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }

        public int set_Endereco(string documento, string ds_endereco,string nr_endereco, string ds_complemento,string ds_bairro,string ds_cidade,string ds_uf)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("[Cliente].[pro_setEndereco]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@numerodocumento", documento);
                        cmd.Parameters.AddWithValue("@ds_endereco", ds_endereco);
                        cmd.Parameters.AddWithValue("@nr_endereco", nr_endereco);
                        cmd.Parameters.AddWithValue("@ds_complemento", ds_complemento);
                        cmd.Parameters.AddWithValue("@ds_bairro", ds_bairro);
                        cmd.Parameters.AddWithValue("@ds_cidade", ds_cidade);
                        cmd.Parameters.AddWithValue("@dsuf", ds_uf);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }
        public int set_Telefone(string documento, string dddTelefone, string telefone)
        {
            int processo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();


                        SqlCommand cmd = new SqlCommand("[Cliente].[pro_setTelefone]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@numerodocumento", documento);
                        cmd.Parameters.AddWithValue("@nr_ddd", dddTelefone);
                        cmd.Parameters.AddWithValue("@nr_telefone", telefone);
                       SqlDataAdapter da = new SqlDataAdapter(cmd);
                        processo = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return processo;
        }
     
     
    }
}

using Frame.ServiceLayer.Modelos;
using Frame.ServiceLayer.Modelos.Projeto;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frame.ServiceLayer.Controllers
{
    public class CadastroProjetoControllers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Retorno InsereProjeto(CadastroProjeto projeto)
        {
            WS.ServiceLayer.ServiceLayer Service = new WS.ServiceLayer.ServiceLayer();
            Retorno _Retorno = new Retorno();

            try
            {
                #region Insere Projeto

                var Json = JsonConvert.SerializeObject(projeto, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                _Retorno = Service.Add("Projects", Json);

                #endregion
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

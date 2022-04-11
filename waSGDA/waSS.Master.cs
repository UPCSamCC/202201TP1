using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA
{
    public partial class waSS : MasterPage
    {
        private int CodigoUsuario = 0;
        private string PaginaPrincial = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CodigoUsuario = ValidarUsuario();

                if (CodigoUsuario <= 0)
                {
                    Response.Redirect("../Seguridad/Logueo.aspx");
                }              
            }
        }

        #region "Acción de Controles"

        #endregion
               
        #region "Métodos y Funciones locales"

        private int ValidarUsuario()
        {
            int CodigoUsuario = -1;

            if (Session["Usuario"] != null)
            {
                BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
                CodigoUsuario = DatosUsuario.iCodUsuario;
            }

            return CodigoUsuario;
        }

        public void MensajeSOL(string Logo, string Mensaje, string Tipo)
        {
            hfLogoMsj.Value = Logo;
            hfMensaje.Value = Mensaje;
            hfTipoMsj.Value = Tipo;
        }

        #endregion
    }
}
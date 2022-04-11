using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waSGDA.Base;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA.Seguridad
{
    public partial class SolicitudContrasena : System.Web.UI.Page
    {
        BLLUsuario Us = new BLLUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar_Formulario();
            }
        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {

        }
        

        private void Limpiar_Formulario()
        {
            txtUsuario.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }       
    }
}
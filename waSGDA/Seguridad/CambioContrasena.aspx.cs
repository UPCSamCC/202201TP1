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
    public partial class CambioContrasena : Page
    {
        BLLUsuario Us = new BLLUsuario();
        Util cU = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Limpiar_Formulario();
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar_Formulario()
        {
            txtContrasena01.Text = string.Empty;
            txtContrasena02.Text = string.Empty;
        }

    }
}
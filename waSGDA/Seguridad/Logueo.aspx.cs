using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waSGDA.Base;
using waSGDA.BLL;
using waSGDA.BE;

namespace waSGDA.Seguridad
{
    public partial class Logueo : System.Web.UI.Page
    {
        Util cU = new Util();
        BLLUsuario Us = new BLLUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Iniciar_Formulario();
                txtUsuario.Focus();
            }
        }

        protected void btnLogueo_Click(object sender, EventArgs e)
        {
            if (Validar_Form())
            {
                BEUsuario DatosUsuario = Us.ObtenerInfoUsuario(txtUsuario.Text.Trim(), txtContrasena.Text.Trim());

                if (DatosUsuario.iCodUsuario == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), UniqueID, "vNoti('Credenciales incorrectas','" + Constantes.cNotiPeligro + "');", true);
                }
                else
                {
                    Session["Usuario"] = DatosUsuario;
                    Response.Redirect("../Ds/Dashboard.aspx");
                }

            }
        }

        private void Iniciar_Formulario()
        {
            Session["Usuario"] = null;

            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private bool Validar_Form()
        {
            if (txtUsuario.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), UniqueID, "vNoti('Debe ingresar un usuario','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            if (txtContrasena.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), UniqueID, "vNoti('Debe ingresar una contraseña','" + Constantes.cNotiPeligro + "');", true);
                return false;
            }

            return true;
        }
    }
}
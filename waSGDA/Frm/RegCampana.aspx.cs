using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using waSGDA.Base;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA.Frm
{
    public partial class RegCampana : Page
    {
        Util cU = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConfigurarFrm("Registro");
                ValidarCodigo();
            }
        }

        private void ValidarCodigo()
        {
            if (Request.QueryString["iCC"] != null)
            {
                int iCodCampana = Convert.ToInt32(Request.QueryString["iCC"]);

                if (iCodCampana > 0)
                {
                    BLLCampana bllCa = new BLLCampana();
                    BECampana beCa = bllCa.ObtenerCampana(iCodCampana);

                    hfCodCampana.Value = iCodCampana.ToString();
                    imgCampana.ImageUrl = "../img/Camp/" + beCa.cImagen.Trim();
                    lblDatosCampana.Text = "Esta campaña se mantiene vigente del " + cU.FormatoFecha(beCa.dFechaInicioCampana.ToShortDateString(), "d/m/Y SH") +
                                           " al " + cU.FormatoFecha(beCa.dFechaFinCampana.ToShortDateString(), "d/m/Y SH");
                }
                else
                    Response.Redirect("../Ds/Dashboard.aspx");
            }
            else
                Response.Redirect("../Ds/Dashboard.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
            BLLCampana bllCa = new BLLCampana();
            string sFecha = cU.FormatoFecha(txtFecha.Text, "YMD SH");

            BEResultado beR = bllCa.MantenimientoCampana("I", DatosUsuario.iCodUsuario, Convert.ToInt32(hfCodCampana.Value), sFecha);

            if ((beR.Codigo == 1) && (beR.Descripcion.Trim() == "ok"))
            {
                ConfigurarFrm("Exito");
                RedirigirTiempo(5, "../Ds/Dashboard.aspx");
            }
        }

        private void ConfigurarFrm(string dvVisible)
        {
            dvRegistro.Visible = dvVisible == "Registro" ? true : false;
            dvExito.Visible = dvVisible == "Exito" ? true : false;
        }

        private void RedirigirTiempo(int iTiempo, string sURL)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = iTiempo.ToString() + ";url=" + sURL;
            Page.Controls.Add(meta);
        }
    }
}
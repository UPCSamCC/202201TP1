using System;
using System.Collections.Generic;
using System.Web.UI;
using waSGDA.Base;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA.Forms
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCampanas();
            }
        }

        private void CargarCampanas()
        {
            BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];

            BLLCampana _bllC = new BLLCampana();
            List<BECampana> lstDatosC = _bllC.ListarCampanas(DatosUsuario.cUbigeo, DatosUsuario.iEdad, DatosUsuario.cSexo);

            if (lstDatosC.Count > 0)
            {
                for (int i = 0; i < lstDatosC.Count; i++)
                {
                    olOpc.InnerHtml = olOpc.InnerHtml + "<li data-target='#carouselExampleIndicators' data-slide-to='" + i.ToString() + "'" + (i == 0 ? " class='active'" : "") + "></li>";

                    divImgSlider.InnerHtml = divImgSlider.InnerHtml + @"<div class='carousel-item" + (i == 0 ? " active" : "") + "'><img class='img-size' src='../img/Camp/" + lstDatosC[i].cImagen + "' alt='" + lstDatosC[i].vNombreCampana + " slide' /></div>";
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "setTimeout(function(){ ShowPopup(); }, 1000);", true);
            }
        }
    }
}
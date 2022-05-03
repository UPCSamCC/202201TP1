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
        Util cU = new Util();
        public int iCitasAsistidas = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCampanasUsuario();
                CargarPlanesAliUsuario();
            }
        }

        private void CargarCampanasUsuario()
        {
            BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
            BLLCampana _bllC = new BLLCampana();

            List<BECampana> lstDatosC = _bllC.ListarCampanasUsuario(DatosUsuario.iCodUsuario, DatosUsuario.cUbigeo, DatosUsuario.iEdad, DatosUsuario.cSexo);

            if (lstDatosC.Count > 0)
            {
                for (int i = 0; i < lstDatosC.Count; i++)
                {
                    olOpc.InnerHtml = olOpc.InnerHtml + "<li data-target='#carouselExampleIndicators' data-slide-to='" + i.ToString() + "'" + (i == 0 ? " class='active'" : "") + "></li>";

                    divImgSlider.InnerHtml = divImgSlider.InnerHtml + @"<a href='../Frm/RegCampana.aspx?iCC=" + lstDatosC[i].iCodCampana + "'><div class='carousel-item" + (i == 0 ? " active" : "") + "'><img class='img-size' src='../img/Camp/" + lstDatosC[i].cImagen + "' alt='" + lstDatosC[i].vNombreCampana + " slide' /></div></a>";
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "setTimeout(function(){ ShowPopup(); }, 1000);", true);
            }

            List<BECitasCampanas> lstDatosCC = _bllC.ListarCitasCampanas(DatosUsuario.iCodUsuario);

            if (lstDatosCC.Count > 0)
            {
                iCitasAsistidas = lstDatosCC[0].iAsistidas;

                for (int i = 0; i < lstDatosCC.Count; i++)
                {
                    lstDatosCC[i].sTextoCita = "La cita a esta campaña está registrada para el " + cU.FormatoFecha(lstDatosCC[i].dFechaAsistencia.ToShortDateString(), "d/m/Y SH");
                }

                rpCitas.DataSource = lstDatosCC;
                rpCitas.DataBind();
            }
        }

        private void CargarPlanesAliUsuario()
        {
            BEUsuario DatosUsuario = (BEUsuario)Session["Usuario"];
            BLLPlanAli _bllP = new BLLPlanAli();

            List<BEPlanAli> lstDatosPA = _bllP.ListarPlanAliUsuario(0, DatosUsuario.iEdad);

            if (lstDatosPA.Count > 0)
            {
                rpPlanesA.DataSource = lstDatosPA;
                rpPlanesA.DataBind();
            }
        }
    }
}
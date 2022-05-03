using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waSGDA.Base;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA.Frm
{
    public partial class MntCita : Page
    {
        Util cU = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Listas();
                Inicializar_Frm();
                Cargar_Datos(1);               
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BEMedicoEspecialidad> lstME = (List<BEMedicoEspecialidad>)Session["lstME"];

            var lstMedicos = lstME.Where(c => c.iEspecialidad.ToString() == ddlEspecialidad.SelectedValue)
                                  .Select(c => new { c.iCodMedico, c.sNombreMedico })
                                  .Distinct().ToList(); ;

            ddlMedico.DataSource = lstMedicos;
            ddlMedico.DataTextField = "sNombreMedico";
            ddlMedico.DataValueField = "iCodMedico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("SELECCIONE", "0"));

            dvInfo.Visible = false;
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BEMedicoEspecialidad> lstME = (List<BEMedicoEspecialidad>)Session["lstME"];

            var lstMedicos = lstME.Where(c => c.iEspecialidad.ToString() == ddlEspecialidad.SelectedValue && c.iCodMedico.ToString() == ddlMedico.SelectedValue)
                                  .Select(c => new { c.iAnhosLaborales, c.iCantidadCitas }).Distinct().ToList();
            
            lblInfoCalificacion.Text = "Nuestro médico ha atendido cerca de <b>" + lstMedicos[0].iCantidadCitas.ToString() +
                                       "</b> pacientes en los más de <b>" + lstMedicos[0].iAnhosLaborales.ToString() + "</b> años que trabaja con nosotros";

            dvInfo.Visible = true;
        }

        private void Cargar_Listas()
        {
            BLLCita _obj = new BLLCita();

            List<BEMedicoEspecialidad> lstME = _obj.ListarMedicosEspecialidad();
            Session["lstME"] = lstME;

            var lstEspecialidad = lstME.Select(m => new { m.iEspecialidad, m.sNombreEspecialidad }).Distinct().ToList();

            ddlEspecialidad.DataSource = lstEspecialidad;
            ddlEspecialidad.DataTextField = "sNombreEspecialidad";
            ddlEspecialidad.DataValueField = "iEspecialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("SELEECIONE", "0"));
        }

        protected void btnNuevaCita_Click(object sender, EventArgs e)
        {
            Limpiar_Frm();
            hdfAccionCM.Value = "I";
            hdfCodigoCM.Value = "0";
            Activar_Tab(2);
        }

        protected void btnGrabarCita_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarCita_Click(object sender, EventArgs e)
        {
            Activar_Tab(1);
            hdfAccionCM.Value = string.Empty;
            Limpiar_Frm();
        }

        private void Inicializar_Frm()
        {
            Activar_Tab(1);
            dvInfo.Visible = false;
        }

        private void Cargar_Datos(int NroPagina)
        {
            string RegistroInicial = "";
            string RegistroFinal = "";
            int TotalRegistros = 0;
            BEUsuario _BEUsuario = (BEUsuario)Session["Usuario"];
            BLLCita objC = new BLLCita();

            List<BEPaginado> _lstPaginado = new List<BEPaginado>();
            List<BECita> lstCM = objC.ListarCitas(_BEUsuario.iCodUsuario, NroPagina, 8);

            if (lstCM.Count == 0)
            {
                lblRegistros.Text = "No se encontraron resultados a mostrar";

                rpCitas.DataSource = null;
                rpPaginado.DataSource = null;
            }
            else
            {
                RegistroInicial = lstCM.Min(t => t.NumeroFila).ToString();
                RegistroFinal = lstCM.Max(t => t.NumeroFila).ToString();
                TotalRegistros = lstCM.ElementAt(0).TotalRegistros;

                lblRegistros.Text = "Mostrando del " + RegistroInicial + " al " + RegistroFinal + " de " + TotalRegistros + " registros totales";

                rpCitas.DataSource = lstCM;

                // Creación de paginado
                _lstPaginado = cU.ObtenerPaginado(TotalRegistros, 8, NroPagina);

                rpPaginado.DataSource = _lstPaginado;                
            }
            
            rpCitas.DataBind();
            rpPaginado.DataBind();
        }

        private void Activar_Tab(int NroTab)
        {
            switch (NroTab)
            {
                case 1:
                    Tab01_FD.Attributes.Add("class", Tab01_FD.Attributes["class"].ToString().Replace("disabled", "active text-info"));
                    Tab02_FD.Attributes.Add("class", Tab02_FD.Attributes["class"].ToString().Replace("active text-info", "disabled"));

                    Contenido01_CM.Attributes.Add("class", Contenido01_CM.Attributes["class"].ToString().Replace("AuxSGDA", "show active"));
                    Contenido02_CM.Attributes.Add("class", Contenido02_CM.Attributes["class"].ToString().Replace("show active", "AuxSGDA"));

                    btnNuevaCita.Visible = true;
                    btnGrabarCita.Visible = false;
                    btnCancelarCita.Visible = false;

                    break;
                case 2:
                    Tab01_FD.Attributes.Add("class", Tab01_FD.Attributes["class"].ToString().Replace("active text-info", "disabled"));
                    Tab02_FD.Attributes.Add("class", Tab02_FD.Attributes["class"].ToString().Replace("disabled", "active text-info"));

                    Contenido01_CM.Attributes.Add("class", Contenido01_CM.Attributes["class"].ToString().Replace("show active", "AuxSGDA"));
                    Contenido02_CM.Attributes.Add("class", Contenido02_CM.Attributes["class"].ToString().Replace("AuxSGDA", "show active"));

                    btnNuevaCita.Visible = false;
                    btnGrabarCita.Visible = true;
                    btnCancelarCita.Visible = true;

                    break;
                default:
                    break;
            }
        }

        private void Limpiar_Frm()
        {
            hdfCodigoCM.Value = string.Empty;

            txtFecha.Text = string.Empty;
            ddlSucursal.SelectedValue = "0";
            ddlEspecialidad.SelectedValue = "0";
            ddlEspecialidad_SelectedIndexChanged(null, null);
            lblInfoCalificacion.Text = string.Empty;
            dvInfo.Visible = false;
            txtMotivo.Text = string.Empty;
        }

        protected void rpPaginado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Pag":
                    Cargar_Datos(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }
    }
}
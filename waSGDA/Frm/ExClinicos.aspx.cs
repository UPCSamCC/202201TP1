using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waSGDA.Base;
using waSGDA.BE;
using waSGDA.BLL;

namespace waSGDA.Frm
{
    public partial class ExClinicos : Page
    {
        Util cU = new Util();
        Mail.Util eU = new Mail.Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar_Listas();
                Inicializar_Frm();
                Cargar_Datos(1);
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            BEUsuario _BEUsuario = (BEUsuario)Session["Usuario"];
            BLLDiagnostico objC = new BLLDiagnostico();
            List<BEDiagnostico> lstEM = objC.ListarDiagnosticos(_BEUsuario.iCodUsuario, 0, 0, 0);

            string NombreGenerado = ExportarExcel(lstEM);
            string[] resultado = NombreGenerado.Split(':');

            if (resultado[0] != "0")
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "AbrirDescarga", string.Format("window.open('../Frm/DescargarExcel.aspx?Fileid={0}');", NombreGenerado), true);
        }

        private string ExportarExcel(List<BEDiagnostico> lstEM)
        {
            string PrefijoArchivo = "ExamenesClinicos_";
            var Workbook = new XLWorkbook();
            string ruta = Server.MapPath("../Frm/temp/" + PrefijoArchivo + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");

            // Creación de columnas
            string[] columnasEC = { "Codigo", "Descripcion", "Tipo", "Fecha", "Medico", "Especialidad", "Resultado" };

            var worksheetOC = Workbook.Worksheets.Add("Examenes");

            // Encabezado
            int nrofilOC = 1;
            int nrocolOC = 1;

            foreach (string col in columnasEC)
            {
                worksheetOC.Cell(nrofilOC, nrocolOC).Value = col;
                nrocolOC++;
            }

            // Datos del Reporte
            nrofilOC = nrofilOC + 1;

            foreach (BEDiagnostico dato in lstEM)
            {
                worksheetOC.Cell(nrofilOC, 1).Value = dato.iCodMedico;
                worksheetOC.Cell(nrofilOC, 2).Value = dato.vDescrDiagnostico;
                worksheetOC.Cell(nrofilOC, 3).Value = dato.iTipoDiagnostico;
                worksheetOC.Cell(nrofilOC, 4).Value = dato.cFechaDiagnostico;
                worksheetOC.Cell(nrofilOC, 5).Value = dato.vNombreMedico;
                worksheetOC.Cell(nrofilOC, 6).Value = dato.vNombreEspecialidad;
                worksheetOC.Cell(nrofilOC, 7).Value = "http://localhost:19299/doc/" + dato.vResultado;

                nrofilOC++;
            }

            // Estilos
            var RangoEncabezados = worksheetOC.Range(1, 1, 1, columnasEC.Length);

            RangoEncabezados.Style.Font.Bold = true;
            RangoEncabezados.Style.Fill.BackgroundColor = XLColor.LightBlue;

            RangoEncabezados.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            RangoEncabezados.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            RangoEncabezados.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            RangoEncabezados.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            RangoEncabezados.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            RangoEncabezados.Style.Border.DiagonalBorder = XLBorderStyleValues.Thin;

            RangoEncabezados.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheetOC.SheetView.FreezeRows(1);

            Workbook.SaveAs(ruta);

            return PrefijoArchivo + DateTime.Now.ToString("yyyyMMdd");
        }

        private void Cargar_Listas()
        {
            BLLCita _obj = new BLLCita();

            BEUsuario _BEUsuario = (BEUsuario)Session["Usuario"];
            List<BECita> lstCitas = _obj.ListarCitas(_BEUsuario.iCodUsuario, 0, 0);

            var lstCitasFormato = lstCitas.Select(m => new { m.iCodCita, m.vFormatoDDL }).Distinct().ToList();

            ddlCitas.DataSource = lstCitasFormato;
            ddlCitas.DataTextField = "vFormatoDDL";
            ddlCitas.DataValueField = "iCodCita";
            ddlCitas.DataBind();
            ddlCitas.Items.Insert(0, new ListItem("TODAS", "0"));
        }

        private void Inicializar_Frm()
        {
            if (Request.QueryString["iCC"] != null)
                ddlCitas.SelectedValue = Request.QueryString["iCC"]; 
            else
                ddlCitas.SelectedValue = "0";
        }

        private void Cargar_Datos(int NroPagina)
        {
            string RegistroInicial = "";
            string RegistroFinal = "";
            int TotalRegistros = 0;
            int iCodCita = Convert.ToInt32(ddlCitas.SelectedValue);

            BEUsuario _BEUsuario = (BEUsuario)Session["Usuario"];
            BLLDiagnostico objC = new BLLDiagnostico();

            List<BEPaginado> _lstPaginado = new List<BEPaginado>();
            List<BEDiagnostico> lstEM = objC.ListarDiagnosticos(_BEUsuario.iCodUsuario, iCodCita, NroPagina, 8);

            if (lstEM.Count == 0)
            {
                lblRegistros.Text = "No se encontraron resultados a mostrar";

                rpExMedicos.DataSource = null;
                rpPaginado.DataSource = null;
            }
            else
            {
                RegistroInicial = lstEM.Min(t => t.NumeroFila).ToString();
                RegistroFinal = lstEM.Max(t => t.NumeroFila).ToString();
                TotalRegistros = lstEM.ElementAt(0).TotalRegistros;

                lblRegistros.Text = "Mostrando del " + RegistroInicial + " al " + RegistroFinal + " de " + TotalRegistros + " registros totales";

                rpExMedicos.DataSource = lstEM;

                // Creación de paginado
                _lstPaginado = cU.ObtenerPaginado(TotalRegistros, 8, NroPagina);

                rpPaginado.DataSource = _lstPaginado;
            }

            rpExMedicos.DataBind();
            rpPaginado.DataBind();
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

        protected void ddlCitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos(1);
        }

        protected void btnEnviarMail_Click(object sender, ImageClickEventArgs e)
        {
            BEUsuario _BEUsuario = (BEUsuario)Session["Usuario"];

            // Obtener destinatario
            string CorreoDestino = _BEUsuario.vCorreo;

            // Armar correo
            StringBuilder body = new StringBuilder();

            body.AppendLine("Estimado(a) paciente " + _BEUsuario.vApePaterno.Trim() + "," + "<br>");
            body.AppendLine("<br>");
            body.AppendLine("Se detalla el resultado de su examen médico:" + "<br>");
            body.AppendLine("<ul>");
            body.AppendLine("<li> Fecha:" + "-" + "</li>");
            body.AppendLine("<li> Especialidad:" + "-" + "</li>");            
            body.AppendLine("<li> Médico:" + "-" + "</li>");
            body.AppendLine("<li> Tipo:" + "-" + "</li>");
            body.AppendLine("<li> Diagnostico:" + "-" + "</li>");
            body.AppendLine("</ul>");
            body.AppendLine("<br>");
            body.AppendLine("Adjunto al presente correo le enviamos los resultados");

            // Obtener adjunto
            string docAux = MapPath("../doc/PDFPrueba.pdf");

            int rptaMsj = eU.Enviar("resultados@essalud.gob.pe", "ESSALUD", CorreoDestino, "Examen médico 000", body, docAux);

            if (rptaMsj == 1)
            {
                divMsj.Attributes.Add("class", cU.claseMsj("success"));
                divMsj.InnerHtml = "Su mensaje ha sido enviado con éxito";
            }
            else
            {
                divMsj.Attributes.Add("class", cU.claseMsj("danger"));
                divMsj.InnerHtml = "Se presentaron problemas para el envío del mensaje, intentar nuevamente";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waSGDA.Frm
{
    public partial class DescargarExcel : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Fileid"] != null)
                {
                    string NombreArchivo = Request.QueryString["Fileid"].ToString();

                    System.IO.FileStream fs = null;
                    fs = System.IO.File.Open(Server.MapPath("temp/" + NombreArchivo + ".xlsx"), System.IO.FileMode.Open);
                    byte[] txtbyte = new byte[fs.Length];
                    fs.Read(txtbyte, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-disposition", "attachment; filename=" + NombreArchivo + ".xlsx");
                    Response.BinaryWrite(txtbyte);
                    Response.End();

                    BorrarTodosArchivos("temp");
                }
            }
        }

        private void BorrarTodosArchivos(string carpeta)
        {
            if (System.IO.Directory.Exists(Server.MapPath(carpeta)))
            {
                string[] ArchivosExistentes = System.IO.Directory.GetFiles(Server.MapPath(carpeta + "/"));
                foreach (string archivo in ArchivosExistentes)
                {
                    System.IO.File.Delete(archivo);
                }
            }
        }
    }
}
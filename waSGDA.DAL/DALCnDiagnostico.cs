using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;

namespace waSGDA.DAL
{
    public class DALCnDiagnostico
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListarDiagnosticos = "PRC_LISTAR_DIAGNOSTICOS";

        #endregion

        public List<BEDiagnostico> ListarDiagnosticos(int iCodPaciente, int iCodCita, int iNroPagina, int iNroFilas)
        {
            List<BEDiagnostico> lstDatos = new List<BEDiagnostico>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarDiagnosticos, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodPaciente", SqlDbType.Int).Value = iCodPaciente;
                cmd.Parameters.Add("@iCodCita", SqlDbType.Int).Value = iCodCita;
                cmd.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = iNroPagina;
                cmd.Parameters.Add("@NumeroFilas", SqlDbType.Int).Value = iNroFilas;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BEDiagnostico _objE = new BEDiagnostico();

                        _objE.NumeroFila = Convert.ToInt32(Result["NumeroFila"]);
                        _objE.iCodDiagnostico = Convert.ToInt32(Result["iCodDiagnostico"]);
                        _objE.vDescrDiagnostico = Result["vDescrDiagnostico"].ToString();
                        _objE.iTipoDiagnostico = Result["iTipoDiagnostico"].ToString();
                        _objE.cFechaDiagnostico = Result["cFechaDiagnostico"].ToString();
                        _objE.iCodMedico = Convert.ToInt32(Result["iCodMedico"]);
                        _objE.vNombreMedico = Result["vNombreMedico"].ToString();
                        _objE.iEspecialidad = Convert.ToInt32(Result["iEspecialidad"]);
                        _objE.vNombreEspecialidad = Result["vNombre"].ToString();
                        _objE.vResultado = Result["vResultado"].ToString().Trim();
                        _objE.TotalRegistros = Convert.ToInt32(Result["TotalRegistros"]);

                        lstDatos.Add(_objE);
                    }

                    Result.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return lstDatos;
        }
    }
}

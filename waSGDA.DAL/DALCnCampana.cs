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
    public class DALCnCampana
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListarCampanas = "PRC_OBTENER_CAMPANA";

        #endregion

        public List<BECampana> ListarCampanas(string cUbigeo, int iEdad, string cSexo)
        {
            List<BECampana> lstDatos = new List<BECampana>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarCampanas, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@cDepartamento", SqlDbType.Char).Value = cUbigeo.Substring(0,2) + "0000";
                cmd.Parameters.Add("@cProvincia", SqlDbType.Char).Value = cUbigeo.Substring(0, 4) + "00";
                cmd.Parameters.Add("@cDistrito", SqlDbType.Char).Value = cUbigeo;
                cmd.Parameters.Add("@iEdad", SqlDbType.Int).Value = iEdad;
                cmd.Parameters.Add("@cSexo", SqlDbType.Char).Value = cSexo;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BECampana _objE = new BECampana();

                        _objE.iCodCampana = Convert.ToInt32(Result["iCodCampana"]);
                        _objE.vNombreCampana = Result["vNombreCampana"].ToString();
                        _objE.vDescrCampana = Result["vDescrCampana"].ToString();
                        _objE.dFechaInicioCampana = Convert.ToDateTime(Result["dFechaInicioCampana"]);
                        _objE.dFechaFinCampana = Convert.ToDateTime(Result["dFechaFinCampana"]);
                        _objE.cImagen = Result["cImagen"].ToString();

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

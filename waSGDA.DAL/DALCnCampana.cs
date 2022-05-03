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

        private const string prcObtenerCampana = "PRC_OBTENER_CAMPANA";
        private const string prcListarCampanasUsuario = "PRC_LISTAR_CAMPANA_USUARIO";
        private const string prcListarCitasCampanas = "PRC_OBTENER_CITAS_CAMPANAS";
        private const string prcMantenimientoCampana = "PRC_MNT_CAMPANA";

        #endregion

        public BECampana ObtenerCampana(int iCodCampana)
        {
            BECampana _objE = new BECampana();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcObtenerCampana, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodCampana", SqlDbType.Int).Value = iCodCampana;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        _objE.iCodCampana = Convert.ToInt32(Result["iCodCampana"]);
                        _objE.vNombreCampana = Result["vNombreCampana"].ToString();
                        _objE.vDescrCampana = Result["vDescrCampana"].ToString();
                        _objE.dFechaInicioCampana = Convert.ToDateTime(Result["dFechaInicioCampana"]);
                        _objE.dFechaFinCampana = Convert.ToDateTime(Result["dFechaFinCampana"]);
                        _objE.cImagen = Result["cImagen"].ToString();
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

            return _objE;
        }

        public List<BECampana> ListarCampanasUsuario(int iCodUsuario, string cUbigeo, int iEdad, string cSexo)
        {
            List<BECampana> lstDatos = new List<BECampana>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarCampanasUsuario, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = iCodUsuario;
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

        public List<BECitasCampanas> ListarCitasCampanas(int iCodUsuario)
        {
            List<BECitasCampanas> lstDatos = new List<BECitasCampanas>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarCitasCampanas, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = iCodUsuario;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BECitasCampanas _objE = new BECitasCampanas();

                        _objE.iAsistidas = Convert.ToInt32(Result["iAsistidas"]);
                        _objE.vNombreCampana = Result["vNombreCampana"].ToString();
                        _objE.dFechaAsistencia = Convert.ToDateTime(Result["dFechaAsistencia"]);

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

        public BEResultado MantenimientoCampana(string sAccion, int iCodUsuario, int iCodCampana, string sFechaCita)
        {
            BEResultado _Resultado = new BEResultado();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcMantenimientoCampana, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                cmd.Parameters.Add("@sAccion", SqlDbType.Char).Value = sAccion;
                cmd.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = iCodUsuario;
                cmd.Parameters.Add("@iCodCampana", SqlDbType.Int).Value = iCodCampana;
                cmd.Parameters.Add("@dFechaCita", SqlDbType.Char).Value = sFechaCita;

                using (SqlDataReader Result = cmd.ExecuteReader())
                {
                    while (Result.Read())
                    {
                        _Resultado.Codigo = Convert.ToInt32(Result["CodigoRespuesta"]);
                        _Resultado.Descripcion = Result["DescripcionRespuesta"].ToString();
                    }

                    Result.Close();
                }
            }
            catch (Exception ex)
            {
                _Resultado.Codigo = 0;
                _Resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return _Resultado;
        }
    }
}

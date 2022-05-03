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
    public class DALCnPlanAli
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListarPlanAliUsuario = "PRC_LISTAR_PLANALI_USUARIO";

        #endregion
        
        public List<BEPlanAli> ListarPlanAliUsuario(int iCodPlan, int iEdad)
        {
            List<BEPlanAli> lstDatos = new List<BEPlanAli>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarPlanAliUsuario, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodPlan", SqlDbType.Int).Value = iCodPlan;
                cmd.Parameters.Add("@iEdad", SqlDbType.Int).Value = iEdad;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BEPlanAli _objE = new BEPlanAli();

                        _objE.iCodPlan = Convert.ToInt32(Result["iCodPlan"]);
                        _objE.vTitulo = Result["vTitulo"].ToString();
                        _objE.vResumen = Result["vResumen"].ToString();
                        _objE.tDetalle = Result["tDetalle"].ToString();
                        _objE.vImagen = Result["vImagen"].ToString();
                        _objE.cFechaPublicacion = Result["cFechaPublicacion"].ToString();

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

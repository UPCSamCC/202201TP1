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
    public class DALCnUsuario : DALBase
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcObtenerDatosUsuario = "PRC_OBTENER_USUARIO";

        #endregion

        public BEUsuario ObtenerInfoUsuario(string NombreUsuario, string Contrasena)
        {
            BEUsuario _BEUsuario = new BEUsuario();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcObtenerDatosUsuario, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@cNumeroDocumento", SqlDbType.Char).Value = NombreUsuario;
                cmd.Parameters.Add("@cContrasena", SqlDbType.Char).Value = Contrasena;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (Result.Read())
                    {
                        _BEUsuario.iCodUsuario = Convert.ToInt32(Result["iCodUsuario"]);
                        _BEUsuario.vNombres = Result["vNombres"].ToString().ToUpper();
                        _BEUsuario.vApePaterno = Result["vApePaterno"].ToString().ToUpper();
                        _BEUsuario.vApeMaterno = Result["vApeMaterno"].ToString().ToUpper();
                        _BEUsuario.cNumeroDocumento = Result["cNumeroDocumento"].ToString();
                        _BEUsuario.dFechaNacimiento = Convert.ToDateTime(Result["dFechaNacimiento"]);
                        _BEUsuario.iEdad = Convert.ToInt32(Result["iEdad"]);
                        _BEUsuario.cSexo = Result["cSexo"].ToString().ToUpper();
                        _BEUsuario.iCodDireccion = Convert.ToInt32(Result["iCodDireccion"]);
                        _BEUsuario.vDireccion = Result["vDireccion"].ToString().ToUpper();
                        _BEUsuario.cUbigeo = Result["cUbigeo"].ToString();
                        _BEUsuario.iCodPerfil = Convert.ToInt32(Result["iCodPerfil"]);
                        _BEUsuario.vPerfil = Result["vPerfil"].ToString().ToUpper();
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

            return _BEUsuario;
        }
    }
}

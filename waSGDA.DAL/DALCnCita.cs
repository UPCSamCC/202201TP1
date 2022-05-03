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
    public class DALCnCita
    {
        DALBase Db = new DALBase();

        #region Procedimientos

        private const string prcListarMedicosEspecialidad = "PRC_LISTAR_MEDICOS_ESPECIALIDAD";
        private const string prcListarCitas = "PRC_LISTAR_CITAS";

        #endregion

        public List<BEMedicoEspecialidad> ListarMedicosEspecialidad()
        {
            List<BEMedicoEspecialidad> lstDatos = new List<BEMedicoEspecialidad>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarMedicosEspecialidad, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BEMedicoEspecialidad _objE = new BEMedicoEspecialidad();

                        _objE.iCodMedico = Convert.ToInt32(Result["iCodMedico"]);
                        _objE.sNombreMedico = Result["sNombreMedico"].ToString();
                        _objE.iEspecialidad = Convert.ToInt32(Result["iEspecialidad"]);
                        _objE.sNombreEspecialidad = Result["sNombreEspecialidad"].ToString();
                        _objE.iAnhosLaborales = Convert.ToInt32(Result["iAnhosLaborales"]);
                        _objE.iCantidadCitas = Convert.ToInt32(Result["iCantidadCitas"]);

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

        public List<BECita> ListarCitas(int iCodPaciente, int iNroPagina, int iNroFilas)
        {
            List<BECita> lstDatos = new List<BECita>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(Db.CadenaCon());
                SqlCommand cmd = new SqlCommand(prcListarCitas, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.Parameters.Add("@iCodPaciente", SqlDbType.Int).Value = iCodPaciente;
                cmd.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = iNroPagina;
                cmd.Parameters.Add("@NumeroFilas", SqlDbType.Int).Value = iNroFilas;

                using (var Result = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (Result.Read())
                    {
                        BECita _objE = new BECita();

                        _objE.NumeroFila = Convert.ToInt32(Result["NumeroFila"]);
                        _objE.iCodCita = Convert.ToInt32(Result["iCodCita"]);
                        _objE.vDescrCita = Result["vDescrCita"].ToString();
                        _objE.vTipoCita = Result["vTipoCita"].ToString();
                        _objE.cFechaCita = Result["cFechaCita"].ToString();
                        _objE.vNombreMedico = Result["vNombreMedico"].ToString();
                        _objE.vEspecialidad = Result["vEspecialidad"].ToString();
                        _objE.cTieneReceta = Result["cTieneReceta"].ToString();
                        _objE.cEstiloReceta = _objE.cTieneReceta == "Si" ? "" : "hidden";
                        _objE.iCodReceta = Convert.ToInt32(Result["iCodReceta"]);
                        _objE.vDescrReceta = Result["vDescrReceta"].ToString();
                        _objE.cFechaInicio = Result["cFechaInicio"].ToString();
                        _objE.cFechaFin = Result["cFechaFin"].ToString();
                        _objE.cEstado = Result["cEstado"].ToString();
                        _objE.cEstiladoEstado = _objE.cEstado == "Pendiente" ? "text-danger" : "text-success";
                        _objE.vObservaciones = Result["vObservaciones"].ToString();
                        _objE.TotalRegistros = Convert.ToInt32(Result["TotalRegistros"]);

                        _objE.vFormatoDDL = "Cita #" + _objE.iCodCita.ToString() + " del " + _objE.cFechaCita;

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

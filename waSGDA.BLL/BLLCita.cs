using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;
using waSGDA.DAL;

namespace waSGDA.BLL
{
    public class BLLCita
    {
        public List<BEMedicoEspecialidad> ListarMedicosEspecialidad()
        {
            DALCnCita obj = new DALCnCita();
            return obj.ListarMedicosEspecialidad();
        }

        public List<BECita> ListarCitas(int iCodPaciente, int iNroPagina, int iNroFilas)
        {
            DALCnCita obj = new DALCnCita();
            return obj.ListarCitas(iCodPaciente, iNroPagina, iNroFilas);
        }
    }
}

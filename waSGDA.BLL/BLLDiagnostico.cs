using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;
using waSGDA.DAL;

namespace waSGDA.BLL
{
    public class BLLDiagnostico
    {
        public List<BEDiagnostico> ListarDiagnosticos(int iCodPaciente, int iCodCita, int iNroPagina, int iNroFilas)
        {
            DALCnDiagnostico obj = new DALCnDiagnostico();
            return obj.ListarDiagnosticos(iCodPaciente, iCodCita, iNroPagina, iNroFilas);
        }
    }
}

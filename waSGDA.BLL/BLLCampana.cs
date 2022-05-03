using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;
using waSGDA.DAL;

namespace waSGDA.BLL
{
    public class BLLCampana
    {
        public BECampana ObtenerCampana(int iCodCampana)
        {
            DALCnCampana obj = new DALCnCampana();
            return obj.ObtenerCampana(iCodCampana);
        }

        public List<BECampana> ListarCampanasUsuario(int iCodUsuario, string cUbigeo, int iEdad, string cSexo)
        {
            DALCnCampana obj = new DALCnCampana();
            return obj.ListarCampanasUsuario(iCodUsuario, cUbigeo, iEdad, cSexo);
        }

        public List<BECitasCampanas> ListarCitasCampanas(int iCodUsuario)
        {
            DALCnCampana obj = new DALCnCampana();
            return obj.ListarCitasCampanas(iCodUsuario);
        }

        public BEResultado MantenimientoCampana(string sAccion, int iCodUsuario, int iCodCampana, string sFechaCita)
        {
            DALCnCampana obj = new DALCnCampana();
            return obj.MantenimientoCampana(sAccion, iCodUsuario, iCodCampana, sFechaCita);
        }
    }
}

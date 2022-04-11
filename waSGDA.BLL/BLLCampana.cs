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
        public List<BECampana> ListarCampanas(string cUbigeo, int iEdad, string cSexo)
        {
            DALCnCampana obj = new DALCnCampana();
            return obj.ListarCampanas(cUbigeo, iEdad, cSexo);
        }
    }
}

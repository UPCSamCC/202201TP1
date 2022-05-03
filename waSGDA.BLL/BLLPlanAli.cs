using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;
using waSGDA.DAL;

namespace waSGDA.BLL
{
    public class BLLPlanAli
    {
        public List<BEPlanAli> ListarPlanAliUsuario(int iCodPlan, int iEdad)
        {
            DALCnPlanAli _obj = new DALCnPlanAli();
            return _obj.ListarPlanAliUsuario(iCodPlan, iEdad);
        }
    }
}

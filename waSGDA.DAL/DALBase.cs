using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waSGDA.DAL
{
    public class DALBase
    {
        public string CadenaCon()
        {
            return ConfigurationManager.ConnectionStrings["UPCConnection"].ConnectionString;
        }
    }
}

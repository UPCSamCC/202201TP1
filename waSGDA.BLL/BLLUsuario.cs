using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waSGDA.BE;
using waSGDA.DAL;

namespace waSGDA.BLL
{
    public class BLLUsuario
    {
        public BLLUsuario() { }

        public BEUsuario ObtenerInfoUsuario(string NombreUsuario, string Contrasena)
        {
            DALCnUsuario obj = new DALCnUsuario();
            return obj.ObtenerInfoUsuario(NombreUsuario, Contrasena);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waSGDA.BE
{
    public class BEUsuario
    {
        public int iCodUsuario { get; set; }
        public string vNombres { get; set; }
        public string vApePaterno { get; set; }
        public string vApeMaterno { get; set; }
        public string cNumeroDocumento { get; set; }
        public DateTime dFechaNacimiento { get; set; }
        public int iEdad { get; set; }
        public string cSexo { get; set; }
        public string vCorreo { get; set; }
        public int iCodDireccion { get; set; }
        public string vDireccion { get; set; }
        public string cUbigeo { get; set; }
        public int iCodPerfil { get; set; }
        public string vPerfil { get; set; }        
    }
}
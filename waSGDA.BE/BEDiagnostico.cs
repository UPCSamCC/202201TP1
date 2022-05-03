using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waSGDA.BE
{
    public class BEDiagnostico
    {
        public int NumeroFila { get; set; }
        public int iCodDiagnostico { get; set; }
        public string vDescrDiagnostico { get; set; }
        public string iTipoDiagnostico { get; set; }
        public string cFechaDiagnostico { get; set; }
        public int iCodMedico { get; set; }
        public string vNombreMedico { get; set; }
        public int iEspecialidad { get; set; }
        public string vNombreEspecialidad { get; set; }
        public string vResultado { get; set; }
        public int TotalRegistros { get; set; }
    }
}

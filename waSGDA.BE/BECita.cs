using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waSGDA.BE
{
    public class BECita
    {
        public int NumeroFila { get; set; }
        public int iCodCita { get; set; }
        public string vDescrCita { get; set; }
        public string vTipoCita { get; set; }
        public string cFechaCita { get; set; }
        public string vNombreMedico { get; set; }
        public string vEspecialidad { get; set; }
        public string cTieneReceta { get; set; }
        public string cEstiloReceta { get; set; }
        public int iCodReceta { get; set; }
        public string vDescrReceta { get; set; }
        public string cFechaInicio { get; set; }
        public string cFechaFin { get; set; }
        public string cEstado { get; set; }
        public string cEstiladoEstado { get; set; }
        public string vObservaciones { get; set; }
        public int TotalRegistros { get; set; }

        public string vFormatoDDL { get; set; }
    }
}

                     
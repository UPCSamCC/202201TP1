using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waSGDA.Base
{
    public class Constantes
    {
        #region Notificaciones

        public const string cObjNotificacion = "setTimeout(function(){ notiSOL(); }, 1000);";

        public const string cNotiPorDefecto = "default";
        public const string cNotiPeligro = "danger";
        public const string cNotiInformacion = "info";
        public const string cNotiExito = "success";
        public const string cNotiSecundario = "secondary";
        public const string cNotiAdvertencia = "warning";

        public const string cLogoPeligro = "danger-24.png";
        public const string cLogoExito = "success-24.png";
        public const string cLogoAdvertencia = "warning-24.png";
        public const string cLogoInformacion = "info-24.png";

        #endregion

        #region Seguridad

        public const string cContrasenaPorDefecto = "123456";

        #endregion
    }
}
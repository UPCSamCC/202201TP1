using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using waSGDA.BE;

namespace waSGDA.Base
{
    public class Util
    {
        public string Encriptar(string pTexto)
        {
            string Key = "<RSAKeyValue><Modulus>usUc+6vLgrWrQuJ9SP5UJDsdJagLNUKtCJOoacJdYEzGeksCB3avb68smCvW4IgUxPBYEidXSEA0HQ4h58kqdJ+VtsWmT2FFCBdAJnq22qeTbbVJswZseVqDWptFieVf1zFOQ8WNnnlMm5AbZNhnRYJ+XIHpOked6H7ABIIQ3tc=</Modulus><Exponent>AQAB</Exponent><P>9GBIJRPWQYa5wmwYXXyZSPMpCj0Ao72LLF2op03L1GtCzAcfWavM0QcfVLK+2LEPi2+oUTSA4SPoy2d6+jeYfw==</P><Q>w6dfjyKCcaQaEvtvra+GtLuWO80Bbq8PFtIev8UfZD160inNMIYomiifDcW5634e45re+iJGwVFu6TJz/gFNqQ==</Q><DP>l0ViY1E8N6OmKWuwSW5vlHCw3t2UH8ec9wGi/K1zlzIuTw25olBuoJXAFzXuXUR9UtrzXhEaFkOcPwz3Wxw/EQ==</DP><DQ>DCaK0rLL8w7D58Xhq6Go9fRoYhJbMmqAv2QRMMunJWyEAiVCbu8F+nznU82hvDQ66tulWVdjmYHbJ3RQq8ec8Q==</DQ><InverseQ>SIOiPZBxHdc+9GpDUmyijcXZ5/9Sr4o0XrhaUK1Itykdw+ztO3sWwHCi53PgZR+5n0OzkWZzzfjJuO3fGxdGMw==</InverseQ><D>djYcSg5KGMjzRLolofWXO/dOU28w6Nzyt+L9TTL/9tuhI/YlqqOsFnxBNW9J6YM34g5dL+BGlixMz7cKLrJcc62rdE4NF4zKeRjUCjN/EvZFD0LKhS1qXcFd3GXFRDj9CuraP0QKl82e5z7jR5jkh3aAcgrAVl/CdSH9SNSeJYE=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Key);
            byte[] Value = Encoding.UTF8.GetBytes(pTexto);
            byte[] EncryptValue = rsa.Encrypt(Value, false);

            return Convert.ToBase64String(EncryptValue);
        }

        public string Desencriptar(string pTexto)
        {
            string Key = "<RSAKeyValue><Modulus>usUc+6vLgrWrQuJ9SP5UJDsdJagLNUKtCJOoacJdYEzGeksCB3avb68smCvW4IgUxPBYEidXSEA0HQ4h58kqdJ+VtsWmT2FFCBdAJnq22qeTbbVJswZseVqDWptFieVf1zFOQ8WNnnlMm5AbZNhnRYJ+XIHpOked6H7ABIIQ3tc=</Modulus><Exponent>AQAB</Exponent><P>9GBIJRPWQYa5wmwYXXyZSPMpCj0Ao72LLF2op03L1GtCzAcfWavM0QcfVLK+2LEPi2+oUTSA4SPoy2d6+jeYfw==</P><Q>w6dfjyKCcaQaEvtvra+GtLuWO80Bbq8PFtIev8UfZD160inNMIYomiifDcW5634e45re+iJGwVFu6TJz/gFNqQ==</Q><DP>l0ViY1E8N6OmKWuwSW5vlHCw3t2UH8ec9wGi/K1zlzIuTw25olBuoJXAFzXuXUR9UtrzXhEaFkOcPwz3Wxw/EQ==</DP><DQ>DCaK0rLL8w7D58Xhq6Go9fRoYhJbMmqAv2QRMMunJWyEAiVCbu8F+nznU82hvDQ66tulWVdjmYHbJ3RQq8ec8Q==</DQ><InverseQ>SIOiPZBxHdc+9GpDUmyijcXZ5/9Sr4o0XrhaUK1Itykdw+ztO3sWwHCi53PgZR+5n0OzkWZzzfjJuO3fGxdGMw==</InverseQ><D>djYcSg5KGMjzRLolofWXO/dOU28w6Nzyt+L9TTL/9tuhI/YlqqOsFnxBNW9J6YM34g5dL+BGlixMz7cKLrJcc62rdE4NF4zKeRjUCjN/EvZFD0LKhS1qXcFd3GXFRDj9CuraP0QKl82e5z7jR5jkh3aAcgrAVl/CdSH9SNSeJYE=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Key);
            byte[] Value = Convert.FromBase64String(pTexto);
            byte[] DecryptValue = rsa.Decrypt(Value, false);

            return Encoding.UTF8.GetString(DecryptValue);
        }

        public DataTable EstablecerCol(DataTable dtDatos, string TipoDatos)
        {
            switch (TipoDatos)
            {
                case "E": // Hace referencia a Enteros
                    dtDatos.Columns.Add("Valor", typeof(int));
                    break;
                case "T": // Hace referencia a Textos
                    dtDatos.Columns.Add("Valor", typeof(string));
                    break;
                case "2E":
                    dtDatos.Columns.Add("Entero1", typeof(int));
                    dtDatos.Columns.Add("Entero2", typeof(int));
                    break;
                case "2T":
                    dtDatos.Columns.Add("Texto1", typeof(string));
                    dtDatos.Columns.Add("Texto2", typeof(string));
                    break;
                default:
                    break;
            }

            return dtDatos;
        }
               
        public string FormatoFecha(string FechaHora, string TipoFormato)
        {
            DateTime oDate = Convert.ToDateTime(FechaHora);
            string FechaFormato = "";

            switch (TipoFormato)
            {
                case "d/m/Y SH":
                    FechaFormato = oDate.Day.ToString("00") + "/" + oDate.Month.ToString("00") + "/" + oDate.Year.ToString();
                    break;
                case "d/m/Y":
                    FechaFormato = oDate.Day.ToString("00") + "/" + oDate.Month.ToString("00") + "/" + oDate.Year.ToString() + " " + oDate.Hour.ToString("00") + ":" + oDate.Minute.ToString("00");
                    break;
                case "YMD SH":
                    FechaFormato = oDate.Year.ToString() + oDate.Month.ToString("00") + oDate.Day.ToString("00");
                    break;
                case "YMD":
                    FechaFormato = oDate.Year.ToString() + oDate.Month.ToString("00") + oDate.Day.ToString("00") + " " + oDate.Hour.ToString("00") + ":" + oDate.Minute.ToString("00");
                    break;
                default:
                    break;
            }

            return FechaFormato;
        }

        public string NombreMes(int NumeroMes)
        {
            string sNombreMes = new DateTime(2020, NumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

            return sNombreMes;
        }

        public List<BEPaginado> ObtenerPaginado(int TotalRegistros, decimal NroFilasXpagina, int NroPagina)
        {
            int Aux = -2;
            List<BEPaginado> lstDatos = new List<BEPaginado>();
            BEPaginado SimPrimero = new BEPaginado();
            BEPaginado SimAnterior = new BEPaginado();
            BEPaginado SimSiguiente = new BEPaginado();
            BEPaginado SimUltimo = new BEPaginado();

            decimal dcPaginas = TotalRegistros / NroFilasXpagina;
            int PaginasTotal = Convert.ToInt32(Math.Ceiling(dcPaginas));

            if (NroPagina <= 0) { NroPagina = 1; }
            if (NroPagina >= PaginasTotal) { NroPagina = PaginasTotal; }

            SimPrimero.Url = "1";
            SimPrimero.Valor = "Primera";

            SimAnterior.Url = (NroPagina - 1).ToString();
            SimAnterior.Valor = "Anterior";

            if (NroPagina == 1)
            {
                SimPrimero.Estilo = "disabled";
                SimAnterior.Estilo = "disabled";
            }

            lstDatos.Add(SimPrimero);
            lstDatos.Add(SimAnterior);

            // -------------------------------------
            // Creacion de la paginación - INI
            // -------------------------------------

            for (int i = 1; i <= 5; i++)
            {
                BEPaginado Pagina = new BEPaginado();
                int iPagina = NroPagina + Aux;

                if (iPagina < 1 || iPagina > PaginasTotal) { Pagina.Estilo = "d-none"; }
                if (iPagina == NroPagina) { Pagina.Estilo = "active"; }

                Pagina.Url = iPagina.ToString();
                Pagina.Valor = iPagina.ToString();

                lstDatos.Add(Pagina);

                Aux = Aux + 1;
            }

            // -------------------------------------
            // Creacion de la paginación - FIN
            // -------------------------------------

            SimSiguiente.Url = (NroPagina + 1).ToString();
            SimSiguiente.Valor = "Siguiente";

            SimUltimo.Url = PaginasTotal.ToString();
            SimUltimo.Valor = "Última";

            if (NroPagina == PaginasTotal)
            {
                SimSiguiente.Estilo = "disabled";
                SimUltimo.Estilo = "disabled";
            }

            lstDatos.Add(SimSiguiente);
            lstDatos.Add(SimUltimo);

            return lstDatos;
        }

        public string claseMsj(string Etiqueta)
        {
            string Clase = "";

            switch (Etiqueta)
            {
                case "primary":
                    Clase = "alert alert-primary";
                    break;
                case "secondary":
                    Clase = "alert alert-secondary";
                    break;
                case "success":
                    Clase = "alert alert-success";
                    break;
                case "danger":
                    Clase = "alert alert-danger";
                    break;
                case "warning":
                    Clase = "alert alert-warning";
                    break;
                case "info":
                    Clase = "alert alert-info";
                    break;
                case "light":
                    Clase = "alert alert-light";
                    break;
                case "dark":
                    Clase = "alert alert-dark";
                    break;
                default:
                    break;
            }

            return Clase;
        }
    }
}
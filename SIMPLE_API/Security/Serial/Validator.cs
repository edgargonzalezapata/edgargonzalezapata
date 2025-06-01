using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLE_API.Security.Serial
{
    public class Validator
    {
        private string apiKey { get; set; }
        public string Message { get; set; }
        public bool IsValido { get; set; }
        public DateTime fechaValidez { get; set; }
        public int CantidadDTE { get; set; }
        public string rutContribuyente { get; set; }
        public string tipoDTE { get; set; }
        public int folio { get; set; }
        public string razonSocialEmisor { get; set; }
        public string rutReceptor { get; set; }

        public Validator(string apiKey, string rutContribuyente, string tipoDTE, int folio, string razonSocialEmisor, string rutReceptor)
        {
            this.apiKey = apiKey;
            this.rutContribuyente = rutContribuyente;
            this.tipoDTE = tipoDTE;
            this.folio = folio;
            this.razonSocialEmisor = razonSocialEmisor;
            this.rutReceptor = rutReceptor;
            Message = string.Empty;
            IsValido = false;
            ValidarAsync();
        }

        public bool ValidarAsync()
        {
            if (ValidaSintaxisYFecha())
            {
                IsValido = ValidaCantidadDocumentos();
                if (!IsValido)
                    Message = "Ha superado el límite permitido para su subscripción.";
            }
            return IsValido;
        }

        private bool ValidaSintaxisYFecha()
        {
            try
            {
                string[] seriales = apiKey.Split('-');
                string serial1 = seriales[2];
                string serial2 = seriales[0];
                string serial3 = seriales[4];
                string serial4 = seriales[1];
                string serial5 = seriales[3];

                string cantidadDTESerial = serial4.Substring(0, 1);

                switch (cantidadDTESerial)
                {
                    case "A": CantidadDTE = 100; break;
                    case "J": CantidadDTE = 250; break;
                    case "H": CantidadDTE = 1000; break;
                    case "8": CantidadDTE = 5000; break;
                    case "4": CantidadDTE = 10000; break;
                    case "F": CantidadDTE = 15000; break;
                    case "Q": CantidadDTE = 20000; break;
                    case "Z": CantidadDTE = 100000; break;
                    case "E": CantidadDTE = 45000; break;
                    default: CantidadDTE = 0; break;
                }
                string ticks = serial1 + serial2 + serial3 + serial4.Substring(1, 3);

                DateTime fecha = new DateTime(long.Parse(ticks.PadRight(18, '0')));
                if (fecha < DateTime.Now || CantidadDTE == 0)
                {
                    Message = "APIKEY CADUCADA. www.simple-api.cl";
                    return false;
                }
                else
                {
                    fechaValidez = fecha;
                    return true;
                }
            }
            catch
            {
                Message = "APIKEY INCORRECTA. www.simple-api.cl";
                return false;
            }            
        }

        private bool ValidaCantidadDocumentos()
        {           
            var cantidadTask = Element.GetCount(apiKey, rutContribuyente, tipoDTE, folio, razonSocialEmisor);
            var instance = Element.GetInstance(apiKey, rutContribuyente, tipoDTE, folio, razonSocialEmisor);
            return CantidadDTE >= cantidadTask && CantidadDTE >= instance.CantidadDTEOffline;
        }
    }
}

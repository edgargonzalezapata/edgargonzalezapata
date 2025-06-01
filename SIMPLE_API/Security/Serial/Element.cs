using ChileSystems.DTE.WS.EnvioBoleta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Console = System.Diagnostics.Debug;

namespace SIMPLE_API.Security.Serial
{
    public class Element
    {
        private static Element instance;

        HttpValidator httpValidator = new HttpValidator();
        public int CantidadDTE { get; set; }
        public int CantidadDTEOffline { get; set; }
        public string apiKey { get; set; }
        private string rutEmpresa { get; set; }
        private string tipoDTE { get; set; }
        private int folio { get; set; }
        private string razonSocial { get; set; }
        private Element()
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
            CantidadDTE = 0;
            CantidadDTEOffline = 0;
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            if (adapters.Any(x => x.OperationalStatus == OperationalStatus.Up))
            {
                try
                {
                    if (instance.CantidadDTEOffline > 0)
                    {
                        instance.UpdateUsoSinRed(instance.CantidadDTEOffline);
                        var nuevaCantidad = instance.GetCountWS();
                        if (nuevaCantidad != 1)
                        {
                            instance.CantidadDTE = nuevaCantidad;
                            instance.CantidadDTEOffline = 0;
                        }
                    }

                }
                catch { }

            }
        }

        public static int NotificarUso(string apiKey, string rutContribuyente, string tipoDTE, int folio, string razonSocialEmisor)
        {
            if (instance == null)
            {
                instance = new Element();
                instance.apiKey = apiKey;
                instance.rutEmpresa = rutContribuyente;
                instance.tipoDTE = tipoDTE;
                instance.folio = folio;
                instance.razonSocial = razonSocialEmisor;
               
            }
            instance.CantidadDTE = instance.NotificarUsoWS(apiKey, rutContribuyente, tipoDTE, folio, razonSocialEmisor);        
            return instance.CantidadDTE;
        }

        public static Element GetInstance(string apikey, string rutContribuyente, string tipoDTE, int folio, string razonSocialEmisor)
        {
            if (instance == null)
            {
                instance = new Element();
                instance.apiKey = apikey;
                instance.rutEmpresa = rutContribuyente;
                instance.tipoDTE = tipoDTE;
                instance.folio = folio;
                instance.razonSocial = razonSocialEmisor;
                instance.CantidadDTE = GetCount(apikey, rutContribuyente, tipoDTE, folio, razonSocialEmisor);
            }
            return instance;
        }

        public static int GetCount(string apikey, string rutContribuyente, string tipoDTE, int folio, string razonSocialEmisor)
        {
            if (instance == null)
            {
                instance = new Element();
                instance.apiKey = apikey;
                instance.rutEmpresa = rutContribuyente;
                instance.tipoDTE = tipoDTE;
                instance.folio = folio;
                instance.razonSocial = razonSocialEmisor;
                instance.CantidadDTE = instance.GetCountWS();
            }
            return instance.CantidadDTE;
        }

        private int NotificarUsoWS(string apiKey, string rutContribuyente, string tipoDTE, int folio, string razonSocialEmisor)
        {
            Debug.WriteLine("Notifico USO");
            dynamic resultEnvio = httpValidator.WSInsertUsage(new DetailUsage() { ApiKey = apiKey, RutEmpresa = rutContribuyente, Folio = folio, RazonSocial = razonSocialEmisor, TipoDTE = tipoDTE });
            if (resultEnvio.Status != "OK")
            {
                throw new Exception(resultEnvio.Mensaje);
            }
            dynamic objRespuesta = JsonConvert.DeserializeObject(resultEnvio.Mensaje);
            Debug.WriteLine($"CURRENT DTE:  {objRespuesta.current_dte}");
            return objRespuesta.current_dte;
        }

        private int UpdateUsoSinRed(int cantidad)
        {
            Debug.WriteLine("Notifico USO por RANGO");
            dynamic resultEnvio = httpValidator.WSInsertRangeUsage(new DetailUsage() { ApiKey = apiKey, RutEmpresa = instance.rutEmpresa, CantidadIngreso = cantidad, RazonSocial = instance.razonSocial, TipoDTE = instance.tipoDTE });
            if (resultEnvio.Status != "OK")
            {
                throw new Exception(resultEnvio.Mensaje);
            }
            dynamic objRespuesta = JsonConvert.DeserializeObject(resultEnvio.Mensaje);
            Debug.WriteLine($"CURRENT DTE:  {objRespuesta.current_dte}");
            return objRespuesta.current_dte;
        }

        private int GetCountWS()
        {
            try
            {

                dynamic resultCantidad = httpValidator.WSGetCantidad(apiKey).Result;
                //error += "llamé exitosamente a WSGetCantidad ";
                if (resultCantidad.Status == "NotFound")
                {
                    throw new Exception("Api key incorrecta. No es posible enviar");
                }
                if (resultCantidad.Status != "OK")
                {
                    return 0;
                }
                dynamic objRespuesta = JsonConvert.DeserializeObject(resultCantidad.Mensaje);
                return objRespuesta.current_dte;              
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPCIÓN AL OBTENER LA CANTIDAD: {0}", ex.Message + ex.StackTrace);
                return 1;
            }

        }
    }
}

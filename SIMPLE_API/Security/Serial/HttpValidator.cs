using ChileSystems.DTE.WS.EnvioBoleta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLE_API.Security.Serial
{
    public class HttpValidator
    {
        public async Task<dynamic> WSGetCantidad(string apiKey)
        {
            string baseUrl = $"https://simpleapibasedatos.azurewebsites.net/api/suscripcion/getenvios?apiKey={apiKey}";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("busti:o9imoyax")));
                using (var response = httpClient.GetAsync(baseUrl).Result)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return new { Status = response.StatusCode.ToString(), Mensaje = apiResponse };
                };
            }
        }

        public dynamic WSInsertRangeUsage(DetailUsage model)
        {
            string baseUrl = $"https://simpleapibasedatos.azurewebsites.net/api/suscripcion/insert_usage_range";
            var solicitudJson = JsonConvert.SerializeObject(model);
            string error = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl);

            string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("busti:o9imoyax"));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(solicitudJson);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return new { Status = httpResponse.StatusCode.ToString(), Mensaje = result };
            }
        }

        public dynamic WSInsertUsage(DetailUsage model)
        {
            string baseUrl = $"https://simpleapibasedatos.azurewebsites.net/api/suscripcion/insert_usage";
            //string baseUrl = $"https://localhost:44337/api/suscripcion/insert_usage";
            var solicitudJson = JsonConvert.SerializeObject(model);
            string error = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl);

            string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("busti:o9imoyax"));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(solicitudJson);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": httpResponse " + httpResponse.ToString() + Environment.NewLine);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": " + result + Environment.NewLine);
                return new { Status = httpResponse.StatusCode.ToString(), Mensaje = result };
            }
        }

        public dynamic WSInsertEnvio(DetailEnvio model)
        {
            string baseUrl = $"https://simpleapibasedatos.azurewebsites.net/api/suscripcion/insertdetail";

            //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": WSInsertDetail. model: " + model + Environment.NewLine);
            var solicitudJson = JsonConvert.SerializeObject(model);
            //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": " + solicitudJson + Environment.NewLine);
            string error = string.Empty;
            //string url = _appSettings.getOrquestador.url + "documentos/insert";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl);

            string encoded = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("busti:o9imoyax"));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(solicitudJson);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": httpResponse " + httpResponse.ToString() + Environment.NewLine);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //File.AppendAllText(DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now + ": " + result + Environment.NewLine);
                return new { Status = httpResponse.StatusCode.ToString(), Mensaje = result };
            }
        }

    }
}

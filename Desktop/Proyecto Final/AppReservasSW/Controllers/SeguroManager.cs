using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppReservasSW.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;


namespace AppReservasSW.Controllers
{
    public class SeguroManager
    {
        const string URL = "http://localhost:49220/api/seguro/";
        const string URLIngresar = "http://localhost:49220/api/seguro/ingresar/";

        HttpClient GetClient(string token)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
        public async Task<IEnumerable<Models.Seguro>> ObtenerSeguros(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL);
            return JsonConvert.DeserializeObject<IEnumerable<Models.Seguro>>(resultado);
        }

        public async Task<IEnumerable<Models.Seguro>> ObtenerSeguro(string token, string codigo)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL + codigo);
            return JsonConvert.DeserializeObject<IEnumerable<Models.Seguro>>(resultado);
        }
        public async Task<Models.Seguro> Ingresar(Models.Seguro seguro, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PostAsync(URLIngresar,
                new StringContent(JsonConvert.SerializeObject(seguro), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Models.Seguro>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Models.Seguro> Actualizar(Models.Seguro seguro, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(seguro), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Models.Seguro>(await response.Content.ReadAsStringAsync());
        }
        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.DeleteAsync(URL + codigo);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}

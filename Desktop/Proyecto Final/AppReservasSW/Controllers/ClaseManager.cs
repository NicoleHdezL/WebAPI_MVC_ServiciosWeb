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
    public class ClaseManager
    {
        const string URL = "http://localhost:49220/api/clase/";
        const string URLIngresar = "http://localhost:49220/api/clase/ingresar/";

        HttpClient GetClient(string token)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Models.Clase>> ObtenerClases(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<IEnumerable<Models.Clase>>(resultado);
        }

        public async Task<IEnumerable<Models.Clase>> ObtenerClase(string token, string codigo)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL + codigo);
            return JsonConvert.DeserializeObject<IEnumerable<Models.Clase>>(resultado);
        }
        public async Task<Models.Clase> Ingresar(Models.Clase clase, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PostAsync(URLIngresar,
                new StringContent(JsonConvert.SerializeObject(clase), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Models.Clase>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Models.Clase> Actualizar(Models.Clase clase, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(clase), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Models.Clase>(await response.Content.ReadAsStringAsync());
        }
        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.DeleteAsync(URL + codigo);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
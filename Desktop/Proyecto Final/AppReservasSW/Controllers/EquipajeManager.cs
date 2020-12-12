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
    public class EquipajeManager
    {
        const string URL = "http://localhost:49220/api/equipaje/";
        const string URLIngresar = "http://localhost:49220/api/equipaje/ingresar/";

        HttpClient GetClient(string token)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
        public async Task<IEnumerable<Equipaje>> ObtenerEquipajes(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<IEnumerable<Equipaje>>(resultado);
        }

        public async Task<IEnumerable<Equipaje>> ObtenerEquipaje(string token, string codigo)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL + codigo);
            return JsonConvert.DeserializeObject<IEnumerable<Equipaje>>(resultado);
        }
        public async Task<Equipaje> Ingresar(Equipaje equipaje, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PostAsync(URLIngresar,
                new StringContent(JsonConvert.SerializeObject(equipaje), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Equipaje>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Equipaje> Actualizar(Equipaje equipaje, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(equipaje), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Equipaje>(await response.Content.ReadAsStringAsync());
        }
        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.DeleteAsync(URL + codigo);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
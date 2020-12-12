using System.Collections.Generic;
using AppReservasSW.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace AppTicketsSW.Controllers
{
    public class TicketManager
    {
        const string URL = "http://localhost:49220/api/ticket/";
        const string URLIngresar = "http://localhost:49220/api/ticket/ingresar/";

        HttpClient GetClient(string token)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
        public async Task<IEnumerable<Ticket>> ObtenerTickets(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<IEnumerable<Ticket>>(resultado);
        }

        public async Task<IEnumerable<Ticket>> ObtenerTicket(string token, string codigo)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL + codigo);
            return JsonConvert.DeserializeObject<IEnumerable<Ticket>>(resultado);
        }
        public async Task<Ticket> Ingresar(Ticket ticket, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PostAsync(URLIngresar,
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Ticket>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Ticket> Actualizar(Ticket ticket, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
                "application/json"));
            return JsonConvert.DeserializeObject<Ticket>(await response.Content.ReadAsStringAsync());
        }
        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.DeleteAsync(URL + codigo);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
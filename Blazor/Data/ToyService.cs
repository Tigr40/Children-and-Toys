using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class ToyService : IToyService
    {
        private string uri = "http://localhost:5003";
        private readonly HttpClient client;

        public ToyService()
        {
            client = new HttpClient();
        }
        
        public async Task AddToyAsync(Toy toy)
        {
            string toyAsJson = JsonSerializer.Serialize(toy);
            HttpContent content = new StringContent(toyAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/toy", content);

        }

        public async Task<IList<Toy>> GetAllToysAsync()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            Task<string> stringAsync = client.GetStringAsync(uri + "/toy");
            string message = await stringAsync;
            List<Toy> toys = JsonSerializer.Deserialize<List<Toy>>(message, options);
            return toys;
        }

        public async Task DeleteToyAsync(int toyId)
        {
            await client.DeleteAsync($"{uri}/toy/{toyId}");
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class ChildService : IChildService
    {
        private string uri = "http://localhost:5003";
        private readonly HttpClient client;

        public ChildService()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Child>> GetChildrenAsync()
        {
            //You need these options for deserealizing the first time
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            Task<string> stringAsync = client.GetStringAsync(uri + "/child");
            string message = await stringAsync;
            List<Child> children = JsonSerializer.Deserialize<List<Child>>(message, options);
            return children;
        }
        
        public async Task AddChildAsync(Child child)
        {
            string childAsJson = JsonSerializer.Serialize(child);
            HttpContent content = new StringContent(childAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/child", content);
        }
    }
}
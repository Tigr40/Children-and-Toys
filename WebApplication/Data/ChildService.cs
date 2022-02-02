using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace WebApplication.Data
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
            HttpResponseMessage reponse = await client.GetAsync(uri + "/child");
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Error or whatever");
            }
            string message = await reponse.Content.ReadAsStringAsync();
            List<Child> children = JsonSerializer.Deserialize<List<Child>>(message);
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
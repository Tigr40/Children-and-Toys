using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IToyService
    {
        Task<Toy> AddToyAsync(Toy toy);
        Task<IList<Toy>> GetToysAsync();
        Task RemoveToyAsync(int toyId);
    }
}
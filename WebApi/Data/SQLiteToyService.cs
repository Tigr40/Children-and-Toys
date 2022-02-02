using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.Models;
using WebApi.Persistance;

namespace WebApi.Data
{
    public class SQLiteToyService : IToyService
    {
        private KinderGartenContext context;

        public SQLiteToyService(KinderGartenContext context)
        {
            this.context = context;
        }
        
        [HttpPost]
        public async Task<Toy> AddToyAsync(Toy toy)
        {
           // var child = await context.children.SingleOrDefaultAsync(c => c.Id == toy.Owner.Id);
            //toy.Owner = child;
            EntityEntry<Toy> newlyAdded = await context.toys.AddAsync(toy);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        [HttpGet]
        public async Task<IList<Toy>> GetToysAsync()
        {
            return await context.toys.ToListAsync();
        }

        [HttpDelete]
        public async Task RemoveToyAsync(int toyId)
        {
            Toy toDelete = await context.toys.FirstOrDefaultAsync(t => t.Id == toyId);
            if (toDelete != null)
            {
                context.toys.Remove(toDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
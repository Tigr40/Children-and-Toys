using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.Models;
using WebApi.Persistance;

namespace WebApi.Data
{
    public class SQLiteChildService : IChildService
    {
        private KinderGartenContext context;

        public SQLiteChildService(KinderGartenContext context)
        {
            this.context = context;
        }
        
        [HttpPost]
        public async Task<Child> AddChildAsync(Child child)
        {
            EntityEntry<Child> newlyAdded = await context.children.AddAsync(child);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        [HttpGet]
        public async Task<IList<Child>> GetChildrenAsync()
        {
            return await context.children.ToListAsync();
        }
    }
}
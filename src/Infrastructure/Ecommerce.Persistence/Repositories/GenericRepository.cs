global using Ecommerce.Application.Persistance.Contracts;
global using Ecommerce.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Set<T>().Remove(await GetAsync(id));
            await SaveChangesAsync();
        }

        public async Task<bool> Exisit(int id)
        {
            var entry = await GetAsync(id);
            return entry != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
         => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetAsync(int id)
         => await _context.Set<T>().FindAsync(id);
        

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}

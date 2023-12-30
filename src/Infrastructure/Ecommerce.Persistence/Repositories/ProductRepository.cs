using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsyncWithInclude()
         => await _context.Products.AsNoTracking().Include(x => x.Category).ToListAsync();

        public async Task<bool> IsCategoryExist(int categoryId)
        {
            var result = await _context.Categories.FindAsync(categoryId);
            return result != null;
        }
    }
}

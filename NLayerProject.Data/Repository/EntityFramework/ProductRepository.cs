using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.DataAccess.EntityFramework;
using NLayerProject.Data.Context;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repository.EntityFramework
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context):base(context)
        {
            
        }
      
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.ProductID == productId);
        }
    }
}

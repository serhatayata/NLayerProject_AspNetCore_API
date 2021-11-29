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
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(DbContext context):base(context)
        {

        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.CategoryID == categoryId);

        }
    }
}

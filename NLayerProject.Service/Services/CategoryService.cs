using NLayerProject.Core.DataAccess.EntityFramework;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IEfRepository<Category> repository) : base(unitOfWork,repository)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
           return await _unitOfWork.Category.GetWithProductsByIdAsync(categoryId);
        }
    }
}

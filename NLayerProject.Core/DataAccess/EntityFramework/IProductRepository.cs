using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.DataAccess.EntityFramework
{
    public interface IProductRepository:IEfRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

    }
}

using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}

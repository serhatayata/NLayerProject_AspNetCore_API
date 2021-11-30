using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Entity.DTOs
{
    public class CategoryWithProductDTO:CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}

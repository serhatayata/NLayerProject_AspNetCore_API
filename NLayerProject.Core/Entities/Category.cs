using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Entities
{
    internal class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public bool IsDeleted { get; set; }

    }
}

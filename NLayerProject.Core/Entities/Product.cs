using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Entities
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
    }
}

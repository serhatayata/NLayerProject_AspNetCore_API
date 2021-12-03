using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Entity.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "{0} is must")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} has to be more than 1")]
        public int Stock { get; set; } 
        [Range(1, double.MaxValue, ErrorMessage = "{0} has to be more than 1")]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}

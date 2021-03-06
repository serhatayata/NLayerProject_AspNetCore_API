using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Entity.DTOs
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="{0} cannot be empty.")]
        public string Name { get; set; }
    }
}

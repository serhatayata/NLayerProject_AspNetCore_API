using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerProject.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Category = new CategoryDTO();
        }
        public SelectList CategorySelectList { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}

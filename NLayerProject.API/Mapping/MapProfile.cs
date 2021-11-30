using AutoMapper;
using NLayerProject.Entity.DTOs;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Category, CategoryWithProductDTO>();
            CreateMap<CategoryWithProductDTO, Category > ();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            
        }
    }
}

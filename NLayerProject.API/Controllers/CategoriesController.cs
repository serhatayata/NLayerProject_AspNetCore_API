using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Services;
using NLayerProject.Entity.DTOs;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDTO>(category));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductId(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO entity)
        {
             var newCategory = await _categoryService.AddASync(_mapper.Map<Category>(entity));
             return Created(string.Empty,_mapper.Map<CategoryDTO>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO entity)
        {
            var updatedCategory = _categoryService.Update(_mapper.Map<Category>(entity));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(entity);
            return NoContent();
        }

       




    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Services;
using NLayerProject.Entity.DTOs;
using NLayerProject.Entity.Entities;
using NLayerProject.Web.ApiServices.Category;
using NLayerProject.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper,CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            await _categoryApiService.AddAsync(category);
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }
        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDTO));
            return RedirectToAction("Index", "Category");
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index", "Category");
        }





    }
}

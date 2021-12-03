using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper,CategoryApiService categoryApiService)
        {
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
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            await _categoryApiService.Update(categoryDTO);
            return RedirectToAction("Index", "Category");
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Delete(id);
            return RedirectToAction("Index", "Category");
        }

    }
}

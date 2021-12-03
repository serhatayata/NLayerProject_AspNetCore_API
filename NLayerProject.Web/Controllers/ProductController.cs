using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerProject.Core.Services;
using NLayerProject.Entity.DTOs;
using NLayerProject.Entity.Entities;
using NLayerProject.Web.Filters;
using NLayerProject.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly CategoryViewModel _categoryViewModel;
        public ProductController(IProductService productService,ICategoryService categoryService, IMapper mapper,CategoryViewModel categoryViewModel)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryViewModel = categoryViewModel;
        }
        public async Task<IActionResult> Index()
        {
            
            var products = await _productService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllAsync().Result;
            IEnumerable<CategoryDTO> categoryList = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            IEnumerable<CategoryDTO> AllCategories = categoryList.ToList();
            SelectList categorySelectList = new SelectList(categoryList,dataValueField:"CategoryID",dataTextField:"Name");
            _categoryViewModel.CategorySelectList = categorySelectList;
            ViewBag.selectList = _categoryViewModel;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            await _productService.AddASync(_mapper.Map<Product>(product));
            return RedirectToAction("Index","Product");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categories = _categoryService.GetAllAsync().Result;
            IEnumerable<CategoryDTO> categoryList = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            IEnumerable<CategoryDTO> AllCategories = categoryList.ToList();
            SelectList categorySelectList = new SelectList(categoryList, dataValueField: "CategoryID", dataTextField: "Name");
            _categoryViewModel.CategorySelectList = categorySelectList;
            ViewBag.selectList = _categoryViewModel;
            var product = await _productService.GetByIdAsync(id);
            var productValue = _mapper.Map<ProductDTO>(product);
            return View(productValue);
        }
        [HttpPost]
        public IActionResult Update(ProductDTO product)
        {
            var updatedProduct = _mapper.Map<Product>(product);
            _productService.Update(updatedProduct);
            return RedirectToAction("Index","Product");
        }
        [ServiceFilter(typeof(NotFoundFilterProduct))]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedProduct = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deletedProduct);
            return RedirectToAction("Index", "Product");
        }
    }
}

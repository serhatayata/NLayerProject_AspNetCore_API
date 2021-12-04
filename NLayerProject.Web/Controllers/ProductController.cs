using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerProject.Entity.DTOs;
using NLayerProject.Entity.Entities;
using NLayerProject.Web.ApiServices.Category;
using NLayerProject.Web.ApiServices.Product;
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
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        private readonly CategoryViewModel _categoryViewModel;
        public ProductController(ProductApiService productApiService,CategoryApiService categoryApiService, IMapper mapper,CategoryViewModel categoryViewModel)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
            _categoryViewModel = categoryViewModel;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryApiService.GetAllAsync().Result;
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
            await _productApiService.AddAsync(product);
            return RedirectToAction("Index","Product");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categories = _categoryApiService.GetAllAsync().Result;
            IEnumerable<CategoryDTO> categoryList = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            IEnumerable<CategoryDTO> AllCategories = categoryList.ToList();
            SelectList categorySelectList = new SelectList(categoryList, dataValueField: "CategoryID", dataTextField: "Name");
            _categoryViewModel.CategorySelectList = categorySelectList;
            ViewBag.selectList = _categoryViewModel;
            var product = await _productApiService.GetByIdAsync(id);
            var productValue = product;
            return View(productValue);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO product)
        {
            await _productApiService.Update(product);
            return RedirectToAction("Index","Product");
        }
        [ServiceFilter(typeof(NotFoundFilterProduct))]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Delete(id);
            return RedirectToAction("Index", "Product");
        }
    }
}

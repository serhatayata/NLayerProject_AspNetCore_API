using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Entity.DTOs;
using NLayerProject.Web.ApiServices.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;
        public NotFoundFilter(CategoryApiService categoryService)
        {
            _categoryApiService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryApiService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Errors.Add($"ID = {id} category cannot be found in the database");
                context.Result = new RedirectToActionResult("Error", "Home",errorDTO);
            }


        }






    }
}

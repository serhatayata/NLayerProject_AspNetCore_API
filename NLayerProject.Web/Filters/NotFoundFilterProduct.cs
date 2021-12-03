using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Entity.DTOs;
using NLayerProject.Web.ApiServices.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilterProduct:ActionFilterAttribute
    {
        private readonly ProductApiService _productApiService;
        public NotFoundFilterProduct(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productApiService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Errors.Add($"ID = {id} product cannot be found in the database");
                context.Result = new RedirectToActionResult("Error", "Home", errorDTO);
            }
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Core.Services;
using NLayerProject.Data.Context;
using NLayerProject.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;
        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryService.GetByIdAsync(id);
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
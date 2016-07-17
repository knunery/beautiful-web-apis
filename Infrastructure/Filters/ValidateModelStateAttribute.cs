using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

public class ValidateModelStateAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // SkipValidateModelState skips the ValidateModelState Filter
        if (context.Filters.Any(item => item is SkipValidateModelStateAttribute))
        {
            return;
        }

        if(!context.ModelState.IsValid)
            context.Result = new BadRequestObjectResult(context.ModelState);
    }
}
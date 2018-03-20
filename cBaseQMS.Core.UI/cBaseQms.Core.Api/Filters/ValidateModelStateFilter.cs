using cBaseQms.Core.Api.ValidationResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;


namespace cBaseQms.Core.Api.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
                actionContext.Result = new ValidationFailedResult(actionContext.ModelState);
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Wrappers
{
    public class ServiceResponseFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result && result.Value is ServiceResponse response)
            {
                if (!response.Status)
                {
                    context.Result = new BadRequestObjectResult(response);
                }
            }
        }
    }
}

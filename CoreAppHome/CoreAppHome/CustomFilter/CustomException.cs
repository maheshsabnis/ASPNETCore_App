using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoreAppHome.CustomFilter
{
    public class AppExceptionFilterArribute : IExceptionFilter
    {

        // Inject IModelMetadataProvider as ctor injected
        // so that for the current filter the instance of
        // ModelMetadata is available 
        private readonly IModelMetadataProvider modelMetadata;
        public AppExceptionFilterArribute(IModelMetadataProvider modelMetadata)
        {
            this.modelMetadata = modelMetadata;
        }
        public void OnException(ExceptionContext context)
        {
            // 1. Handle the exception and complete the process
            context.ExceptionHandled = true;
            // 2. Read rge Exception Object
            var errorMessage = context.Exception.Message;
            var viewResult = new ViewResult() { ViewName="CustomError"};

            // 3. Create a ViewDataDictionary for ViewResult
            viewResult.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);

            viewResult.ViewData["ControllerName"] = context.RouteData.Values["controller"].ToString();
            viewResult.ViewData["ActionName"] = context.RouteData.Values["action"].ToString();
            viewResult.ViewData["ErrorMessage"] = errorMessage;

            // set the result
            context.Result = viewResult;

        }
    }
}

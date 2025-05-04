using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace progectmvc.Filters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";

            ContentResult contentResult = new ContentResult();
            contentResult.Content = "some Exception"; 
            context.Result = viewResult;
        }
    }
}

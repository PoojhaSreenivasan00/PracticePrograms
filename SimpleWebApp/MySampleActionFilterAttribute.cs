using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleWebApp
{
    public class MySampleActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }
    }
}
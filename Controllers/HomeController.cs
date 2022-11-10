using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Services;

namespace MyFirstWebApp.Controllers
{
    //Creating instance for the Dependency injection.
    public class HomeController : Controller
    {
        private readonly ILoggerService _service;
        public HomeController(ILoggerService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            _service.Log("Hello World");
            return View();
        }
    }
}

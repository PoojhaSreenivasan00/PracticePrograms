using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger){
            _logger = logger;
            _logger.LogInformation("Hello from Home Controller");
        }
        
        /*public IActionResult Index()
        {
            _logger.LogInformation("Log message in the Index() method");

            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("Log message in the About() method");
            
            return View();
        }*/
    }
}

using CircleAndComments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CircleAndComments.Controllers
{
    public class CircleController : Controller
    {
        private readonly ILogger<CircleController> _logger;

        public CircleController(ILogger<CircleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
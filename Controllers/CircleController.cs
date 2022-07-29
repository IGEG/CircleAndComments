using CircleAndComments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CircleAndComments.Data;

namespace CircleAndComments.Controllers
{
    public class CircleController : Controller
    {
        private readonly ILogger<CircleController> _logger;
        private readonly IDataCircle dataCircle;

        public CircleController(ILogger<CircleController> logger, IDataCircle _dataCircle)
        {
            _logger = logger;
            this.dataCircle = _dataCircle;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var AllCirclesWithComments = await dataCircle.GetAllCirclesAsync();
            return View(AllCirclesWithComments);
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
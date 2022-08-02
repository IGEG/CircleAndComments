using CircleAndComments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CircleAndComments.Data;

namespace CircleAndComments.Controllers
{
    public class CircleController : Controller
    {
       
        private readonly IDataCircle dataCircle;
        public CircleController( IDataCircle _dataCircle)
        {
            this.dataCircle = _dataCircle;
        }
        
        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCirclesAndComments()
        { 
        return await dataCircle.GetAllCirclesAsync();  
        }

        [HttpDelete]
        public async Task DeleteCirclesAndComments(int Id)
        {
            await dataCircle.DeleteCircleAsync(Id);
             
        }

    }
}
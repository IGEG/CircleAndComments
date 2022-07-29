using CircleAndComments.Models;
using Microsoft.AspNetCore.Mvc;

namespace CircleAndComments.Data
{
    public interface IDataCircle
    {
        Task<JsonResult> GetAllCirclesAsync();
        Task<JsonResult> GetCircleAsync(int Id);
        Task<JsonResult> DeleteCircleAsync(int Id);

            
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CircleAndComments.Data
{
    public class DataCircle : IDataCircle
    {
        private readonly AppDbContext context;

        public DataCircle(AppDbContext _context)
        {
            context = _context;
        }
        public Task<JsonResult> DeleteCircleAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<JsonResult> GetAllCirclesAsync()
        {
            var Circle = await context.Circles.Include(p => p.CommentsInCircle).ToArrayAsync();
            return new JsonResult(Circle);
        }

        public Task<JsonResult> GetCircleAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

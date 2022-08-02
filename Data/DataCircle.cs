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
        public async Task DeleteCircleAsync(int Id)
        {

            var circle = await context.Circles.FirstOrDefaultAsync(c => c.CircleId == Id);
            if (circle != null)
            {
                context.Circles.Remove(circle);
            }
            await context.SaveChangesAsync();
        }

        public async Task<JsonResult> GetAllCirclesAsync()
        {
            var circle = await context.Circles.Include(p => p.CommentsInCircle.OrderBy(c=>c.CommentId)).ToArrayAsync();
            return new JsonResult(circle);
        }

        public Task<JsonResult> GetCircleAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

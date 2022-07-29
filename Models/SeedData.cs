using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CircleAndComments.Data;
namespace CircleAndComments.Models
{
    // класс для загрузки исходными данными in-memory DB 
    public class SeedData
    {
        public static  void EnsurePopulated(IApplicationBuilder app)
        { 
        AppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            if (!context.Circles.Any())
            {
                context.Circles.AddRange(
                    new Circle { CircleId = 1, PointX = 100, PointY = 100, Radius = 10, Color = "black" },
                    new Circle { CircleId = 2, PointX = 200, PointY = 200, Radius = 20, Color = "yellow" },
                    new Circle { CircleId = 3, PointX = 300, PointY = 300, Radius = 30, Color = "black" },
                    new Circle { CircleId = 4, PointX = 400, PointY = 400, Radius = 40, Color = "yellow" }

                    );
                context.SaveChanges();
            }
            if (!context.Comments.Any())
            {
                context.Comments.AddRange(
                    new Comment { CommentId = 1, Text = "Comment1", Color = "green", CircleId = 1 },
                    new Comment { CommentId = 2, Text = "Comment2", Color = "yellow", CircleId = 1 },
                    new Comment { CommentId = 3, Text = "Comment1", Color = "green", CircleId = 2 },
                    new Comment { CommentId = 4, Text = "Comment1", Color = "red", CircleId = 3 },
                    new Comment { CommentId = 5, Text = "Comment2", Color = "brown", CircleId = 3 },
                    new Comment { CommentId = 6, Text = "Comment3", Color = "blue", CircleId = 3 },
                    new Comment { CommentId = 7, Text = "Comment4", Color = "orange", CircleId = 3 },
                    new Comment { CommentId = 8, Text = "Comment1", Color = "red", CircleId = 4 },
                    new Comment { CommentId = 9, Text = "Comment2", Color = "orange", CircleId = 4 },
                    new Comment { CommentId = 10, Text = "Comment3", Color = "blue", CircleId = 4 }
                    );
                context.SaveChanges();
            }
        }

    }
}

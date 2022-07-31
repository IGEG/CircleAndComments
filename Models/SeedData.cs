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
                    new Circle { CircleId = 1, PointX = 100, PointY = 100, Radius = 10, Color = "yellow" },
                    new Circle { CircleId = 2, PointX = 300, PointY = 300, Radius = 30, Color = "blue" },
                    new Circle { CircleId = 3, PointX = 500, PointY = 300, Radius = 30, Color = "green" },
                    new Circle { CircleId = 4, PointX = 800, PointY = 100, Radius = 10, Color = "brown" }

                    );
                context.SaveChanges();
            }
            if (!context.Comments.Any())
            {
                context.Comments.AddRange(
                    new Comment { CommentId = 1, Text = "Comment1", Color = "white", CircleId = 1 },
                    new Comment { CommentId = 2, Text = "Comment2", Color = "yellow", CircleId = 1 },
                    new Comment { CommentId = 3, Text = "Comment1", Color = "white", CircleId = 2 },
                    new Comment { CommentId = 4, Text = "Comment1", Color = "grey", CircleId = 3 },
                    new Comment { CommentId = 5, Text = "Comment2", Color = "white", CircleId = 3 },
                    new Comment { CommentId = 6, Text = "Comment3", Color = "yellow", CircleId = 3 },
                    new Comment { CommentId = 7, Text = "Comment4", Color = "white", CircleId = 3 },
                    new Comment { CommentId = 8, Text = "Comment1", Color = "grey", CircleId = 4 },
                    new Comment { CommentId = 9, Text = "Comment2 looooooooong", Color = "white", CircleId = 4 },
                    new Comment { CommentId = 10, Text = "Comment3", Color = "grey", CircleId = 4 }
                    );
                context.SaveChanges();
            }
        }

    }
}

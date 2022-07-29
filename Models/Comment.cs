namespace CircleAndComments.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public string? Color { get; set; }

        public int CircleId { get; set; }
        public Circle? Circle { get; set; }
    }
}

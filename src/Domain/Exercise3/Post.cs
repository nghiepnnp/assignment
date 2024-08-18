namespace Domain.Exercise3
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}
namespace Domain.Exercise3
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Guid> FollowedUserIds { get; set; } = new List<Guid>();
    }
}
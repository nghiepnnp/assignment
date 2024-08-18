using Domain.Constants;
using System.Text.Json.Serialization;

namespace Domain.Exercise1
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;
        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;
        [JsonPropertyName("lastUpdatePwd")]
        public DateTime LastUpdatePwd { get; set; }
    }

    public class MockDataService
    {   
        private readonly Dictionary<int, User> _users;

        public MockDataService()
        {
            _users = new Dictionary<int, User>
            {
                { 1, new User { Id = 1, Email = "user1@vng.com.vn", Status = UserStatus.ACTIVE, LastUpdatePwd = DateTime.Now.AddMonths(-7) } },
                { 2, new User { Id = 2, Email = "user2@vng.com.vn", Status = UserStatus.ACTIVE, LastUpdatePwd = DateTime.Now.AddMonths(-5) } },
                { 3, new User { Id = 3, Email = "user3@vng.com.vn", Status = UserStatus.ACTIVE, LastUpdatePwd = DateTime.Now.AddMonths(-8) } },
            };
        }

        public List<User> GetUsers()
        {
            return [.. _users.Values];
        }

        public void UpdateUser(User user)
        {
            _users[user.Id] = user;
        }
    }
}

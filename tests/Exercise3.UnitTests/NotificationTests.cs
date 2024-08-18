using Application.Common.Interfaces;
using Application.Services;
using Domain.Exercise3;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise3.UnitTests
{
    public class NotificationTests
    {
        private readonly INotificationService _service;

        public NotificationTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INotificationService, NotificationService>()
                .BuildServiceProvider();

            _service = serviceProvider.GetService<INotificationService>()!;
        }

        [Fact]
        public void SubscriberShouldReceiveNotification_WhenFollowedUserPosts()
        {
            // Arrange
            var (user1, user2, user3) = CreateUsers();

            bool isReceived = false;

            _service.Subscribe(followerId: user2.Id, followeeId: user1.Id, post =>
            {
                if (post.UserId == user1.Id)
                {
                    isReceived = true;
                }
            });

            // Act
            _service.Publish(new Post
            {
                Id = Guid.NewGuid(),
                UserId = user1.Id,
                Content = "Go to sleep!",
                Timestamp = DateTime.UtcNow
            });

            // Assert
            Assert.True(isReceived, "User2 must receive a notification when User1 posts.");
        }

        [Fact]
        public void SubscriberShouldNotReceiveNotification_WhenNotFollowingUser()
        {
            // Arrange
            var (user1, user2, user3) = CreateUsers();

            bool isReceived = false;

            _service.Subscribe(followerId: user3.Id, followeeId: user1.Id, post =>
            {
                if (post.UserId == user1.Id)
                {
                    isReceived = true;
                }
            });

            // Act
            _service.Publish(new Post
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(), // Poster not User1
                Content = "This should not notify",
                Timestamp = DateTime.UtcNow
            });

            // Assert
            Assert.False(isReceived, "User3 does not receive notifications when it's not User1 posts.");
        }

        private (User, User, User) CreateUsers(string name1 = null!, string name2 = null!, string name3 = null!)
        {
            var user1 = new User { Id = Guid.NewGuid(), Name = "Nguyen Van A" };
            var user2 = new User { Id = Guid.NewGuid(), Name = "Tran Thi B" };
            var user3 = new User { Id = Guid.NewGuid(), Name = "Tran Van C" };

            return (user1, user2, user3);
        }
    }
}
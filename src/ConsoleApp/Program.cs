using Application.Common.Interfaces;
using Application.Services;
using Domain.Exercise3;
using Microsoft.Extensions.DependencyInjection;

// Configure DI
var serviceProvider = new ServiceCollection()
                .AddSingleton<INotificationService, NotificationService>()
                .AddSingleton<ISocialMediaService, SocialMediaService>()
                .BuildServiceProvider();

// Resolve services
var platform = serviceProvider.GetRequiredService<ISocialMediaService>();

// Create some users
var user1 = new User { Id = Guid.NewGuid(), Name = "Nguyen Van A" }; // Followee
var user2 = new User { Id = Guid.NewGuid(), Name = "Tran Thi B" };
var user3 = new User { Id = Guid.NewGuid(), Name = "Tran Van C" };

// User2 follows User1
platform.FollowUser(user2, user1);
//platform.FollowUser(user3, user1);

Console.WriteLine($"Followee: {user1.Name}");

while (true)
{
    Console.WriteLine("Enter the content for the post (or type 'exit' to quit):");
    string content = Console.ReadLine()!;

    if (content.ToLower() == "exit")
    {
        break;
    }

    // User1 creates a post with the input content
    platform.CreatePost(user1, content);
}
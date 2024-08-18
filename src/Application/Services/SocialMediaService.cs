using Application.Common.Interfaces;
using Domain.Exercise3;

namespace Application.Services
{
    /// <summary>
    /// SocialMediaService
    /// </summary>
    public class SocialMediaService : ISocialMediaService
    {
        /// <summary>
        /// Handles notifications.
        /// </summary>
        private readonly INotificationService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public SocialMediaService(INotificationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="user"></param>
        /// <param name="content"></param>
        public void CreatePost(User user, string content)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Content = content,
                Timestamp = DateTime.Now
            };

            _service.Publish(post);
        }

        /// <summary>
        /// Follow User
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="followee"></param>
        public void FollowUser(User follower, User followee)
        {
            if (!follower.FollowedUserIds.Contains(followee.Id))
            {
                //follower.FollowedUserIds.Add(followee.Id);

                _service.Subscribe(follower.Id, followee.Id, x =>
                {
                    Console.WriteLine($"> '{follower.Name}' received: [Content: '{x.Content}' - Author: '{followee.Name}']");
                });
            }
        }
    }
}

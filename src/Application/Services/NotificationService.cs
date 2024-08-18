using Application.Common.Interfaces;
using Domain.Exercise3;

namespace Application.Services
{
    /// <summary>
    /// Notification Service
    /// </summary>
    public class NotificationService : INotificationService
    {
        /// <summary>
        /// List subscription
        /// </summary>
        private readonly Dictionary<Guid, List<Action<Post>>> _subscriptions = [];

        /// <summary>
        /// Subscriber
        /// Each follower should receive a notification containing the post content and author information.
        /// </summary>
        /// <param name="followerId"></param>
        /// <param name="followeeId"></param>
        /// <param name="onPostPublished"></param>
        public void Subscribe(Guid followerId, Guid followeeId, Action<Post> onPostPublished)
        {
            if (!_subscriptions.ContainsKey(followeeId))
            {
                _subscriptions[followeeId] = new List<Action<Post>>();
            }

            _subscriptions[followeeId].Add(onPostPublished);
        }

        /// <summary>
        /// Publisher
        /// When a user creates a new post, it should be published to all followers.
        /// </summary>
        /// <param name="post"></param>
        public void Publish(Post post)
        {
            if (_subscriptions.ContainsKey(post.UserId))
            {
                foreach (var notify in _subscriptions[post.UserId])
                {
                    notify(post);
                }
            }
        }
    }
}
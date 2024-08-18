using Domain.Exercise3;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// INotificationService
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="followerId"></param>
        /// <param name="followeeId"></param>
        /// <param name="onPostPublished"></param>
        void Subscribe(Guid followerId, Guid followeeId, Action<Post> onPostPublished);

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="post"></param>
        void Publish(Post post);
    }
}

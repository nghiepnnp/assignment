using Domain.Exercise3;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// ISocialMediaService
    /// </summary>
    public interface ISocialMediaService
    {
        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="user"></param>
        /// <param name="content"></param>
        void CreatePost(User user, string content);

        /// <summary>
        /// Follow User
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="followee"></param>
        void FollowUser(User follower, User followee);
    }
}

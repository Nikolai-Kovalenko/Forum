using Forum.Models;
using System.Linq.Expressions;

namespace Forum.Repository.IRepository
{
    public interface ITopicCommentRepository : IRepository<TopicComment>
    {
        void Update(TopicComment obj, DateTime dateTime);

        void Delete(TopicComment obj, DateTime dateTime);
    }
}

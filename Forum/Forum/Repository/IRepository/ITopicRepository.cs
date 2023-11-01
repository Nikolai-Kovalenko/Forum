using Forum.Models;
using System.Linq.Expressions;

namespace Forum.Repository.IRepository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        void Update(Topic obj);

        void Delete(Topic obj, DateTime dateTime);
    }
}

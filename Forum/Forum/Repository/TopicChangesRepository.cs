using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;

namespace Forum.Repository
{
    public class TopicChangesRepository : Repository<TopicChanges>, ITopicChangesRepository
    {
        private readonly AppDbContext _db;

        public TopicChangesRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

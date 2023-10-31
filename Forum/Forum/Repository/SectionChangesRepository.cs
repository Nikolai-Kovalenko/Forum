using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;

namespace Forum.Repository
{
    public class SectionChangesRepository : Repository<SectionChanges>, ISectionChangesRepository
    {
        private readonly AppDbContext _db;

        public SectionChangesRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;

namespace Forum.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly AppDbContext _db;

        public SectionRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Section obj)
        {
            /*var objFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);*/
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;

            }
        }
    }
}

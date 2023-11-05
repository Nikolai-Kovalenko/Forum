using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.Repository
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        private readonly AppDbContext _db;

        public TopicRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Delete(Topic obj, DateTime dateTime)
        {
            obj.DeleteTime = dateTime;
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if(obj == WC.SectionType)
            {
                return _db.Sections.Where(i => i.DeleteTime == null).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return null;
        }
            

        public void Update(Topic obj)
        {
            /*var objFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);*/
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.LastChangeTime = obj.LastChangeTime;
                objFromDb.SectionId = obj.SectionId;
            }
        }
    }
}

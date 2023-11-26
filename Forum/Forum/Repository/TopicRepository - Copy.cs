using Forum.Data;
using Forum.Models;
using Forum.Models.Dto;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forum.Repository
{
    public class TopicCommentRepository : Repository<TopicComment>, ITopicCommentRepository
    {
        private readonly AppDbContext _db;

        public TopicCommentRepository(AppDbContext db) : base(db)
        {   
            _db = db;
        }

        public void Delete(TopicComment obj, DateTime dateTime)
        {
            obj.DeleteTime = dateTime;
        }         

        public void Update(TopicComment obj, DateTime dateTime)
        {
            /*var objFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);*/
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Content = obj.Content;
                objFromDb.EditTime = dateTime;
            }
        }
    }
}

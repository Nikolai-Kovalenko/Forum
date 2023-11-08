using Forum.Models;
using Forum.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Forum.Repository.IRepository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        void Update(TopicUpsertDTO obj, DateTime dateTime);

        void Delete(Topic obj, DateTime dateTime);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}

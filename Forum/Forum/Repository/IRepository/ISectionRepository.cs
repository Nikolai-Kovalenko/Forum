using Forum.Models;
using System.Linq.Expressions;

namespace Forum.Repository.IRepository
{
    public interface ISectionRepository : IRepository<Section>
    {
        void Update(Section obj);

        void Delete(Section obj);
    }
}

using Forum.Data;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class SectionController : Controller
    {
        public readonly AppDbContext _db;
        public readonly ISectionRepository _sectionRepo;

        public SectionController(AppDbContext db, ISectionRepository sectionRepo)
        {
            _db = db;
            _sectionRepo = sectionRepo;
        }

        public IActionResult Index()
        {
            var objList = _sectionRepo.GetAll();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

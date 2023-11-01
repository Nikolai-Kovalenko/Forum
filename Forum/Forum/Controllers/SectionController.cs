using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class SectionController : Controller
    {
        public readonly AppDbContext _db;
        public readonly ISectionRepository _sectionRepo;
        public readonly ISectionChangesRepository _sectionChangasRepo;

        public SectionController(AppDbContext db, ISectionRepository sectionRepo, 
            ISectionChangesRepository sectionChangasRepo)
        {
            _db = db;
            _sectionRepo = sectionRepo;
            _sectionChangasRepo = sectionChangasRepo;
        }

        public IActionResult Index()
        {
            var objList = _sectionRepo.GetAll(u => u.DeleteTime == null);
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Section obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreateTime = DateTime.Now;

                _sectionRepo.Add(obj);
                _sectionRepo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Update(int id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            var obj = _sectionRepo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Section obj)
        {
            if (ModelState.IsValid)
            {
                Section oldSection = _sectionRepo.Find(obj.Id);
                DateTime curentTime = DateTime.Now;
                if(oldSection.Name != obj.Name)
                {
                    SectionChanges sectionChanges = new()
                    {
                        SectionId = obj.Id,
                        Field = WC.Name,
                        FromValue = oldSection.Name,
                        ToValue = obj.Name,
                        ChangeTime = curentTime
                    };

                    _sectionChangasRepo.Add(sectionChanges);
                    obj.LastChangeTime = curentTime;
                }

                if (oldSection.Description != obj.Description)
                {
                    SectionChanges sectionChanges = new()
                    {
                        SectionId = obj.Id,
                        Field = WC.Description,
                        FromValue = oldSection.Description,
                        ToValue = obj.Description,
                        ChangeTime = curentTime
                    };

                    _sectionChangasRepo.Add(sectionChanges);
                    obj.LastChangeTime = curentTime;
                }
                _sectionChangasRepo.Save();

                _sectionRepo.Update(obj);
                _sectionRepo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sectionRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _sectionRepo.Find(id.GetValueOrDefault());
            DateTime curentTime = DateTime.Now;
            if(obj == null)
            {
                return NotFound();
            }

            SectionChanges sectionChanges = new()
            {
                SectionId = obj.Id,
                Field = WC.DeleteTime,
                FromValue = null,
                ToValue = curentTime.ToString(),
                ChangeTime = curentTime
            };

            _sectionChangasRepo.Add(sectionChanges);

            _sectionRepo.Delete(obj, curentTime);
            _sectionRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

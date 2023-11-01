using Forum.Data;
using Forum.Models;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        public readonly AppDbContext _db;
        public readonly ITopicRepository _topicRepo;
        public readonly ITopicChangesRepository _topicChangasRepo;

        public TopicController(AppDbContext db, ITopicRepository topicRepo,
            ITopicChangesRepository topicChangasRepo)
        {
            _db = db;
            _topicRepo = topicRepo;
            _topicChangasRepo = topicChangasRepo;
        }

        public IActionResult Index()
        {
            var objList = _topicRepo.GetAll(u => u.DeleteTime == null);
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Topic obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreateTime = DateTime.Now;

                _topicRepo.Add(obj);
                _topicRepo.Save();
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
            var obj = _topicRepo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Topic obj)
        {
            if (ModelState.IsValid)
            {
                var oldSection = _topicRepo.Find(obj.Id);
                DateTime curentTime = DateTime.Now;
                if (oldSection.Name != obj.Name)
                {
                    TopicChanges topicChanges = new()
                    {
                        TopicId = obj.Id,
                        Field = WC.Name,
                        FromValue = oldSection.Name,
                        ToValue = obj.Name,
                        ChangeTime = curentTime
                    };

                    _topicChangasRepo.Add(topicChanges);
                    obj.LastChangeTime = curentTime;
                }

                if (oldSection.Description != obj.Description)
                {
                    TopicChanges topicChanges = new()
                    {
                        TopicId = obj.Id,
                        Field = WC.Description,
                        FromValue = oldSection.Description,
                        ToValue = obj.Description,
                        ChangeTime = curentTime
                    };

                    _topicChangasRepo.Add(topicChanges);
                    obj.LastChangeTime = curentTime;
                }

                if (oldSection.SectionId != obj.SectionId)
                {
                    TopicChanges topicChanges = new()
                    {
                        TopicId = obj.Id,
                        Field = WC.SectionId,
                        FromValue = oldSection.SectionId.ToString(),
                        ToValue = obj.SectionId.ToString(),
                        ChangeTime = curentTime
                    };

                    _topicChangasRepo.Add(topicChanges);
                    obj.LastChangeTime = curentTime;
                }

                _topicChangasRepo.Save();

                _topicRepo.Update(obj);
                _topicRepo.Save();
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
            var obj = _topicRepo.Find(id.GetValueOrDefault());
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
            var obj = _topicRepo.Find(id.GetValueOrDefault());
            DateTime curentTime = DateTime.Now;
            if (obj == null)
            {
                return NotFound();
            }

            TopicChanges topicChanges = new()
            {
                TopicId = obj.Id,
                Field = WC.DeleteTime,
                FromValue = null,
                ToValue = curentTime.ToString(),
                ChangeTime = curentTime
            };

            _topicChangasRepo.Add(topicChanges);

            _topicRepo.Delete(obj, curentTime);
            _topicRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

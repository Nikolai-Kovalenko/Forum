using AutoMapper;
using Forum.Data;
using Forum.Models;
using Forum.Models.Dto;
using Forum.Models.ViewModels;
using Forum.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        public readonly AppDbContext _db;
        public readonly ITopicRepository _topicRepo;
        public readonly ITopicChangesRepository _topicChangasRepo;
        public readonly ITopicCommentRepository _topicCommentRepo;
        public IMapper _mapper { get; set; }


        public TopicController(AppDbContext db, ITopicRepository topicRepo,
            ITopicChangesRepository topicChangasRepo,
            ITopicCommentRepository topicCommentRepo, IMapper mapper)
        {
            _db = db;
            _topicRepo = topicRepo;
            _topicChangasRepo = topicChangasRepo;
            _topicCommentRepo = topicCommentRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var objList = _topicRepo.GetAll(u => u.DeleteTime == null, includePropreties: "Section");
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            if(id == null) // Create Topic
            {
                TopicUpsertVM topicUpsertVM = new()
                {
                    Topic = new TopicUpsertDTO(),
                    SectionSelectList = _topicRepo.GetAllDropdownList(WC.SectionType)
                };

                return View(topicUpsertVM);
            }

            // Update Topic

            Topic objFromDb = _topicRepo.Find(id.GetValueOrDefault());

            if(objFromDb != null) 
            {
                TopicUpsertVM topicUpsertVM = new()
                {
                    Topic = _mapper.Map<TopicUpsertDTO>(objFromDb),
                    SectionSelectList = _topicRepo.GetAllDropdownList(WC.SectionType)
                };

                return View(topicUpsertVM);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TopicUpsertVM obj)
        {
            if (ModelState.IsValid)
            {
                // Create
                if (obj.Topic.Id == 0)
                {
                    Topic topic = _mapper.Map<Topic>(obj.Topic);
                    topic.CreateTime = DateTime.Now;

                    _topicRepo.Add(topic);
                    _topicRepo.Save();
                    return RedirectToAction(nameof(Index));
                }
                // Update
                else
                {
                    var allTopic = _db.Topics.Where(t => t.Id == obj.Topic.Id).ToList();

                    Topic objFromDb = _topicRepo.FirstOrDefault(u => u.Id == obj.Topic.Id);

                    if (objFromDb != null)
                    {
                        objFromDb.Update(obj.Topic.Name, obj.Topic.Description, obj.Topic.SectionId);

                        _topicRepo.Save();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Topic = _topicRepo.FirstOrDefault(u => u.Id == id, includePropreties: "Section");
            if (Topic == null)
            {
                return NotFound();
            }

            TopicDeleteDTO dleteVM = _mapper.Map<TopicDeleteDTO>(Topic);

            return View(dleteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var Topic = _topicRepo.Find(id.GetValueOrDefault());
            DateTime deliteTime = DateTime.Now;

            if (Topic == null)
            {
                return NotFound();
            }

            Topic.Delete(deliteTime);

            _topicRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewDeteils(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Topic = _topicRepo.FirstOrDefault(u => u.Id == id, includePropreties: WC.SectionType);
            if (Topic == null || Topic.DeleteTime != null)
            {
                return NotFound();
            }

            IEnumerable<TopicComment> topicComment = _topicCommentRepo.GetAll(
                u => u.Id == id && u.DeleteTime != null);

            IEnumerable<TopicCommentDTO> topicCommentDto = _mapper.Map<IEnumerable<TopicCommentDTO>>(topicComment);

            TopicCommentVM topicCommentVM = new()
            {
                topicCommentDTO = topicCommentDto,
                topicDTO = _mapper.Map<TopicDTO>(Topic)
            };

            return View(topicCommentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewDeteilsPost(int? id)
        {
            var Topic = _topicRepo.Find(id.GetValueOrDefault());
            DateTime deliteTime = DateTime.Now;

            if (Topic == null)
            {
                return NotFound();
            }

            Topic.Delete(deliteTime);

            // _topicRepo.Delete(Topic, deliteTime);
            _topicRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

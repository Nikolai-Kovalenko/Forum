using Forum.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class TopicUpsertVM
    {
        public TopicUpsertDTO Topic { get; set; }
        public IEnumerable<SelectListItem>? SectionSelectList { get; set; }
    }
}

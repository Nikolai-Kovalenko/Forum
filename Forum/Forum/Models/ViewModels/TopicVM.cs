using Forum.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class TopicVM
    {
        public TopicCreateDTO Topic { get; set; }
        public IEnumerable<SelectListItem>? SectionSelectList { get; set; }
    }
}

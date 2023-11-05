using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class TopicVM
    {
        public Topic Topic { get; set; }
        public IEnumerable<SelectListItem>? SetionSelectList { get; set; }
    }
}

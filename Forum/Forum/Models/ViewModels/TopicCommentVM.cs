﻿using Forum.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class TopicCommentVM
    {
        public IEnumerable<TopicCommentDTO> listTopicCommentDTO { get; set; }
        public TopicCommentDTO topicCommentDTO { get; set; }
        public TopicDTO topicDTO { get; set; }

        // UserDTO // хз зачем...
            // Тут по идее должны выводится тема и, ниже, кооменты пользователй по этой теме
            // Также, можно сделать что-то типу _individualPartialView для комментов,
            // чтобы далее разедлить более удобно их на страницы
    }
}

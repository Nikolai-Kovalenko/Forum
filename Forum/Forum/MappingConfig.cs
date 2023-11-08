using AutoMapper;
using Forum.Models;
using Forum.Models.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Forum
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Topic, TopicUpsertDTO>().ReverseMap();
            CreateMap<Topic, TopicUpdateDTO>().ReverseMap();
            CreateMap<Topic, TopicUpsertDTO>().ReverseMap();
        }
    }
}

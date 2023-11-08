using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models.Dto
{
    public class TopicUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SectionId { get; set; }

        public string? Description { get; set; }
    }
}

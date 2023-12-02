using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models.Dto
{
    public class TopicDTO
    {
        public int Id { get; set; }

        [Display(Name = "Section Type")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}

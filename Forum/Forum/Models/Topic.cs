using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Section Type")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? LastChangeTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}

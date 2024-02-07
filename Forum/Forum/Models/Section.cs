using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; set; }

        public string? CreateUserId { get; set; }

        [ForeignKey("CreateUserId")]
        public virtual AppUser AppUser { get; set; }

        public DateTime? LastChangeTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}

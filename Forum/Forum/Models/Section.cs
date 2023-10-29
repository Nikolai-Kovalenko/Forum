using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Forum.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}

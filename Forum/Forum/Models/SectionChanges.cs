using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class SectionChanges
    {
        [Key]
        public int Id { get; set; }

        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        public string Field { get; set; }
        public string? FromValue { get; set; }
        public string? ToValue { get; set; }
        public DateTime ChangeTime { get; set; }



    }
}

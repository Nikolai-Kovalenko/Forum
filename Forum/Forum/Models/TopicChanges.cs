using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class TopicChanges
    {
        [Key]
        public int Id { get; set; }

        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public string Field { get; set; }
        public string? FromValue { get; set; }
        public string? ToValue { get; set; }
        public DateTime ChangeTime { get; set; }



    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class TopicComment
    {
        [Key]
        public int Id { get; set; }

        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public Guid CreateUserId { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}

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

        public string? CreateUserId { get; set; }

        [ForeignKey("CreateUserId")]
        public virtual AppUser AppUser { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? EditTime { get; set; } // Доступно только в течении 10 минут после написания комментария

        public DateTime? DeleteTime { get; set; }
    }
}

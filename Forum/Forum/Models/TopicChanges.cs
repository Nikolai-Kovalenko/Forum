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

        private TopicChanges() { }

        public TopicChanges(int topicId, string field, string? fromValue, string? toValue)
        {
            TopicId = topicId;
            Field = field;
            FromValue = fromValue;
            ToValue = toValue;
            ChangeTime = DateTime.UtcNow;
            Topic = null;
        }

    }
}

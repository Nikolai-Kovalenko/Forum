using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Core;

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

        public List<TopicChanges> Changes { get; set; } = new List<TopicChanges>();

        public void Update(
            string name,
            string? description,
            int sectionId
            )
        {
            if (name != Name)
            {
                AddChange(WC.Name, Name, name);

                Name = name;
            }

            if (description != Description)
            {
                AddChange(WC.Description, Description, description);

                Description = description;
            }

            if (SectionId != sectionId)
            {
                AddChange(WC.SectionId, SectionId.ToString(), sectionId.ToString());

                Description = description;
            }
        }

        public void Delete(DateTime deliteTime)
        {
            if (DeleteTime.HasValue)
            {
                new IndexOutOfRangeException("Record has already been deleted.");
            }

            AddChange(WC.DeleteTime, null, deliteTime.ToString());
        }


        private void AddChange(string field, string? fromValue, string? toValue)
        {
            Changes.Add(new TopicChanges(Id, field, fromValue, toValue));
        }
    }
}

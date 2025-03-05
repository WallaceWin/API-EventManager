using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventManager.Models
{
    public class EventModel
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column("EventName")]
        [MaxLength(80)]
        public string EventName { get; set; } = null!;

        public DateTime EventDate { get; set; }

        [ForeignKey("Locality")]
        public Guid? LocalityId { get; set; }

        public LocalityModel? Locality { get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}

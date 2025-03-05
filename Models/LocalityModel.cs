using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventManager.Models
{
    public class LocalityModel
    {
     
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(80)]
        public string LocalityName { get; set; }

        [Required]
        [MaxLength(80)]
        public string Ender { get; set; }

        [JsonIgnore]
        public ICollection<EventModel>? Events { get; set; }
    }
}

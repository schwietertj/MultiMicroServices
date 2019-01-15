using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicesDataModels.Models
{
    public class Link : BaseEntity
    {
        public long EventId { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Url { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}

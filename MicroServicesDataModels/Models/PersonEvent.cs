using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicesDataModels.Models
{
    public class PersonEvent : BaseEntity
    {
        public long PersonId { get; set; }
        public long EventId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}

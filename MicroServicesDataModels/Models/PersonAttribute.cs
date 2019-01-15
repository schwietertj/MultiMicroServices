using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicesDataModels.Models
{
    public class PersonAttribute : BaseEntity
    {
        public long PersonId { get; set; }
        public long AttributeId { get; set; }

        [Required, MaxLength(255)]
        public string Value { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [ForeignKey("AttributeId")]
        public Attribute Attribute { get; set; }
    }
}

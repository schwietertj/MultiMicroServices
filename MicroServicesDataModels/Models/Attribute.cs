using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroServicesDataModels.Models
{
    public class Attribute : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public IEnumerable<PersonAttribute> PersonAttributes { get; set; }
    }
}

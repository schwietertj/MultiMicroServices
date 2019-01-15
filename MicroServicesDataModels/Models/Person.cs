using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroServicesDataModels.Models
{
    public class Person : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public IEnumerable<PersonAttribute> PersonAttributes { get; set; }
        public IEnumerable<PersonEvent> PersonEvents { get; set; }

    }
}

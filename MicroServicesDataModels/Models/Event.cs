using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroServicesDataModels.Models
{
    public class Event : BaseEntity
    {
        [Required, MaxLength(512)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        public IEnumerable<Link> Links { get; set; }
        public IEnumerable<PersonEvent> PersonEvents { get; set; }
    }
}

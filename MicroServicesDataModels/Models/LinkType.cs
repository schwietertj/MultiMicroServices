using System.ComponentModel.DataAnnotations;

namespace MicroServicesDataModels.Models
{
    public class LinkType : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}

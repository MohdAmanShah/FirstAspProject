using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Categories.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public required string Name { get; set; }
        [Range(1,100)]
        [DisplayName("Display Order")]
        public required string DisplayOrder { get; set; } 

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

}

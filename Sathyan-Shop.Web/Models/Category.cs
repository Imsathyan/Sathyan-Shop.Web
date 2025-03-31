using System.ComponentModel.DataAnnotations;

namespace Sathyan_Shop.Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
    
using System.ComponentModel.DataAnnotations;

namespace TI_Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

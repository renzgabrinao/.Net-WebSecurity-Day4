using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Currenct")]
        public string Currency { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}

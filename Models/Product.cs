using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        [Required]
        public virtual int ProductCategoryId { get; set; }
        [Required]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
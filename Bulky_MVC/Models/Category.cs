using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky_MVC.Models
{

    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int ID{ get; set; }
        [Required]
        [MaxLength(20)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("display_order")]
        public int DisplayOrder { get; set; }
    }
}

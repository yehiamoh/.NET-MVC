using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//  [DisplayName("Display Order")] => is For How The fields will appear in the UI 

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
        [DisplayName("Category Name")]

        public string Name { get; set; }

        [Required]
        [Column("display_order")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }

        [Required]                   
        [StringLength(200)]            
        public string name_cate { get; set; } = null!;

        [StringLength(20)]          
        public int? parent_id { get; set; }   

        [StringLength(20)]            
        public string? link { get; set; }  

 
    }
}

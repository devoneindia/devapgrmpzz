using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Grampzz.Server.Models
{
    [Table("pizza")]
    public class Pizza
    {
        [Key]
        [Column("pizz_id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 15 characters")]
        [Column("name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Size is required Large|Medium|Samll")]
        [Column("pizaa_size")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Prize is required")]
        [Column("price")]
        public int? Price { get; set; }
    }
}

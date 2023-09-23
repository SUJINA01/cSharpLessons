using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace FirstMVCApp.Models
{
    public class Emp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Eno { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3,ErrorMessage = "Name must be between 3 and 20 char")]
        public String Name { get; set; }
        [Required]
        [Range(10000, 5000000)]
        public decimal Salary { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "City must be between 3 and 20 char")]
        public String City { get; set; }
    }
}

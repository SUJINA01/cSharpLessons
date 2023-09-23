using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { set; get; }
        [StringLength(10, ErrorMessage = "AuthorName must not have more than 10 chars")]
        [MinLength(3, ErrorMessage = "AuthorName must have at least 3 chars")]
        [Required(ErrorMessage = "AuthorName is Required")]

        public String AuthorName { set; get; }
        public String AuthorDOB { set; get; }
        public int NoOfBooksPublished { set; get; }
        [StringLength(15, ErrorMessage = "Royalty company must not have more than 15 chars")]
        [MinLength(3, ErrorMessage = "Royalty company must have at least 3 chars")]
        public string RoyaltyCompany { set; get; } 
    }
}

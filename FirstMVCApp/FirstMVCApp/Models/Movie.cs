using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace FirstMVCApp.Models
{
    public class Movie
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        [StringLength(30)]
        [MinLength(2, ErrorMessage = "Title must be between 3 and 30 char")]
        public String Title { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Language must be between 3 and 20 char")]
        public String Language { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Hero must be between 3 and 20 char")]

        public String Hero { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Director must be between 3 and 20 char")]
        public String Director{ get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "MusicDirector must be between 3 and 20 char")]
        public String MusicDirector { get; set; }

        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(50,100000)]
        
        public int MovieCost { get; set; }
        [Required]
        [Range(500000,10000000)]
        
        public int Collection { get; set; }
        [Required]
        public int Review { get; set; }

        
    }
}

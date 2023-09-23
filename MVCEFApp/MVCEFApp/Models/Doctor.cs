using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFApp.Models
{
    public class Doctor
    {
        [Key]
        [Column("doctorno")]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Name must be between 3 and 20 char")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Speciality { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public decimal VisitingFees { get; set; }
        [Required]
        [Column(TypeName = "numeric(18,0)")]
        public long PhoneNumber { get; set; }

    }
}

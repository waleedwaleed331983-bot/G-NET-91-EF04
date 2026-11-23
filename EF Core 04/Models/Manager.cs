using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignment_EF_Core_04.Models
{
    public class Manager
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public DateOnly HireDate { get; set; }
        [Required]
        public Branch Branch { get; set; } = null!;
    }
}

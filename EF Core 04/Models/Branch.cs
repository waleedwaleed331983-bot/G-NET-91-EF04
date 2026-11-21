using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Assignment_EF_Core_04.Enums;

namespace Assignment_EF_Core_04.Models
{
    public class Branch
    {
        [Key]
        public int Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(75)]
        public Address Address { get; set; }
        [Required]
        [Phone]
        public int PhoneNumber { get; set; }
    }
}

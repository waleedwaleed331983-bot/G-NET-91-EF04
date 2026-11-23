using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using EF_Core_04.Models;

namespace Assignment_EF_Core_04.Models
{
    public class Branch
    {
        [Key]
        public int Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(75)]
        public Address Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public Manager Manager { get; set; } = null!;
    }
}

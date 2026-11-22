using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Assignment_EF_Core_04.Enums;
using EF_Core_04.Models;

namespace Assignment_EF_Core_04.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public CustomerType CustomerType { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Assignment_EF_Core_04.Enums;


namespace Assignment_EF_Core_04.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public decimal CurrentBalance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        public TimeOnly OpeningDate { get; set; }
    }
}

using Assignment_EF_Core_04.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignment_EF_Core_04.Models
{
    public class CustomerAccount
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; } = null!;
        [Required]
        public int AccountId { get; set; }
        [Required]
        public Account Account { get; set; } = null!;
        public DateOnly OwnerShipStartDate { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public OwnerShipType OwnerShipType { get; set; }
    }
}

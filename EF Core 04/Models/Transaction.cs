using Assignment_EF_Core_04.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment_EF_Core_04.Models
{
    public class Transaction
    {
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public DateOnly TransactionDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        [MaxLength(25)]
        public string Note { get; set; } = null!;
        [Required]
        public int AccountNumber { get; set; }
        [ForeignKey(nameof(AccountNumber))]
        [Required]
        public Account Account { get; set; } = null!;
    }
}

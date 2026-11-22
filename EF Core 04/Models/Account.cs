using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Assignment_EF_Core_04.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_EF_Core_04.Models
{
    public class Account
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNumber { get; set; }
        [Required]
        public decimal CurrentBalance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        public AccountStatus AccountStatus { get; set; }
        [Required]
        public TimeOnly OpeningDate { get; set; }
        [Required]
        public int TransactionId { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        [Required]
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        [Required]
        public Branch Branch { get; set; } = null!;
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();
    }
}

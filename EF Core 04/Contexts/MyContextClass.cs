using System;
using System.Collections.Generic;
using System.Text;
using Assignment_EF_Core_04.Models;
using EF_Core_04.Contexts;
using EF_Core_04.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_EF_Core_04.Contexts
{
    internal class MyContextClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NationalBankManagementSystemDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => new { ca.CustomerId, ca.AccountId });
            modelBuilder.Entity<Customer>().OwnsOne(e => e.Address, a =>
            {
                a.Property(p => p.City).HasColumnName("City");
                a.Property(p => p.Country).HasColumnName("Country");
                a.Property(p => p.Street).HasColumnName("Street");
            });
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    }
}

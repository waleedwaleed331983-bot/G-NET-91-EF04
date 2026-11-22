using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Assignment_EF_Core_04.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_04.Contexts
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(new Branch { Name = "SecondBranch", Code = 2, ManagerId = 2, PhoneNumber = "01478523691" });
            builder.OwnsOne(e => e.Address).HasData(new
            {
                BranchCode = 2,
                Street = "MoharemBek",
                City = "Alex",
                Country = "Egypt"
            });

            builder.HasData(new Branch { Name = "SecondBranch", Code = 3, ManagerId = 3, PhoneNumber = "01478523691" });
            builder.OwnsOne(e => e.Address).HasData(new
            {
                BranchCode = 3,
                Street = "El-Dokki",
                City = "Cairo",
                Country = "Egypt"
            });
        }
    }
}

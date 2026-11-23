using Assignment_EF_Core_04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_04.Contexts
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasData(
                new Manager { FullName = "Ali", Id = 2, Email = "Ali@gmail.com", PhoneNumber = "02587413690", HireDate = new DateOnly(2015,11,07)},
                new Manager { FullName = "Mohamed", Id = 3, Email = "Mohamed@gmail.com", PhoneNumber = "02587413690", HireDate = new DateOnly(2015,11,07)}
                );
        }
    }
}

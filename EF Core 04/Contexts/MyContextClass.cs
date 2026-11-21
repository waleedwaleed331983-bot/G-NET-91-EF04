using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assignment_EF_Core_04.Contexts
{
    internal class MyContextClass : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NationalBankManagementSystemDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public static class ModuleBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Tani", Email = "tani@gmail.com", Department = Dept.HR },
                new Employee { Id = 2, Name = "Tanbin", Email = "bin@gmail.com", Department = Dept.IT },
                new Employee { Id = 3, Name = "Ritu", Email = "ritu@gmail.com", Department = Dept.Payroll }
            );

            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, ProductName = "Sofa", Price=30000 },
    new Product { Id = 2, ProductName = "Bed", Price=50000 }
   
  
);



            modelBuilder.Entity<Account>().HasData(
   new Account { Id = 1, AccountNumber = "12345", EmployeeName = "Tania", Salary = 30000,UrlImage="download.jpg",TypeId=1 });

            modelBuilder.Entity<Type>().HasData(
   new Type { Id = 1, TypeName = "Deposit" },
   new Type { Id = 2, TypeName = "Savings" },
   new Type { Id = 3, TypeName = "Fixed" }
   
   );

        }
    }
}

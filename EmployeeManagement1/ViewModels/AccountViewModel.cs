using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Enter Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Enter Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Please Choose an Image")]
        public IFormFile UrlImage { get; set; }
        public int TypeId { get; set; }
    }
}

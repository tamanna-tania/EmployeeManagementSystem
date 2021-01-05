using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement1.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement1.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 chracters")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

        //public string PhotoPath { get; set; }

        public IFormFile Photo { get; set; }
        public string PageTitle { get; set; }
    }
}

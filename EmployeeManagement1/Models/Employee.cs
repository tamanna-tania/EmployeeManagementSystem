﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 chracters")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

        public string PhotoPath { get; set; }
    }
}

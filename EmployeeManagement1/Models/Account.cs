using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Enter Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Choose an Image")]
        public string UrlImage { get; set; }
       
        public int TypeId { get; set; }
      
        public virtual Type Type { get; set; }
    }
}

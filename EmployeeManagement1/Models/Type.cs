using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class Type
    {
        public Type()
        {
            Account = new HashSet<Account>();
        }
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}

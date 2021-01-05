using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeDetails(int id);
        Employee AddEmployee(Employee objEmployee);

        Employee UpdateEmployee(Employee changeEmployee);
        Employee DeleteEmployee(int id);
    }
}

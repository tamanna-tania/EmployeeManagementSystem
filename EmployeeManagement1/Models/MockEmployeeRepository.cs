using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee () {Id = 1, Name = "Tanbin", Email = "tanbin@gmail.com", Department = Dept.HR},
                new Employee () {Id = 2, Name = "Ritu", Email = "ritu@gmail.com", Department = Dept.IT},
                new Employee () {Id = 3, Name = "Tania", Email = "tani@gmail.com", Department = Dept.Payroll}
            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var emplist = _employeeList.ToList();
            return emplist;
        }
        public Employee GetEmployeeDetails(int id)
        {
            Employee employee = this._employeeList.FirstOrDefault(e=>e.Id == id);
            return employee;
        }

        public Employee AddEmployee(Employee objEmployee)
        {
            objEmployee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(objEmployee);
            return objEmployee;
            
        }

        public Employee UpdateEmployee(Employee changeEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == changeEmployee.Id);
            if (employee != null)
            {
                employee.Name = changeEmployee.Name;
                employee.Email = changeEmployee.Email;
                employee.Department = changeEmployee.Department;
            }
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}

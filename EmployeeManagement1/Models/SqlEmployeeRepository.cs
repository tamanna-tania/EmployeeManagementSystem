using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement1.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public SqlEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee objEmployee)
        {
            _context.Employees.Add(objEmployee);
            _context.SaveChanges();
            return objEmployee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = GetEmployeeDetails(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;

        }

        public Employee GetEmployeeDetails(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public Employee UpdateEmployee(Employee changeEmployee)
        {
            var upEmployee = _context.Employees.Attach(changeEmployee);
            upEmployee.State = EntityState.Modified;
            _context.SaveChanges();
            return changeEmployee;
        }
    }
}

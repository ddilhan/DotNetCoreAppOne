using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAppOne.Models
{
    public class Employee
    {
        private AppDBContext _context;
        public Employee()
        {

        }

        public Employee(AppDBContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Location { get; set; }
        [BindProperty]
        public int Age { get; set; }

        public Employee getEmployee(int id)
        {
            var employee = _context.EmployeeTable.Find(id);
            return employee;
        }

        public Employee addEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee deleteEmployee(int id) 
        {
            var employee = _context.EmployeeTable.Find(id);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _context.EmployeeTable;
            return employees;
        }

        public Employee updateEmployee(Employee employee)
        {
            var employees = _context.EmployeeTable.Attach(employee);
            employees.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }
    }
}

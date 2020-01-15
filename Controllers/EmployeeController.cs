using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCoreAppOne.Models;

namespace TestCoreAppOne.Controllers
{
    public class EmployeeController : Controller
    {
        private Employee _employee;

        public EmployeeController(Models.Employee employee)
        {
            _employee = employee;
        }
        public IActionResult Index()
        {
            return View(_employee.GetEmployees());
        }

        [HttpGet]
        public IActionResult EditEmployee(int id) 
        {
            return View(_employee.getEmployee(id));
        }

        [HttpPost]
        public IActionResult EditEmployee( Employee emp)
        {
            _employee.updateEmployee(emp);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id) 
        {
            _employee.deleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddEmployee(Employee emp)
        {
            _employee.addEmployee(emp);
            return RedirectToAction("Index");
        }
    }
}
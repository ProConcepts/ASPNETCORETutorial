using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProConcepts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProConcepts.Controllers
{
    
    public class EmployeeController : Controller
    {
        public IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            List<Employee> employees = _repository.GetEmployees();
            return View(employees);
        }
        
        public string DeleteEmployee(int id)
        {
            return "Controller = Empoloyee and Action = DeleteEmployee";
        }
    }
}

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProConcepts.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}

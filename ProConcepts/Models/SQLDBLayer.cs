using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProConcepts.Models
{
    public class SQLDBLayer : IEmployeeRepository
    {
        public IConfiguration Configuration { get; }
        public SQLDBLayer(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("EmployeeContext")))
            {
                string query = "SELECT ID, NAME, SALARY, A.DEPARTMENT, DEPT_NAME FROM TBLEMPLOYEE A " +
                    "LEFT JOIN TBLDEPARTMENT B ON A.DEPARTMENT = B.DEPT_ID;";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id= Convert.ToInt32(sdr["id"]),
                                Name=sdr["name"].ToString(),
                                Salary = Convert.ToInt32(sdr["Salary"]),
                                Department = Convert.ToInt32(sdr["Department"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return employees;
        }
    }
}

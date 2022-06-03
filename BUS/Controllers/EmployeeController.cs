using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DTO.Entities;

namespace BUS.Controllers
{
    public class EmployeeController
    {
        public List<Employee> GetAllEmployees(ref string error)
        {
            using (var context = new Context())
            {
                try
                {
                    var employee = context.Employees.ToList();
                    error = "Get All Employee Success!!!";
                    return employee;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }

    }
}

using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesLibrary
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeByNameAsync(string name);
    }
}

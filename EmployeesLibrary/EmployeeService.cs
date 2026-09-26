using EmployeeModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesLibrary
{

    public class EmployeeService : IEmployeeService
    {
        private readonly string connectionString =
            "Server=PAVANPRADEEP\\MSSQLSERVER01;Database=Employee;Trusted_Connection=True;TrustServerCertificate=True";

        public async Task<List<Employee>> GetEmployeeByNameAsync(string name)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM EmployeeDetails WHERE Name = @Name";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);

                        await con.OpenAsync();

                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee
                            {
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Company = reader["Company"].ToString(),
                                Salary = Convert.ToDecimal(reader["Salary"])
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return employees;
        }
    }

}

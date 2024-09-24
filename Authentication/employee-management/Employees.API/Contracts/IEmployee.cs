using Employees.API.Controllers;
using Employees.API.Models;

namespace Employees.API.Contracts
{
    public interface IEmployee
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployeeById(int id);

        public Employee AddEmployee(Employee employee);

        public bool DeleteEmployee(int id);

        public bool UpdateEmployee(int id, Employee employee);
    }
}

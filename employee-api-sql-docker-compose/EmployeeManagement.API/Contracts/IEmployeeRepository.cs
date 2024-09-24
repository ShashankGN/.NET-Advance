using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Contracts
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);
        Task<bool> UpdateEmployee(int id, Employee employee);

        Task<bool> DeleteEmployee(int id);
    }
}

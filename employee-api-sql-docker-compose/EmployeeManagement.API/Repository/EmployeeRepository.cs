using EmployeeManagement.API.Contracts;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employeeExists = await GetEmployee(id);
            if(employeeExists != null)
            {
                _dbContext.Employees.Remove(employeeExists);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
           var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            if(employees.Count>0)
            return employees;

            return null;
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await GetEmployee(id);
            if(existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

using Employees.API.Contracts;
using Employees.API.Controllers;
using Employees.API.DBContext;
using Employees.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Employees.API.Repository
{
    public class EmployeeInMemoryRepository:IEmployee
    {
        EmployeeDBContext _employeeDBContext;
        public EmployeeInMemoryRepository(EmployeeDBContext employeeDBContext) 
        { 
            _employeeDBContext = employeeDBContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var Addemployee = _employeeDBContext.Employees.Add(employee);
            if (Addemployee != null)
            {
                _employeeDBContext.SaveChanges();
                return employee;
            }
            return null;
        }


        public bool DeleteEmployee(int id)
        {
            var employee=_employeeDBContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee!=null)
            {
                _employeeDBContext.Employees.Remove(employee);
                _employeeDBContext.SaveChanges();
                return true;
                
            }
            return false;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee=_employeeDBContext.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return null;
            }
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDBContext.Employees;
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            var updateEmployee=_employeeDBContext.Employees.FirstOrDefault(x=>x.Id == id);
            if (updateEmployee != null)
            {
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.salary = employee.salary;
                updateEmployee.Email = employee.Email;
                _employeeDBContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

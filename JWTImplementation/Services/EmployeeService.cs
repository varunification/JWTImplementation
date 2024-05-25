using JWTImplementation.Context;
using JWTImplementation.Interfaces;
using JWTImplementation.Models;

namespace JWTImplementation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _jwtContext;
        public EmployeeService(JwtContext jwtcontext)
        {
            _jwtContext = jwtcontext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var t = _jwtContext.usersByEmail.Add(employee);
            _jwtContext.SaveChanges();
            return employee;
        }

        public void deleteEmployee(int id)
        {
            var emp = _jwtContext.usersByEmail.SingleOrDefault(s=>s.id==id);
            if (emp == null)
            {
                throw new Exception("user not found");
            }
            _jwtContext.usersByEmail.Remove(emp);
            _jwtContext.SaveChanges();
        }

        public List<Employee> GetEmployeeDetails()
        {

            var employees = _jwtContext.usersByEmail.ToList();
            return employees;
        }

        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                var emp = _jwtContext.usersByEmail.SingleOrDefault(s => s.id == id);
                return emp;
            }
            catch (Exception ex)
            {
                return new Employee();
            }
           
        }

        public Employee Update(Employee employee)
        {
            var updated = _jwtContext.usersByEmail.Update(employee);
            _jwtContext.SaveChanges();
            return updated.Entity;
        }
    }
}

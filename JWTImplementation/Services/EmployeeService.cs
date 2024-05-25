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



            employee.id = 0;
            var temp = _jwtContext.usersByEmail.Add(employee);
            _jwtContext.SaveChanges();
            return temp.Entity;
        }

        public bool deleteEmployee(int id)
        {
            var flag = false;
            var emp = _jwtContext.usersByEmail.SingleOrDefault(s=>s.id==id);
            if (emp == null)
            {
                return flag;
            }
            _jwtContext.usersByEmail.Remove(emp);
            _jwtContext.SaveChanges();
            flag = true;
            return flag;
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

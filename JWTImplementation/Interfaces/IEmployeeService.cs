﻿using JWTImplementation.Models;

namespace JWTImplementation.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployeeDetails(int id);
        public Employee AddEmployee(Employee employee);
        public Employee Update(Employee employee);
        public void deleteEmployee(int id);
    }
}

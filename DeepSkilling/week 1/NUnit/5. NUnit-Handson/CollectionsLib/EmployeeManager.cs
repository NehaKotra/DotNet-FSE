using System.Collections.Generic;

namespace CollectionsLib
{
    public class EmployeeManager
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee(100,"Neha"),
                new Employee(101,"Rahul"),
                new Employee(102,"Priya"),
                new Employee(103,"Arjun")
            };
        }

        public List<Employee> GetEmployeesWhoJoinedInPreviousYears()
        {
            return new List<Employee>
            {
                new Employee(100,"Neha"),
                new Employee(101,"Rahul"),
                new Employee(102,"Priya"),
                new Employee(103,"Arjun")
            };
        }
    }
}
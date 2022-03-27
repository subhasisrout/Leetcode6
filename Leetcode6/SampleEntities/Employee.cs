using System.Collections.Generic;

//Sample entity and comparer for testing generic priority queue/maxheap/minheap

namespace Leetcode.SampleEntities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Salary { get; set; }
    }

    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return y.Salary - x.Salary;// this will result in a maxheap.
            //x - y will result in minheap.
        }
    }

    public class EmployeeUtils
    {
        public static IEnumerable<KeyValuePair<Employee, Employee>> GetEmployees()
        {
            List<KeyValuePair<Employee, Employee>> kvPairList = new List<KeyValuePair<Employee, Employee>>();

            Employee emp = new Employee() { Id = 1, Name = "Subhasis", Salary = 100 };
            kvPairList.Add(new KeyValuePair<Employee, Employee>(emp, emp));
            
            emp = new Employee() { Id = 2, Name = "Kabir", Salary = 50 };
            kvPairList.Add(new KeyValuePair<Employee, Employee>(emp, emp));

            emp = new Employee() { Id = 3, Name = "Jason", Salary = 200 };
            kvPairList.Add(new KeyValuePair<Employee, Employee>(emp, emp));

            emp = new Employee() { Id = 4, Name = "Matt", Salary = 150 };
            kvPairList.Add(new KeyValuePair<Employee, Employee>(emp, emp));

            return kvPairList;
        }
    }
}

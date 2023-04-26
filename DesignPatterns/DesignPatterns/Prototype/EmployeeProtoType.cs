using System;

namespace DesignPatterns.Prototype
{
    public class EmployeeProtoType
    {
        public void Debug()
        {
            var _employee = new Employee();
            _employee.Name = "Ajay";
            _employee.Role = "Developer";
            _employee.Department = "P Systems";


            var _employeeCopy = (Employee)_employee.Clone();
            _employeeCopy.Name = "X"; // All the values are copied from the 1st object
            Console.ReadKey();


        }
    }
    public interface IPrototype
    {
        IPrototype Clone();
    }
    public class Employee : IPrototype
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        public IPrototype Clone()
        {
            /*Shallow Copy: only top-level objects are duplicated
            ie. if the object contains any reference types then only the address
            of that reference type will be copied from source to target*/
            return (IPrototype)MemberwiseClone();
        }
    }
}

using System;

namespace CollectionsLib
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Required for CollectionAssert.AllItemsAreUnique()

        public override bool Equals(object obj)
        {
            if (obj is Employee emp)
                return Id == emp.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
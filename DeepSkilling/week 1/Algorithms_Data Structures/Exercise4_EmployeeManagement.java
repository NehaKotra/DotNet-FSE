/*
============================================================
CTS Deep Skilling

Exercise 4
Employee Management System

Problem Understanding

Array Representation

An array stores elements in contiguous memory locations.
Each element can be accessed directly using its index,
making retrieval very fast.

Advantages of Arrays

• Fast random access using index.
• Simple implementation.
• Memory efficient.

Limitations

• Fixed size.
• Insertion and deletion require shifting elements.
• Memory cannot grow dynamically.

============================================================
*/

class Employee {

    int employeeId;
    String name;
    String position;
    double salary;

    Employee(int employeeId, String name,
             String position, double salary) {

        this.employeeId = employeeId;
        this.name = name;
        this.position = position;
        this.salary = salary;
    }

    void display() {

        System.out.println(employeeId + "\t"
                + name + "\t"
                + position + "\t"
                + salary);

    }

}

public class Exercise4_EmployeeManagement {

    static Employee[] employees = new Employee[10];
    static int count = 0;

    // Add Employee

    static void addEmployee(Employee emp) {

        if (count < employees.length) {

            employees[count++] = emp;

            System.out.println("Employee Added Successfully.");

        } else {

            System.out.println("Array is Full.");

        }

    }

    // Search Employee

    static Employee searchEmployee(int id) {

        for (int i = 0; i < count; i++) {

            if (employees[i].employeeId == id) {

                return employees[i];

            }

        }

        return null;

    }

    // Traverse Employees

    static void traverseEmployees() {

        System.out.println("----------------------------------------------");
        System.out.println("ID\tName\tPosition\tSalary");
        System.out.println("----------------------------------------------");

        for (int i = 0; i < count; i++) {

            employees[i].display();

        }

    }

    // Delete Employee

    static void deleteEmployee(int id) {

        int index = -1;

        for (int i = 0; i < count; i++) {

            if (employees[i].employeeId == id) {

                index = i;
                break;

            }

        }

        if (index == -1) {

            System.out.println("Employee Not Found.");
            return;

        }

        for (int i = index; i < count - 1; i++) {

            employees[i] = employees[i + 1];

        }

        employees[count - 1] = null;

        count--;

        System.out.println("Employee Deleted Successfully.");

    }

    public static void main(String[] args) {

        addEmployee(new Employee(101,
                "John",
                "Manager",
                70000));

        addEmployee(new Employee(102,
                "Alice",
                "Developer",
                55000));

        addEmployee(new Employee(103,
                "Bob",
                "Tester",
                45000));

        System.out.println("\nEmployee Records");

        traverseEmployees();

        System.out.println("\nSearching Employee ID 102");

        Employee emp = searchEmployee(102);

        if (emp != null)

            emp.display();

        else

            System.out.println("Employee Not Found.");

        System.out.println("\nDeleting Employee ID 101");

        deleteEmployee(101);

        System.out.println("\nEmployee Records After Deletion");

        traverseEmployees();

    }

}

/*
============================================================
Analysis

Operation                Time Complexity

Add Employee             O(1)
Search Employee          O(n)
Traverse Employees       O(n)
Delete Employee          O(n)

------------------------------------------------------------

Advantages of Arrays

• Fast access using index.
• Simple implementation.
• Low memory overhead.

Limitations of Arrays

• Fixed size.
• Deletion requires shifting elements.
• Insertion in the middle is costly.
• Not suitable when data size changes frequently.

When to Use Arrays

Arrays are suitable when:

• Number of records is fixed.
• Fast index-based access is required.
• Memory efficiency is important.

============================================================
*/
/*
============================================================
CTS Deep Skilling

Exercise 10
MVC (Model View Controller) Pattern

Problem Understanding

MVC Pattern

MVC is an Architectural Design Pattern that separates
an application into three components:

1. Model
   Stores application data.

2. View
   Displays data to the user.

3. Controller
   Acts as a bridge between Model and View.

Advantages

• Separation of concerns.
• Easy maintenance.
• Better code organization.
• Improved scalability.

Scenario

A Student Management System stores student details,
updates them through the Controller, and displays them
using the View.

============================================================
*/

// =======================
// Model
// =======================

class Student {

    private String name;
    private int id;
    private String grade;

    public Student(String name, int id, String grade) {

        this.name = name;
        this.id = id;
        this.grade = grade;

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getGrade() {
        return grade;
    }

    public void setGrade(String grade) {
        this.grade = grade;
    }

}

// =======================
// View
// =======================

class StudentView {

    public void displayStudentDetails(Student student) {

        System.out.println("Student Details");
        System.out.println("-----------------------");
        System.out.println("ID    : " + student.getId());
        System.out.println("Name  : " + student.getName());
        System.out.println("Grade : " + student.getGrade());
        System.out.println();

    }

}

// =======================
// Controller
// =======================

class StudentController {

    private Student model;
    private StudentView view;

    public StudentController(Student model,
                             StudentView view) {

        this.model = model;
        this.view = view;

    }

    public void setStudentName(String name) {

        model.setName(name);

    }

    public void setStudentGrade(String grade) {

        model.setGrade(grade);

    }

    public void updateView() {

        view.displayStudentDetails(model);

    }

}

// =======================
// Test Class
// =======================

public class Exercise10_MVCPattern {

    public static void main(String[] args) {

        Student student =
                new Student("Alice", 101, "A");

        StudentView view =
                new StudentView();

        StudentController controller =
                new StudentController(student, view);

        System.out.println("Initial Student Details\n");

        controller.updateView();

        controller.setStudentName("Neha");

        controller.setStudentGrade("A+");

        System.out.println("Updated Student Details\n");

        controller.updateView();

    }

}

/*
============================================================
Sample Output

Initial Student Details

Student Details
-----------------------
ID    : 101
Name  : Alice
Grade : A

Updated Student Details

Student Details
-----------------------
ID    : 101
Name  : Neha
Grade : A+

============================================================

Analysis

Working

1. Student acts as the Model.
2. StudentView displays student details.
3. StudentController updates the model.
4. Controller requests the View to display data.

------------------------------------------------------------

Advantages

• Separation of concerns.
• Easy maintenance.
• Better code organization.
• Supports multiple views.
• Easy testing.

Disadvantages

• More classes.
• Slight increase in complexity.

------------------------------------------------------------

Time Complexity

Update Student : O(1)

Display Student : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The MVC Pattern separates business logic,
presentation logic, and application control.

It improves maintainability, scalability,
and code reusability.

MVC is widely used in Java Swing,
Spring MVC, Android, and web applications.

============================================================
*/
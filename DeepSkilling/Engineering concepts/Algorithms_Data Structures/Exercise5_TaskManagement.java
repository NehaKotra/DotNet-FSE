/*
============================================================
CTS Deep Skilling

Exercise 5
Task Management System

Problem Understanding

Linked Lists

1. Singly Linked List
- Each node contains data and a pointer to the next node.
- Traversal is possible only in the forward direction.

2. Doubly Linked List
- Each node contains data, next pointer and previous pointer.
- Traversal is possible in both forward and backward directions.

This exercise uses a Singly Linked List to manage tasks.

============================================================
*/

class Task {

    int taskId;
    String taskName;
    String status;

    Task next;

    Task(int taskId, String taskName, String status) {

        this.taskId = taskId;
        this.taskName = taskName;
        this.status = status;
        this.next = null;

    }

}

public class Exercise5_TaskManagement {

    static Task head = null;

    // Add Task

    static void addTask(int id, String name, String status) {

        Task newTask = new Task(id, name, status);

        if (head == null) {

            head = newTask;

        } else {

            Task temp = head;

            while (temp.next != null)

                temp = temp.next;

            temp.next = newTask;

        }

        System.out.println("Task Added Successfully.");

    }

    // Search Task

    static void searchTask(int id) {

        Task temp = head;

        while (temp != null) {

            if (temp.taskId == id) {

                System.out.println("\nTask Found");
                System.out.println("Task ID   : " + temp.taskId);
                System.out.println("Task Name : " + temp.taskName);
                System.out.println("Status    : " + temp.status);

                return;

            }

            temp = temp.next;

        }

        System.out.println("Task Not Found.");

    }

    // Traverse Tasks

    static void traverseTasks() {

        Task temp = head;

        System.out.println("\n-----------------------------------------");
        System.out.println("Task ID\tTask Name\tStatus");
        System.out.println("-----------------------------------------");

        while (temp != null) {

            System.out.println(
                    temp.taskId + "\t"
                    + temp.taskName + "\t\t"
                    + temp.status);

            temp = temp.next;

        }

    }

    // Delete Task

    static void deleteTask(int id) {

        if (head == null) {

            System.out.println("List is Empty.");
            return;

        }

        if (head.taskId == id) {

            head = head.next;

            System.out.println("Task Deleted Successfully.");

            return;

        }

        Task current = head;
        Task previous = null;

        while (current != null && current.taskId != id) {

            previous = current;
            current = current.next;

        }

        if (current == null) {

            System.out.println("Task Not Found.");
            return;

        }

        previous.next = current.next;

        System.out.println("Task Deleted Successfully.");

    }

    public static void main(String[] args) {

        addTask(101, "Design UI", "Pending");
        addTask(102, "Write Code", "In Progress");
        addTask(103, "Testing", "Pending");
        addTask(104, "Deployment", "Completed");

        traverseTasks();

        searchTask(102);

        deleteTask(103);

        System.out.println("\nAfter Deletion");

        traverseTasks();

    }

}

/*
============================================================
Analysis

Time Complexity

Add Task
--------
O(n)

Search Task
-----------
O(n)

Traverse Tasks
--------------
O(n)

Delete Task
-----------
O(n)

------------------------------------------------------------

Advantages of Linked Lists over Arrays

• Dynamic size.
• Efficient insertion and deletion.
• No shifting of elements required.
• Better memory utilization.

Disadvantages

• Sequential access only.
• Extra memory required for pointers.
• Slower searching than arrays.

------------------------------------------------------------

Conclusion

Linked Lists are more suitable than arrays when the
number of tasks changes frequently because insertion
and deletion are easier without shifting elements.

============================================================
*/
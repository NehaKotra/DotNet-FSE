/*
============================================================
CTS Deep Skilling

Exercise 1
Implementing the Singleton Pattern

Problem Understanding

Singleton Pattern

The Singleton Pattern is a Creational Design Pattern
that ensures only one instance of a class exists
throughout the application's lifecycle.

Why Singleton?

• Saves memory.
• Provides a single point of access.
• Ensures consistent logging.
• Prevents multiple object creation.

Real-Life Examples

• Logger
• Printer Spooler
• Database Connection
• Configuration Manager

============================================================
*/

// Singleton Class

class Logger {

    // Single object

    private static Logger instance;

    // Private Constructor

    private Logger() {

        System.out.println("Logger Instance Created");

    }

    // Static Method

    public static Logger getInstance() {

        if (instance == null) {

            instance = new Logger();

        }

        return instance;

    }

    // Logging Method

    public void log(String message) {

        System.out.println("LOG : " + message);

    }

}

// Test Class

public class Exercise1_SingletonPattern {

    public static void main(String[] args) {

        Logger logger1 = Logger.getInstance();

        logger1.log("Application Started");

        Logger logger2 = Logger.getInstance();

        logger2.log("User Logged In");

        Logger logger3 = Logger.getInstance();

        logger3.log("Application Closed");

        System.out.println();

        System.out.println("Checking Objects");

        System.out.println(logger1 == logger2);

        System.out.println(logger2 == logger3);

        System.out.println(logger1 == logger3);

    }

}

/*
============================================================
Output

Logger Instance Created

LOG : Application Started
LOG : User Logged In
LOG : Application Closed

Checking Objects

true
true
true

============================================================

Analysis

Advantages

• Only one object is created.
• Saves memory.
• Global access point.
• Easy to manage shared resources.

Disadvantages

• Difficult to unit test.
• Can become a global variable.
• Not suitable when multiple instances are required.

Time Complexity

getInstance()

Best Case    : O(1)
Worst Case   : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Singleton Pattern ensures that only one Logger
object exists during the application lifecycle.

All logging requests use the same object, providing
consistent and centralized logging.

============================================================
*/
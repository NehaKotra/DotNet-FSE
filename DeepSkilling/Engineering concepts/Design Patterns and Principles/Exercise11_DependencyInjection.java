/*
============================================================
CTS Deep Skilling

Exercise 11
Dependency Injection

Problem Understanding

Dependency Injection (DI)

Dependency Injection is a design principle in which
an object's dependencies are provided externally
instead of the object creating them itself.

In Constructor Injection, dependencies are passed
through the constructor.

Advantages

• Loose coupling.
• Easy testing.
• Better maintainability.
• Easy to replace implementations.

Scenario

A Customer Management System where CustomerService
depends on CustomerRepository.

Instead of CustomerService creating the repository,
it receives it through constructor injection.

============================================================
*/

// Repository Interface

interface CustomerRepository {

    String findCustomerById(int id);

}

// Concrete Repository

class CustomerRepositoryImpl implements CustomerRepository {

    @Override
    public String findCustomerById(int id) {

        switch (id) {

            case 101:
                return "Rahul";

            case 102:
                return "Neha";

            case 103:
                return "Priya";

            default:
                return "Customer Not Found";
        }

    }

}

// Service Class

class CustomerService {

    private CustomerRepository repository;

    // Constructor Injection

    public CustomerService(CustomerRepository repository) {

        this.repository = repository;

    }

    public void displayCustomer(int id) {

        System.out.println("Customer ID : " + id);
        System.out.println("Customer Name : "
                + repository.findCustomerById(id));

    }

}

// Test Class

public class Exercise11_DependencyInjection {

    public static void main(String[] args) {

        CustomerRepository repository =
                new CustomerRepositoryImpl();

        CustomerService service =
                new CustomerService(repository);

        service.displayCustomer(101);

        System.out.println();

        service.displayCustomer(102);

        System.out.println();

        service.displayCustomer(105);

    }

}

/*
============================================================
Sample Output

Customer ID : 101
Customer Name : Rahul

Customer ID : 102
Customer Name : Neha

Customer ID : 105
Customer Name : Customer Not Found

============================================================

Analysis

Working

1. CustomerRepository defines the contract.

2. CustomerRepositoryImpl provides the implementation.

3. CustomerService depends on the interface,
   not the implementation.

4. Repository object is injected through the
   constructor.

5. CustomerService uses the injected repository
   to fetch customer information.

------------------------------------------------------------

Advantages

• Loose coupling.
• Easy unit testing.
• Better maintainability.
• Easy to replace implementations.
• Supports Dependency Inversion Principle.

Disadvantages

• More classes.
• Slight increase in complexity.

------------------------------------------------------------

Time Complexity

Find Customer : O(1)

Constructor Injection : O(1)

Space Complexity

O(1)

============================================================

Conclusion

Dependency Injection improves software design by
removing tight coupling between classes.

Constructor Injection is the most commonly used form
of Dependency Injection because it guarantees that
required dependencies are available when an object
is created.

Frameworks such as Spring Boot heavily use
Dependency Injection.

============================================================
*/
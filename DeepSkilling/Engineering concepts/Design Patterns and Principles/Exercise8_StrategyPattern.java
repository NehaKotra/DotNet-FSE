/*
============================================================
CTS Deep Skilling

Exercise 8
Strategy Pattern

Problem Understanding

Strategy Pattern

The Strategy Pattern is a Behavioral Design Pattern
that allows selecting an algorithm or behavior at runtime.

Instead of hardcoding a single payment method,
different payment strategies can be chosen dynamically.

Advantages

• Easy to switch algorithms.
• Follows Open/Closed Principle.
• Reduces complex if-else statements.
• Promotes code reusability.

Scenario

An online payment system supports multiple payment
methods such as Credit Card and PayPal.

============================================================
*/

// Strategy Interface

interface PaymentStrategy {

    void pay(double amount);

}

// Concrete Strategy - Credit Card

class CreditCardPayment implements PaymentStrategy {

    @Override
    public void pay(double amount) {

        System.out.println("Paid ₹" + amount +
                " using Credit Card.");

    }

}

// Concrete Strategy - PayPal

class PayPalPayment implements PaymentStrategy {

    @Override
    public void pay(double amount) {

        System.out.println("Paid ₹" + amount +
                " using PayPal.");

    }

}

// Context Class

class PaymentContext {

    private PaymentStrategy strategy;

    public void setPaymentStrategy(PaymentStrategy strategy) {

        this.strategy = strategy;

    }

    public void executePayment(double amount) {

        if (strategy == null) {

            System.out.println("Please select a payment method.");

            return;

        }

        strategy.pay(amount);

    }

}

// Test Class

public class Exercise8_StrategyPattern {

    public static void main(String[] args) {

        PaymentContext payment = new PaymentContext();

        payment.setPaymentStrategy(new CreditCardPayment());

        payment.executePayment(2500);

        payment.setPaymentStrategy(new PayPalPayment());

        payment.executePayment(3500);

    }

}

/*
============================================================
Sample Output

Paid ₹2500.0 using Credit Card.

Paid ₹3500.0 using PayPal.

============================================================

Analysis

Working

1. PaymentContext stores a PaymentStrategy.
2. User selects the desired payment method.
3. Context delegates payment processing to the
   selected strategy.
4. Payment method can be changed at runtime
   without modifying existing code.

------------------------------------------------------------

Advantages

• Easy to add new payment methods.
• Eliminates large conditional statements.
• Promotes flexibility.
• Supports runtime behavior changes.

Disadvantages

• Increases the number of classes.
• Client must know which strategy to choose.

------------------------------------------------------------

Time Complexity

Selecting Strategy : O(1)

Payment Execution  : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Strategy Pattern allows different payment
algorithms to be selected dynamically at runtime.

It makes the payment system flexible,
maintainable, and easy to extend with new
payment methods.

============================================================
*/
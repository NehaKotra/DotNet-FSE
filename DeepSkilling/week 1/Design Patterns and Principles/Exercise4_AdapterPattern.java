/*
============================================================
CTS Deep Skilling

Exercise 4
Adapter Pattern

Problem Understanding

Adapter Pattern

The Adapter Pattern is a Structural Design Pattern
that allows incompatible interfaces to work together.

It acts as a bridge between an existing class
(Adaptee) and the required interface (Target).

Advantages

• Reuses existing code.
• Improves compatibility.
• Reduces modification of existing classes.
• Promotes loose coupling.

Scenario

A payment system integrates multiple third-party
payment gateways having different interfaces.

The Adapter Pattern allows all gateways to be used
through a common PaymentProcessor interface.

============================================================
*/

// Target Interface

interface PaymentProcessor {

    void processPayment(double amount);

}

// Adaptee 1

class PayPalGateway {

    public void makePayment(double amount) {

        System.out.println("Payment of ₹" + amount
                + " processed using PayPal.");

    }

}

// Adaptee 2

class StripeGateway {

    public void pay(double amount) {

        System.out.println("Payment of ₹" + amount
                + " processed using Stripe.");

    }

}

// Adaptee 3

class RazorpayGateway {

    public void completeTransaction(double amount) {

        System.out.println("Payment of ₹" + amount
                + " processed using Razorpay.");

    }

}

// Adapter for PayPal

class PayPalAdapter implements PaymentProcessor {

    private PayPalGateway gateway;

    public PayPalAdapter() {

        gateway = new PayPalGateway();

    }

    @Override
    public void processPayment(double amount) {

        gateway.makePayment(amount);

    }

}

// Adapter for Stripe

class StripeAdapter implements PaymentProcessor {

    private StripeGateway gateway;

    public StripeAdapter() {

        gateway = new StripeGateway();

    }

    @Override
    public void processPayment(double amount) {

        gateway.pay(amount);

    }

}

// Adapter for Razorpay

class RazorpayAdapter implements PaymentProcessor {

    private RazorpayGateway gateway;

    public RazorpayAdapter() {

        gateway = new RazorpayGateway();

    }

    @Override
    public void processPayment(double amount) {

        gateway.completeTransaction(amount);

    }

}

// Test Class

public class Exercise4_AdapterPattern {

    public static void main(String[] args) {

        PaymentProcessor paypal = new PayPalAdapter();
        PaymentProcessor stripe = new StripeAdapter();
        PaymentProcessor razorpay = new RazorpayAdapter();

        paypal.processPayment(2500);

        stripe.processPayment(4500);

        razorpay.processPayment(6200);

    }

}

/*
============================================================
Output

Payment of ₹2500.0 processed using PayPal.

Payment of ₹4500.0 processed using Stripe.

Payment of ₹6200.0 processed using Razorpay.

============================================================

Analysis

Advantages

• Integrates incompatible interfaces.
• Existing code remains unchanged.
• Improves flexibility.
• Easy to add new payment gateways.

Disadvantages

• Introduces additional classes.
• Slight increase in complexity.

Time Complexity

Payment Processing : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Adapter Pattern enables multiple third-party
payment gateways to work through a common
PaymentProcessor interface.

This makes the payment system flexible,
extensible and easy to maintain.

============================================================
*/
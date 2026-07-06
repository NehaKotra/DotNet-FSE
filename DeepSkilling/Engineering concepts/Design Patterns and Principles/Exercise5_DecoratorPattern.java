/*
============================================================
CTS Deep Skilling

Exercise 5
Decorator Pattern

Problem Understanding

Decorator Pattern

The Decorator Pattern is a Structural Design Pattern
that allows additional functionalities to be added
to an object dynamically without modifying its
existing code.

Advantages

• Follows Open/Closed Principle.
• Flexible alternative to inheritance.
• Adds responsibilities dynamically.
• Easy to extend functionality.

Scenario

A notification system sends notifications through
different channels such as Email, SMS, and Slack.

Using the Decorator Pattern, multiple notification
channels can be combined dynamically.

============================================================
*/

// Component Interface

interface Notifier {

    void send(String message);

}

// Concrete Component

class EmailNotifier implements Notifier {

    @Override
    public void send(String message) {

        System.out.println("Email Notification : " + message);

    }

}

// Abstract Decorator

abstract class NotifierDecorator implements Notifier {

    protected Notifier notifier;

    public NotifierDecorator(Notifier notifier) {

        this.notifier = notifier;

    }

    @Override
    public void send(String message) {

        notifier.send(message);

    }

}

// SMS Decorator

class SMSNotifierDecorator extends NotifierDecorator {

    public SMSNotifierDecorator(Notifier notifier) {

        super(notifier);

    }

    @Override
    public void send(String message) {

        super.send(message);

        System.out.println("SMS Notification   : " + message);

    }

}

// Slack Decorator

class SlackNotifierDecorator extends NotifierDecorator {

    public SlackNotifierDecorator(Notifier notifier) {

        super(notifier);

    }

    @Override
    public void send(String message) {

        super.send(message);

        System.out.println("Slack Notification : " + message);

    }

}

// Test Class

public class Exercise5_DecoratorPattern {

    public static void main(String[] args) {

        Notifier emailNotifier =
                new EmailNotifier();

        System.out.println("Email Notification");
        emailNotifier.send("Project Submitted");

        System.out.println();

        Notifier emailSMS =
                new SMSNotifierDecorator(
                        new EmailNotifier());

        System.out.println("Email + SMS Notification");
        emailSMS.send("Project Submitted");

        System.out.println();

        Notifier allChannels =
                new SlackNotifierDecorator(
                        new SMSNotifierDecorator(
                                new EmailNotifier()));

        System.out.println("Email + SMS + Slack Notification");
        allChannels.send("Project Submitted");

    }

}

/*
============================================================
Output

Email Notification
Email Notification : Project Submitted

Email + SMS Notification
Email Notification : Project Submitted
SMS Notification   : Project Submitted

Email + SMS + Slack Notification
Email Notification : Project Submitted
SMS Notification   : Project Submitted
Slack Notification : Project Submitted

============================================================

Analysis

Advantages

• Functionality can be added dynamically.
• Avoids creating many subclasses.
• Promotes code reusability.
• Easy to extend notification channels.

Disadvantages

• Multiple decorator classes increase complexity.
• Debugging can become difficult with many layers.

Time Complexity

Notification Sending : O(n)

where n = Number of decorators used.

Space Complexity

O(n)

============================================================

Conclusion

The Decorator Pattern allows notification
functionalities to be added dynamically without
changing the original EmailNotifier class.

It provides a flexible and scalable approach for
supporting multiple notification channels.

============================================================
*/
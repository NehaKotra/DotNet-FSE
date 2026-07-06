/*
============================================================
CTS Deep Skilling

Exercise 7
Observer Pattern

Problem Understanding

Observer Pattern

The Observer Pattern is a Behavioral Design Pattern
that defines a one-to-many dependency between objects.

Whenever the Subject changes its state,
all registered Observers are notified automatically.

Advantages

• Loose coupling.
• Automatic notification.
• Easy to add/remove observers.
• Improves scalability.

Scenario

A Stock Market application notifies multiple clients
(Mobile App, Web App) whenever stock prices change.

============================================================
*/

import java.util.ArrayList;
import java.util.List;

// Observer Interface

interface Observer {

    void update(String stockName, double price);

}

// Subject Interface

interface Stock {

    void registerObserver(Observer observer);

    void deregisterObserver(Observer observer);

    void notifyObservers();

}

// Concrete Subject

class StockMarket implements Stock {

    private List<Observer> observers = new ArrayList<>();

    private String stockName;
    private double stockPrice;

    @Override
    public void registerObserver(Observer observer) {

        observers.add(observer);

    }

    @Override
    public void deregisterObserver(Observer observer) {

        observers.remove(observer);

    }

    @Override
    public void notifyObservers() {

        for (Observer observer : observers) {

            observer.update(stockName, stockPrice);

        }

    }

    public void setStock(String name, double price) {

        stockName = name;
        stockPrice = price;

        System.out.println("\nStock Updated");
        System.out.println("Stock : " + stockName);
        System.out.println("Price : ₹" + stockPrice);

        notifyObservers();

    }

}

// Mobile App Observer

class MobileApp implements Observer {

    @Override
    public void update(String stockName, double price) {

        System.out.println("Mobile App Notification");
        System.out.println(stockName + " price changed to ₹" + price);

    }

}

// Web App Observer

class WebApp implements Observer {

    @Override
    public void update(String stockName, double price) {

        System.out.println("Web App Notification");
        System.out.println(stockName + " price changed to ₹" + price);

    }

}

// Test Class

public class Exercise7_ObserverPattern {

    public static void main(String[] args) {

        StockMarket stockMarket = new StockMarket();

        Observer mobile = new MobileApp();
        Observer web = new WebApp();

        stockMarket.registerObserver(mobile);
        stockMarket.registerObserver(web);

        stockMarket.setStock("TCS", 3850.75);

        stockMarket.setStock("Infosys", 1675.50);

        stockMarket.deregisterObserver(web);

        System.out.println("\nAfter Removing Web App");

        stockMarket.setStock("Wipro", 510.25);

    }

}

/*
============================================================
Sample Output

Stock Updated
Stock : TCS
Price : ₹3850.75

Mobile App Notification
TCS price changed to ₹3850.75

Web App Notification
TCS price changed to ₹3850.75


Stock Updated
Stock : Infosys
Price : ₹1675.5

Mobile App Notification
Infosys price changed to ₹1675.5

Web App Notification
Infosys price changed to ₹1675.5


After Removing Web App

Stock Updated
Stock : Wipro
Price : ₹510.25

Mobile App Notification
Wipro price changed to ₹510.25

============================================================

Analysis

Working

1. Observers register with StockMarket.
2. Stock price changes.
3. StockMarket notifies all registered observers.
4. Each observer receives updated stock details.
5. Removed observers no longer receive updates.

------------------------------------------------------------

Advantages

• Loose coupling between Subject and Observers.
• Automatic notification mechanism.
• Easy to add new observer types.
• Supports event-driven programming.

Disadvantages

• Notification overhead if many observers exist.
• Debugging becomes difficult in complex systems.

------------------------------------------------------------

Time Complexity

Register Observer      : O(1)

Deregister Observer    : O(n)

Notify Observers       : O(n)

where n = Number of observers

Space Complexity

O(n)

============================================================

Conclusion

The Observer Pattern allows one object (StockMarket)
to notify multiple dependent objects automatically
whenever its state changes.

It is widely used in stock market systems,
chat applications, event handling, and notification
services.

============================================================
*/
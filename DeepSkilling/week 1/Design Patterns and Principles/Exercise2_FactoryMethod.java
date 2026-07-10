/*
============================================================
CTS Deep Skilling

Exercise 2
Factory Method Pattern

Problem Understanding

Factory Method Pattern

The Factory Method Pattern is a Creational Design Pattern
that creates objects without exposing the object creation
logic to the client.

Instead of creating objects directly using "new",
the client requests the factory to create the object.

Advantages

• Loose coupling
• Easy to extend
• Hides object creation
• Better code maintenance

Scenario

A Document Management System can create different types
of documents such as Word, PDF, and Excel.

============================================================
*/

// Document Interface

interface Document {

    void open();

}

// Concrete Products

class WordDocument implements Document {

    public void open() {

        System.out.println("Word Document Opened.");

    }

}

class PdfDocument implements Document {

    public void open() {

        System.out.println("PDF Document Opened.");

    }

}

class ExcelDocument implements Document {

    public void open() {

        System.out.println("Excel Document Opened.");

    }

}

// Abstract Factory

abstract class DocumentFactory {

    public abstract Document createDocument();

}

// Concrete Factories

class WordFactory extends DocumentFactory {

    public Document createDocument() {

        return new WordDocument();

    }

}

class PdfFactory extends DocumentFactory {

    public Document createDocument() {

        return new PdfDocument();

    }

}

class ExcelFactory extends DocumentFactory {

    public Document createDocument() {

        return new ExcelDocument();

    }

}

// Test Class

public class Exercise2_FactoryMethod {

    public static void main(String[] args) {

        DocumentFactory factory;

        factory = new WordFactory();
        Document doc1 = factory.createDocument();
        doc1.open();

        factory = new PdfFactory();
        Document doc2 = factory.createDocument();
        doc2.open();

        factory = new ExcelFactory();
        Document doc3 = factory.createDocument();
        doc3.open();

    }

}

/*
============================================================
Output

Word Document Opened.
PDF Document Opened.
Excel Document Opened.

============================================================

Analysis

Advantages

• Promotes loose coupling.
• Object creation is centralized.
• Easy to add new document types.
• Follows Open/Closed Principle.

Disadvantages

• More classes are required.
• Slightly increases project complexity.

Time Complexity

Object Creation : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Factory Method Pattern separates object creation
from object usage.

The client only communicates with the factory and
does not know how the object is created.

This makes the system flexible and easy to extend.

============================================================
*/
/*
============================================================
CTS Deep Skilling

Exercise 3
Builder Pattern

Problem Understanding

Builder Pattern

The Builder Pattern is a Creational Design Pattern
used to construct complex objects step by step.

Instead of creating an object with a long constructor,
the Builder Pattern allows optional attributes to be
added easily.

Advantages

• Improves code readability.
• Handles optional parameters.
• Avoids telescoping constructors.
• Creates immutable objects.

Scenario

A Computer can have different configurations
such as CPU, RAM, Storage and Graphics Card.

============================================================
*/

class Computer {

    // Attributes

    private String cpu;
    private int ram;
    private int storage;
    private String graphicsCard;

    // Private Constructor

    private Computer(Builder builder) {

        this.cpu = builder.cpu;
        this.ram = builder.ram;
        this.storage = builder.storage;
        this.graphicsCard = builder.graphicsCard;

    }

    // Display Method

    public void display() {

        System.out.println("Computer Configuration");
        System.out.println("--------------------------");
        System.out.println("CPU           : " + cpu);
        System.out.println("RAM           : " + ram + " GB");
        System.out.println("Storage       : " + storage + " GB");
        System.out.println("Graphics Card : " + graphicsCard);
        System.out.println();

    }

    // Static Nested Builder Class

    public static class Builder {

        private String cpu;
        private int ram;
        private int storage;
        private String graphicsCard;

        public Builder setCPU(String cpu) {

            this.cpu = cpu;
            return this;

        }

        public Builder setRAM(int ram) {

            this.ram = ram;
            return this;

        }

        public Builder setStorage(int storage) {

            this.storage = storage;
            return this;

        }

        public Builder setGraphicsCard(String graphicsCard) {

            this.graphicsCard = graphicsCard;
            return this;

        }

        public Computer build() {

            return new Computer(this);

        }

    }

}

public class Exercise3_BuilderPattern {

    public static void main(String[] args) {

        Computer gamingPC = new Computer.Builder()

                .setCPU("Intel Core i9")
                .setRAM(32)
                .setStorage(1000)
                .setGraphicsCard("NVIDIA RTX 4080")

                .build();

        Computer officePC = new Computer.Builder()

                .setCPU("Intel Core i5")
                .setRAM(16)
                .setStorage(512)
                .setGraphicsCard("Integrated Graphics")

                .build();

        gamingPC.display();

        officePC.display();

    }

}

/*
============================================================
Output

Computer Configuration
--------------------------
CPU           : Intel Core i9
RAM           : 32 GB
Storage       : 1000 GB
Graphics Card : NVIDIA RTX 4080

Computer Configuration
--------------------------
CPU           : Intel Core i5
RAM           : 16 GB
Storage       : 512 GB
Graphics Card : Integrated Graphics

============================================================

Analysis

Advantages

• Simplifies object creation.
• Supports optional parameters.
• Improves readability.
• Reduces constructor complexity.
• Easy to maintain.

Disadvantages

• More classes and code.
• Slightly increases project size.

Time Complexity

Object Creation : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Builder Pattern is ideal for creating complex
objects with multiple optional attributes.

It separates object construction from object
representation, making the code clean,
flexible and easy to maintain.

============================================================
*/
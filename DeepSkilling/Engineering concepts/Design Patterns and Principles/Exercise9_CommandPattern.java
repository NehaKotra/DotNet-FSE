/*
============================================================
CTS Deep Skilling

Exercise 9
Command Pattern

Problem Understanding

Command Pattern

The Command Pattern is a Behavioral Design Pattern
that encapsulates a request as an object.

It separates the object that invokes an operation
from the object that performs it.

Advantages

• Loose coupling.
• Easy to add new commands.
• Supports undo/redo operations.
• Improves flexibility.

Scenario

A Home Automation System controls a light
using a remote control.

============================================================
*/

// Command Interface

interface Command {

    void execute();

}

// Receiver

class Light {

    public void turnOn() {

        System.out.println("Light is ON");

    }

    public void turnOff() {

        System.out.println("Light is OFF");

    }

}

// Concrete Command - Light ON

class LightOnCommand implements Command {

    private Light light;

    public LightOnCommand(Light light) {

        this.light = light;

    }

    @Override
    public void execute() {

        light.turnOn();

    }

}

// Concrete Command - Light OFF

class LightOffCommand implements Command {

    private Light light;

    public LightOffCommand(Light light) {

        this.light = light;

    }

    @Override
    public void execute() {

        light.turnOff();

    }

}

// Invoker

class RemoteControl {

    private Command command;

    public void setCommand(Command command) {

        this.command = command;

    }

    public void pressButton() {

        if (command != null)

            command.execute();

        else

            System.out.println("No command assigned.");

    }

}

// Test Class

public class Exercise9_CommandPattern {

    public static void main(String[] args) {

        Light light = new Light();

        Command lightOn = new LightOnCommand(light);

        Command lightOff = new LightOffCommand(light);

        RemoteControl remote = new RemoteControl();

        System.out.println("Turning Light ON");

        remote.setCommand(lightOn);

        remote.pressButton();

        System.out.println();

        System.out.println("Turning Light OFF");

        remote.setCommand(lightOff);

        remote.pressButton();

    }

}

/*
============================================================
Sample Output

Turning Light ON

Light is ON

Turning Light OFF

Light is OFF

============================================================

Analysis

Working

1. RemoteControl acts as the Invoker.
2. Light acts as the Receiver.
3. Commands encapsulate actions.
4. RemoteControl executes commands without
   knowing implementation details.

------------------------------------------------------------

Advantages

• Loose coupling between sender and receiver.
• Easy to add new commands.
• Supports command queue and undo operations.
• Improves code maintainability.

Disadvantages

• More classes are required.
• Slight increase in complexity.

------------------------------------------------------------

Time Complexity

Set Command      : O(1)

Execute Command  : O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Command Pattern encapsulates requests as objects,
making the system flexible and extensible.

It is widely used in home automation systems,
GUI applications, menu actions, and remote controls.

============================================================
*/
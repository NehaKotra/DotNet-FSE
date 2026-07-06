/*
============================================================
CTS Deep Skilling

Exercise 6
Proxy Pattern

Problem Understanding

Proxy Pattern

The Proxy Pattern is a Structural Design Pattern
that provides a placeholder (proxy) for another object
to control access to it.

The proxy delays the creation of expensive objects until
they are actually needed (Lazy Initialization).

Advantages

• Lazy loading
• Improved performance
• Security
• Caching support

Scenario

An image viewer loads images from a remote server.
Images should only be loaded when required.

============================================================
*/

// Subject Interface

interface Image {

    void display();

}

// Real Subject

class RealImage implements Image {

    private String fileName;

    public RealImage(String fileName) {

        this.fileName = fileName;
        loadImage();

    }

    private void loadImage() {

        System.out.println("Loading image from remote server : " + fileName);

    }

    @Override
    public void display() {

        System.out.println("Displaying image : " + fileName);

    }

}

// Proxy Class

class ProxyImage implements Image {

    private String fileName;
    private RealImage realImage;

    public ProxyImage(String fileName) {

        this.fileName = fileName;

    }

    @Override
    public void display() {

        if (realImage == null) {

            realImage = new RealImage(fileName);

        }

        realImage.display();

    }

}

// Test Class

public class Exercise6_ProxyPattern {

    public static void main(String[] args) {

        Image image = new ProxyImage("Nature.jpg");

        System.out.println("First Display");

        image.display();

        System.out.println();

        System.out.println("Second Display");

        image.display();

    }

}

/*
============================================================
Output

First Display

Loading image from remote server : Nature.jpg
Displaying image : Nature.jpg

Second Display

Displaying image : Nature.jpg

============================================================

Analysis

Working

• Initially, ProxyImage does not create RealImage.

• During the first display(), RealImage is created
  and the image is loaded.

• During subsequent display() calls,
  the existing RealImage object is reused.

This demonstrates:

✔ Lazy Initialization
✔ Object Caching

------------------------------------------------------------

Advantages

• Improves performance.
• Saves memory.
• Supports lazy loading.
• Adds security and access control.

Disadvantages

• Additional layer increases complexity.
• Slight overhead due to proxy object.

------------------------------------------------------------

Time Complexity

Image Loading

First Call     : O(1)

Subsequent Call: O(1)

Space Complexity

O(1)

============================================================

Conclusion

The Proxy Pattern delays object creation until it is
actually required. This minimizes unnecessary resource
usage and improves application performance by reusing
the already created object.

============================================================
*/
/*
============================================================
CTS Deep Skilling

Exercise 2
E-Commerce Platform Search Function

Problem Understanding

Big O Notation
--------------
Big O notation is used to measure the efficiency of an
algorithm. It tells how the running time increases as the
input size increases.

Linear Search
-------------
Best Case    : O(1)
Average Case : O(n)
Worst Case   : O(n)

Binary Search
-------------
Best Case    : O(1)
Average Case : O(log n)
Worst Case   : O(log n)

Binary Search is much faster than Linear Search for
large datasets but requires the array to be sorted.

============================================================
*/

class Product {

    int productId;
    String productName;
    String category;

    Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    void display() {
        System.out.println("Product ID   : " + productId);
        System.out.println("Product Name : " + productName);
        System.out.println("Category     : " + category);
        System.out.println("-----------------------------");
    }
}

public class Exercise2_SearchAlgorithms {

    // Linear Search
    static Product linearSearch(Product[] products, int key) {

        for (Product product : products) {

            if (product.productId == key) {
                return product;
            }

        }

        return null;
    }

    // Binary Search
    static Product binarySearch(Product[] products, int key) {

        int low = 0;
        int high = products.length - 1;

        while (low <= high) {

            int mid = (low + high) / 2;

            if (products[mid].productId == key)
                return products[mid];

            if (products[mid].productId < key)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return null;
    }

    public static void main(String[] args) {

        // Array for Linear Search

        Product[] linearProducts = {

                new Product(103, "Mouse", "Accessories"),
                new Product(101, "Laptop", "Electronics"),
                new Product(105, "Printer", "Office"),
                new Product(104, "Monitor", "Electronics"),
                new Product(102, "Keyboard", "Accessories")

        };

        System.out.println("===== Linear Search =====");

        Product p1 = linearSearch(linearProducts, 104);

        if (p1 != null)
            p1.display();
        else
            System.out.println("Product Not Found");



        // Sorted Array for Binary Search

        Product[] binaryProducts = {

                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Keyboard", "Accessories"),
                new Product(103, "Mouse", "Accessories"),
                new Product(104, "Monitor", "Electronics"),
                new Product(105, "Printer", "Office")

        };

        System.out.println("\n===== Binary Search =====");

        Product p2 = binarySearch(binaryProducts, 104);

        if (p2 != null)
            p2.display();
        else
            System.out.println("Product Not Found");

    }
}

/*
============================================================
Analysis

Linear Search
-------------
Advantages
- Works on sorted and unsorted arrays.
- Easy to implement.

Disadvantages
- Slow for large datasets.

Time Complexity
Best Case    : O(1)
Average Case : O(n)
Worst Case   : O(n)

------------------------------------------------------------

Binary Search
-------------
Advantages
- Very fast searching.
- Suitable for large datasets.

Disadvantages
- Works only on sorted arrays.

Time Complexity
Best Case    : O(1)
Average Case : O(log n)
Worst Case   : O(log n)

------------------------------------------------------------

Conclusion

For an e-commerce platform with thousands of products,
Binary Search is preferred because it searches much faster
than Linear Search. However, the data must be sorted before
Binary Search can be used.

============================================================
*/
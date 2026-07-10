/*
============================================================
CTS Deep Skilling
Exercise 1 - Inventory Management System
============================================================

Problem Understanding:
Data Structures and Algorithms are essential for handling
large inventories because they allow fast storage, retrieval,
update, and deletion of products. As the number of products
increases, efficient algorithms improve performance and
reduce execution time.

Data Structure Used:
HashMap<Integer, Product>

Reason:
- Fast insertion
- Fast searching
- Fast updating
- Fast deletion
using Product ID as the key.

Operations Implemented:
1. Add Product
2. Update Product
3. Delete Product
4. Display Products

Time Complexity Analysis

Add Product       : O(1)
Update Product    : O(1)
Delete Product    : O(1)
Search Product    : O(1)
Display Products  : O(n)

Optimization:
Using HashMap avoids traversing the entire collection.
Product ID acts as a unique key, making operations very
efficient compared to arrays or linked lists.

============================================================
*/



import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

class Product {
    int productId;
    String productName;
    int quantity;
    double price;

    public Product(int productId, String productName, int quantity, double price) {
        this.productId = productId;
        this.productName = productName;
        this.quantity = quantity;
        this.price = price;
    }

    public void display() {
        System.out.println("--------------------------------");
        System.out.println("Product ID   : " + productId);
        System.out.println("Product Name : " + productName);
        System.out.println("Quantity     : " + quantity);
        System.out.println("Price        : " + price);
    }
}

public class Exercise1_InventoryManagement {

    static HashMap<Integer, Product> inventory = new HashMap<>();

    // Add Product
    public static void addProduct(Product product) {
        inventory.put(product.productId, product);
        System.out.println("Product Added Successfully.");
    }

    // Update Product
    public static void updateProduct(int id, int quantity, double price) {
        Product product = inventory.get(id);

        if (product != null) {
            product.quantity = quantity;
            product.price = price;
            System.out.println("Product Updated Successfully.");
        } else {
            System.out.println("Product Not Found.");
        }
    }

    // Delete Product
    public static void deleteProduct(int id) {
        if (inventory.remove(id) != null) {
            System.out.println("Product Deleted Successfully.");
        } else {
            System.out.println("Product Not Found.");
        }
    }

    // Display Products
    public static void displayProducts() {
        if (inventory.isEmpty()) {
            System.out.println("Inventory is Empty.");
            return;
        }

        System.out.println("\nInventory Details");

        for (Map.Entry<Integer, Product> entry : inventory.entrySet()) {
            entry.getValue().display();
        }
    }

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        while (true) {

            System.out.println("\n===== Inventory Management System =====");
            System.out.println("1. Add Product");
            System.out.println("2. Update Product");
            System.out.println("3. Delete Product");
            System.out.println("4. Display Products");
            System.out.println("5. Exit");

            System.out.print("Enter Choice: ");
            int choice = sc.nextInt();

            switch (choice) {

                case 1:
                    System.out.print("Enter Product ID: ");
                    int id = sc.nextInt();

                    sc.nextLine();

                    System.out.print("Enter Product Name: ");
                    String name = sc.nextLine();

                    System.out.print("Enter Quantity: ");
                    int qty = sc.nextInt();

                    System.out.print("Enter Price: ");
                    double price = sc.nextDouble();

                    addProduct(new Product(id, name, qty, price));
                    break;

                case 2:
                    System.out.print("Enter Product ID: ");
                    id = sc.nextInt();

                    System.out.print("Enter New Quantity: ");
                    qty = sc.nextInt();

                    System.out.print("Enter New Price: ");
                    price = sc.nextDouble();

                    updateProduct(id, qty, price);
                    break;

                case 3:
                    System.out.print("Enter Product ID: ");
                    id = sc.nextInt();

                    deleteProduct(id);
                    break;

                case 4:
                    displayProducts();
                    break;

                case 5:
                    System.out.println("Thank You!");
                    sc.close();
                    System.exit(0);

                default:
                    System.out.println("Invalid Choice.");
            }
        }
    }
}
/*
============================================================
CTS Deep Skilling

Exercise 3
Sorting Customer Orders

Problem Understanding

Sorting customer orders helps prioritize high-value orders,
making order processing faster and more efficient.

Sorting Algorithms

1. Bubble Sort
- Repeatedly compares adjacent elements.
- Swaps them if they are in the wrong order.

2. Insertion Sort
- Inserts each element into its correct position.
- Efficient for small or nearly sorted datasets.

3. Quick Sort
- Uses a pivot element.
- Partitions the array into smaller subarrays.
- Recursively sorts the partitions.

4. Merge Sort
- Divides the array into halves.
- Sorts each half recursively.
- Merges the sorted halves.

============================================================
*/

class Order {

    int orderId;
    String customerName;
    double totalPrice;

    Order(int orderId, String customerName, double totalPrice) {
        this.orderId = orderId;
        this.customerName = customerName;
        this.totalPrice = totalPrice;
    }

    void display() {
        System.out.println(orderId + "\t"
                + customerName + "\t"
                + totalPrice);
    }
}

public class Exercise3_SortingOrders {

    // Display Orders

    static void display(Order[] orders) {

        System.out.println("---------------------------------------");
        System.out.println("ID\tCustomer\tPrice");
        System.out.println("---------------------------------------");

        for (Order order : orders) {
            order.display();
        }

        System.out.println();
    }

    // Bubble Sort

    static void bubbleSort(Order[] orders) {

        int n = orders.length;

        for (int i = 0; i < n - 1; i++) {

            for (int j = 0; j < n - i - 1; j++) {

                if (orders[j].totalPrice > orders[j + 1].totalPrice) {

                    Order temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;

                }
            }
        }
    }

    // Quick Sort

    static void quickSort(Order[] orders, int low, int high) {

        if (low < high) {

            int pivot = partition(orders, low, high);

            quickSort(orders, low, pivot - 1);
            quickSort(orders, pivot + 1, high);

        }
    }

    static int partition(Order[] orders, int low, int high) {

        double pivot = orders[high].totalPrice;

        int i = low - 1;

        for (int j = low; j < high; j++) {

            if (orders[j].totalPrice < pivot) {

                i++;

                Order temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;

            }
        }

        Order temp = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = temp;

        return i + 1;
    }

    public static void main(String[] args) {

        Order[] bubbleOrders = {

                new Order(101, "Alice", 4500),
                new Order(102, "Bob", 2100),
                new Order(103, "Charlie", 6700),
                new Order(104, "David", 1500),
                new Order(105, "Emily", 5200)

        };

        System.out.println("Original Orders");
        display(bubbleOrders);

        bubbleSort(bubbleOrders);

        System.out.println("After Bubble Sort");
        display(bubbleOrders);

        Order[] quickOrders = {

                new Order(101, "Alice", 4500),
                new Order(102, "Bob", 2100),
                new Order(103, "Charlie", 6700),
                new Order(104, "David", 1500),
                new Order(105, "Emily", 5200)

        };

        quickSort(quickOrders, 0, quickOrders.length - 1);

        System.out.println("After Quick Sort");
        display(quickOrders);

    }
}

/*
============================================================
Analysis

Bubble Sort

Advantages
----------
- Simple to understand.
- Easy to implement.

Disadvantages
-------------
- Slow for large datasets.
- Performs many unnecessary swaps.

Time Complexity

Best Case    : O(n)
Average Case : O(n²)
Worst Case   : O(n²)

------------------------------------------------------------

Quick Sort

Advantages
----------
- Very efficient for large datasets.
- Faster than Bubble Sort.
- Uses Divide and Conquer technique.

Disadvantages
-------------
- Worst case occurs when pivot selection is poor.

Time Complexity

Best Case    : O(n log n)
Average Case : O(n log n)
Worst Case   : O(n²)

------------------------------------------------------------

Comparison

Bubble Sort
- Simple
- Slow
- Suitable only for small datasets

Quick Sort
- Fast
- Efficient
- Suitable for large datasets

------------------------------------------------------------

Conclusion

Quick Sort is generally preferred over Bubble Sort
because its average time complexity is O(n log n),
making it much faster for sorting large numbers of
customer orders.

============================================================
*/
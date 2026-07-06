/*
============================================================
CTS Deep Skilling

Exercise 6
Library Management System

Problem Understanding

Search Algorithms

1. Linear Search
----------------
Linear Search checks each book one by one until the
required title is found.

Advantages
- Simple to implement.
- Works on sorted and unsorted data.

Disadvantages
- Slow for large datasets.

2. Binary Search
----------------
Binary Search repeatedly divides the sorted array into
two halves until the required book is found.

Advantages
- Very fast for large datasets.

Disadvantages
- Requires the array to be sorted before searching.

============================================================
*/

class Book {

    int bookId;
    String title;
    String author;

    Book(int bookId, String title, String author) {

        this.bookId = bookId;
        this.title = title;
        this.author = author;

    }

    void display() {

        System.out.println("Book ID : " + bookId);
        System.out.println("Title   : " + title);
        System.out.println("Author  : " + author);
        System.out.println("-----------------------------");

    }

}

public class Exercise6_LibraryManagement {

    // Linear Search

    static Book linearSearch(Book[] books, String title) {

        for (Book book : books) {

            if (book.title.equalsIgnoreCase(title))

                return book;

        }

        return null;

    }

    // Binary Search

    static Book binarySearch(Book[] books, String title) {

        int low = 0;
        int high = books.length - 1;

        while (low <= high) {

            int mid = (low + high) / 2;

            int compare = books[mid].title.compareToIgnoreCase(title);

            if (compare == 0)

                return books[mid];

            else if (compare < 0)

                low = mid + 1;

            else

                high = mid - 1;

        }

        return null;

    }

    public static void main(String[] args) {

        // Unsorted array for Linear Search

        Book[] library1 = {

                new Book(103, "Python", "Guido"),
                new Book(101, "Java", "James Gosling"),
                new Book(105, "Machine Learning", "Tom Mitchell"),
                new Book(102, "C Programming", "Dennis Ritchie"),
                new Book(104, "Data Structures", "Mark Allen")

        };

        System.out.println("===== Linear Search =====");

        Book b1 = linearSearch(library1, "Java");

        if (b1 != null)

            b1.display();

        else

            System.out.println("Book Not Found");



        // Sorted array for Binary Search

        Book[] library2 = {

                new Book(102, "C Programming", "Dennis Ritchie"),
                new Book(104, "Data Structures", "Mark Allen"),
                new Book(101, "Java", "James Gosling"),
                new Book(105, "Machine Learning", "Tom Mitchell"),
                new Book(103, "Python", "Guido")

        };

        System.out.println("\n===== Binary Search =====");

        Book b2 = binarySearch(library2, "Machine Learning");

        if (b2 != null)

            b2.display();

        else

            System.out.println("Book Not Found");

    }

}

/*
============================================================
Analysis

Linear Search

Time Complexity

Best Case    : O(1)
Average Case : O(n)
Worst Case   : O(n)

Advantages
- Works on sorted and unsorted data.
- Easy to implement.

Disadvantages
- Slow for large datasets.

------------------------------------------------------------

Binary Search

Time Complexity

Best Case    : O(1)
Average Case : O(log n)
Worst Case   : O(log n)

Advantages
- Very fast searching.
- Efficient for large datasets.

Disadvantages
- Requires sorted data.

------------------------------------------------------------

Comparison

Linear Search
- Suitable for small or unsorted datasets.

Binary Search
- Suitable for large sorted datasets.

------------------------------------------------------------

Conclusion

Linear Search is preferred when the number of books is
small or the data is unsorted.

Binary Search is preferred for large libraries because
it searches much faster, provided the books are stored
in sorted order.

============================================================
*/
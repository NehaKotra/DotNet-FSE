/*
============================================================
CTS Deep Skilling

Exercise 7
Financial Forecasting

Problem Understanding

Recursion

Recursion is a programming technique in which a method
calls itself to solve a smaller version of the same problem.

It is useful for problems that can be divided into
smaller sub-problems.

In this exercise, recursion is used to calculate the
future value of an investment based on a fixed annual
growth rate.

Formula

Future Value = Present Value × (1 + Growth Rate)^Years

============================================================
*/

public class Exercise7_FinancialForecasting {

    // Recursive Method

    static double futureValue(double presentValue,
                              double growthRate,
                              int years) {

        if (years == 0)

            return presentValue;

        return futureValue(presentValue,
                           growthRate,
                           years - 1)
                * (1 + growthRate);

    }

    public static void main(String[] args) {

        double presentValue = 10000;
        double growthRate = 0.10;     // 10%
        int years = 5;

        double result = futureValue(
                presentValue,
                growthRate,
                years);

        System.out.println("Present Value : " + presentValue);
        System.out.println("Growth Rate   : " + (growthRate * 100) + "%");
        System.out.println("Years         : " + years);
        System.out.println("Future Value  : " + result);

    }

}

/*
============================================================
Analysis

Working

For every recursive call,
the number of years decreases by one.

Example

futureValue(10000,0.10,5)

↓

futureValue(10000,0.10,4)

↓

futureValue(10000,0.10,3)

↓

futureValue(10000,0.10,2)

↓

futureValue(10000,0.10,1)

↓

futureValue(10000,0.10,0)

↓

Returns Present Value

============================================================

Time Complexity

T(n) = T(n-1) + O(1)

Best Case
----------
O(1)
(Years = 0)

Worst Case
-----------
O(n)

where n = Number of Years

Space Complexity
----------------
O(n)

because each recursive call is stored
in the function call stack.

============================================================

Optimization

The recursive solution can be optimized using:

1. Memoization
   - Store previously computed values.
   - Avoid repeated calculations.

2. Dynamic Programming
   - Compute values iteratively.
   - Eliminates recursion overhead.

3. Iterative Approach
   - Uses loops instead of recursion.
   - Space Complexity becomes O(1).

============================================================

Conclusion

Recursion provides a simple and elegant solution for
financial forecasting. However, for large numbers of
years, an iterative or dynamic programming approach is
more efficient because it reduces memory usage and
avoids excessive recursive calls.

============================================================
*/
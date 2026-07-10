using System;

namespace MathLibrary
{
    public class MathLibrary
    {
        private int result;

        public int GetResult
        {
            get { return result; }
        }

        public int Addition(int a, int b)
        {
            result = a + b;
            return result;
        }

        public int Subtraction(int a, int b)
        {
            result = a - b;
            return result;
        }

        public int Multiplication(int a, int b)
        {
            result = a * b;
            return result;
        }

        public int Division(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Division by zero");

            result = a / b;
            return result;
        }

        public void AllClear()
        {
            result = 0;
        }
    }
}
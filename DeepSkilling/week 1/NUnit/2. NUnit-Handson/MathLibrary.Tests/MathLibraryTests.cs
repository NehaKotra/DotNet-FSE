/*
============================================================
CTS Deep Skilling

NUnit Handson - Exercise 2

Commands
--------

dotnet new nunit -n MathLibrary.Tests

dotnet add reference ../MathLibrary/MathLibrary.csproj

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run

dotnet test

============================================================
*/

using NUnit.Framework;
using System;
using MathLibrary;

namespace MathLibrary.Tests
{
    [TestFixture]
    public class MathLibraryTests
    {
        private MathLibrary.MathLibrary math;

        [SetUp]
        public void Init()
        {
            math = new MathLibrary.MathLibrary();
        }

        [TearDown]
        public void Cleanup()
        {
            math = null;
        }

        //==============================
        // Subtraction
        //==============================

        [TestCase(10, 5, 5)]
        [TestCase(20, 10, 10)]
        [TestCase(-5, -5, 0)]
        public void TestSubtraction(int a, int b, int expected)
        {
            int actual = math.Subtraction(a, b);

            Assert.AreEqual(expected, actual);
        }

        //==============================
        // Multiplication
        //==============================

        [TestCase(2, 3, 6)]
        [TestCase(5, 5, 25)]
        [TestCase(-2, 5, -10)]
        public void TestMultiplication(int a, int b, int expected)
        {
            int actual = math.Multiplication(a, b);

            Assert.AreEqual(expected, actual);
        }

        //==============================
        // Division
        //==============================

        [TestCase(20, 4, 5)]
        [TestCase(15, 3, 5)]
        public void TestDivision(int a, int b, int expected)
        {
            int actual = math.Division(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDivisionByZero()
        {
            try
            {
                math.Division(10, 0);

                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Division by zero", ex.Message);

                Assert.IsInstanceOf<ArgumentException>(ex);
            }
        }

        //==============================
        // Void Method
        //==============================

        [Test]
        public void TestAddAndClear()
        {
            math.Addition(20, 30);

            Assert.AreEqual(50, math.GetResult);

            math.AllClear();

            Assert.AreEqual(0, math.GetResult);
        }
    }
}

/*
============================================================

Analysis

Attributes Used

[TestFixture]

Marks the class as a test class.

-----------------------------------

[TestCase]

Executes the same test with
multiple input values.

-----------------------------------

[SetUp]

Runs before every test.

-----------------------------------

[TearDown]

Runs after every test.

-----------------------------------

Assert.AreEqual()

Compares expected and actual values.

-----------------------------------

Assert.Fail()

Fails the test with a custom message.

-----------------------------------

try-catch

Used to verify exception type and message.

============================================================
*/
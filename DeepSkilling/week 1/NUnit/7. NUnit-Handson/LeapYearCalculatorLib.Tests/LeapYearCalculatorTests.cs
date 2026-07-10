/*
============================================================
CTS Deep Skilling

NUnit Handson - Leap Year Calculator

Commands
--------

Create Test Project

dotnet new nunit -n LeapYearCalculatorLib.Tests

Add Reference

dotnet add reference ../LeapYearCalculatorLib/LeapYearCalculatorLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator calculator;

        [SetUp]
        public void Init()
        {
            calculator = new LeapYearCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        //--------------------------------------------------
        // Parameterized Test Cases
        //--------------------------------------------------

        [TestCase(2000, 1)]
        [TestCase(2024, 1)]
        [TestCase(1900, 0)]
        [TestCase(2023, 0)]
        [TestCase(1752, -1)]
        [TestCase(10000, -1)]
        [TestCase(1753, 0)]
        [TestCase(9999, 0)]
        public void CheckLeapYear_ValidInputs_ReturnsExpectedResult(
            int year,
            int expected)
        {
            int actual = calculator.CheckLeapYear(year);

            Assert.That(actual, Is.EqualTo(expected));
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

[SetUp]

Runs before every test.

-----------------------------------

[TearDown]

Runs after every test.

-----------------------------------

[TestCase]

Allows multiple test inputs using a
single test method.

------------------------------------------------------------

Test Cases Covered

✔ Leap Year

✔ Non-Leap Year

✔ Lower Invalid Boundary

✔ Upper Invalid Boundary

✔ Boundary Value 1753

✔ Boundary Value 9999

------------------------------------------------------------

Advantages

• Less code

• Better readability

• Easier maintenance

• Parameterized testing

============================================================
*/
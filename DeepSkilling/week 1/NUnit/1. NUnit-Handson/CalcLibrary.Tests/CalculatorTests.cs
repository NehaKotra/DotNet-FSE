/*
============================================================
CTS Deep Skilling

NUnit Handson

Commands
--------

Create Test Project

dotnet new nunit -n CalcLibrary.Tests

Add Reference

dotnet add reference ../CalcLibrary/CalcLibrary.csproj

Install NUnit

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [TestCase(10, 20, 30)]
        [TestCase(15, 25, 40)]
        [TestCase(-5, 10, 5)]
        [TestCase(0, 0, 0)]
        public void Addition_ReturnsExpectedResult(
            int num1,
            int num2,
            int expected)
        {
            int actual = calculator.Addition(num1, num2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Ignore("Demonstration of Ignore Attribute")]
        [Test]
        public void Ignored_Test()
        {
            Assert.Pass();
        }
    }
}

/*
============================================================

Analysis

Attributes Used

[TestFixture]

Marks the class as a test class.

------------------------------------

[SetUp]

Runs before every test method.

------------------------------------

[TearDown]

Runs after every test method.

------------------------------------

[Test]

Marks a method as a test.

------------------------------------

[TestCase]

Executes the same test with
multiple input values.

------------------------------------

[Ignore]

Skips execution of a test.

Advantages

• Automated testing

• Faster execution

• Reusable test cases

• Easy maintenance

============================================================
*/
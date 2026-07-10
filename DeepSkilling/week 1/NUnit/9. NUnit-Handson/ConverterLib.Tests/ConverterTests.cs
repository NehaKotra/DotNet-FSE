/*
============================================================
CTS Deep Skilling

NUnit Handson 9 - Moq

Commands
--------

Create Test Project

dotnet new nunit -n ConverterLib.Tests

Add Reference

dotnet add reference ../ConverterLib/ConverterLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

dotnet add package Moq

Run Tests

dotnet test

============================================================
*/

using ConverterLib;
using Moq;
using NUnit.Framework;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> exchangeRateMock;
        private Converter converter;

        [SetUp]
        public void Init()
        {
            exchangeRateMock =
                new Mock<IDollarToEuroExchangeRateFeed>();

            converter =
                new Converter(exchangeRateMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            converter = null;
            exchangeRateMock = null;
        }

        //-----------------------------------------------------
        // Test 1
        //-----------------------------------------------------

        [Test]
        public void USDToEuro_ValidAmount_ReturnsExpectedValue()
        {
            exchangeRateMock

                .Setup(x => x.GetExchangeRate())

                .Returns(0.80M);

            decimal result = converter.USDToEuro(100);

            Assert.That(result, Is.EqualTo(80));
        }

        //-----------------------------------------------------
        // Test 2
        //-----------------------------------------------------

        [Test]
        public void USDToEuro_ZeroDollar_ReturnsZero()
        {
            exchangeRateMock

                .Setup(x => x.GetExchangeRate())

                .Returns(0.80M);

            decimal result = converter.USDToEuro(0);

            Assert.That(result, Is.EqualTo(0));
        }

        //-----------------------------------------------------
        // Test 3
        //-----------------------------------------------------

        [Test]
        public void USDToEuro_DifferentRate_ReturnsExpectedValue()
        {
            exchangeRateMock

                .Setup(x => x.GetExchangeRate())

                .Returns(0.90M);

            decimal result = converter.USDToEuro(200);

            Assert.That(result, Is.EqualTo(180));
        }
    }
}

/*
============================================================

Analysis

Dependency

IDollarToEuroExchangeRateFeed

is mocked using Moq.

------------------------------------------------------------

Mock Setup

exchangeRateMock

.Setup(x => x.GetExchangeRate())

.Returns(0.80M);

------------------------------------------------------------

Advantages

• No external service call.

• Faster execution.

• Isolated unit testing.

• Predictable results.

------------------------------------------------------------

Assertions

Assert.That()

------------------------------------------------------------

Frameworks Used

✔ NUnit

✔ Moq

============================================================
*/
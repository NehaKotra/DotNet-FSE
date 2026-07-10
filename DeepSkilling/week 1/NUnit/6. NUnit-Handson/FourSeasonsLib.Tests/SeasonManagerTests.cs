/*
============================================================
CTS Deep Skilling

NUnit Handson - TestCaseSource

Commands
--------

Create Test Project

dotnet new nunit -n FourSeasonsLib.Tests

Add Reference

dotnet add reference ../FourSeasonsLib/FourSeasonsLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

dotnet add package Moq

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using FourSeasonsLib;
using System.Collections;

namespace FourSeasonsLib.Tests
{
    [TestFixture]
    public class SeasonManagerTests
    {
        private SeasonManager seasonManager;

        [SetUp]
        public void Init()
        {
            seasonManager = new SeasonManager();
        }

        [TearDown]
        public void Cleanup()
        {
            seasonManager = null;
        }

        //-----------------------------------------------------
        // TestCaseSource (Straight Forward)
        //-----------------------------------------------------

        public static IEnumerable SeasonTestData
        {
            get
            {
                yield return new TestCaseData("February", "Spring");
                yield return new TestCaseData("March", "Spring");
                yield return new TestCaseData("April", "Summer");
                yield return new TestCaseData("June", "Summer");
                yield return new TestCaseData("July", "Monsoon");
                yield return new TestCaseData("August", "Monsoon");
                yield return new TestCaseData("October", "Autumn");
                yield return new TestCaseData("November", "Autumn");
                yield return new TestCaseData("December", "Winter");
                yield return new TestCaseData("January", "Winter");
            }
        }

        [Test]
        [TestCaseSource(nameof(SeasonTestData))]
        public void GetSeason_ValidMonth_ReturnsExpectedSeason(
            string month,
            string expected)
        {
            string actual = seasonManager.GetSeason(month);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //-----------------------------------------------------
        // Invalid Month
        //-----------------------------------------------------

        [Test]
        public void GetSeason_InvalidMonth_ThrowsArgumentException()
        {
            var ex = Assert.Throws<System.ArgumentException>(() =>
                seasonManager.GetSeason("Hello"));

            Assert.That(ex.Message, Is.EqualTo("Invalid month"));
        }
    }
}

/*
============================================================

Analysis

Attributes Used

[TestFixture]

[SetUp]

[TearDown]

[Test]

[TestCaseSource]

------------------------------------------------------------

Benefits of TestCaseSource

• Avoids duplicate test methods.

• Easy maintenance.

• Supports large datasets.

• Improves readability.

------------------------------------------------------------

Assertions

Assert.That()

Assert.Throws<ArgumentException>()

============================================================
*/
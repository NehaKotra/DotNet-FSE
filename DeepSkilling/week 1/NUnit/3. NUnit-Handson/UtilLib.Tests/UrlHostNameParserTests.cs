/*
============================================================
CTS Deep Skilling

NUnit Handson - Exercise 3

Commands
--------

Create Test Project

dotnet new nunit -n UtilLib.Tests

Add Reference

dotnet add reference ../UtilLib/UtilLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser parser;

        [SetUp]
        public void Init()
        {
            parser = new UrlHostNameParser();
        }

        [TearDown]
        public void Cleanup()
        {
            parser = null;
        }

        //----------------------------------------------------
        // Valid URL
        //----------------------------------------------------

        [Test]
        public void ParseHostName_ValidUrl_ReturnsHostName()
        {
            string result =
                parser.ParseHostName("https://www.google.com/search");

            Assert.That(result, Is.EqualTo("www.google.com"));
        }

        //----------------------------------------------------
        // Invalid URL
        //----------------------------------------------------

        [Test]
        public void ParseHostName_InvalidUrl_ReturnsEmptyString()
        {
            string result =
                parser.ParseHostName("google.com");

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        //----------------------------------------------------
        // Empty URL
        //----------------------------------------------------

        [Test]
        public void ParseHostName_EmptyString_ReturnsEmptyString()
        {
            string result =
                parser.ParseHostName("");

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        //----------------------------------------------------
        // Null URL
        //----------------------------------------------------

        [Test]
        public void ParseHostName_Null_ReturnsEmptyString()
        {
            string result =
                parser.ParseHostName(null);

            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}

/*
============================================================

Analysis

Naming Convention

UnitUnderTest_Scenario_ExpectedOutcome

Examples

ParseHostName_ValidUrl_ReturnsHostName

ParseHostName_InvalidUrl_ReturnsEmptyString

------------------------------------------------------------

Assertions

Assert.That()

Used to compare expected and actual values.

------------------------------------------------------------

Execution Paths Covered

✔ Valid URL

✔ Invalid URL

✔ Empty String

✔ Null Input

------------------------------------------------------------

Advantages

• Single Assertion Rule followed.

• Independent test methods.

• Easy maintenance.

• Automated testing.

============================================================
*/
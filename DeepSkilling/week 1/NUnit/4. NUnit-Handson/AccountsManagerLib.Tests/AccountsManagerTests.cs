/*
============================================================
CTS Deep Skilling

NUnit Handson - Exercise 4

Commands
--------

Create Test Project

dotnet new nunit -n AccountsManagerLib.Tests

Add Reference

dotnet add reference ../AccountsManagerLib/AccountsManagerLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using System;
using NUnit.Framework;
using AccountsManagerLib;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class AccountsManagerTests
    {
        private AccountsManager manager;

        [SetUp]
        public void Init()
        {
            manager = new AccountsManager();
        }

        [TearDown]
        public void Cleanup()
        {
            manager = null;
        }

        //----------------------------------------------------
        // Valid Login - User 11
        //----------------------------------------------------

        [Test]
        public void Login_ValidUser11_ReturnsWelcomeMessage()
        {
            string result = manager.Login(
                "user_11",
                "secret@user11");

            Assert.That(result,
                Is.EqualTo("Welcome user_11!!!"));
        }

        //----------------------------------------------------
        // Valid Login - User 22
        //----------------------------------------------------

        [Test]
        public void Login_ValidUser22_ReturnsWelcomeMessage()
        {
            string result = manager.Login(
                "user_22",
                "secret@user22");

            Assert.That(result,
                Is.EqualTo("Welcome user_22!!!"));
        }

        //----------------------------------------------------
        // Invalid Login
        //----------------------------------------------------

        [Test]
        public void Login_InvalidCredentials_ReturnsErrorMessage()
        {
            string result = manager.Login(
                "user_33",
                "wrongpassword");

            Assert.That(result,
                Is.EqualTo("Invalid user id/password"));
        }

        //----------------------------------------------------
        // Empty User Id
        //----------------------------------------------------

        [Test]
        public void Login_EmptyUserId_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                manager.Login("", "secret@user11"));

            Assert.That(ex.Message,
                Is.EqualTo("User id and password are required."));
        }

        //----------------------------------------------------
        // Empty Password
        //----------------------------------------------------

        [Test]
        public void Login_EmptyPassword_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                manager.Login("user_11", ""));

            Assert.That(ex.Message,
                Is.EqualTo("User id and password are required."));
        }

        //----------------------------------------------------
        // Null User Id
        //----------------------------------------------------

        [Test]
        public void Login_NullUserId_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                manager.Login(null, "secret@user11"));

            Assert.That(ex.Message,
                Is.EqualTo("User id and password are required."));
        }

        //----------------------------------------------------
        // Null Password
        //----------------------------------------------------

        [Test]
        public void Login_NullPassword_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                manager.Login("user_11", null));

            Assert.That(ex.Message,
                Is.EqualTo("User id and password are required."));
        }
    }
}

/*
============================================================

Analysis

Test Methods

✔ Valid Login User 11

✔ Valid Login User 22

✔ Invalid Credentials

✔ Empty User Id

✔ Empty Password

✔ Null User Id

✔ Null Password

------------------------------------------------------------

Attributes Used

[TestFixture]

[SetUp]

[TearDown]

[Test]

------------------------------------------------------------

Assertions

Assert.That()

Assert.Throws<ArgumentException>()

------------------------------------------------------------

Naming Convention

UnitUnderTest_Scenario_ExpectedOutcome

Examples

Login_ValidUser11_ReturnsWelcomeMessage

Login_InvalidCredentials_ReturnsErrorMessage

============================================================
*/
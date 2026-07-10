/*
============================================================
CTS Deep Skilling

NUnit Handson - UserManager

Commands
--------

Create Test Project

dotnet new nunit -n UserManagerLib.Tests

Add Reference

dotnet add reference ../UserManagerLib/UserManagerLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using System;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager manager;

        [SetUp]
        public void Init()
        {
            manager = new UserManager();
        }

        [TearDown]
        public void Cleanup()
        {
            manager = null;
        }

        //----------------------------------------------------
        // Happy Path
        //----------------------------------------------------

        [Test]
        public void CreateUser_ValidPAN_ReturnsSuccessMessage()
        {
            User user = new User
            {
                PANCardNo = "ABCDE1234F"
            };

            string result = manager.CreateUser(user);

            Assert.That(result,
                Is.EqualTo("User Created Successfully"));
        }

        //----------------------------------------------------
        // Null User
        //----------------------------------------------------

        [Test]
        public void CreateUser_NullUser_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
                manager.CreateUser(null));

            Assert.That(ex.Message,
                Is.EqualTo("PAN Card Number is required."));
        }

        //----------------------------------------------------
        // Empty PAN
        //----------------------------------------------------

        [Test]
        public void CreateUser_EmptyPAN_ThrowsNullReferenceException()
        {
            User user = new User
            {
                PANCardNo = ""
            };

            var ex = Assert.Throws<NullReferenceException>(() =>
                manager.CreateUser(user));

            Assert.That(ex.Message,
                Is.EqualTo("PAN Card Number is required."));
        }

        //----------------------------------------------------
        // Invalid PAN Length
        //----------------------------------------------------

        [Test]
        public void CreateUser_InvalidPANLength_ThrowsFormatException()
        {
            User user = new User
            {
                PANCardNo = "ABC123"
            };

            var ex = Assert.Throws<FormatException>(() =>
                manager.CreateUser(user));

            Assert.That(ex.Message,
                Is.EqualTo("PAN Card Number should contain exactly 10 characters."));
        }
    }
}

/*
============================================================

Analysis

Test Cases Covered

✔ Valid PAN

✔ Null User

✔ Empty PAN

✔ Invalid PAN Length

------------------------------------------------------------

Exceptions

NullReferenceException

• User is null

• PAN is null or empty

------------------------------------------------------------

FormatException

• PAN length is not 10 characters

------------------------------------------------------------

Assertions Used

Assert.That()

Assert.Throws<NullReferenceException>()

Assert.Throws<FormatException>()

============================================================
*/
/*
============================================================
CTS Deep Skilling

NUnit Handson - CollectionAssert

Commands

Create Test Project

dotnet new nunit -n CollectionsLib.Tests

Add Reference

dotnet add reference ../CollectionsLib/CollectionsLib.csproj

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

Run Tests

dotnet test

============================================================
*/

using NUnit.Framework;
using CollectionsLib;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager manager;

        [SetUp]
        public void Init()
        {
            manager = new EmployeeManager();
        }

        [TearDown]
        public void Cleanup()
        {
            manager = null;
        }

        //--------------------------------------------------
        // Scenario 1
        //--------------------------------------------------

        [Test]
        public void GetEmployees_NoNullValues_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            CollectionAssert.AllItemsAreNotNull(employees);
        }

        //--------------------------------------------------
        // Scenario 2
        //--------------------------------------------------

        [Test]
        public void GetEmployees_Employee100Exists_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            Assert.That(
                employees.Any(e => e.Id == 100),
                Is.True);
        }

        //--------------------------------------------------
        // Scenario 3
        //--------------------------------------------------

        [Test]
        public void GetEmployees_AllEmployeesUnique_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            CollectionAssert.AllItemsAreUnique(employees);
        }

        //--------------------------------------------------
        // Scenario 4
        //--------------------------------------------------

        [Test]
        public void GetEmployees_CollectionsAreEqual_ReturnsTrue()
        {
            var list1 = manager.GetEmployees();

            var list2 = manager.GetEmployeesWhoJoinedInPreviousYears();

            CollectionAssert.AreEqual(list1, list2);

            // Constraint Model (Alternative)
            Assert.That(list1, Is.EqualTo(list2));
        }
    }
}

/*
============================================================

Analysis

Scenario 1

CollectionAssert.AllItemsAreNotNull()

Ensures no null values exist.

------------------------------------------------------------

Scenario 2

Assert.That()

Checks Employee ID 100 exists.

------------------------------------------------------------

Scenario 3

CollectionAssert.AllItemsAreUnique()

Uses overridden Equals()
and GetHashCode().

------------------------------------------------------------

Scenario 4

CollectionAssert.AreEqual()

Checks both collections contain
identical employees.

Constraint Model

Assert.That(list1, Is.EqualTo(list2))

============================================================
*/
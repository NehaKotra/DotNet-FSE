/*
============================================================
CTS Deep Skilling

Exercise 1
Mock Mail Sender using Moq

Commands
--------

Create Test Project

dotnet new classlib -n CustomerComm.Tests

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

dotnet add package Moq

Run Tests

dotnet test

============================================================
*/

using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mailSenderMock = new Mock<IMailSender>();

            _customerComm =
                new CustomerComm(_mailSenderMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ReturnsTrue()
        {
            _mailSenderMock

                .Setup(x => x.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>()))

                .Returns(true);

            bool result =
                _customerComm.SendMailToCustomer();

            Assert.IsTrue(result);
        }
    }
}

/*
============================================================

Analysis

Concepts Used

• Dependency Injection

• Interface

• Mock Object

• NUnit

• Moq

Mock Setup

.Setup(x => x.SendMail(
It.IsAny<string>(),
It.IsAny<string>()))

.Returns(true);

Advantages

• No real email sent.

• Faster execution.

• No SMTP dependency.

• Isolated unit testing.

============================================================
*/
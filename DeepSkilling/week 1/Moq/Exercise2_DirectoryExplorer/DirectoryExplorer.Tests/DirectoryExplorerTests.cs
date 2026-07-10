/*
============================================================
CTS Deep Skilling

Exercise 2
Mock File Object using Moq

Commands
--------

Create Test Project

dotnet new classlib -n DirectoryExplorer.Tests

Install Packages

dotnet add package NUnit

dotnet add package NUnit3TestAdapter

dotnet add package Moq

Run Tests

dotnet test

============================================================
*/

using System.Collections.Generic;
using MagicFilesLib;
using Moq;
using NUnit.Framework;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _directoryMock;

        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            _directoryMock =
                new Mock<IDirectoryExplorer>();
        }

        [TestCase]
        public void GetFiles_ReturnsMockFiles()
        {
            var files = new List<string>
            {
                _file1,
                _file2
            };

            _directoryMock

                .Setup(x => x.GetFiles(It.IsAny<string>()))

                .Returns(files);

            ICollection<string> result =
                _directoryMock.Object.GetFiles("C:\\Temp");

            Assert.IsNotNull(result);

            Assert.AreEqual(2, result.Count);

            Assert.Contains(_file1, (System.Collections.ICollection)result);
        }
    }
}

/*
============================================================

Analysis

Concepts Used

• Interface

• Mock Object

• NUnit

• Moq

Mock Setup

.Setup(x => x.GetFiles(It.IsAny<string>()))

.Returns(files);

Assertions

✔ Collection Not Null

✔ Count = 2

✔ Contains file.txt

Advantages

• No real file system access.

• Faster execution.

• Independent of local folders.

• Isolated Unit Testing.

============================================================
*/
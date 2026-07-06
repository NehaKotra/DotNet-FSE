-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Views
-- ==========================================

-- ==========================================
-- Database Schema
-- ==========================================

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- ==========================================
-- Sample Data
-- ==========================================

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES
(1, 'Human Resources'),
(2, 'Information Technology'),
(3, 'Finance'),
(4, 'Marketing');

INSERT INTO Employees
(EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES
(101, 'Alice', 'Johnson', 1, 45000, '2021-01-10'),
(102, 'Bob', 'Smith', 2, 60000, '2020-03-15'),
(103, 'Charlie', 'Brown', 3, 55000, '2019-06-20'),
(104, 'David', 'Wilson', 4, 50000, '2022-02-01');

-- ==========================================
-- Exercise 1
-- Create Simple View
-- ==========================================

CREATE VIEW vw_EmployeeBasicInfo
AS
SELECT
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID;

-- View Output
SELECT * FROM vw_EmployeeBasicInfo;

-- ==========================================
-- Exercise 2
-- View with Full Name
-- ==========================================

CREATE VIEW vw_EmployeeFullName
AS
SELECT
    EmployeeID,
    FirstName + ' ' + LastName AS FullName,
    DepartmentID,
    Salary
FROM Employees;

-- View Output
SELECT * FROM vw_EmployeeFullName;

-- ==========================================
-- Exercise 3
-- View with Annual Salary
-- ==========================================

CREATE VIEW vw_EmployeeAnnualSalary
AS
SELECT
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    Salary * 12 AS AnnualSalary
FROM Employees;

-- View Output
SELECT * FROM vw_EmployeeAnnualSalary;

-- ==========================================
-- Exercise 4
-- Employee Report View
-- ==========================================

CREATE VIEW vw_EmployeeReport
AS
SELECT
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS FullName,
    d.DepartmentName,
    e.Salary * 12 AS AnnualSalary,
    (e.Salary * 12) * 0.10 AS Bonus
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID;

-- View Output
SELECT * FROM vw_EmployeeReport;
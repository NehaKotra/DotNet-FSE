-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Functions
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

INSERT INTO Departments VALUES
(1,'HR'),
(2,'IT'),
(3,'Finance');

INSERT INTO Employees VALUES
(1,'John','Doe',1,5000.00,'2020-01-15'),
(2,'Jane','Smith',2,6000.00,'2019-03-22'),
(3,'Bob','Johnson',3,5500.00,'2021-07-01');

-- ==========================================
-- Exercise 1
-- Scalar Function
-- ==========================================

CREATE FUNCTION fn_CalculateAnnualSalary
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO

SELECT
    EmployeeID,
    FirstName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

-- ==========================================
-- Exercise 2
-- Table-Valued Function
-- ==========================================

CREATE FUNCTION fn_GetEmployeesByDepartment
(
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Employees
    WHERE DepartmentID=@DepartmentID
);
GO

SELECT *
FROM dbo.fn_GetEmployeesByDepartment(2);

-- ==========================================
-- Exercise 3
-- User Defined Function
-- ==========================================

CREATE FUNCTION fn_CalculateBonus
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;
GO

SELECT
EmployeeID,
FirstName,
Salary,
dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;

-- ==========================================
-- Exercise 4
-- Modify Function
-- ==========================================

ALTER FUNCTION fn_CalculateBonus
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;
GO

SELECT
EmployeeID,
FirstName,
dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;

-- ==========================================
-- Exercise 5
-- Delete Function
-- ==========================================

DROP FUNCTION fn_CalculateBonus;
GO

-- ==========================================
-- Recreate Function
-- (Required for remaining exercises)
-- ==========================================

CREATE FUNCTION fn_CalculateBonus
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;
GO

-- ==========================================
-- Exercise 6
-- Execute Scalar Function
-- ==========================================

SELECT
EmployeeID,
FirstName,
dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;

-- ==========================================
-- Exercise 7
-- Annual Salary for EmployeeID = 1
-- ==========================================

SELECT
EmployeeID,
FirstName,
dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID=1;

-- ==========================================
-- Exercise 8
-- Table-Valued Function
-- Finance Department
-- ==========================================

SELECT *
FROM dbo.fn_GetEmployeesByDepartment(3);

-- ==========================================
-- Exercise 9
-- Nested Function
-- ==========================================

CREATE FUNCTION fn_CalculateTotalCompensation
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN dbo.fn_CalculateAnnualSalary(@Salary)
         + dbo.fn_CalculateBonus(@Salary);
END;
GO

SELECT
EmployeeID,
FirstName,
dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;

-- ==========================================
-- Exercise 10
-- Modify Nested Function
-- ==========================================

ALTER FUNCTION fn_CalculateTotalCompensation
(
    @Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN dbo.fn_CalculateAnnualSalary(@Salary)
         + (@Salary * 0.20);
END;
GO

SELECT
EmployeeID,
FirstName,
dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;
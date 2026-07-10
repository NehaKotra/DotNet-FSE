-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Stored Procedures
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
(2,'Finance'),
(3,'IT'),
(4,'Marketing');

INSERT INTO Employees VALUES
(1,'John','Doe',1,5000.00,'2020-01-15'),
(2,'Jane','Smith',2,6000.00,'2019-03-22'),
(3,'Michael','Johnson',3,7000.00,'2018-07-30'),
(4,'Emily','Davis',4,5500.00,'2021-11-05');

-- ==========================================
-- Exercise 1
-- Retrieve Employees by Department
-- ==========================================

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID,
           FirstName,
           LastName,
           DepartmentID,
           Salary,
           JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetEmployeesByDepartment 1;

-- ==========================================
-- Insert Employee Procedure
-- ==========================================

CREATE PROCEDURE sp_InsertEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees
    VALUES
    (
        @EmployeeID,
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );
END;

EXEC sp_InsertEmployee
5,
'Robert',
'Taylor',
3,
6500,
'2024-01-01';

-- ==========================================
-- Exercise 2
-- Modify Stored Procedure
-- ==========================================

ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID,
           FirstName,
           LastName,
           DepartmentID,
           Salary,
           JoinDate
    FROM Employees
    WHERE DepartmentID=@DepartmentID;
END;

EXEC sp_GetEmployeesByDepartment 3;

-- ==========================================
-- Exercise 3
-- Delete Stored Procedure
-- ==========================================

DROP PROCEDURE sp_InsertEmployee;

-- ==========================================
-- Exercise 4
-- Execute Stored Procedure
-- ==========================================

EXEC sp_GetEmployeesByDepartment 2;

-- ==========================================
-- Exercise 5
-- Return Employee Count
-- ==========================================

CREATE PROCEDURE sp_TotalEmployees
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID=@DepartmentID;
END;

EXEC sp_TotalEmployees 1;

-- ==========================================
-- Exercise 6
-- Output Parameter
-- ==========================================

CREATE PROCEDURE sp_TotalSalary
    @DepartmentID INT,
    @TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT
    @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID=@DepartmentID;
END;

DECLARE @Salary DECIMAL(10,2);

EXEC sp_TotalSalary
1,
@Salary OUTPUT;

SELECT @Salary AS TotalSalary;

-- ==========================================
-- Exercise 7
-- Update Employee Salary
-- ==========================================

CREATE PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary=@Salary
    WHERE EmployeeID=@EmployeeID;
END;

EXEC sp_UpdateEmployeeSalary
1,
5500;

-- ==========================================
-- Exercise 8
-- Give Bonus
-- ==========================================

CREATE PROCEDURE sp_GiveBonus
    @DepartmentID INT,
    @Bonus DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary=Salary+@Bonus
    WHERE DepartmentID=@DepartmentID;
END;

EXEC sp_GiveBonus
1,
500;

-- ==========================================
-- Exercise 9
-- Transaction
-- ==========================================

CREATE PROCEDURE sp_UpdateSalaryTransaction
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION;

UPDATE Employees
SET Salary=@NewSalary
WHERE EmployeeID=@EmployeeID;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Transaction Failed';

END CATCH

END;

EXEC sp_UpdateSalaryTransaction
2,
6500;

-- ==========================================
-- Exercise 10
-- Dynamic SQL
-- ==========================================

CREATE PROCEDURE sp_SearchEmployee
    @ColumnName NVARCHAR(100),
    @Value NVARCHAR(100)
AS
BEGIN

DECLARE @SQL NVARCHAR(MAX);

SET @SQL='SELECT * FROM Employees
WHERE '+@ColumnName+'='''+@Value+'''';

EXEC(@SQL);

END;

EXEC sp_SearchEmployee
'FirstName',
'John';

-- ==========================================
-- Exercise 11
-- Error Handling
-- ==========================================

CREATE PROCEDURE sp_UpdateSalaryWithErrorHandling
    @EmployeeID INT,
    @Salary DECIMAL(10,2)
AS
BEGIN

BEGIN TRY

UPDATE Employees
SET Salary=@Salary
WHERE EmployeeID=@EmployeeID;

PRINT 'Salary Updated Successfully';

END TRY

BEGIN CATCH

PRINT 'Error Occurred';

PRINT ERROR_MESSAGE();

END CATCH

END;

EXEC sp_UpdateSalaryWithErrorHandling
1,
7000;
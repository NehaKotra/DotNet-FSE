-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Exception Handling
-- ==========================================

-- ==========================================
-- Database Schema
-- ==========================================

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Salary DECIMAL(10,2),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE AuditLog
(
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Action VARCHAR(100),
    ErrorMessage VARCHAR(4000),
    ActionDate DATETIME DEFAULT GETDATE()
);

-- ==========================================
-- Sample Data
-- ==========================================

INSERT INTO Departments VALUES
(1,'HR'),
(2,'Finance'),
(3,'IT');

INSERT INTO Employees VALUES
(1,'John','Doe','john@gmail.com',5000,1),
(2,'Jane','Smith','jane@gmail.com',6000,2);

-- ==========================================
-- Question 1
-- TRY...CATCH with Error Logging
-- ==========================================

CREATE PROCEDURE AddEmployee
(
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
)
AS
BEGIN

BEGIN TRY

INSERT INTO Employees
VALUES
(
@EmployeeID,
@FirstName,
@LastName,
@Email,
@Salary,
@DepartmentID
);

PRINT 'Employee Added Successfully';

END TRY

BEGIN CATCH

INSERT INTO AuditLog
(
Action,
ErrorMessage
)

VALUES
(
'Insert Employee',
ERROR_MESSAGE()
);

PRINT 'Error Logged';

END CATCH

END;
GO

-- Test

EXEC AddEmployee
3,
'Bob',
'Johnson',
'bob@gmail.com',
5500,
3;

-- ==========================================
-- Question 2
-- THROW
-- ==========================================

ALTER PROCEDURE AddEmployee
(
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
)
AS
BEGIN

BEGIN TRY

INSERT INTO Employees
VALUES
(
@EmployeeID,
@FirstName,
@LastName,
@Email,
@Salary,
@DepartmentID
);

END TRY

BEGIN CATCH

INSERT INTO AuditLog
(
Action,
ErrorMessage
)

VALUES
(
'Insert Employee',
ERROR_MESSAGE()
);

THROW;

END CATCH

END;
GO

-- ==========================================
-- Question 3
-- RAISERROR
-- ==========================================

ALTER PROCEDURE AddEmployee
(
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
)
AS
BEGIN

IF @Salary<=0

BEGIN

RAISERROR
(
'Salary must be greater than zero.',
16,
1
);

RETURN;

END

BEGIN TRY

INSERT INTO Employees
VALUES
(
@EmployeeID,
@FirstName,
@LastName,
@Email,
@Salary,
@DepartmentID
);

END TRY

BEGIN CATCH

INSERT INTO AuditLog
VALUES
(
'Insert Employee',
ERROR_MESSAGE(),
GETDATE()
);

END CATCH

END;
GO

-- ==========================================
-- Question 4
-- Nested TRY...CATCH
-- ==========================================

CREATE PROCEDURE TransferEmployee
(
@EmployeeID INT,
@DepartmentID INT
)

AS

BEGIN

BEGIN TRY

BEGIN TRY

IF NOT EXISTS
(
SELECT *
FROM Departments
WHERE DepartmentID=@DepartmentID
)

RAISERROR
(
'Department does not exist.',
16,
1
);

UPDATE Employees

SET DepartmentID=@DepartmentID

WHERE EmployeeID=@EmployeeID;

END TRY

BEGIN CATCH

INSERT INTO AuditLog
VALUES
(
'Transfer Employee',
ERROR_MESSAGE(),
GETDATE()
);

THROW;

END CATCH

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

END CATCH

END;
GO

-- ==========================================
-- Question 5
-- Transaction
-- ==========================================

CREATE PROCEDURE BatchInsertEmployees

AS

BEGIN

BEGIN TRY

BEGIN TRANSACTION;

INSERT INTO Employees
VALUES
(
4,
'David',
'Wilson',
'david@gmail.com',
7000,
1
);

INSERT INTO Employees
VALUES
(
5,
'Emily',
'Davis',
'david@gmail.com',
6500,
2
);

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

INSERT INTO AuditLog
VALUES
(
'Batch Insert',
ERROR_MESSAGE(),
GETDATE()
);

END CATCH

END;
GO

EXEC BatchInsertEmployees;

-- ==========================================
-- Question 6
-- Dynamic RAISERROR
-- ==========================================

ALTER PROCEDURE AddEmployee
(
@EmployeeID INT,
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Email VARCHAR(100),
@Salary DECIMAL(10,2),
@DepartmentID INT
)

AS

BEGIN

IF @Salary<0

BEGIN

RAISERROR
(
'Salary cannot be negative.',
16,
1
);

RETURN;

END

IF @Salary<1000

BEGIN

RAISERROR
(
'Warning: Salary is very low.',
10,
1
);

END

BEGIN TRY

INSERT INTO Employees
VALUES
(
@EmployeeID,
@FirstName,
@LastName,
@Email,
@Salary,
@DepartmentID
);

END TRY

BEGIN CATCH

INSERT INTO AuditLog
VALUES
(
'Insert Employee',
ERROR_MESSAGE(),
GETDATE()
);

THROW;

END CATCH

END;
GO

-- ==========================================
-- View Error Logs
-- ==========================================

SELECT *
FROM AuditLog;
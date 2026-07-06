-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Triggers
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
(1,'John','Doe',1,5000.00,'2022-01-15'),
(2,'Jane','Smith',2,6000.00,'2021-03-22'),
(3,'Michael','Johnson',3,7000.00,'2020-07-30'),
(4,'Emily','Davis',4,5500.00,'2019-11-05');

-- ==========================================
-- Exercise 1
-- AFTER Trigger
-- Log Salary Changes
-- ==========================================

CREATE TABLE EmployeeChanges
(
    ChangeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);

GO

CREATE TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    INSERT INTO EmployeeChanges
    (
        EmployeeID,
        OldSalary,
        NewSalary
    )
    SELECT
        d.EmployeeID,
        d.Salary,
        i.Salary
    FROM deleted d
    JOIN inserted i
    ON d.EmployeeID=i.EmployeeID
    WHERE d.Salary<>i.Salary;
END;
GO

-- Test
UPDATE Employees
SET Salary=5500
WHERE EmployeeID=1;

SELECT * FROM EmployeeChanges;

-- ==========================================
-- Exercise 2
-- INSTEAD OF DELETE Trigger
-- ==========================================

GO

CREATE TRIGGER trg_PreventDelete
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR
    (
        'Employee records cannot be deleted.',
        16,
        1
    );
END;
GO

-- Test
DELETE FROM Employees
WHERE EmployeeID=2;

-- ==========================================
-- Exercise 3
-- LOGON Trigger
-- ==========================================

GO

CREATE TRIGGER trg_LogonRestriction
ON ALL SERVER
FOR LOGON
AS
BEGIN

IF DATEPART(HOUR,GETDATE()) BETWEEN 2 AND 2

BEGIN

ROLLBACK;

PRINT 'Login not allowed during maintenance hours.';

END

END;
GO

-- ==========================================
-- Exercise 4
-- Modify Trigger
-- ==========================================

ALTER TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN

INSERT INTO EmployeeChanges
(
    EmployeeID,
    OldSalary,
    NewSalary,
    ChangeDate
)

SELECT
d.EmployeeID,
d.Salary,
i.Salary,
GETDATE()

FROM deleted d
JOIN inserted i

ON d.EmployeeID=i.EmployeeID;

END;
GO

-- ==========================================
-- Exercise 5
-- Delete Trigger
-- ==========================================

DROP TRIGGER trg_PreventDelete;
GO

-- ==========================================
-- Exercise 6
-- Update Computed Column
-- ==========================================

ALTER TABLE Employees

ADD AnnualSalary DECIMAL(10,2);

GO

CREATE TRIGGER trg_UpdateAnnualSalary

ON Employees

AFTER INSERT,UPDATE

AS
BEGIN

UPDATE e

SET AnnualSalary=e.Salary*12

FROM Employees e

JOIN inserted i

ON e.EmployeeID=i.EmployeeID;

END;
GO

-- Test

UPDATE Employees

SET Salary=6500

WHERE EmployeeID=2;

SELECT
EmployeeID,
FirstName,
Salary,
AnnualSalary

FROM Employees;
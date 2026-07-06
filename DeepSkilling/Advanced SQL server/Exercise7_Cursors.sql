-- ==========================================
-- CTS Deep Skilling
-- SQL Exercise - Cursors
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
(3,'Bob','Johnson',3,5500.00,'2021-07-30');

-- ==========================================
-- Exercise 1
-- Create a Cursor
-- ==========================================

DECLARE
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE;

DECLARE EmployeeCursor CURSOR
FOR
SELECT
    EmployeeID,
    FirstName,
    LastName,
    DepartmentID,
    Salary,
    JoinDate
FROM Employees;

OPEN EmployeeCursor;

FETCH NEXT FROM EmployeeCursor
INTO
    @EmployeeID,
    @FirstName,
    @LastName,
    @DepartmentID,
    @Salary,
    @JoinDate;

WHILE @@FETCH_STATUS = 0
BEGIN

    PRINT 'Employee ID : ' + CAST(@EmployeeID AS VARCHAR(10));
    PRINT 'Name        : ' + @FirstName + ' ' + @LastName;
    PRINT 'Department  : ' + CAST(@DepartmentID AS VARCHAR(10));
    PRINT 'Salary      : ' + CAST(@Salary AS VARCHAR(20));
    PRINT 'Join Date   : ' + CONVERT(VARCHAR(20), @JoinDate);
    PRINT '------------------------------------';

    FETCH NEXT FROM EmployeeCursor
    INTO
        @EmployeeID,
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate;

END;

CLOSE EmployeeCursor;
DEALLOCATE EmployeeCursor;

-- ==========================================
-- Exercise 2
-- STATIC Cursor
-- ==========================================

DECLARE StaticCursor CURSOR STATIC
FOR
SELECT *
FROM Employees;

OPEN StaticCursor;

PRINT 'STATIC CURSOR CREATED';

CLOSE StaticCursor;
DEALLOCATE StaticCursor;

-- ==========================================
-- DYNAMIC Cursor
-- ==========================================

DECLARE DynamicCursor CURSOR DYNAMIC
FOR
SELECT *
FROM Employees;

OPEN DynamicCursor;

PRINT 'DYNAMIC CURSOR CREATED';

CLOSE DynamicCursor;
DEALLOCATE DynamicCursor;

-- ==========================================
-- FORWARD_ONLY Cursor
-- ==========================================

DECLARE ForwardCursor CURSOR FORWARD_ONLY
FOR
SELECT *
FROM Employees;

OPEN ForwardCursor;

PRINT 'FORWARD_ONLY CURSOR CREATED';

CLOSE ForwardCursor;
DEALLOCATE ForwardCursor;

-- ==========================================
-- KEYSET Cursor
-- ==========================================

DECLARE KeysetCursor CURSOR KEYSET
FOR
SELECT *
FROM Employees;

OPEN KeysetCursor;

PRINT 'KEYSET CURSOR CREATED';

CLOSE KeysetCursor;
DEALLOCATE KeysetCursor;

-- ==========================================
-- Comparison of Cursor Types
-- ==========================================

PRINT 'Cursor Comparison';
PRINT '1. STATIC Cursor      - Snapshot of data.';
PRINT '2. DYNAMIC Cursor     - Reflects all changes.';
PRINT '3. FORWARD_ONLY       - Moves only forward.';
PRINT '4. KEYSET Cursor      - Key values fixed, data can change.';
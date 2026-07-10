/*==========================================================
CTS Deep Skilling
Exercise 1 - Ranking and Window Functions
==========================================================*/

-- Display ranking of products based on price in each category

SELECT
    ProductID,
    ProductName,
    Category,
    Price,

    ROW_NUMBER() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS Row_Number,

    RANK() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS Rank_Number,

    DENSE_RANK() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS Dense_Rank

FROM Products;


-----------------------------------------------------------
-- Top 3 Most Expensive Products in Each Category
-----------------------------------------------------------

WITH RankedProducts AS
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,

        ROW_NUMBER() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS Row_Number

    FROM Products
)

SELECT *
FROM RankedProducts
WHERE Row_Number <= 3;



/*==========================================================
Exercise 2 - GROUPING SETS
==========================================================*/

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY GROUPING SETS
(
    (c.Region, p.Category),
    (c.Region),
    (p.Category)
);



/*==========================================================
Exercise 2 - ROLLUP
==========================================================*/

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY ROLLUP
(
    c.Region,
    p.Category
);



/*==========================================================
Exercise 2 - CUBE
==========================================================*/

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN OrderDetails od
ON o.OrderID = od.OrderID

JOIN Customers c
ON o.CustomerID = c.CustomerID

JOIN Products p
ON od.ProductID = p.ProductID

GROUP BY CUBE
(
    c.Region,
    p.Category
);



/*==========================================================
Exercise 3 - Recursive CTE
==========================================================*/

WITH Calendar AS
(
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate

    UNION ALL

    SELECT DATEADD(DAY,1,CalendarDate)

    FROM Calendar

    WHERE CalendarDate < '2025-01-31'
)

SELECT *
FROM Calendar
OPTION (MAXRECURSION 100);



/*==========================================================
Exercise 3 - Create Staging Table
==========================================================*/

CREATE TABLE StagingProducts
(
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10,2)
);



INSERT INTO StagingProducts
VALUES
(1,'Laptop','Electronics',65000),
(9,'Smart Watch','Electronics',5500);



/*==========================================================
Exercise 3 - MERGE
==========================================================*/

MERGE Products AS Target

USING StagingProducts AS Source

ON Target.ProductID = Source.ProductID

WHEN MATCHED THEN

UPDATE SET
Target.Price = Source.Price

WHEN NOT MATCHED THEN

INSERT
(
    ProductID,
    ProductName,
    Category,
    Price
)

VALUES
(
    Source.ProductID,
    Source.ProductName,
    Source.Category,
    Source.Price
);



/*==========================================================
Exercise 4 - PIVOT
==========================================================*/

SELECT *
FROM
(
    SELECT
        p.ProductName,
        MONTH(o.OrderDate) AS MonthNo,
        od.Quantity

    FROM Orders o

    JOIN OrderDetails od
    ON o.OrderID = od.OrderID

    JOIN Products p
    ON od.ProductID = p.ProductID

) AS SalesData

PIVOT
(
    SUM(Quantity)

    FOR MonthNo IN
    (
        [1],[2],[3],[4],[5],[6],
        [7],[8],[9],[10],[11],[12]
    )

) AS PivotTable;



/*==========================================================
Exercise 4 - UNPIVOT
==========================================================*/

SELECT
    ProductName,
    MonthNo,
    Quantity

FROM PivotTable

UNPIVOT
(
    Quantity FOR MonthNo IN
    (
        [1],[2],[3],[4],[5],[6],
        [7],[8],[9],[10],[11],[12]
    )

) AS UnPivotTable;



/*==========================================================
Exercise 5 - Common Table Expression
==========================================================*/

WITH CustomerOrderCounts AS
(
    SELECT
        CustomerID,
        COUNT(OrderID) AS OrderCount

    FROM Orders

    GROUP BY CustomerID
)

SELECT
    c.CustomerID,
    c.Name,
    coc.OrderCount

FROM CustomerOrderCounts coc

JOIN Customers c
ON c.CustomerID = coc.CustomerID

WHERE coc.OrderCount > 3;
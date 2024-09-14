-- This query retrieves the top 3 highest-paid employees in each department.
-- Approach:
-- 1. Use the ROW_NUMBER() window function to rank employees within each department based on their salary in descending order.
--    The ranking resets for each department using the PARTITION BY clause.
-- 2. The Common Table Expression (CTE) "RankedEmployees" stores the result of the ranking for later filtering.
-- 3. In the main query, filter the rows where the rank is 3 or less, i.e., only the top 3 employees for each department.
-- 4. The final result is sorted by Department and Rank for clarity.

WITH RankedEmployees AS (
    SELECT 
        EmployeeID,
        Name,
        Department,
        Salary,
        ROW_NUMBER() OVER (PARTITION BY Department ORDER BY Salary DESC) AS Rank
    FROM Employees
)
SELECT 
    EmployeeID,
    Name,
    Department,
    Salary
FROM RankedEmployees
WHERE Rank <= 3
ORDER BY Department, Rank;

-- Create a stored procedure that takes in params and creates a new user. 
-- next, the stored procedure should return the updated count of total users




-- CREATE OR ALTER PROCEDURE p1.CreateUser (
--     @email NVARCHAR(30),
--     @age INT,
--     @banned BIT,
--     @created_at DATETIMEOFFSET(7),
--     @last_login DATETIMEOFFSET(7)
-- )
-- AS
-- BEGIN
--     INSERT INTO p1.Users (email, age, banned, created_at, last_login) 
--     VALUES (@email, @age, @banned, @created_at, @last_login);
--     SELECT COUNT(*) AS TotalUsers FROM p1.Users;
-- END;

-- DECLARE @created_at2 DATETIMEOFFSET(7) = SYSDATETIMEOFFSET();
-- DECLARE @last_login2 DATETIMEOFFSET(7) = DATEADD(MONTH, -1, SYSDATETIMEOFFSET());

-- EXEC p1.CreateUser 
--     @email = 'Sampleemail45@gmail.com',
--     @age = 20,
--     @banned = 0,
--     @created_at = @created_at2, -- is it because these are technically function calls?
--     @last_login = @last_login2;
    
-- SELECT COUNT(*) FROM users?
--can i try running it?


-- list all customers who made purchases, along with their invoice IDs and totals
-- SELECT t.FirstName, t.LastName, inv.InvoiceId AS InvoiceId 
-- FROM dbo.Customer t
-- INNER JOIN dbo.Invoice inv
--     ON t.CustomerId = inv.CustomerId;

-- -- return all customers, including those who have never made a purchase. show 
-- -- their name and invoice id (if any)
-- SELECT c.FirstName + ' ' + c.LastName AS Name, inv.InvoiceId 
-- FROM dbo.Customer c  
-- LEFT JOIN dbo.Invoice inv
--     ON c.CustomerId = inv.CustomerId
--     AND inv.Total > 5;

-- -- return all artists and albums including artists with no albums and 
-- -- albums without artists (if any)
-- SELECT --Full outer join
--     ar.Name AS Artist,
--     a.Title AS ALBUM
-- FROM dbo.Artist ar
-- FULL OUTER JOIN dbo.Album a 
--     ON ar.ArtistId = a.ArtistId;
    
-- -- list all employees IDs next to their manager's IDs (if any)
-- SELECT --  
--     emp.EmployeeId AS employees,
--     man.EmployeeId AS managers
-- FROM dbo.Employee emp
-- LEFT JOIN dbo.Employee man
--     ON emp.ReportsTo = man.ReportsTo;

-- scalar subquery 
-- SELECT * 
-- FROM Customer c 
-- WHERE c.CustomerId IN (
--     SELECT i.CustomerId 
--     FROM Invoice i 
--     WHERE i.Total > (
--         SELECT AVG(Total)
--         FROM Invoice
--     )
-- );


-- CTE - common table expressions 

-- SELECT 
--     c.CustomerId,
--     c.FirstName,
--     c.LastName
-- FROM Customer c 
-- WHERE NOT EXISTS (
--     SELECT *
--     FROM Invoice i
--     WHERE i.CustomerId = c.CustomerId
-- );


-- find artists without any albums 

-- find customers whose total spending is above the average customer spending, using a CTE


-- WITH CustomerTotals AS (
--     SELECT 
--         c.FirstName,
--         c.LastName,
--         SUM(i.Total) AS TotalSpent 
--     FROM Customer c 
--     JOIN Invoice i 
--         ON c.CustomerId = i.CustomerId
--     GROUP BY c.FirstName, c.LastName
-- )
-- SELECT * 
-- FROM CustomerTotals
-- WHERE TotalSpent > (
--     SELECT AVG(TotalSpent) FROM CustomerTotals
-- );



-- a VIEW is essentially a stored and named result set 
-- we can use VIEWS to name queries and call on that name later 

-- CREATE VIEW RecentOrdersView 
-- AS 
-- SELECT 
--     c.Email,
--     i.InvoiceDate,
--     i.Total 
-- FROM Customer c 
-- JOIN Invoice i
--     ON c.CustomerId = i.CustomerId
-- WHERE i.InvoiceDate > DATEADD(YEAR, -1, GETDATE());


-- SELECT 
--     t.AlbumId,
--     t.Name,
--     ROW_NUMBER() OVER (
--         PARTITION BY t.AlbumId 
--         ORDER BY t.Milliseconds DESC 
--     ) AS TrackRank 
-- FROM dbo.Track t;

-- SELECT 
--     i.CustomerId,
--     i.InvoiceDate,
--     i.Total,
--     SUM(i.Total) OVER (
--         PARTITION BY i.CustomerId 
--         ORDER BY i.InvoiceDate
--     ) AS RunningTotal
-- FROM Invoice i 
-- ORDER BY i.CustomerId, i.InvoiceDate;

-- write a query to show the top 3 tracks per album 
-- WITH RankedTracks AS (
--     SELECT 
--         a.Title,
--         t.Name,
--         t.Milliseconds,
--         ROW_NUMBER() OVER (
--             PARTITION BY t.AlbumId 
--             ORDER BY t.Milliseconds DESC 
--         ) AS rn
--     FROM dbo.Track t 
--     JOIN Album a 
--         ON t.AlbumId = a.AlbumId
-- )
-- SELECT *
-- FROM RankedTracks
-- WHERE rn <= 3
-- ORDER BY Title;



--2.
SELECT * FROM Event;
--3.
SELECT * FROM Event
WHERE available_seats > 0;
--4.
SELECT * FROM Event
WHERE event_name LIKE '%Rock%';
--5.
SELECT * FROM Event
WHERE ticket_price BETWEEN 100 AND 250;
--6.
SELECT * FROM Event
WHERE event_date BETWEEN '2025-05-01' AND '2025-06-01';
--7.
SELECT * FROM Event
WHERE available_seats > 0
AND event_type = 'Movie'
AND event_name LIKE '%Movie%';
--8.
SELECT * FROM Customer
ORDER BY customer_id
OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY;

--9.
SELECT * FROM Booking
WHERE num_tickets > 2;
--10.
SELECT * FROM Customer
WHERE phone_number LIKE '%210';
--11.
SELECT * FROM Event
WHERE total_seats > 150
ORDER BY total_seats;

--12.
SELECT * FROM Event
WHERE event_name NOT LIKE 'cricket%' AND event_name NOT LIKE 'Fiesta%' AND event_name NOT LIKE 'fever%';
------------------------------------------------TASK 2--------------------------------------------------
--13.
SELECT event_name, AVG(ticket_price) AS avg_ticket_price
FROM Event
GROUP BY event_name;
--14.
SELECT e.event_name, SUM(b.total_cost) AS total_revenue
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY e.event_name;
--15.
SELECT TOP 1 e.event_name, SUM(b.num_tickets) AS total_tickets
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY e.event_name
ORDER BY total_tickets DESC;
--16.
SELECT e.event_name, SUM(b.num_tickets) AS total_tickets_sold
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY e.event_name;
--17.
SELECT e.event_name
FROM Event e
LEFT JOIN Booking b ON e.booking_id = b.booking_id
WHERE b.booking_id IS NULL OR b.num_tickets IS NULL;
--18.
SELECT TOP 1 c.customer_name, SUM(b.num_tickets) AS total_tickets
FROM Customer c
JOIN Booking b ON c.booking_id = b.booking_id
GROUP BY c.customer_name
ORDER BY total_tickets DESC;

--19.
SELECT FORMAT(e.event_date, 'yyyy-MM') AS month_year,e.event_name,SUM(b.num_tickets) AS tickets_sold
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY FORMAT(e.event_date, 'yyyy-MM'), e.event_name
ORDER BY month_year;

--20.
SELECT v.venue_name, AVG(e.ticket_price) AS avg_price
FROM Venue v
JOIN Event e ON v.venue_id = e.venue_id
GROUP BY v.venue_name;

--21.
SELECT e.event_type, SUM(b.num_tickets) AS total_tickets
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY e.event_type;

--22.
SELECT YEAR(e.event_date) AS event_year, SUM(b.total_cost) AS revenue
FROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
GROUP BY YEAR(e.event_date)
ORDER BY event_year;
--23.
SELECT c.customer_name, COUNT(DISTINCT b.event_id) AS events_booked
FROM Customer c
JOIN Booking b ON c.booking_id = b.booking_id
GROUP BY c.customer_name
HAVING COUNT(DISTINCT b.event_id) > 0;

--24.
SELECT c.customer_name, SUM(b.total_cost) AS total_spent
FROM Customer c
JOIN Booking b ON c.booking_id = b.booking_id
GROUP BY c.customer_name;

--25.
SELECT e.event_type, v.venue_name, AVG(e.ticket_price) AS avg_price
FROM Event e
JOIN Venue v ON e.venue_id = v.venue_id
GROUP BY e.event_type, v.venue_name;

--26.
SELECT c.customer_name, SUM(b.num_tickets) AS tickets_last_30_days
FROM Customer c
JOIN Booking b ON c.booking_id = b.booking_id
WHERE b.booking_date >= DATEADD(DAY, -30, GETDATE())
GROUP BY c.customer_name;
-------------------------------------------------------TASK 3---------------------------------------------
--27.
SELECT venue_name, (SELECT AVG(ticket_price) FROM Event e 
WHERE e.venue_id = v.venue_id) AS avg_ticket_price
FROM Venue v;
--28.
SELECT event_name 
FROM Event 
WHERE (total_seats - available_seats) > (total_seats / 2);
--29.
SELECT event_name, (SELECT SUM(num_tickets) FROM Booking b 
WHERE b.event_id = e.event_id) AS total_tickets_sold
FROM Event e;
--30.
SELECT customer_name FROM Customer c
WHERE NOT EXISTS (SELECT 1 FROM Booking b WHERE b.customer_id = c.customer_id);
--31.
SELECT event_name FROM Event 
WHERE event_id NOT IN (SELECT event_id FROM Booking WHERE event_id IS NOT NULL);
--31.
SELECT event_type, SUM(tickets_sold) AS total_tickets
FROM (SELECT e.event_type, b.num_tickets AS tickets_soldFROM Event e
JOIN Booking b ON e.booking_id = b.booking_id
) AS sub
GROUP BY event_type;
--32.
SELECT event_name, ticket_price FROM Event
WHERE ticket_price > (SELECT AVG(ticket_price) FROM Event);

--33.
SELECT c.customer_name,(SELECT SUM(b.total_cost) 
FROM Booking b WHERE b.customer_id = c.customer_id) AS total_spent
FROM Customer c;

--34.
SELECT customer_name FROM Customer 
WHERE booking_id IN (SELECT booking_id FROM Event 
WHERE venue_id = 1 );
--35.
SELECT event_type, SUM(tickets_sold) AS total_tickets
FROM (SELECT e.event_type, b.num_tickets AS tickets_sold
FROM Event e JOIN Booking b
ON e.booking_id = b.booking_id
) AS sub GROUP BY event_type;
--36.
SELECT DISTINCT customer_name FROM Customer c
WHERE booking_id IN (SELECT booking_id FROM Booking 
WHERE FORMAT(booking_date, 'yyyy-MM') IS NOT NULL);

--37.
SELECT venue_name,(SELECT AVG(ticket_price)FROM Event e
WHERE e.venue_id = v.venue_id) AS avg_price
FROM Venue v;


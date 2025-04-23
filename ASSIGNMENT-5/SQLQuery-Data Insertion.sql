INSERT INTO Venue (venue_name, address) VALUES
('Royal Arena', '12 Kingsway Rd, Delhi'),
('Ocean Plaza', '99 Beachside Blvd, Mumbai'),
('Green Gardens', '45 Park St, Bangalore'),
('Sky Dome', '80 Skyline Rd, Hyderabad'),
('Sunset Hall', '102 Marina Bay, Chennai');


INSERT INTO Booking (customer_id, event_id, num_tickets, total_cost, booking_date) VALUES
(NULL, NULL, 2, 500.00, '2025-04-10'),
(NULL, NULL, 4, 1000.00, '2025-04-11'),
(NULL, NULL, 1, 250.00, '2025-04-12'),
(NULL, NULL, 3, 750.00, '2025-04-13'),
(NULL, NULL, 2, 600.00, '2025-04-14');


INSERT INTO Event (event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id) VALUES
('Rock Blast', '2025-05-01', '19:00:00', 1, 500, 300, 250.00, 'Concert', 1),
('Champions League', '2025-05-03', '20:30:00', 2, 1000, 750, 300.00, 'Sports', 2),
('Movie Fiesta', '2025-05-05', '18:45:00', 3, 300, 120, 200.00, 'Movie', 3),
('Stand-up Special', '2025-05-07', '21:00:00', 4, 450, 200, 350.00, 'Concert', 4),
('Cricket Fever', '2025-05-10', '17:00:00', 5, 1200, 900, 400.00, 'Sports', 5);

INSERT INTO Customer (customer_name, email, phone_number, booking_id) VALUES
('Anjali Mehra', 'anjali@example.com', '9876543210', 1),
('Rahul Nair', 'rahul@example.com', '9123456789', 2),
('Pooja Sharma', 'pooja@example.com', '9000012345', 3),
('Vikram Joshi', 'vikram@example.com', '9888888888', 4),
('Neha Kapoor', 'neha@example.com', '9999999999', 5);

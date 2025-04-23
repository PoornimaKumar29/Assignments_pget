-- 1. Venue Table
CREATE TABLE Venue (
    venue_id INT PRIMARY KEY IDENTITY(1,1),
    venue_name VARCHAR(100),
    address VARCHAR(255)
);

-- 2. Booking Table
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,  -- Will be a FK later
    event_id INT,     -- Will be a FK later
    num_tickets INT,
    total_cost DECIMAL(10,2),
    booking_date DATE
);

-- 3. Event Table
CREATE TABLE Event (
    event_id INT PRIMARY KEY IDENTITY(1,1),
    event_name VARCHAR(100),
    event_date DATE,
    event_time TIME,
    venue_id INT,
    total_seats INT,
    available_seats INT,
    ticket_price DECIMAL(10,2),
    event_type VARCHAR(20),
    booking_id INT,
    FOREIGN KEY (venue_id) REFERENCES Venue(venue_id),
    FOREIGN KEY (booking_id) REFERENCES Booking(booking_id),
    CHECK (event_type IN ('Movie', 'Sports', 'Concert'))
);

-- 4. Customer Table
CREATE TABLE Customer (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    customer_name VARCHAR(100),
    email VARCHAR(100),
    phone_number VARCHAR(15),
    booking_id INT,
    FOREIGN KEY (booking_id) REFERENCES Booking(booking_id)
);


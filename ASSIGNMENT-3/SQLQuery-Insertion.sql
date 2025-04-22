USE HMBANK

-- Insert data into Customers table
INSERT INTO Customers (Customer_FirstName, Customer_LastName, Customer_DOB, Customer_Email, Customer_Phone, Customer_Address)
VALUES 
('John', 'Doe', '1990-05-15', 'john.doe@example.com', 9876543210, '123 Street, NY'),
('Alice', 'Brown', '1985-08-20', 'alice.brown@example.com', 9876543211, '456 Avenue, CA'),
('Michael', 'Smith', '1992-02-10', 'michael.smith@example.com', 9876543212, '789 Road, TX'),
('Emma', 'Johnson', '1995-12-05', 'emma.johnson@example.com', 9876543213, '321 Lane, FL'),
('David', 'Williams', '1988-04-25', 'david.williams@example.com', 9876543214, '654 Blvd, WA'),
('Sophia', 'Miller', '1993-07-19', 'sophia.miller@example.com', 9876543215, '987 Circle, NV'),
('Daniel', 'Wilson', '1987-10-30', 'daniel.wilson@example.com', 9876543216, '159 Square, OH'),
('Olivia', 'Anderson', '1991-06-18', 'olivia.anderson@example.com', 9876543217, '753 Park, NJ'),
('James', 'Thomas', '1994-09-09', 'james.thomas@example.com', 9876543218, '852 Drive, MI'),
('Emily', 'Harris', '1989-11-23', 'emily.harris@example.com', 9876543219, '951 Court, IL')

-- Insert data into Accounts table
INSERT INTO Accounts (Customer_id, Account_Type, Balance)
VALUES 
(1, 'Saving', 5000.00),
(2, 'Current', 10000.00),
(3, 'Saving', 7000.00),
(4, 'Zero_balance', 0.00),
(5, 'Saving', 3000.00),
(6, 'Current', 12000.00),
(7, 'Saving', 8000.00),
(8, 'Zero_balance', 0.00),
(9, 'Current', 15000.00),
(10, 'Saving', 6000.00)

-- Insert data into Transactions table
INSERT INTO Transactions (Account_id, Transaction_type, Amount, Transaction_date)
VALUES 
(101, 'deposit', 2000, '2024-03-01'),
(102, 'withdrawal', 500, '2024-03-02'),
(103, 'deposit', 3000, '2024-03-03'),
(104, 'transfer', 1000, '2024-03-04'),
(105, 'deposit', 1500, '2024-03-05'),
(106, 'withdrawal', 200, '2024-03-06'),
(107, 'transfer', 2500, '2024-03-07'),
(108, 'deposit', 4000, '2024-03-08'),
(109, 'withdrawal', 1000, '2024-03-09'),
(110, 'deposit', 3500, '2024-03-10')

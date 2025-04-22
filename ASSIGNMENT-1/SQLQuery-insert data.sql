-- Inserting sample data into Customers table
INSERT INTO Customers (Customer_FirstName, Customer_LastName, Customer_Email, Customer_Phone, Address)
VALUES
('John', 'Doe', 'john.doe@example.com', 9876543210, '123 Main St, City, Country'),
('Alice', 'Smith', 'alice.smith@example.com', 9876543220, '456 Elm St, City, Country'),
('Bob', 'Johnson', 'bob.johnson@example.com', 9876543230, '789 Oak St, City, Country'),
('Charlie', 'Brown', 'charlie.brown@example.com', 9876543240, '101 Pine St, City, Country'),
('David', 'Williams', 'david.williams@example.com', 9876543250, '202 Maple St, City, Country');
GO

-- Inserting sample data into Products table
INSERT INTO Products (Product_Name, Product_Description, Product_Price)
VALUES
('Laptop', 'High-performance laptop with 16GB RAM and 512GB SSD', 50000),
('Smartphone', 'Latest smartphone with a 6.5-inch display', 25000),
('Headphones', 'Noise-canceling wireless headphones', 7000),
('Smartwatch', 'Fitness tracking smartwatch with heart rate monitor', 15000),
('Tablet', '10-inch tablet with 128GB storage and stylus support', 22000);
GO

-- Inserting sample data into Orders table
INSERT INTO Orders (Customer_id, Total_Amount)
VALUES
(1, 60000),
(2, 30000),
(3, 18000),
(4, 15000),
(5, 22000);
GO

-- Inserting sample data into OrderDetails table
INSERT INTO OrderDetails (Order_id, Product_id, Quantity)
VALUES
(1, 1, 1),  -- Order 1, Product 1, 1 item
(2, 2, 1),  -- Order 2, Product 2, 1 item
(3, 3, 2),  -- Order 3, Product 3, 2 items
(4, 4, 1),  -- Order 4, Product 4, 1 item
(5, 5, 1);  -- Order 5, Product 5, 1 item
GO

-- Inserting sample data into Inventory table
INSERT INTO Inventory (Product_id, Quantity_InStock, LastStock_Update)
VALUES
(1, 50, GETDATE()),
(2, 100, GETDATE()),
(3, 200, GETDATE()),
(4, 150, GETDATE()),
(5, 75, GETDATE());
GO


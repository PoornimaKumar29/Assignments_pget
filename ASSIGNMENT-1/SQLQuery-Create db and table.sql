CREATE DATABASE TechShop
USE TechShop
--------------------Customer table
CREATE TABLE Customers (
    Customer_id INT IDENTITY(1,1) PRIMARY KEY,
    Customer_FirstName VARCHAR(100) NOT NULL,
    Customer_LastName VARCHAR(100),
    Customer_Email VARCHAR(100) UNIQUE CHECK (Customer_Email LIKE '_%@_%._%'),
    Customer_Phone BIGINT UNIQUE CHECK(Customer_Phone BETWEEN 6000000000 AND 9999999999),
    Address VARCHAR(300) NOT NULL
)
----------------product table
CREATE TABLE Products (
    Product_id INT IDENTITY(1,1) PRIMARY KEY,
    Product_Name VARCHAR(100) NOT NULL,
    Product_Description TEXT,
    Product_Price INT NOT NULL CHECK(Product_Price >= 0)
)
------------------------------order table
CREATE TABLE Orders (
    Order_id INT IDENTITY(1,1) PRIMARY KEY,
    Customer_id INT NOT NULL,
    Order_Date DATE DEFAULT GETDATE(),
    Total_Amount INT NOT NULL DEFAULT 0,
    FOREIGN KEY (Customer_id) REFERENCES Customers(Customer_id)
)
--------------------order details
CREATE TABLE OrderDetails (
    OrderDetail_id INT IDENTITY(1,1) PRIMARY KEY,
    Order_id INT NOT NULL,
    Product_id INT NOT NULL,
    Quantity INT NOT NULL CHECK(Quantity > 0),
    FOREIGN KEY (Order_id) REFERENCES Orders(Order_id),
    FOREIGN KEY (Product_id) REFERENCES Products(Product_id)
)
------------------------inventory table
CREATE TABLE Inventory (
    Inventory_id INT IDENTITY(1,1) PRIMARY KEY,
    Product_id INT NOT NULL,
    Quantity_InStock INT NOT NULL,
    LastStock_Update DATE,
    FOREIGN KEY (Product_id) REFERENCES Products(Product_id) ON DELETE CASCADE
)

ALTER TABLE Orders
ADD Status VARCHAR(50) DEFAULT 'Pending';

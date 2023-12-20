-- create database
CREATE DATABASE TechShop

USE TechShop

-- creating the tables 

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
FirstName VARCHAR (20),
LastName VARCHAR (20),
Email VARCHAR (40),
Phone INT ,
Address CHAR (50)
)

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName VARCHAR (20),
Description VARCHAR (40),
Price INT 
);

-- Creating Orders table using foreign key also

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT ,
OrderDate Date,
TotalAmount INT,
FOREIGN KEY (CustomerID) REFERENCES Customers(	CustomerID),
)

CREATE TABLE OrderDetails(
OrderDetailID INT PRIMARY KEY,
OrderID INT,
ProductID INT,
Quantity INT,
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
)

CREATE TABLE Inventory(
InventoryID INT PRIMARY KEY,
ProductID INT,
QuantityInStock INT,
LastStockUpdate INT,
FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
)

-- adding the constraints to above table

ALTER TABLE Customers
ALTER COLUMN FirstName VARCHAR (20) NOT NULL

ALTER TABLE Products
ALTER COLUMN ProductName VARCHAR (20) NOT NULL

ALTER TABLE Customers
ALTER COLUMN Phone VARCHAR (20);

ALTER TABLE Products
ALTER COLUMN Price DECIMAL(10,2);

ALTER TABLE Inventory
ALTER COLUMN LastStockUpdate DATETIME;
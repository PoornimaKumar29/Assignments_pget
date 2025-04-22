use HMBANK
------------------------------------------------------Create CustomerTable-------------------------------
create table Customers(
Customer_id int identity(1,1)
constraint pk_studentid primary key(Customer_id),
Customer_FirstName varchar(100) not null,
Customer_LastNAme varchar(100),
Customer_DOB date not null,
Customer_Email varchar(100) not null unique,
Customer_Phone bigint not null unique,
Customer_Address varchar(250) not null
)
drop table Customers
---------------------------------------------------create Accountstable-----------------------------------
create table Accounts(
Account_id int identity(101,1)
constraint pk_accountid primary key(Account_id),
Customer_id int not null
constraint fk_customerid foreign key(Customer_id) references Customers(Customer_id) on delete cascade,
Account_Type varchar(100) not null check (Account_type in ('Saving','Current','Zero_balance')),
Balance decimal(15,2) default 0.00
)
drop table Accounts
--------------------------------------------------create Transaction table----------------------------------------------------------
create table Transactions(
Transaction_id int identity(1,1) 
constraint pk_transactionid primary key(Transaction_id),
Account_id int not null
constraint fk_accountid foreign key(Account_id) references Accounts(Account_id) on delete cascade,
Transaction_type varchar(100) not null check (Transaction_type in('deposit','withdrawal','transfer')),
Amount int not null check(amount>0),
Transaction_date date,
)
drop table Transactions
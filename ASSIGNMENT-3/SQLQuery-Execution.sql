------------------------------------------------------------------------TASK 2-----------------------------------------------------------------
--1.retrieve the name, account type and email of all customers. 
select (c.Customer_FirstName+' '+c.Customer_LastNAme) as
Customer_Name, c.Customer_Email,
a.Account_Type from Customers c
join Accounts a on c.Customer_id=a.Customer_id

--2.o list all transaction corresponding customer
select t.Transaction_id ,c.Customer_FirstName , Customer_lastName , t.Transaction_date,t.Transaction_Type from Transactions t

join Accounts a on a.Account_id=t.Account_id
 join Customers c on c.Customer_id=a.Customer_id
 where c.Customer_id=4

 --3.increase the balance of a specific account by a certain amount.
 select * from Transactions
 update Transactions set Amount=200000 where Amount=500

 --4.Combine first and last names of customers as a full_name
 
 select concat(Customer_FirstName,' ', Customer_LastName)
 as Customer_Nmae from Customers
 --5.remove accounts with a balance of zero where the account
--type is savings.

INSERT INTO Accounts (Customer_id, Account_Type, Balance)  
VALUES (1, 'Saving', 0.00);
 delete from Accounts where Balance=0.00 and Account_Type='Saving'

 --6.cFind customers living in a specific city
 select Customer_FirstName , Customer_DOB , 
 Customer_Phone from Customers
 where Customer_Address='123 Street, NY'

 --7.Get the account balance for a specific account

 select  c.Customer_firstname , c.Customer_Phone, c.Customer_Email ,
 a.balance from Accounts a
 join Customers c on a.Customer_id=c.Customer_id
 where Account_id=101
 --8.List all current accounts with a balance greater than $8,000
  select  c.Customer_firstname , c.Customer_Phone, c.Customer_Email ,
 a.balance from Accounts a
 join Customers c on a.Customer_id=c.Customer_id
 where a.Balance>=8000

--9.o Retrieve all transactions for a specific account
select Account_id, Transaction_id,Transaction_type, Transaction_date
from Transactions
where Account_id=101

--10.o Calculate the interest accrued on savings accounts based on a
--given interest rate.

select Account_id,Account_Type,Balance ,
(Balance * 0.03) as Interest
from Accounts
where Account_Type='saving'


--11.dentify accounts where the balance is less than a specified
--overdraft limit.
select a.Account_id , c.Customer_id , c.Customer_FirstName,
a.Balance from Accounts a
join Customers c on a.Customer_id=c.Customer_id
where Balance<5000

--12.query to Find customers not living in a specific city
select Customer_id, Customer_FirstName ,Customer_LastName 
from Customers
where Customer_Address not like ('123 Street, NY')

------------------------------------------------------------------------TASK 3----------------------------------------------------------

 --1.Find the average account balance for all customers
 select a.Account_id ,c.Customer_id,c.Customer_FirstName ,
 c.Customer_LastName , avg(a.balance) as Average_Balance from Accounts a
 join Customers c on a.Customer_id=c.Customer_id
 group by a.Account_id ,c.Customer_id,c.Customer_FirstName ,
 c.Customer_LastName 

 --2.Retrieve the top 10 highest account balances.
  
  select top 5 (c.Customer_FirstName+' '+c.Customer_LastName) 
  as Customer_Name  , max(a.Balance) as Max_Balance from Customers c
 join Accounts a on a.Customer_id=c.Customer_id
 group by c.Customer_FirstName,c.Customer_LastName
order by Max_Balance desc

--3.Calculate Total Deposits for All Customers in specific date
select c.Customer_id,c.Customer_FirstName , a.Account_id 
, t.Transaction_id ,t.Transaction_date, sum(t.Amount) as Total_deposit
from Customers c
join Accounts a on a.Customer_id=c.Customer_id
join Transactions t on t.Account_id=a.Account_id
where t.Transaction_date='2024-03-01' and t.Transaction_type='deposit'
group by c.Customer_id,c.Customer_FirstName , a.Account_id ,
t.Transaction_id ,t.Transaction_date

 --4.Find the Oldest and Newest Customers.
select  Customer_firstName as Oldest_Csutomer from
(select top 1  Customer_FirstName from Customers order by Customer_DOB asc) as Oldestcus
union all
select  Customer_FirstName as New_Customer from
(select top 1 Customer_FirstName from Customers order by Customer_DOB desc)as Newcus

--5.Retrieve transaction details along with the account type.
select t.Transaction_id, t.Transaction_type,t.Transaction_date,
a.Account_Type from Transactions t
join Accounts a on a.Account_id=t.Account_id
order by a.Account_Type desc

--6.Get a list of customers along with their account details
select c.Customer_FirstName,a.Balance,a.Account_Type,
a.Account_id from Customers c
join Accounts a on a.Customer_id=c.Customer_id


--7.o Retrieve transaction details along with customer information for a
--specific account.

select c.Customer_FirstName, c.Customer_DOB ,
a.Account_id,t.Transaction_type,t.Transaction_id,
t.Transaction_date  from Customers c
join Accounts a on a.Customer_id=c.Customer_id
join Transactions t on a.Account_id=t.Account_id
---take sschot---
--8.Identify customers who have more than one account
 SELECT c.Customer_id, c.Customer_FirstName, c.Customer_LastName,
COUNT(a.Account_id) AS Account_Count  
FROM Customers c  
JOIN Accounts a ON c.Customer_id = a.Customer_id  
GROUP BY c.Customer_id, c.Customer_FirstName, c.Customer_LastName  
HAVING COUNT(a.Account_id) > 1

--9.difference in transaction amounts between deposits and withdrawals

select  top 5 account_id, 
sum(case when transaction_type = 'deposit' then amount else 0 end) -
sum(case when transaction_type = 'withdrawal' then amount else 0 end) as amount_difference
from transactions
group by account_id
order by amount_difference desc

--10.Calculate the average daily balance for each account 
--over a specified period.
select account_id, avg(balance) as avg_daily_balance
from accounts
where account_id in (select distinct account_id from transactions
where transaction_date between '2024-01-01' and '2024-12-31')
group by account_id


 --11.Calculate the total balance for each account type
 select Account_Type, sum(Balance) as Total_Amount from Accounts
 group by Account_Type

--12.the highest number of transactions order by descending order
 select Account_id ,count(Transaction_Type) as Num_Transactions
 from Transactions group by Account_id
 order by Num_Transactions desc

 --13.high aggregate account balances, along with their account types
 SELECT C.Customer_id,  C.Customer_FirstName,C.Customer_LastName,
 A.Account_Type, SUM(A.Balance) AS Total_Balance
FROM Customers C
JOIN Accounts A ON C.Customer_id = A.Customer_id
GROUP BY C.Customer_id, C.Customer_FirstName, 
C.Customer_LastName, A.Account_Type
HAVING SUM(A.Balance) > 10000
ORDER BY Total_Balance DESC

--14. list duplicate transactions based on transaction amount, date, and account
select Account_id, Amount, Transaction_date, count(*) as duplicate_count
from transactions
group by account_id, amount, transaction_date
having count(*) > 0;

-------------------------------------------------------------------------------TASK 4-------------------------------------------------------------
 select * from Accounts
 select * from Customers
 select * from Transactions

 --1.Retrieve the customer(s) with the highest account balance.
 
 select c.customer_firstname, c.customer_phone, a.balance 
from customers c
join accounts a on c.customer_id = a.customer_id
where a.balance = (select max(balance) from accounts)

--2.average account balance for customers who have more than one account
select Customer_id , avg(Balance)  as Average_balance from Accounts
group by Customer_id
having count(account_id)>1

--3.Retrieve accounts with transactions whose amounts exceed the average transaction amount
select * from Transactions
where Amount>(select avg(Amount) from Transactions)

--4. Identify customers who have no recorded transactions
select c.customer_id , c.customer_firstname from customers c
left join accounts a on a.customer_id=c.Customer_id
left join Transactions t on a.Account_id=t.Account_id
where t.Transaction_id is null

--5.e total balance of accounts with no recorded transactions
select a.Account_id ,sum(a.balance) as total_balance
from accounts a
left join transactions t on a.account_id = t.account_id
where t.transaction_id is null
group by a.Account_id

--6. transactions for accounts with the lowest balance.
select * from transactions
where account_id in (select account_id from accounts where balance = 
(select min(balance) from accounts));

--7.Identify customers who have accounts of multiple types

select customer_id
from accounts
group by customer_id
having count(distinct account_type) > 1

--8.Calculate the percentage of each account
--type out of the total number of accounts

select account_type, count(*) * 100.0 / (select count(*) 
from accounts) as percentage
from accounts group by account_type

--9.Retrieve all transactions for a customer with a given customer_id

select t.*
from transactions t
join accounts a on t.account_id = a.account_id
where a.customer_id = 1

--10.Calculate the total balance for each account type, including a subquery within the SELECT clause
select account_type, (select sum(balance) from accounts a2
where a2.account_type = a1.account_type) as total_balance
from accounts a1 group by account_type














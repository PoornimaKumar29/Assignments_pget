﻿-----------------------------------------------------------------TASK 2---------------------------------------------------------------
-- 1. List all customers:
select * from user_tb

-- 2. List all orders for a specific customer:
select * from courier where sendername = 'Customer_Name'
-- 3. List all couriers:
select * from courier

-- 4. List all packages for a specific order:
select * from courier where courier_id = 101

-- 5. List all deliveries for a specific courier:
select * from courier where status = 'delivered' and courier_id = 101

-- 6. List all undelivered packages:
select * from courier where status <> 'delivered'

-- 7. List all packages that are scheduled for delivery today:
select * from courier where delivary_date = cast(getdate() as date)

-- 8. List all packages with a specific status:
select * from courier where status = 'dispatched'

-- 9. Calculate the total number of packages for each courier:
select sendername, count(*) as total_packages from courier group by sendername

-- 10. Find the average delivery time for each courier (assuming delivery time is calculated using order and delivery date)
select sendername, avg(datediff(day, delivary_date, 
getdate())) as avg_delivery_time from courier group by sendername

-- 11. List all packages with a specific weight range (replace 2 and 5 with the desired range)
select * from courier where weight between 2 and 5;

-- 12. Retrieve employees whose names contain 'john'
select * from employee where employee_name like '%john%'

-- 13. Retrieve all courier records with payments greater than $50
select c.* from courier c 
join payment p on c.courier_id = p.courier_id 
where p.amount > 50
----------------------------------------------------------------------------TASK 3-----------------------------------------------------
-- 14. Find the total number of couriers handled by each employee

select e.employee_name, count(c.courier_id) as total_couriers 
from employee e 
join courier c on e.employee_id = c.courier_id 
group by e.employee_name

-- 15. Calculate the total revenue generated by each location
select l.location_name, sum(p.amount) as total_revenue 
from location l 
join payment p on l.location_id = p.location_id 
group by l.location_name

-- 16. Find the total number of couriers delivered to each location
select l.location_name, count(c.courier_id) as total_deliveries 
from location l 
join payment p on l.location_id = p.location_id 
join courier c on p.courier_id = c.courier_id 
where c.status = 'delivered' 
group by l.location_name

-- 17. Find the courier with the highest average delivery time
select top 1 sendername, avg(datediff(day, delivary_date, getdate())) as avg_delivery_time 
from courier 
group by sendername 
order by avg_delivery_time desc

-- 18. Find locations with total payments less than a certain amount (replace 500 with desired amount)
select l.location_name, sum(p.amount) as total_payments 
from location l 
join payment p on l.location_id = p.location_id 
group by l.location_name 
having sum(p.amount) < 500

-- 19. Calculate total payments per location
select l.location_name, sum(p.amount) as total_payments 
from location l 
join payment p on l.location_id = p.location_id 
group by l.location_name

-- 20. Retrieve couriers who have received payments totaling more than $1000 in a specific location (replace X with location ID)
SELECT c.Courier_id, c.SenderName, SUM(p.Amount) AS Total_Payments
FROM Courier c
JOIN Payment p ON c.Courier_id = p.Courier_id
WHERE p.Location_id = 201
GROUP BY c.Courier_id, c.SenderName
select * from Courier
select * from Payment
-- 21. Retrieve couriers who have received payments totaling more than $1000 after a certain date (replace 'YYYY-MM-DD' with actual date)
select c.sendername, sum(p.amount) as total_payments 
from courier c 
join payment p on c.courier_id = p.courier_id 
where p.paymentdate > '2024-03-02' 
group by c.sendername 
having sum(p.amount) > 100
select * from Payment
-- 22. Retrieve locations where the total amount received is more than $5000 before a certain date (replace 'YYYY-MM-DD' with actual date)
select l.location_name, sum(p.amount) as total_payments 
from location l 
join payment p on l.location_id = p.location_id 
where p.paymentdate < '2025-03-02' 
group by l.location_name 
having sum(p.amount) > 50

----------------------------------------------------------------------TASK 4_----------------------------------------------------------------------------
--23. Retrieve Payments with Courier Information

SELECT p.Payment_id, p.Amount, p.PaymentDate, 
c.Courier_id, c.SenderName, c.ReceiverName, c.Status, c.Tracking_Number
FROM Payment p
JOIN Courier c ON p.Courier_id = c.Courier_id

--24. Retrieve Payments with Location Information

SELECT p.Payment_id, p.Amount, p.PaymentDate, 
l.Location_id, l.Location_Name, l.Address
FROM Payment p
JOIN Location l ON p.Location_id = l.Location_id

--25. Retrieve Payments with Courier and Location Information

SELECT p.Payment_id, p.Amount, p.PaymentDate, c.Courier_id,
c.SenderName, c.ReceiverName, c.Status, c.Tracking_Number,
l.Location_id, l.Location_Name, l.Address
FROM Payment p
JOIN Courier c ON p.Courier_id = c.Courier_id
JOIN Location l ON p.Location_id = l.Location_id

--26. List all payments with courier details

SELECT p.*, c.* FROM Payment p
JOIN Courier c ON p.Courier_id = c.Courier_id

--27. Total payments received for each courier

SELECT c.Courier_id, c.SenderName, c.ReceiverName, SUM(p.Amount) AS Total_Payment
FROM Payment p
JOIN Courier c ON p.Courier_id = c.Courier_id
GROUP BY c.Courier_id, c.SenderName, c.ReceiverName

--28. List payments made on a specific date (e.g., '2024-03-10')

SELECT * FROM Payment WHERE PaymentDate = '2024-03-10'

--29. Get Courier Information for Each Payment

SELECT p.Payment_id, p.Amount, p.PaymentDate, 
c.Courier_id, c.SenderName, c.ReceiverName, c.Weight, c.Status, c.Tracking_Number
FROM Payment p
LEFT JOIN Courier c ON p.Courier_id = c.Courier_id
--30. get payment details with location

select p.payment_id, p.amount, p.paymentdate, 
l.location_id, l.location_name, l.address
from payment p
left join location l on p.location_id = l.location_id
--31. calculating total payments for each courier

select c.courier_id, c.sendername, c.receivername, sum(p.amount) as total_payment
from payment p
join courier c on p.courier_id = c.courier_id
group by c.courier_id, c.sendername, c.receivername

--32. list payments within a date range

select * from payment 
where paymentdate between '2024-03-01' and '2024-03-10'

--33. retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side

select u.user_id, u.user_name, c.courier_id, c.sendername, c.receivername
from user_tb u
full join courier c on u.user_id = c.courier_id;

--34. retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side

select c.courier_id, c.sendername, c.receivername, 
cs.service_id, cs.servicename, cs.cost
from courier c
full outer join courierservice cs on 
c.courier_id =cs.service_id;

--35. retrieve a list of all employees and their corresponding payments, including cases where there are no matches on either side

select e.employee_id, e.employee_name, p.payment_id, p.amount, p.paymentdate
from employee e
full outer join courier c on e.employee_id = c.employee_id
full outer join payment p on c.courier_id = p.Courier_id
--36. list all users and all courier services, showing all possible combinations

select u.user_id, u.user_name, cs.service_id, 
cs.servicename, cs.cost
from user_tb u
cross join courierservice cs;

--37. list all employees and all locations, showing all possible combinations

select e.employee_id, e.employee_name, l.location_id, 
l.location_name, l.address
from employee e
cross join location l

--38. retrieve a list of couriers and their corresponding sender information (if available)

select c.courier_id, c.tracking_number, c.status, 
u.user_id as sender_id, u.user_name as sender_name, 
u.user_address as sender_address
from courier c
left join user_tb u on c.sendername = u.user_name

--39. retrieve a list of couriers and their corresponding receiver information (if available)

select c.courier_id, c.tracking_number, c.status, c.weight, 
u.user_id, u.user_name, u.user_email, 
u.user_phone, u.user_address
from courier c
left join user_tb u on c.ReceiverName=u.User_Name

--40. retrieve a list of couriers along with the courier service details (if available)

select c.courier_id, c.tracking_number, c.status, 
cs.service_id, cs.servicename, cs.cost
from courier c
left join courierservice cs on c.courier_id = cs.service_id;

--41. retrieve a list of employees and the number of couriers assigned to each employee

select e.employee_id, e.employee_name, count(c.courier_id) as total_couriers
from employee e
left join courier c on e.employee_id = c.employee_id
group by e.employee_id, e.employee_name
--42. retrieve a list of locations and the total payment amount received at each location

select l.location_id, l.location_name, sum(p.amount) 
as total_payment from location l
left join payment p on l.location_id = p.location_id
group by l.location_id, l.location_name;

--43. retrieve all couriers sent by the same sender (based on sendername)

select * from courier 
where sendername in (select sendername from courier 
group by sendername having count(*) > =1)

--44. list all employees who share the same role

select * from employee 
where employee_role in (select employee_role from employee 
group by employee_role having count(*) > =1)

--45. retrieve all payments made for couriers sent from the same location

select p.* from payment p
join courier c on p.courier_id = c.courier_id
where c.senderaddress in (
select senderaddress from courier 
group by senderaddress having count(*) >=1)

--46. retrieve all couriers sent from the same location (based on senderaddress)
select * from courier 
where senderaddress in (
select senderaddress from courier 
group by senderaddress having count(*) > =1)

--47. list employees and the number of couriers they have delivered

select e.employee_id, e.employee_name, count(c.courier_id) as delivered_couriers
from employee e
join courier c on e.employee_id = c.employee_id
where c.status = 'delivered'
group by e.employee_id, e.employee_name

--48. find couriers that were paid an amount greater than the cost of their respective courier services

select p.payment_id, p.courier_id, p.amount, cs.cost
from payment p
join courier c on p.courier_id = c.courier_id
join courierservice cs on c.courier_id = cs.service_id
where p.amount > =cs.cost

--49. find couriers that have a weight greater than the average weight of all couriers

select * from courier 
where weight > (select avg(weight) from courier)

--50. find the names of all employees who have a salary greater than the average salary

select employee_name from employee 
where salary > (select avg(salary) from employee)

--51. find the total cost of all courier services where the cost is less than the maximum cost

select sum(cost) as total_cost from courierservice 
where cost < (select max(cost) from courierservice)

--52. find all couriers that have been paid for

select * from courier 
where exists (select 1 from payment
where payment.courier_id = courier.courier_id)

--53. find the locations where the maximum payment amount was made

select location_id, location_name from location 
where location_id in 
(select location_id from payment where amount =
(select max(amount) from payment));
--54. find all couriers whose weight is greater than the weight of all couriers sent by a specific sender (e.g., 'SenderName')

select * from courier 
where weight > all 
(select weight from courier where sendername = 'John Doe')


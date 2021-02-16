--1
select productid,supplierid  into catalogue from products p 

--3
select c.SupplierID,count(p.productid) from Products p join catalogue c on p.ProductID=c.ProductID
group by c.SupplierID
having count(p.productid)>2 and count(p.productid)<=4
--4.List out the third costliest product
select * from products where UnitPrice=(
SELECT TOP 1 UnitPrice 
FROM 
    (SELECT TOP 3 unitprice 
     FROM products 
     ORDER BY unitprice DESC) AS Comp 
ORDER BY unitprice ASC)
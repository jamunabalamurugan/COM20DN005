CREATE DATABASE "Tome"

--BookDetails******************************************************************************************************************************** 

CREATE TABLE "BookDetails"
("bookID" int IDENTITY(1, 1) NOT NULL,
"ISBN" nvarchar(15) NOT NULL,
"authorID" int NOT NULL,
"publisherID" int NOT NULL,
"publishedDate" datetime NULL,
"edition" nvarchar(50) NULL,
"bookName" nvarchar(50) NOT NULL,
"bookType" nvarchar(20) NULL,
"language" nvarchar(20) NULL,
"bookPrice" money NOT NULL,
"description" ntext NULL,
"photoPath" nvarchar(250) NULL,
"dimension" nvarchar(50) NULL,
"viewCount" int NOT NULL DEFAULT 0,
"subcategoryID" int NOT NULL,
CONSTRAINT "PK_bookID" PRIMARY KEY  CLUSTERED ("bookID"),
CONSTRAINT "CK_publishedDate" CHECK (publishedDate < getdate()),
CONSTRAINT "FK_BookDetails_authorID" FOREIGN KEY ("authorID") REFERENCES "dbo"."Authors" ("authorID"),
CONSTRAINT "FK_BookDetails_publisherID" FOREIGN KEY ("publisherID") REFERENCES "dbo"."PublisherDetails" ("publisherID"),
CONSTRAINT "FK_BookDetails_subcategoryID" FOREIGN KEY ("subcategoryID") REFERENCES "dbo"."Subcategory" ("subcategoryID")
)

--Category----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Category"
("categoryID" int IDENTITY(1, 1) NOT NULL,
"categoryName" nvarchar(30) NOT NULL,
CONSTRAINT "PK_categoryID" PRIMARY KEY  CLUSTERED ("categoryID")
)

--Subcategory---------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Subcategory"
("subcategoryID" int IDENTITY(1, 1) NOT NULL,
"categoryID" int NOT NULL,
"subcategoryName" nvarchar(30) NOT NULL,
CONSTRAINT "PK_subcategoryID" PRIMARY KEY  CLUSTERED ("subcategoryID"),
CONSTRAINT "FK_Subcategory_categoryID" FOREIGN KEY ("categoryID") REFERENCES "dbo"."Category"("categoryID")
)

--RatingDetails-------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "RatingDetails"
("ratingID" int IDENTITY(1, 1) NOT NULL,
"bookID" int NOT NULL,
"userID" int NOT NULL,
"rating" decimal NULL,
CONSTRAINT "PK_ratingID" PRIMARY KEY  CLUSTERED ("ratingID"),
CONSTRAINT "FK_RatingDetails_bookID" FOREIGN KEY ("bookID") REFERENCES "dbo"."BookDetails" ("bookID"),
CONSTRAINT "FK_RatingDetails_userID" FOREIGN KEY ("userID") REFERENCES "dbo"."Users" ("userID")
)

--Authors-----------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Authors"
("authorID" int IDENTITY(1,1) NOT NULL,
"authorName" nvarchar(50) NOT NULL,
"city" nvarchar(20) NULL,
"state" nvarchar(20) NULL,
"country" nvarchar(20) NULL,
CONSTRAINT "PK_authorID" PRIMARY KEY  CLUSTERED ("authorID"),
)

--PublisherDetails----------------------------------------------------------------------------------------------------------------------------------------------------

 CREATE TABLE "PublisherDetails"
("publisherID" int IDENTITY(1,1) NOT NULL,
"publisherName" nvarchar(30) NOT NULL,
"phone" nvarchar(15) NULL,
"address" nvarchar(100) NULL,
"city" nvarchar(20) NULL,
"state" nvarchar(20) NULL,
"country" nvarchar(20) NULL,
CONSTRAINT "PK_publisherID" PRIMARY KEY  CLUSTERED ("publisherID"),
)

--Suppliers---------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Suppliers"
("supplierID" int IDENTITY(1,1) NOT NULL,
"companyName" nvarchar(20) NOT NULL,
"password" nvarchar(max) NOT NULL,
"email" nvarchar(30) NOT NULL,
"contactName" nvarchar(20) NOT NULL,
"phone" nvarchar(15) NOT NULL,
"address" nvarchar(100) NULL,
"city" nvarchar(20) NULL,
"state" nvarchar(20) NULL,
"country" nvarchar(20) NULL,
CONSTRAINT "PK_supplierID" PRIMARY KEY CLUSTERED ("supplierID")
)

--BookAvailability-------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "BookAvailability"
("BookAvailabilityID" int IDENTITY(1,1) NOT NULL,
"bookID" int NOT NULL,
"supplierID" int NOT NULL,
"rentalPrice" money NOT NULL,
"actualAvailability" int NOT NULL,
"currentAvailability" int NOT NULL,
CONSTRAINT "PK_BookAvailabilityID" PRIMARY KEY CLUSTERED ("BookAvailabilityID"),
CONSTRAINT "FK_BookAvailability_bookID" FOREIGN KEY ("bookID") REFERENCES "dbo"."BookDetails"("bookID"),
CONSTRAINT "FK_BookAvailability_supplierID" FOREIGN KEY ("supplierID") REFERENCES "dbo"."Suppliers"("supplierID")
)

--Membership-------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Membership"
("membershipID" int IDENTITY(1,1) NOT NULL,
"membershipPlan" nvarchar(15) NULL,
"planCost" money NOT NULL
CONSTRAINT "PK_membershipID" PRIMARY KEY CLUSTERED ("membershipID")
)

--Users-----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Users"
("userID" int IDENTITY(1,1) NOT NULL,
"userName" nvarchar(30) NOT NULL,
"password" nvarchar(max) NOT NULL,
"email" nvarchar(30) NOT NULL,
"name" nvarchar(20) NOT NULL,
"dateOfBirth" datetime NOT NULL,
"phone" nvarchar(15) NOT NULL,
"address" nvarchar(50) NULL,
"city" nvarchar(20) NULL,
"state" nvarchar(20) NULL,
"country" nvarchar(20) NULL,
CONSTRAINT "PK_userID" PRIMARY KEY CLUSTERED ("userID"),
CONSTRAINT "CK_dateOfBirth" CHECK ("dateOfBirth" < getdate())
)

--MembershipDetails-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "MembershipDetails"
("membershipDetailsID" int IDENTITY(1,1) NOT NULL,
"membershipID" int NOT NULL,
"userID" int NOT NULL,
"planFromDate" datetime NULL,
"planToDate" datetime NULL,
CONSTRAINT "PK_membershipDetailsID" PRIMARY KEY CLUSTERED ("membershipDetailsID"),
CONSTRAINT "FK_MembershipDetails_membershipID" FOREIGN KEY ("membershipID") REFERENCES "dbo"."Membership"("membershipID"),
CONSTRAINT "FK_MembershipDetails_userID" FOREIGN KEY ("userID") REFERENCES "dbo"."Users"("userID"),
)

--CartDetails-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "CartDetails"
("cartID" int IDENTITY(1,1) NOT NULL,
"userID" int NOT NULL,
"bookID" int NOT NULL,
"quantity" int NULL,
CONSTRAINT "PK_cartID" PRIMARY KEY CLUSTERED ("cartID"),
CONSTRAINT "FK_CartDetails_userID" FOREIGN KEY ("userID") REFERENCES "dbo"."Users"("userID"),
CONSTRAINT "FK_CartDetails_bookID" FOREIGN KEY ("bookID") REFERENCES "dbo"."BookDetails"("bookID"),
)

--Shippers---------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Shippers"
("shipperID" int IDENTITY(1,1) NOT NULL,
"shipperComapanyName" nvarchar(30) NOT NULL,
"phone" nvarchar(15) NOT NULL,
"address" nvarchar(100) NULL,
"city" nvarchar(20) NULL,
"state" nvarchar(20) NULL,
"country" nvarchar(20) NULL,
CONSTRAINT "PK_shipperID" PRIMARY KEY CLUSTERED ("shipperID")
)

--Discounts----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Discounts"
("discountID" int IDENTITY(1,1) NOT NULL,
"discountPercentage" int NULL,
"discountCoupon" nvarchar(5) NULL,
CONSTRAINT "PK_discountID" PRIMARY KEY CLUSTERED ("discountID")
)

--Orders-------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "Orders"
("orderID" int IDENTITY(1,1) NOT NULL,
"userID" int NOT NULL,
"shipperID" int NOT NULL,
"supplierID" int NOT NULL,
"orderDate" datetime NOT NULL,
"deliveryDate" datetime NOT NULL,
"lendingDate" datetime NOT NULL,
"returnDate" datetime NOT NULL,
"actualReturnDate" datetime NULL,
"borrowExtendedDays" int NULL,
"totalPrice" money NOT NULL,
"totalQuantity" int NOT NULL,
"discountID" int NULL,
"orderStatus" nvarchar(10) NOT NULL,
CONSTRAINT "PK_orderID" PRIMARY KEY CLUSTERED ("orderID"),
CONSTRAINT "FK_Orders_discountID" FOREIGN KEY ("discountID") REFERENCES "dbo"."Discounts"("discountID"),
CONSTRAINT "FK_Orders_userID" FOREIGN KEY ("userID") REFERENCES "dbo"."Users"("userID"),
CONSTRAINT "FK_Orders_shipperID" FOREIGN KEY ("shipperID") REFERENCES "dbo"."Shippers"("shipperID"),
CONSTRAINT "FK_Orders_supplierID" FOREIGN KEY ("supplierID") REFERENCES "dbo"."Suppliers"("supplierID"),
CONSTRAINT "CK_orderDate_deliveryDate" CHECK ("orderDate" < "deliveryDate"),
CONSTRAINT "CK_lendingDate_returnDate" CHECK ("lendingDate" < "returnDate"),
CONSTRAINT "CK_deliveryDate_lendingDate" CHECK ("deliveryDate" = "lendingDate")
)

--OrderDetails--------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "OrderDetails"
("orderDetailsID" int IDENTITY(1,1) NOT NULL,
"orderID" int NOT NULL,
"bookID" int NOT NULL,
"quantity" int NOT NULL,
CONSTRAINT "PK_orderDetailsID" PRIMARY KEY CLUSTERED ("orderDetailsID"),
CONSTRAINT "FK_OrderDetails_orderID" FOREIGN KEY ("orderID") REFERENCES "dbo"."Orders"("orderID"),
CONSTRAINT "FK_OrderDetails_bookID" FOREIGN KEY ("bookID") REFERENCES "dbo"."BookDetails"("bookID")
)

--Feedbackdetails-------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE "FeedbackDetails"
("feedbackID" int IDENTITY(1,1) NOT NULL,
"userID" int NOT NULL,
"feedbackdate" datetime NOT NULL,
"subject" nvarchar(max) NOT NULL,
"feedback" ntext NOT NULL,
CONSTRAINT "PK_feedbackID" PRIMARY KEY CLUSTERED ("feedbackID"),
CONSTRAINT "FK_FeedbackDetails_userID" FOREIGN KEY ("userID") REFERENCES "dbo"."Users"("userID"),
CONSTRAINT "CK_feedbackdate" CHECK ("feedbackdate" < getdate())
)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT * FROM "Suppliers"

SELECT * FROM "Users"
 
SELECT * FROM "Authors"

SELECT * FROM "BookAvailability"

SELECT * FROM "BookDetails"

SELECT * FROM "Publisherdetails"

SELECT * FROM "Subcategory"

SELECT * FROM "OrderDetails"

SELECT * FROM "CartDetails"

SELECT * FROM "Shippers"

SELECT * FROM "RatingDetails" 

SELECT * FROM "FeedbackDetails"

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO "Category"("categoryName") VALUES ('Biography')
INSERT INTO "Category"("categoryName") VALUES ('Business and Management')
INSERT INTO "Category"("categoryName") VALUES ('Children')
INSERT INTO "Category"("categoryName") VALUES ('Fiction')
INSERT INTO "Category"("categoryName") VALUES ('History and current affairs')
INSERT INTO "Category"("categoryName") VALUES ('Non-fiction')
INSERT INTO "Category"("categoryName") VALUES ('Religion')
INSERT INTO "Category"("categoryName") VALUES ('Poem')

INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (1, 'Business Personalities')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (1, 'Politicians And Leaders')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (1, 'Sports Personalities')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (2, 'Finance')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (2, 'Leadership')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (2, 'Marketing and Sales')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (3, 'Schoolbooks')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (3, 'Classic stories')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (4, 'Action and Adventures')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (4, 'Literacy and Fiction')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (4, 'Mystery and Thrillers')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (4, 'Romance ')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (4, 'Science Fiction and Fantasy')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (5, 'Current affairs')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (5, 'Politics and economics')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (6, 'Travel')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (6, 'General')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (7, 'Mythology')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (7, 'Spirituality')
INSERT INTO "Subcategory"("categoryID", "subcategoryName") VALUES (8, 'Poems')

INSERT INTO Shippers(shipperComapanyName, phone, "address", city, "state", country)
VALUES ('BlueMax Shipping Company', '9980105620', 'No. 107, Gandhi road, Velachari', 'Chennai', 'Tamil Nadu', 'India')
INSERT INTO Shippers(shipperComapanyName, phone, "address", city, "state", country)
VALUES ('Indian Shippers', '9880995691', 'No. 14, 3rd cross, Bhandra main road, Bhandra', 'Mumbai', 'Maharashtra', 'India')
INSERT INTO Shippers(shipperComapanyName, phone, "address", city, "state", country)
VALUES ('Fedex Free Pickup', '9822406350', 'No. 193, Avenue road, K R Market', 'Bangalore', 'Karnataka', 'India')

--------------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON VIEWCOUNT
-------------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByViewCount @viewCount int
AS
BEGIN
SELECT TOP (@viewCount) * FROM BookDetails ORDER BY viewCount DESC 
END

EXEC DisplayByViewCount @ViewCount = 6

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON PUBLISHED DATE
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE dbo.NewOnes @publishedbook int
AS
BEGIN
SELECT TOP (@publishedbook) * FROM BookDetails ORDER BY publishedDate DESC
END

EXEC dbo.NewOnes @publishedbook = 3

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON CATEGORY
---------------------------------------------------------------------------------------------------------------------------------------------------------
create PROCEDURE dbo.DisplayByCategory @categoryName nvarchar(30)
AS
BEGIN
Select bookID, bookName, bookPrice, authorID, publisherID, categoryName 
FROM BookDetails 
JOIN Subcategory 
ON Subcategory.subcategoryID = BookDetails.subcategoryID 
JOIN Category 
on subcategory.categoryID = Category.categoryID
END

EXEC dbo.DisplayByCategory @categoryName = 'fiction'

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON BOOKNAME
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByBookName @bookName nvarchar(50)
AS
BEGIN
SELECT * FROM BookDetails WHERE bookName = @bookName
END

EXEC DisplayByBookName @bookName = '2 states' 

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON SUBCATEGORY
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayBySubcategory @subcategoryName nvarchar(30)
AS
BEGIN
SELECT bookID, bookName, bookPrice, authorID, publisherID, subcategoryName
FROM BookDetails
JOIN Subcategory
ON Subcategory.subcategoryID = BookDetails.subcategoryID 
WHERE subcategoryName = @subcategoryName
END

EXEC DisplayBySubcategory @subcategoryName ='romance'

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON LANGUAGE
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByLanguage @language nvarchar(20)
AS
BEGIN
SELECT * FROM BookDetails WHERE "language" = @language
END

EXEC DisplayByLanguage @language = 'Hindi'

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON AUTHOR
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByAuthor @authorName nvarchar(50)
AS
BEGIN
SELECT bookID, bookName, bookPrice, authorName, publisherID
FROM BookDetails 
JOIN Authors
ON Authors.authorID = BookDetails.authorID 
WHERE authorName = @authorName
END

EXEC DisplayByAuthor @authorName = 'Chetan Bhagat'

---------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BASED ON PUBLISHER NAME
---------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByPublisher @publisherName nvarchar(30)
AS
BEGIN
SELECT bookID, bookName, bookPrice, publisherName, authorID
FROM BookDetails 
JOIN PublisherDetails
ON PublisherDetails.publisherID = BookDetails.publisherID 
WHERE publisherName = @publisherName
END

EXEC DisplayByPublisher @publisherName = 'Bloomsberry'

------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY AVERAGE BOOK RATING
------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayByRating @bookID int
AS
BEGIN
SELECT bd.bookName, AVG(rating)
FROM RatingDetails
JOIN BookDetails bd ON RatingDetails.BookID = bd.bookID 
WHERE RatingDetails.bookID = @bookID
GROUP BY RatingDetails.bookID, bd.bookName
END

EXEC DisplayByRating @bookID = 43

-------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY EXPENSIVE BOOKS
-------------------------------------------------------------------------------------------------------------------------------------------------------
create PROCEDURE DisplayExpensiveBooks @expensivebooks int
AS
BEGIN
SELECT TOP (@expensivebooks) * FROM BookDetails ORDER BY bookPrice DESC
END

EXEC DisplayExpensiveBooks @expensivebooks = 20

-------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY ECONOMICAL BOOKS
-------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayEconomicalBooks @economicalbooks int
AS
BEGIN
SELECT TOP (@economicalbooks) * FROM BookDetails ORDER BY bookPrice
END

EXEC DisplayEconomicalBooks @economicalbooks = 20

-------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY BOOK INFORMATION
-------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE AuthorDetails
AS
BEGIN
SELECT  authorName, publishername, bookName, publishedDate, "language", bookPrice, viewCount, subcategoryName, actualAvailability, currentAvailability
FROM BookDetails 
JOIN PublisherDetails 
ON PublisherDetails.publisherID = BookDetails.publisherID 
JOIN Authors 
ON Authors.authorID = BookDetails.authorID
JOIN Subcategory
ON Subcategory.subcategoryID = BookDetails.subcategoryID
JOIN BookAvailability
ON BookAvailability.bookID = BookDetails.bookID
END 

EXEC AuthorDetails

-----------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDUE TO DISPLAY ORDER HISTORY
-----------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayOrderHistory @userID int
AS
BEGIN
SELECT bookname, totalprice, quantity, name, bookprice, lendingDate FROM BookDetails
join OrderDetails on BookDetails.bookID = OrderDetails.bookID
join orders on OrderDetails.orderID = Orders.orderID
join Users on Orders.userID = Users.userID
Where Users.userID = @userID
END

EXEC DisplayOrderHistory @userID = 18

-------------------------------------------------------------------------------------------------------------------------------------------------------------
--STORED PROCEDURE TO DISPLAY CART DETAILS
-------------------------------------------------------------------------------------------------------------------------------------------------------------

create PROCEDURE DisplayCartDetails @userID int
AS
BEGIN
SELECT sum(rentalprice)*10 as Subtotal FROM CartDetails
JOIN Users on Users.userID = CartDetails.userID
JOIN BookDetails on BookDetails.bookID = CartDetails.bookID
JOIN  BookAvailability on BookAvailability.bookID = cartDetails.bookID
WHERE Users.userID = @userID
group by Users.userID
END

EXEC DisplayCartDetails @userID = 79

-------------------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO users(userName, "password", email, name, dateofbirth,phone)
VALUES ('Kavin', '123456', 'Kavin@gmail.com','Kavin Kumar', '3/10/2021','9444032689')

INSERT INTO CartDetails(userID, bookID, Quantity)
VALUES (62, 21, 1)

INSERT INTO Orders(userID, shipperID, supplierID, orderDate, deliveryDate, lendingDate, returnDate, actualReturnDate, borrowExtendedDays, totalPrice, totalQuantity, orderStatus )
VALUES ('18','1','10','4/18/2019','4/20/2019','4/20/2019','5/20/2019','5/17/2019','0','40','1','Received')
INSERT INTO Orders(userID, shipperID, supplierID, orderDate, deliveryDate, lendingDate, returnDate, actualReturnDate, borrowExtendedDays, totalPrice, totalQuantity, orderStatus )
VALUES ('18','1','3','6/24/2019','6/26/2019','6/26/2019','7/26/2019','7/20/2019','0','20','1','Received')
INSERT INTO Orders(userID, shipperID, supplierID, orderDate, deliveryDate, lendingDate, returnDate, totalPrice, totalQuantity, orderStatus )
VALUES ('18','1','3','10/10/2019','10/12/2019','10/12/2019','11/11/2019','70','1','On rent')
INSERT INTO Orders(userID, shipperID, supplierID, orderDate, deliveryDate, lendingDate, returnDate, actualReturnDate, borrowExtendedDays, totalPrice, totalQuantity, orderStatus )
VALUES ('18','1','1','8/1/2019','8/3/2019','8/3/2019','9/2/2019','9/1/2019','0','20','1','Received')

INSERT INTO OrderDetails(orderID, bookID, quantity )
VALUES ('3', '11','1' )
INSERT INTO OrderDetails(orderID, bookID, quantity )
VALUES ('5', '36','1' )
INSERT INTO OrderDetails(orderID, bookID, quantity )
VALUES ('6', '70','1' )
INSERT INTO OrderDetails(orderID, bookID, quantity )
VALUES ('7', '45','1' )
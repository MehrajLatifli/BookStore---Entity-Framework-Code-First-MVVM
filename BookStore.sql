create database BookStoreDB


use BookStoreDB



create table Books
(
IdBook int primary key IDENTITY (1,1) NOT NULL,
BookName nvarchar(max) NOT NULL,
BookPrice money NOT NULL,
BookQuantity bigint NOT NULL,

Constraint CK_BookName Check(BookName <>' '),
)







create table Press
(
IdPress int primary key IDENTITY (1,1) NOT NULL,
PressName nvarchar(max) NOT NULL,
PressYear nvarchar(max) NOT NULL,


Constraint CK_PressName Check(PressName <>' '),
Constraint CK_PressYear Check(PressYear <>' ')

)






create table Authors
(
IdAuthor int primary key IDENTITY (1,1) NOT NULL,
Author1 nvarchar(max) NOT NULL,
Author2 nvarchar(max) NOT NULL,

Constraint CK_AuthorFirtName Check(Author1 <>' '),
Constraint CK_AuthorLastName Check(Author2 <>' ')
)







create table BookDetails
(
IdBookDetail int primary key IDENTITY (1,1) NOT NULL,

BookId_forBookDetail int NOT NULL,
AuthorId_forBookDetail int NOT NULL,
PressId_forBookDetail int NOT NULL,


Constraint FK_BookId_forBA Foreign key (BookId_forBookDetail) References Books(IdBook) On Delete CASCADE On Update CASCADE,
Constraint FK_AuthorId_forBA Foreign key (AuthorId_forBookDetail) References Authors(IdAuthor) On Delete CASCADE On Update CASCADE,
Constraint FK_PressId_forBA Foreign key (PressId_forBookDetail) References Press(IdPress) On Delete CASCADE On Update CASCADE
)





CREATE TABLE BookStoreDB.dbo.Customers
(
IdCustomers int primary key IDENTITY (1,1) NOT NULL,
[Name of Customers]  nvarchar(100) NOT NULL,
[Passwords of Customers]  nvarchar(100) NOT NULL,

Constraint CK_Name_of_Customers Check([Name of Customers] <>' '),
Constraint CK_Passwords_of_Customers Check([Passwords of Customers] <>' '),
Constraint UK_Passwords_of_Customers Unique([Passwords of Customers])
)





CREATE TABLE BookStoreDB.dbo.Admins
(
IdAdmins int primary key IDENTITY (1,1) NOT NULL,
[Name of Admins]  nvarchar(100) NOT NULL,
[Passwords of Admins]  nvarchar(100) NOT NULL,

Constraint CK_Name_of_Admins Check([Name of Admins] <>' '),
Constraint CK_Passwords_of_Admins Check([Passwords of Admins] <>' '),
Constraint UK_Passwords_of_Admins Unique([Passwords of Admins])
)




create table Cashregisters
(
IdCashregister int primary key IDENTITY (1,1) NOT NULL,
Profit money,
CustomersId_for_Cashregister int  NOT NULL,
BookId_forCashregister int NOT NULL,

Constraint FK_CustomersIdforOrders Foreign key (CustomersId_for_Cashregister) References Customers(IdCustomers) On Delete CASCADE On Update CASCADE,
Constraint FK_BookId_forC Foreign key (BookId_forCashregister) References Books(IdBook) On Delete CASCADE On Update CASCADE
)




-- GetAll


select 
*
from 
BookStoreDB.dbo.Books
Inner Join
BookStoreDB.dbo.BookDetails
On
BookStoreDB.dbo.Books.IdBook=BookStoreDB.dbo.BookDetails.BookId_forBookDetail
Inner Join
BookStoreDB.dbo.Authors
On
BookStoreDB.dbo.Authors.IdAuthor=BookStoreDB.dbo.BookDetails.AuthorId_forBookDetail





select *from Books
select *from Authors
select *from Press
select *from BookDetails
select *from Cashregisters



















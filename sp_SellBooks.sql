
use BookStoreDB




-- sp_SellBooks


Create OR Alter Procedure sp_SellBooks
@CustomerId as int,
@IdBook as int,
@SellBookQuantity as int
AS
BEGIN
  DECLARE @BookQuantity as bigint
  DECLARE @BookPrice as money
  DECLARE @BookName as nvarchar(max)
  BEGIN Transaction sp_SellBooks_TR
  select
  @BookQuantity=BookStoreDB.dbo.Books.BookQuantity,
  @BookName=BookStoreDB.dbo.Books.BookName,
  @BookPrice=BookStoreDB.dbo.Books.BookPrice
  from
  BookStoreDB.dbo.Books
  where
  @IdBook=BookStoreDB.dbo.Books.IdBook
  if(Not EXISTS
  (
   select
   *from
   BookStoreDB.dbo.Books
   where
   @IdBook=BookStoreDB.dbo.Books.IdBook
  )
  )
  BEGIN
    print 'Can not find this book'
    rollback TRANSACTION sp_SellBooks_TR
  END
  else
  BEGIN
	  if(@BookQuantity>0)
	  BEGIN
       select
	   @CustomerId=BookStoreDB.dbo.Customers.IdCustomers
       from
       BookStoreDB.dbo.Customers
       
        INSERT INTO   BookStoreDB.dbo.Cashregisters(Cashregisters.Profit, CustomersId_for_Cashregister, Cashregisters.BookId_forCashregister)
        values(@BookPrice, @CustomerId, @IdBook)

		print 'The checkout process is correct.'

        Update BookStoreDB.dbo.Books
        Set BookStoreDB.dbo.Books.BookQuantity=BookStoreDB.dbo.Books.BookQuantity-@SellBookQuantity
        where @IdBook=BookStoreDB.dbo.Books.IdBook

		print 'A book was bought from a BookStoreDB.'

		SELECT SUM(Profit)
        FROM Cashregisters

        COMMIT TRANSACTION sp_SellBooks_TR
	  END
	  else
	  BEGIN
		print 'The book called '+@BookName+ ' is no longer available in the store.'
        rollback TRANSACTION sp_SellBooks_TR
	  END
  END
END




select *from Books
select *from Cashregisters

exec sp_SellBooks 0, 0, 1

SELECT SUM(Profit)
FROM Cashregisters
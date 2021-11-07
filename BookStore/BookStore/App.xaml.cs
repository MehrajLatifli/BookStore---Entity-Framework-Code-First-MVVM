using BookStore.DataAccess;
using BookStore.Domain.Abstractions;
using BookStore.Models.DataAccess.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;


        public static void reseed()
        {
            using (var context = new BookStoreModel())
            {


                var count = context.BookDetails
               .Where(o => o.IdBookDetail <= '0')
               .SelectMany(o => o.Book.BookDetails)
               .Count();

                try
                {

                    if (count == 0)
                    {
                        context.Database.ExecuteSqlCommand(@"  delete from BookStoreDB.dbo.Books");
                        context.Database.ExecuteSqlCommand(@"  delete from BookStoreDB.dbo.Authors");
                        context.Database.ExecuteSqlCommand(@"  delete from BookStoreDB.dbo.Press");
                        context.Database.ExecuteSqlCommand(@"  delete from BookStoreDB.dbo.BookDetails");
                        context.Database.ExecuteSqlCommand(@"  delete from BookStoreDB.dbo.Cashregisters");



                        context.Database.ExecuteSqlCommand(@"  DBCC CHECKIDENT ('BookStoreDB.dbo.Books', RESEED, 0)");
                        context.Database.ExecuteSqlCommand(@"  DBCC CHECKIDENT ('BookStoreDB.dbo.Authors', RESEED, 0)");
                        context.Database.ExecuteSqlCommand(@"  DBCC CHECKIDENT ('BookStoreDB.dbo.Press', RESEED, 0)");
                        context.Database.ExecuteSqlCommand(@"  DBCC CHECKIDENT ('BookStoreDB.dbo.BookDetails', RESEED, 0)");
                        context.Database.ExecuteSqlCommand(@"  DBCC CHECKIDENT ('BookStoreDB.dbo.Cashregisters', RESEED, 0)");

                        context.SaveChanges();
                    }

                }
                catch (Exception)
                {


                }
            }
        }

        public App()
        {
            DB = new EF_UnitofWork();

            using (var context = new BookStoreModel())
            {
                context.Database.CreateIfNotExists();


                if (DB.CustomerRepository.GetAllData().Count == 0)
                {

                    var customer = new Customer()
                    {
                        Name_of_Customers = "Customers_1",
                        Passwords_of_Customers = "Customers_1p"
                    };

                    DB.CustomerRepository.AddData(customer);

                    var admin = new Admin()
                    {
                        Name_of_Admins = "Admins_1",
                        Passwords_of_Admins = "Admins_1p"
                    };

                    DB.AdminRepository.AddData(admin);
                }

                reseed();
            }
        }
    }
}

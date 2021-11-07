using BookStore.DataAccess;
using BookStore.DataAccess.Entity_Framework;
using BookStore.DataAccess.Entity_Framework.Contexts;
using BookStore.Domain.Abstractions;
using BookStore.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.DataAccess.Entity_Framework
{
    public class EF_UnitofWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository =>  new EF_CustomerRepository();

        public IAdminRepository AdminRepository =>  new EF_AdminRepository();

        public IAuthorRepository AuthorRepository =>  new EF_AuthorRepositor();

        public IBookRepository BookRepository =>  new EF_BookRepository();

        public IBookDetailRepository BookDetailRepository => new EF_BookDetailRepository();

        public ICashRegisterRepository CashRegisterRepository =>  new EF_CashregisterRepository();

        public IPressRepository PressRepository =>  new EF_PressRepository();
    }
}

using BookStore.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IAdminRepository AdminRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBookDetailRepository BookDetailRepository  { get; }
        ICashRegisterRepository CashRegisterRepository { get; }
        IPressRepository PressRepository { get; }

    }
}

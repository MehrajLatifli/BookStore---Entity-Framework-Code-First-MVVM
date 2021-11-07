using BookStore.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Domain.Abstractions
{
    public interface IBookDetailRepository: IRepository<BookDetail>
    {
    }
}

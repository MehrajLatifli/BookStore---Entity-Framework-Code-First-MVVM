using BookStore.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Entity_Framework
{
    public class EF_BookRepository : IBookRepository
    {
        public void AddData(Book data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeletaData(Book data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ObservableCollection<Book> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Book GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Book data)
        {
            using (var context = new BookStoreModel())
            {
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

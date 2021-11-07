using BookStore.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.DataAccess.Entity_Framework
{
    class EF_BookDetailRepository : IBookDetailRepository
    {
        public void AddData(BookDetail data)
        {

            using (var context = new BookStoreModel())
            {
           
                context.Entry(data).State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void DeletaData(BookDetail data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Deleted;
                context.BookDetails.Remove(data);

                var a = context.Authors.Where(f => f.IdAuthor == data.AuthorId_forBookDetail);


                foreach (var item in a)
                {
                    context.Entry(item).State = EntityState.Deleted;
                    context.Authors.Remove(item);
                }

                var b = context.Books.Where(f => f.IdBook == data.BookId_forBookDetail);


                foreach (var item in b)
                {
                    context.Entry(item).State = EntityState.Deleted;
                    context.Books.Remove(item);
                }

                var p = context.Presses.Where(f => f.IdPress == data.PressId_forBookDetail);
       

                foreach (var item in p)
                {
                    context.Entry(item).State = EntityState.Deleted;
                    context.Presses.Remove(item);
                }


                context.SaveChanges();
            }

        }

        public ObservableCollection<BookDetail> GetAllData()
        {
            var bookdetails = new ObservableCollection<BookDetail>();

            using (var context = new BookStoreModel())
            {
                bookdetails = new ObservableCollection<BookDetail>(context.BookDetails.Include("Book").Include("Author").Include("Press"));
            }

            return bookdetails;
        }

        public BookDetail GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(BookDetail data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Modified;

                var a = context.Authors.Where(f => f.IdAuthor == data.AuthorId_forBookDetail);


                foreach (var item in a)
                {
                    context.Entry(item).State = EntityState.Modified;

                }

                var b = context.Books.Where(f => f.IdBook == data.BookId_forBookDetail);


                foreach (var item in b)
                {
                    context.Entry(item).State = EntityState.Modified;

                }

                var p = context.Presses.Where(f => f.IdPress == data.PressId_forBookDetail);


                foreach (var item in p)
                {
                    context.Entry(item).State = EntityState.Modified;

                }

                context.SaveChanges();
            }
        }
    }
}

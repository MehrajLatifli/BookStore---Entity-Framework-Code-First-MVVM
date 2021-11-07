using BookStore.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess
{
    public class EF_AuthorRepositor : IAuthorRepository
    {
        public void AddData(Author data)
        {
            throw new NotImplementedException();
        }

        public void DeletaData(Author data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ObservableCollection<Author> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Author GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Author data)
        {
            throw new NotImplementedException();
        }
    }
}

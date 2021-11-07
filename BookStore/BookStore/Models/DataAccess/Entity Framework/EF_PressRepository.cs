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
    public class EF_PressRepository : IPressRepository
    {
        public void AddData(Press data)
        {
            throw new NotImplementedException();
        }

        public void DeletaData(Press data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ObservableCollection<Press> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Press GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Press data)
        {
            throw new NotImplementedException();
        }
    }
}

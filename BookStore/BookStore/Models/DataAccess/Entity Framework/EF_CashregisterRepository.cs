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
    public class EF_CashregisterRepository : ICashRegisterRepository
    {
        public void AddData(Cashregister data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeletaData(Cashregister data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Cashregister> GetAllData()
        {
            var cashregistera = new ObservableCollection<Cashregister>();

            using (var context = new BookStoreModel())
            {
                cashregistera = new ObservableCollection<Cashregister>(context.Cashregisters.Include("Book").Include("Customer"));
            }

            return cashregistera;
        }

        public Cashregister GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Cashregister data)
        {
            throw new NotImplementedException();
        }
    }
}

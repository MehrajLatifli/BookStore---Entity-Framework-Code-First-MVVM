using BookStore.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Entity_Framework.Contexts
{
    public class EF_CustomerRepository : ICustomerRepository
    {
        public void AddData(Customer data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeletaData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = new ObservableCollection<Customer>();

            using (var context = new BookStoreModel())
            {
                customers = new ObservableCollection<Customer>(context.Customers);
            }

            return customers;
        }

        public Customer GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}

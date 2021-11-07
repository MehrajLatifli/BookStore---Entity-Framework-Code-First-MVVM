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
    public class EF_AdminRepository : IAdminRepository
    {
        public void AddData(Admin data)
        {
            using (var context = new BookStoreModel())
            {

                context.Entry(data).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeletaData(Admin data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Admin> GetAllData()
        {
            var admins = new ObservableCollection<Admin>();

            using (var context = new BookStoreModel())
            {
                admins = new ObservableCollection<Admin>(context.Admins);
            }

            return admins;
        }

        public Admin GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}

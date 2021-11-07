using BookStore.Commands;
using BookStore.Domain.Views.User_control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.ViewModels
{
    public class CustomerViewModel_UC : BaseViewModel
    {
        public CustomerView_UC CustomerView_UCs { get; set; }

        public MainViewModel MainViewModel { get; set; }

        public BookStoreModel DataContext { get; set; }

        public RelayCommand BuyCommand { get; set; }

        private ObservableCollection<Admin> alladmin;

        public ObservableCollection<Admin> AllAdmins
        {
            get { return alladmin; }
            set { alladmin = value; OnPropertyChanged(); }
        }

        private Admin currentAdmin;

        public Admin CurrentAdmin
        {
            get { return currentAdmin; }
            set { currentAdmin = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Customer> allCustomer;

        public ObservableCollection<Customer> AllCustomers
        {
            get { return allCustomer; }
            set { allCustomer = value; OnPropertyChanged(); }
        }

        private Customer currentCustomer;

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; OnPropertyChanged(); }

        }

        private ObservableCollection<BookDetail> allBookDetail;

        public ObservableCollection<BookDetail> AllBookDetail
        {
            get { return allBookDetail; }
            set { allBookDetail = value; OnPropertyChanged(); }
        }

        private BookDetail currentBookDetail;

        public BookDetail CurrentBookDetail
        {
            get { return currentBookDetail; }
            set { currentBookDetail = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Book> allBook;

        public ObservableCollection<Book> AllBook
        {
            get { return allBook; }
            set { allBook = value; OnPropertyChanged(); }
        }

        private Book currentBook;

        public Book CurrentBook
        {
            get { return currentBook; }
            set { currentBook = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Author> allAuthor;

        public ObservableCollection<Author> AllAuthor
        {
            get { return allAuthor; }
            set { allAuthor = value; OnPropertyChanged(); }
        }

        private Author currentAuthor;

        public Author CurrentAuthor
        {
            get { return currentAuthor; }
            set { currentAuthor = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Press> allPress;

        public ObservableCollection<Press> AllPress
        {
            get { return allPress; }
            set { allPress = value; OnPropertyChanged(); }
        }

        private Press currentPress;

        public Press CurrentPress
        {
            get { return currentPress; }
            set { currentPress = value; OnPropertyChanged(); }
        }



        private ObservableCollection<Cashregister> allCashregister;

        public ObservableCollection<Cashregister> AllCashregister
        {
            get { return allCashregister; }
            set { allCashregister = value; OnPropertyChanged(); }
        }

        private Cashregister currentCashregister;

        public Cashregister CurrentCashregister
        {
            get { return currentCashregister; }
            set { currentCashregister = value; OnPropertyChanged(); }
        }

        public CustomerViewModel_UC()
        {

            AllBookDetail = App.DB.BookDetailRepository.GetAllData();
            AllCashregister = App.DB.CashRegisterRepository.GetAllData();


            BuyCommand = new RelayCommand((sender) =>
            {
                CurrentBookDetail = new BookDetail();
                CurrentBookDetail.Book = new Book();
                CurrentBookDetail.Author = new Author();
                CurrentBookDetail.Press = new Press();

                CurrentPress = new Press();
                CurrentAuthor = new Author();


                using (var context = new BookStoreModel())
                {

                    var selected = CustomerView_UCs.fulldatalistview.SelectedItem as BookDetail;

                    if (selected != null)
                    {

                        try
                        {


                            SqlParameter sqlParameter1 = new SqlParameter();
                            sqlParameter1.SqlDbType = SqlDbType.Int;
                            sqlParameter1.ParameterName = "@CustomerId";
                            sqlParameter1.Value = 1;

                            SqlParameter sqlParameter2 = new SqlParameter();
                            sqlParameter2.SqlDbType = SqlDbType.Int;
                            sqlParameter2.ParameterName = "@IdBook";
                            sqlParameter2.Value = selected.Book.IdBook;

                            SqlParameter sqlParameter3 = new SqlParameter();
                            sqlParameter3.SqlDbType = SqlDbType.Int;
                            sqlParameter3.ParameterName = "@SellBookQuantity";
                            sqlParameter3.Value = 1;

                            context.Database.ExecuteSqlCommand("sp_SellBooks @CustomerId,@IdBook,@SellBookQuantity", sqlParameter1, sqlParameter2, sqlParameter3);

                            context.SaveChanges();


                            AllBookDetail = App.DB.BookDetailRepository.GetAllData();

                            AllCashregister = App.DB.CashRegisterRepository.GetAllData();

                        }
                        catch (Exception)
                        {

                            MessageBox.Show($"A stored procedure named sp_SellBooks could not be found. Please create or alter this stored sp_SellBooks.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }

                    else
                    {
                        MessageBox.Show($"Please select any item in listview.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }

                }           

            });

        }

        }
}

using BookStore.Commands;
using BookStore.Views.User_control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.ViewModels
{
    public class AdminViewModel_UC : BaseViewModel
    {
        public AdminView_UC AdminView_UCs { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public BookStoreModel DataContext { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public RelayCommand OnlyNumberCommand1 { get; set; }
        public RelayCommand OnlyNumberCommand2 { get; set; }
        public RelayCommand OnlyNumberCommand3 { get; set; }



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



        public AdminViewModel_UC()
        {
            CurrentBookDetail = new BookDetail();
            CurrentBookDetail.Book = new Book();
            CurrentBookDetail.Author = new Author();
            CurrentBookDetail.Press = new Press();

            CurrentPress = new Press();
            CurrentAuthor = new Author();

            App.reseed();

            AllBookDetail = App.DB.BookDetailRepository.GetAllData();

            AllCashregister = App.DB.CashRegisterRepository.GetAllData();

            OnlyNumberCommand1 = new RelayCommand((sender) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(AdminView_UCs.BookPriceTxt.Text, @"[^0-9.]"))
                {
                    MessageBox.Show("Please enter only price.");
                    AdminView_UCs.BookPriceTxt.Text = AdminView_UCs.BookPriceTxt.Text.Remove(AdminView_UCs.BookPriceTxt.Text.Length - 1);
                }

            });

            OnlyNumberCommand2 = new RelayCommand((sender) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(AdminView_UCs.BookQuantityTxt.Text, @"[^0-9]"))
                {
                    MessageBox.Show("Please enter only quantity.");
                    AdminView_UCs.BookQuantityTxt.Text = AdminView_UCs.BookQuantityTxt.Text.Remove(AdminView_UCs.BookQuantityTxt.Text.Length - 1);
                }

            });

            OnlyNumberCommand3 = new RelayCommand((sender) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(AdminView_UCs.PressYearTxt.Text, @"[^0-9]"))
                {
                    MessageBox.Show("Please enter only year.");
                    AdminView_UCs.PressYearTxt.Text = AdminView_UCs.PressYearTxt.Text.Remove(AdminView_UCs.PressYearTxt.Text.Length - 1);
                }

            });

            AddCommand = new RelayCommand((sender) =>
             {

                 CurrentBookDetail = new BookDetail();
                 CurrentBookDetail.Book = new Book();
                 CurrentBookDetail.Author = new Author();
                 CurrentBookDetail.Press = new Press();

                 CurrentPress = new Press();
                 CurrentAuthor = new Author();

                 App.reseed();

                 if (!string.IsNullOrEmpty(AdminView_UCs.BooksNameTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.BookPriceTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.BookQuantityTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.Author1FNTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.PressNameTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.PressYearTxt.Text))
                 {


                     if (string.IsNullOrEmpty(AdminView_UCs.Author2FNTxt.Text))
                     {
                         CurrentBookDetail.Book.BookName = AdminView_UCs.BooksNameTxt.Text;
                         CurrentBookDetail.Book.BookPrice = decimal.Parse(AdminView_UCs.BookPriceTxt.Text);
                         CurrentBookDetail.Book.BookQuantity = long.Parse(AdminView_UCs.BookQuantityTxt.Text);
                         CurrentBookDetail.Author.Author1 = AdminView_UCs.Author1FNTxt.Text;
                         CurrentBookDetail.Author.Author2 = "Null";
                         CurrentBookDetail.Press.PressName = AdminView_UCs.PressNameTxt.Text;
                         CurrentBookDetail.Press.PressYear = AdminView_UCs.PressYearTxt.Text;

                         App.DB.BookDetailRepository.AddData(CurrentBookDetail);
                         AllBookDetail = App.DB.BookDetailRepository.GetAllData();



                         CurrentBookDetail = new BookDetail();
                         CurrentBookDetail.Book = new Book();
                         CurrentBookDetail.Author = new Author();
                         CurrentBookDetail.Press = new Press();

                         CurrentPress = new Press();
                         CurrentAuthor = new Author();
                     }

                     if (!string.IsNullOrEmpty(AdminView_UCs.Author2FNTxt.Text))
                     {

                         CurrentBookDetail.Book.BookName = AdminView_UCs.BooksNameTxt.Text;
                         CurrentBookDetail.Book.BookPrice = decimal.Parse(AdminView_UCs.BookPriceTxt.Text);
                         CurrentBookDetail.Book.BookQuantity = long.Parse(AdminView_UCs.BookQuantityTxt.Text);
                         CurrentBookDetail.Author.Author1 = AdminView_UCs.Author1FNTxt.Text;
                         CurrentBookDetail.Author.Author2 = AdminView_UCs.Author2FNTxt.Text;
                         CurrentBookDetail.Press.PressName = AdminView_UCs.PressNameTxt.Text;
                         CurrentBookDetail.Press.PressYear = AdminView_UCs.PressYearTxt.Text;


                         App.DB.BookDetailRepository.AddData(CurrentBookDetail);
                         AllBookDetail = App.DB.BookDetailRepository.GetAllData();


                         CurrentBookDetail = new BookDetail();
                         CurrentBookDetail.Book = new Book();
                         CurrentBookDetail.Author = new Author();
                         CurrentBookDetail.Press = new Press();

                         CurrentPress = new Press();
                         CurrentAuthor = new Author();
                     }

                 }
                     else
                     {
                         MessageBox.Show($"Incomplete information ","Error",MessageBoxButton.OK, MessageBoxImage.Error) ;
                     }
             });


            DeleteCommand = new RelayCommand((sender) =>
            {

                using (var context = new BookStoreModel())
                {
                    var selected = AdminView_UCs.fulldatalistview.SelectedItem as BookDetail;


                    if (selected != null)
                    {



                        App.DB.BookDetailRepository.DeletaData(CurrentBookDetail);



                        CurrentBookDetail = new BookDetail();
                        CurrentBookDetail.Book = new Book();
                        CurrentBookDetail.Author = new Author();
                        CurrentBookDetail.Press = new Press();

                        CurrentPress = new Press();
                        CurrentAuthor = new Author();

                        AllBookDetail = App.DB.BookDetailRepository.GetAllData();
                    }

                    else
                    {
                        MessageBox.Show($"Please select any item in listview.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }

                }


                CurrentBookDetail = new BookDetail();
                CurrentBookDetail.Book = new Book();
                CurrentBookDetail.Author = new Author();
                CurrentBookDetail.Press = new Press();

                CurrentPress = new Press();
                CurrentAuthor = new Author();
            });


            UpdateCommand = new RelayCommand((sender) =>
            {
                using (var context = new BookStoreModel())
                {
                    if (AdminView_UCs.fulldatalistview.SelectedIndex != -1)
                    {
                        if (!string.IsNullOrEmpty(AdminView_UCs.BooksNameTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.BookPriceTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.BookQuantityTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.Author1FNTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.PressNameTxt.Text) && !string.IsNullOrEmpty(AdminView_UCs.PressYearTxt.Text))
                        {

                            if (string.IsNullOrEmpty(AdminView_UCs.Author2FNTxt.Text))
                            {
                                CurrentBookDetail.Book.BookName = AdminView_UCs.BooksNameTxt.Text;
                                CurrentBookDetail.Book.BookPrice = decimal.Parse(AdminView_UCs.BookPriceTxt.Text);
                                CurrentBookDetail.Book.BookQuantity = long.Parse(AdminView_UCs.BookQuantityTxt.Text);
                                CurrentBookDetail.Author.Author1 = AdminView_UCs.Author1FNTxt.Text;
                                CurrentBookDetail.Author.Author2 = "Null";
                                CurrentBookDetail.Press.PressName = AdminView_UCs.PressNameTxt.Text;
                                CurrentBookDetail.Press.PressYear = AdminView_UCs.PressYearTxt.Text;

                                App.DB.BookDetailRepository.UpdateData(CurrentBookDetail);
                                AllBookDetail = App.DB.BookDetailRepository.GetAllData();


                                CurrentBookDetail = new BookDetail();
                                CurrentBookDetail.Book = new Book();
                                CurrentBookDetail.Author = new Author();
                                CurrentBookDetail.Press = new Press();

                                CurrentPress = new Press();
                                CurrentAuthor = new Author();
                            }

                            if (!string.IsNullOrEmpty(AdminView_UCs.Author2FNTxt.Text))
                            {

                                CurrentBookDetail.Book.BookName = AdminView_UCs.BooksNameTxt.Text;
                                CurrentBookDetail.Book.BookPrice = decimal.Parse(AdminView_UCs.BookPriceTxt.Text);
                                CurrentBookDetail.Book.BookQuantity = long.Parse(AdminView_UCs.BookQuantityTxt.Text);
                                CurrentBookDetail.Author.Author1 = AdminView_UCs.Author1FNTxt.Text;
                                CurrentBookDetail.Author.Author2 = AdminView_UCs.Author2FNTxt.Text;
                                CurrentBookDetail.Press.PressName = AdminView_UCs.PressNameTxt.Text;
                                CurrentBookDetail.Press.PressYear = AdminView_UCs.PressYearTxt.Text;


                                App.DB.BookDetailRepository.UpdateData(CurrentBookDetail);
                                AllBookDetail = App.DB.BookDetailRepository.GetAllData();


                                CurrentBookDetail = new BookDetail();
                                CurrentBookDetail.Book = new Book();
                                CurrentBookDetail.Author = new Author();
                                CurrentBookDetail.Press = new Press();

                                CurrentPress = new Press();
                                CurrentAuthor = new Author();


                            }

                        }
                        else
                        {
                            MessageBox.Show($"Incomplete information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

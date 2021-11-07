using BookStore.Additional_Classes;
using BookStore.Commands;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookStore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BookStoreModel DataContext { get; set; }
        public MainWindow MainWindows { get; set; }

        public ComboBoxSelect ComboBoxSelect { get; set; }


        public ObservableCollection<Position> Positions { get; set; }

        private Position _Position;
        public Position Position { get { return _Position; } set { _Position = value; OnPropertyChanged(); } }

        AdminViewModel_UC AdminViewModel_UC { get; set; }

        CustomerViewModel_UC CustomerViewModel_UC { get; set; }

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

        public RelayCommand SelectPositonCommand { get; set; }




        public ICommand GotoAdmin_Command { get; set; }

        private object selectedPositionViewModel_UC;

        public object SelectedPositionViewModel_UC
        {
            get { return selectedPositionViewModel_UC; }
            set
            {
                selectedPositionViewModel_UC = value;
                OnPropertyChanged(nameof(SelectedPositionViewModel_UC));
            }
        }
        public ICommand GotoCustomer_Command { get; set; }





        private void NavigateToCustomer(object obj)
        {
            DataContext = new BookStoreModel();

            var customer = new Customer();
            customer = DataContext.Customers.FirstOrDefault(c => c.Name_of_Customers == MainWindows.NameTxtBox.Text && c.Passwords_of_Customers == MainWindows.PasswordTxtBox.Password);

            try
            {
                if (MainWindows.PositionCombobox.SelectedIndex == 1)
                {
                    if (!string.IsNullOrEmpty(MainWindows.NameTxtBox.Text) || !string.IsNullOrEmpty(MainWindows.PasswordTxtBox.Password))
                    {
                        if (DataContext.Customers.Any(x => x.Name_of_Customers == MainWindows.NameTxtBox.Text) && DataContext.Customers.Any(x => x.Passwords_of_Customers == MainWindows.PasswordTxtBox.Password))
                        {
                            MessageBox.Show($"{customer.Name_of_Customers} {customer.Passwords_of_Customers}");

                            SelectedPositionViewModel_UC = new CustomerViewModel_UC();

                            MainWindows.fulldatalistview.Visibility = Visibility.Hidden;
                            MainWindows.PositionContentControl.Visibility = Visibility.Visible;

                        }


                        if (customer == null)
                        {
                            MessageBox.Show($"SingIn Error");
                        }

                    }

                    else
                    {
                        MessageBox.Show($"Empty Field");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");

            }

        }

        private void NavigateToAdmin(object obj)
        {
            DataContext = new BookStoreModel();

            var admin = new Admin();
            admin = DataContext.Admins.FirstOrDefault(c => c.Name_of_Admins == MainWindows.NameTxtBox.Text && c.Passwords_of_Admins == MainWindows.PasswordTxtBox.Password);



            try
            {

                if (MainWindows.PositionCombobox.SelectedIndex == 0)
                {
                    if (!string.IsNullOrEmpty(MainWindows.NameTxtBox.Text) || !string.IsNullOrEmpty(MainWindows.PasswordTxtBox.Password))
                    {
                        if (DataContext.Admins.Any(x => x.Name_of_Admins == MainWindows.NameTxtBox.Text) && DataContext.Admins.Any(x => x.Passwords_of_Admins == MainWindows.PasswordTxtBox.Password))
                        {
                            MessageBox.Show($"{admin.Name_of_Admins} {admin.Passwords_of_Admins}");


                            SelectedPositionViewModel_UC = new AdminViewModel_UC();


                            MainWindows.fulldatalistview.Visibility = Visibility.Hidden;
                            MainWindows.PositionContentControl.Visibility = Visibility.Visible;

                        }


                        if (admin == null)
                        {
                            MessageBox.Show($"SingIn Error");
                        }

                    }

                    else
                    {
                        MessageBox.Show($"Empty Field");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        public MainViewModel()
        {
            ComboBoxSelect = new ComboBoxSelect();
            Positions = new ObservableCollection<Position>(ComboBoxSelect.ComboBoxGetAll());

            GotoAdmin_Command = new RelayCommand(NavigateToAdmin);
            GotoCustomer_Command = new RelayCommand(NavigateToCustomer);

            AllBookDetail = App.DB.BookDetailRepository.GetAllData();

            SelectPositonCommand = new RelayCommand((sender) =>
            {
                if (MainWindows.PositionCombobox.SelectedIndex == 0)
                {
                    MainWindows.SingInButtonasAdmin.Visibility = Visibility.Visible;
                    MainWindows.SingInButtonasCustomer.Visibility = Visibility.Hidden;


                }

                if (MainWindows.PositionCombobox.SelectedIndex == 1)
                {
                    MainWindows.SingInButtonasCustomer.Visibility = Visibility.Visible;
                    MainWindows.SingInButtonasAdmin.Visibility = Visibility.Hidden;

                }


            });
        }
    }
}

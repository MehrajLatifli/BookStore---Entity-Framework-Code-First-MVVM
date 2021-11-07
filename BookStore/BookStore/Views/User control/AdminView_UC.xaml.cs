using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore.Views.User_control
{
    /// <summary>
    /// Interaction logic for AdminView_UC.xaml
    /// </summary>
    public partial class AdminView_UC : UserControl
    {
        public AdminView_UC()
        {
            InitializeComponent();


            var vm = new AdminViewModel_UC() { AdminView_UCs = this };
            this.DataContext = vm;
        }
    }
}

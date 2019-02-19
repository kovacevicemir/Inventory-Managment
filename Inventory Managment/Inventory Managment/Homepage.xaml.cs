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
using System.Windows.Shapes;

namespace Inventory_Managment
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        public Homepage()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void menu_add_user_Click(object sender, RoutedEventArgs e)
        {
            var add_user = new Add_new_user();
            add_user.Show();
            //this.Close();
        }

        private void menu_add_units_Click(object sender, RoutedEventArgs e)
        {
            var add_units = new Units();
            add_units.Show();
        }
    }
}

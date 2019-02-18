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
using System.Data.SqlClient;
using System.Data;

namespace Inventory_Managment
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");
    
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //check for connection state
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Create Query command that select user_login_inputs from database 'cmd'
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from registration where username='" + username_input.Text + "' and password= '" + password_input.Password.ToString() + "'";
            cmd.ExecuteNonQuery();

            //Create data table and insert cmd to it
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //check how many rows in dt
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if(i == 0)
            {
                MessageBox.Show("Incorrect password");
            }
            else
            {
                //if login is correct navigate to homepage
                var homepage = new Homepage();
                homepage.Show();
                this.Close();
            }
        }
    }
}

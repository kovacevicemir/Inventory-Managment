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
    /// Interaction logic for Add_new_user.xaml
    /// </summary>
    public partial class Add_new_user : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");

        public Add_new_user()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


            //Display Data from db table (all users)
            Display();

        }

        private void btn_add_user_Click(object sender, RoutedEventArgs e)
        {
            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Create Query command that select username where username = add_user_username text box
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from registration where username='" + add_user_username.Text + "'";
            cmd.ExecuteNonQuery();

            //Create data table and insert cmd to it
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //check how many rows in dt
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0) //If non-existing username
            {
                //Insert Query , Insert data from text boxes to table
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "insert into registration values('"+ add_user_first_name.Text +"','"+ add_user_last_name.Text +
                    "','"+ add_user_username.Text +"','"+ add_user_password.Text +"','"+ add_user_email.Text +"','"+ add_user_contact.Text +"')";
                cmd1.ExecuteNonQuery();

                //Clear data from textboxes
                add_user_first_name.Text = ""; add_user_last_name.Text = ""; add_user_password.Text = "";
                add_user_username.Text = ""; add_user_email.Text = ""; add_user_contact.Text = "";
                MessageBox.Show("User record inserted successfully");
                Display();
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        public void Display()
        {
            //Create Query command that select ALL data from db
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from registration";
            cmd.ExecuteNonQuery();

            //Create data table and insert cmd to it
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //Insert data into DataGrid
            dataGrid_users.ItemsSource = dt.DefaultView;
            dataGrid_users.CanUserAddRows = false;

        }

        private void btn_delete_user_Click(object sender, RoutedEventArgs e)
        {
            //Check if user is selected
            if(dataGrid_users.SelectedItem == null)
            {
                MessageBox.Show("Select user first");
                return;
            }
            else
            {
                //Get selected row data, as dataRowView type
                DataRowView id = dataGrid_users.SelectedItem as DataRowView;

                //Convert row data array item to int 32
                int id1 = Convert.ToInt32(id.Row.ItemArray[0]);

                //Create SQL query command to delete user
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from registration where id=" + id1 + "";
                cmd.ExecuteNonQuery();
                Display();
            }
        }
    }
}

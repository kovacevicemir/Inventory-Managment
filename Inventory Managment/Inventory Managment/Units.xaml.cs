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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Inventory_Managment
{
    /// <summary>
    /// Interaction logic for Units.xaml
    /// </summary>
    public partial class Units : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");

        public Units()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Display();
        }

        public void Display()
        {
            //Create query that selects all from units table
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();

            //Create new table and / add cmd query
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //Insert data into datagird
            dataGrid_units.ItemsSource = dt.DefaultView;
            dataGrid_units.CanUserAddRows = false;
            dataGrid_units.MinColumnWidth = 100;
        }

        private void btn_add_unit_Click(object sender, RoutedEventArgs e)
        {
            //Create query that insert into Units table from unit texbox input
            string unit = add_unit_input.Text;

            //Check if unit already exists
            int count;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from units where unit='"+ unit +"'";
            cmd.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            count = Convert.ToInt32(dt1.Rows.Count);

            if(count == 1)
            {
                MessageBox.Show("Unit already exists");
                return;
            }
            else
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "insert into units values('" + unit + "')";
                cmd1.ExecuteNonQuery();

                //Clear txt-box input and re-display
                add_unit_input.Text = "";
                Display();
            }
        }

        private void btn_delete_unit_Click(object sender, RoutedEventArgs e)
        {
            //Check if unit is selected
            if (dataGrid_units.SelectedItem == null)
            {
                MessageBox.Show("Select unit first");
                return;
            }
            else
            {
                //Get selected row data, as dataRowView type
                DataRowView id = dataGrid_units.SelectedItem as DataRowView;

                //Convert row data array item to int 32
                int id1 = Convert.ToInt32(id.Row.ItemArray[0]);

                //Create SQL query command to delete user
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from units where id=" + id1 + "";
                cmd.ExecuteNonQuery();
                Display();
            }
        }
    }
}

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
using System.Data;
using System.Data.SqlClient;

namespace Inventory_Managment
{
    /// <summary>
    /// Interaction logic for Dealer_info.xaml
    /// </summary>
    public partial class Dealer_info : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");
        DataRowView id = null;
        public Dealer_info()
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

        //DATAGRID DISPLAY METHOD
        public void Display()
        {
            //Select all from dealers table
            //Create new datatable and flll it with cmd2
            string q = "select * from dealer_info";
            DataTable dt1 = FetchProducts(q);

            //Insert data into datagrid_products
            dataGrid_dealers.ItemsSource = dt1.DefaultView;
            dataGrid_dealers.CanUserAddRows = false;
        }

        //FETCH PRODUCTS FROM DB / PUT IT IN DataTable x METHOD
        public DataTable FetchProducts(string query)
        {
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = query;
            cmd2.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);
            return dt1;
        }

        //ADD DEALER HANDLER
        private void btn_add_dealer_Click(object sender, RoutedEventArgs e)
        {
            //verification - check if any field is empty
            if (input_add_dealer_name.Text == "" || input_add_dealer_company.Text == "" || input_add_dealer_contact.Text == "" || input_add_dealer_city.Text == "" || input_add_dealer_address.Text == "")
            {
                MessageBox.Show("One or more fields are empty: \n Name, Company, Contact, Address or City ! \n Add dealer failed");
                return;
            }

            //verification - check if dealer already exists
            int counts;
            string q1 = "select * from dealer_info where dealer_name='" + input_add_dealer_name.Text + "' and dealer_company_name='"+
                input_add_dealer_company.Text +"'";

            DataTable dt3 = FetchProducts(q1);
            counts = dt3.Rows.Count;

            if (counts == 1)
            {
                MessageBox.Show("Dealer that you are trying to add already exists !");
                return;
            }
            else
            {
                //add dealer query
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dealer_info values('" + input_add_dealer_name.Text + "','" + input_add_dealer_company.Text + "','"
                    + input_add_dealer_contact.Text + "','" + input_add_dealer_address.Text + "','" + input_add_dealer_city.Text + "')";

                cmd.ExecuteNonQuery();

                //Clear fields and display
                MessageBox.Show(input_add_dealer_name.Text.ToString() + " from " + input_add_dealer_company.Text.ToString() + "\n successfully added!");

                input_add_dealer_company.Text = "";
                input_add_dealer_city.Text = "";
                input_add_dealer_address.Text = "";
                input_add_dealer_contact.Text = "";
                input_add_dealer_name.Text = "";

                Display();
            }
        }

        private void btn_dealer_delete_Click(object sender, RoutedEventArgs e)
        {
            //Check if dealer is selected
            if (id == null)
            {
                MessageBox.Show("Dealer is not selected");
                return;
            }
            else
            {
                //Convert row data array item to int 32
                int id2 = Convert.ToInt32(id.Row.ItemArray[0]);

                //Create SQL query command to delete user
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dealer_info where id=" + id2 + "";
                cmd.ExecuteNonQuery();

                MessageBox.Show(id.Row.ItemArray[1].ToString() + " \n from " + id.Row.ItemArray[1].ToString() + " company is removed !");
                Display();
                id = null;
            }
        }

        //ROW CLICK
        private void dataGrid_dealers_row_Click(object sender, MouseButtonEventArgs e)
        {
            //Get selected row data, as dataRowView type
            id = dataGrid_dealers.SelectedItem as DataRowView;
        }

        //UPDATE SELECTED BUTTON
        private void btn_dealer_update_Click(object sender, RoutedEventArgs e)
        {
            if (id == null)
            {
                MessageBox.Show("Dealer is not selected");
                return;
            }
            else
            {
                //make update panel panel
                grid_update_dealer.Visibility = Visibility.Visible;

                //Fetch data from selected and input in text boxes
                input_add_dealer_name_upd.Text = id.Row.ItemArray[1].ToString();
                input_add_dealer_company_upd.Text = id.Row.ItemArray[2].ToString();
                input_add_dealer_contact_upd.Text = id.Row.ItemArray[3].ToString();
                input_add_dealer_address_upd.Text = id.Row.ItemArray[4].ToString();
                input_add_dealer_city_upd.Text = id.Row.ItemArray[5].ToString();

            }
        }

        //UPDATE BUTTON
        private void btn_upd_dealer_final_Click(object sender, RoutedEventArgs e)
        {
            //VERIFICATION
            if (input_add_dealer_name_upd.Text == "" || input_add_dealer_address_upd.Text == "" || input_add_dealer_city_upd.Text == "" || input_add_dealer_contact_upd.Text == "" || input_add_dealer_company_upd.Text == "")
            {
                MessageBox.Show("Dealers: name,company,address,city and contact \n fields cannot be empty!");
                return;
            }
            else
            {
                //fetch from db where dealer name and company and put into dt3
                //int counts;
                string q1 = "select * from dealer_info where dealer_name='" + input_add_dealer_name_upd.Text + "' and dealer_company_name='" + input_add_dealer_company_upd.Text + "'";
                DataTable dt3 = FetchProducts(q1);
                //counts = dt3.Rows.Count;


                //check if dealer exists
                //if (counts == 0)
                //{
                //    MessageBox.Show("Cant update non-existing dealer");
                //    return;
                //}

                //Convert row data array item to int 32
                int id1 = Convert.ToInt32(id.Row.ItemArray[0]);

                //else update
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dealer_info set dealer_name='" + input_add_dealer_name_upd.Text + "',dealer_company_name='" + input_add_dealer_company_upd.Text +
                    "',contact='" + input_add_dealer_contact_upd.Text + "',address='" + input_add_dealer_address_upd.Text + "',city='" + input_add_dealer_city_upd.Text +
                    "' where id=" + id1 + "";

                cmd1.ExecuteNonQuery();

                //Clear ID
                id = null;

                //Clear input box and message
                MessageBox.Show(input_add_dealer_name_upd.Text + " has been updated successfully!");
                input_add_dealer_name_upd.Text = "";
                input_add_dealer_city_upd.Text = "";
                input_add_dealer_address_upd.Text = "";
                input_add_dealer_contact_upd.Text = "";
                input_add_dealer_company_upd.Text = "";

                grid_update_dealer.Visibility = Visibility.Collapsed;

                Display();
            }
        }
    }
}

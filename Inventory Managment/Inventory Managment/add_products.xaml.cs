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
    /// Interaction logic for add_products.xaml
    /// </summary>
    public partial class add_products : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");
        //DECLARE ID HERE because both: add product and click row events have display(), display destroyes selected...
        DataRowView id = null;
        public add_products()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //Generate combobox
            fill_combo_box();

            //Display products in datagrid
            Display();
        }

        //COMBOBOX
        public void fill_combo_box()
        {
            comboBox_units.Items.Clear();

            //Select all from units table
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();

            //create new datatable and fill with cmd
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //iterate dt and add each row ["unit"] to combo box item
            foreach(DataRow row in dt.Rows)
            {
                comboBox_units.Items.Add(row["unit"].ToString());
                comboBox_units_2.Items.Add(row["unit"].ToString());
            }

        }

        //DATAGRID
        public void Display()
        {
            //Select all from products table
            //Create new datatable and flll it with cmd2
            string q = "select * from products";
            DataTable dt1 = FetchProducts(q);

            //Insert data into datagrid_products
            dataGrid_products.ItemsSource = dt1.DefaultView;
            dataGrid_products.CanUserAddRows = false;
        }

        //FETCH PRODUCTS FROM DB / PUT IT IN DataTable x
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

        //ADD PRODUCT BUTTON HANDLER
        private void btn_add_product_Click(object sender, RoutedEventArgs e)
        {
            //VERIFICATION
            if (input_product_name.Text == "")
            {
                MessageBox.Show("Please enter product name");
                return;
            }
            else if (comboBox_units.SelectedItem == null)
            {
                MessageBox.Show("Please choose product unit");
                return;
            }
            else
            {
                //CHECK IF PRODUCT ALREADY EXISTS
                int counts;
                string q1 = "select * from products where product_name='"+input_product_name.Text+"'";
                DataTable dt3 = FetchProducts(q1);
                counts = dt3.Rows.Count;

                if(counts == 1)
                {
                    MessageBox.Show("Product that you are trying to add already exists !");
                    return;
                }
                else
                {
                    //INSERT INTO PRODUCTS
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into products values('" + input_product_name.Text + "','" + comboBox_units.SelectedItem.ToString() + "')";
                    cmd1.ExecuteNonQuery();

                    //Clear input box and message
                    MessageBox.Show(input_product_name.Text + " has been inserted successfully!");
                    input_product_name.Text = "";
                    comboBox_units.SelectedIndex = -1;
                    Display();
                }
            }
        }

        //UPDATE
        private void btn_update_product_Click(object sender, RoutedEventArgs e)
        {
            //VERIFICATION
            if (input_product_name_upd.Text == "")
            {
                MessageBox.Show("Please enter product name");
                return;
            }
            else if (comboBox_units_2.SelectedItem == null)
            {
                MessageBox.Show("Please choose product unit");
                return;
            }
            else
            {
                //Get selected row data, as dataRowView type
                if (id == null)
                {
                    //Check if product exists
                    int counts;
                    string q1 = "select * from products where product_name='" + input_product_name_upd.Text + "'";
                    DataTable dt3 = FetchProducts(q1);
                    counts = dt3.Rows.Count;

                    if (counts == 0)
                    {
                        MessageBox.Show("Non existing product !");
                        return;
                    }

                    SqlCommand cmd5 = con.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    cmd5.CommandText = "update products set product_name='" + input_product_name_upd.Text + "',product_unit='" + comboBox_units_2.SelectedItem.ToString() + "' where product_name='" + input_product_name_upd.Text + "'";
                    cmd5.ExecuteNonQuery();

                    //Clear ID
                    id = null;

                    //Clear input box and message
                    MessageBox.Show(input_product_name_upd.Text + " has been updated successfully!");
                    input_product_name_upd.Text = "";
                    comboBox_units_2.SelectedIndex = -1;

                    Display();
                }
                else
                {
                    //Check if product exists
                    int counts;
                    string q1 = "select * from products where product_name='" + input_product_name_upd.Text + "'";
                    DataTable dt3 = FetchProducts(q1);
                    counts = dt3.Rows.Count;

                    if (counts == 0)
                    {
                        MessageBox.Show("Non existing product !");
                        return;
                    }

                    //Convert row data array item to int 32
                    int id1 = Convert.ToInt32(id.Row.ItemArray[0]);

                    //else update
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update products set product_name='" + input_product_name_upd.Text + "',product_unit='" + comboBox_units_2.SelectedItem.ToString() + "' where id=" + id1 + "";
                    cmd1.ExecuteNonQuery();

                    //Clear ID
                    id = null;

                    //Clear input box and message
                    MessageBox.Show(input_product_name_upd.Text + " has been updated successfully!");
                    input_product_name_upd.Text = "";
                    comboBox_units_2.SelectedIndex = -1;

                    Display();
                }
            }
        }

        //Generate data to update fields when ROW CLICK
        private void dataGrid_products_row_Click(object sender, MouseButtonEventArgs e)
        {
            //Get selected row data, as dataRowView type
            id = dataGrid_products.SelectedItem as DataRowView;

            //update fields
            input_product_name_upd.Text = id.Row.ItemArray[1].ToString();
            comboBox_units_2.SelectedItem = id.Row.ItemArray[2].ToString();

            Display();
        }

        //DELETE
        private void btn_delete_product_Click(object sender, RoutedEventArgs e)
        {
            //Check if user is selected
            if (id == null)
            {
                MessageBox.Show("Product not selected");
                return;
            }
            else
            {
                //Convert row data array item to int 32
                int id2 = Convert.ToInt32(id.Row.ItemArray[0]);

                //Create SQL query command to delete user
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from products where id=" + id2 + "";
                cmd.ExecuteNonQuery();

                input_product_name_upd.Text = "";
                comboBox_units_2.SelectedIndex = -1;
                MessageBox.Show(id.Row.ItemArray[1].ToString() + "is removed !");
                Display();
            }
        }
    }
}

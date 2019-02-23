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
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");
        DataRowView id = null; //for row click
        //Create Table for datagrid_products (Added products)
        DataTable datatable_products = new DataTable();
        public Sales()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            comboBox_bill_type.Items.Add("CASH");
            comboBox_bill_type.Items.Add("DEBIT");

            //Add fields to datatable_products
            datatable_products.Clear();
            datatable_products.Columns.Add("Product");
            datatable_products.Columns.Add("Price");
            datatable_products.Columns.Add("Quantity");
            datatable_products.Columns.Add("Total");
            dataGrid_products_sell.ColumnWidth = 150;
        }

        
        //PRODUCT NAME KEY DOWN
        private void product_name_key_down(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Down)
            {
                listBox_products.Focus();
                listBox_products.SelectedIndex = 0;
            }
        }

        //LISTBOX KEY DOWN / UP / ENTER
        private void listbox_Key_Down(object sender, KeyEventArgs e)
        {
            try
            {
                //if arrow key up move index +1
                if (e.Key == Key.Down)
                {
                    this.listBox_products.SelectedIndex = this.listBox_products.SelectedIndex + 1;
                }

                //if arrow key up move index -1
                if (e.Key == Key.Up)
                {
                    this.listBox_products.SelectedIndex = this.listBox_products.SelectedIndex - 1;
                }

                //if enter
                if(e.Key == Key.Enter)
                {
                    input_product_name.Text = listBox_products.SelectedItem.ToString();
                    string product = listBox_products.SelectedItem.ToString();
                    listBox_products.Visibility = Visibility.Collapsed;

                    //GeneratePrice (product)
                    GeneratePrice(product);
                    input_total.Focus();
                    
                }
            }
            catch(Exception ex)
            {
                //
            }
        }

        //PRODUCT NAME KEY UP
        private void product_name_key_up(object sender, KeyEventArgs e)
        {
            listBox_products.Visibility = Visibility.Visible;
            listBox_products.Items.Clear();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stock where product_name like('" + input_product_name.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                listBox_products.Items.Add(dr["product_name"].ToString());
            }
        }

        //Generate price method
        private void GeneratePrice(string productName)
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select top 1 * from purchase_master where product_name='" + productName + "' order by id desc";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach(DataRow dr in dt1.Rows)
            {
                input_product_price.Text = dr["product_price"].ToString();
            }
        }

        //AFTER USER ENTER QUANTITY
        private void qty_lost_Focus(object sender, RoutedEventArgs e)
        {
            input_total.Text = (Convert.ToInt32(input_product_quantity.Text) * Convert.ToInt32(input_product_price.Text)).ToString();
        }

        //ON MOUSE SELECT LIST BOX - remove this: list_box_mouse_down <- no need for this
        private void list_box_mouse_down(object sender, MouseButtonEventArgs e) // <- no need for this event
        {
            input_product_name.Text = listBox_products.SelectedItem.ToString();
            string product = listBox_products.SelectedItem.ToString();
            listBox_products.Visibility = Visibility.Collapsed;

            //GeneratePrice (product)
            GeneratePrice(product);
            input_total.Focus();
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            input_product_name.Text = listBox_products.SelectedItem.ToString();
            string product = listBox_products.SelectedItem.ToString();
            listBox_products.Visibility = Visibility.Collapsed;

            //GeneratePrice (product)
            GeneratePrice(product);
            input_total.Focus();
        }

        //ADD BUTTON
        private void btn_sell_Click(object sender, RoutedEventArgs e)
        {
            int stock = 0;
            //Check if there is enough product quantity
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stock where product_name='" + input_product_name.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["product_qty"].ToString());
            }

            if(Convert.ToInt32(input_product_quantity.Text) > stock)
            {
                MessageBox.Show("Not enough items ! \n There is: " + stock.ToString() + " " +input_product_name.Text + " in the stock... ");
                return;
            }
            else
            {
                //if there are enough items in stock:
                // dr represents new row, insert name_input where "Product etc... add dr to datatable
                DataRow dr = datatable_products.NewRow();

                dr["Product"] = input_product_name.Text;
                dr["Price"] = input_product_price.Text;
                dr["Quantity"] = input_product_quantity.Text;
                dr["Total"] = input_total.Text;

                datatable_products.Rows.Add(dr);
                
                //push data to grid
                dataGrid_products_sell.ItemsSource = datatable_products.DefaultView;

                //TOTAL SUM
                total_display.Content = Convert.ToInt32(total_display.Content) + Convert.ToInt32(dr["total"].ToString());
            }
        }

        //ROW CLICK
        private void dataGrid_dealers_row_Click(object sender, MouseButtonEventArgs e)
        {
            //Get selected row data, as dataRowView type
            id = dataGrid_products_sell.SelectedItem as DataRowView;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            //Check if unit is selected
            if (id == null)
            {
                MessageBox.Show("Select item from table first");
                return;
            }
            else
            {
                //Remove item from dataGird_products ITEMS SOURCE ! (datatable_products)
                total_display.Content = 0;
                datatable_products.Rows.RemoveAt(Convert.ToInt32(dataGrid_products_sell.SelectedIndex));
                id = null;

                //Re-calculate total:
                foreach(DataRow dr in datatable_products.Rows)
                {
                    total_display.Content = Convert.ToInt32(total_display.Content) + dr["total"].ToString();
                }
            }
        }
    }
}

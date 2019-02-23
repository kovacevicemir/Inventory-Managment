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
    /// Interaction logic for Purchase_master.xaml
    /// </summary>
    public partial class Purchase_master : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emir\Source\Repos\Inventory Managment\Inventory Managment\Inventory Managment\Inventory.mdf;Integrated Security=True");

        public Purchase_master()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //check for connection state
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            fill_product_name();
            fill_dealer_name();
            comboBox_purchase_type.Items.Add("CASH");
            comboBox_purchase_type.Items.Add("DEBIT");
        }

        //FILL PRODUCT NAME COMBOBOX
        public void fill_product_name()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from products";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                comboBox_product_name.Items.Add(dr["product_name"].ToString());
            }
        }

        //ON PRODUCT NAME SELECT CHANGE UNIT TO : EXAMPLE KG, CM ETC.
        private void comboBox_product_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from products where product_name='"+ comboBox_product_name.Text +"'";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Unit_display.Text = dr["product_unit"].ToString();
            }
        }

        //It wont pick select change first time so i added this event
        private void product_name_Leave(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from products where product_name='" + comboBox_product_name.Text + "'";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Unit_display.Text = dr["product_unit"].ToString();
            }
        }

        //FILL DEALER NAME COMBOBOX
        public void fill_dealer_name()
        {
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from dealer_info";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox_dealer_name.Items.Add(dr["dealer_name"].ToString());
            }
        }

        //WHEN USER ENTER PRODUCT PRICE
        private void product_price_Leave(object sender, RoutedEventArgs e)
        {
            int parsedValue;
            int parsedValue1;
            if (!int.TryParse(input_product_price.Text, out parsedValue))
            {
                MessageBox.Show("Product Price is a number only field");
                input_product_price.Text = "";
                return;
            }

            if (!int.TryParse(input_product_quantity.Text, out parsedValue1))
            {
                MessageBox.Show("Product Quantity is a number only field");
                input_product_quantity.Text = "";
                return;
            }
            
            input_total.Text = Convert.ToString(Convert.ToInt32(input_product_quantity.Text) * Convert.ToInt32(input_product_price.Text));
        }

        //PURCHASE BUTTON
        private void btn_purchase_item_Click(object sender, RoutedEventArgs e)
        {
            //Verification to be added
            //no empty fields

            //CHECL IF ITEM IS ALREADY AVAILABLE IN STOCK
            int stock;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from stock where product_name='" +comboBox_product_name.Text+ "'";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            stock = Convert.ToInt32(dt2.Rows.Count.ToString());

            if(stock == 0)
            {
                //INSERT IN PURCHASED
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into purchase_master values('" + comboBox_product_name.Text + "','" + input_product_quantity.Text + "','" + Unit_display.Text + "','"
                    + input_product_price.Text + "','" + input_total.Text + "','" + input_purchase_date.SelectedDate.Value.ToString("dd-MM-yyyy") + "','" + comboBox_dealer_name.Text +
                    "','" + comboBox_purchase_type.Text + "','" + input_expiry_date.SelectedDate.Value.ToString("dd-MM-yyyy") + "','" + input_profit.Text + "')";

                cmd.ExecuteNonQuery();
                MessageBox.Show("Item purchased successfully!");

                //INSERT IN STOCK
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "insert into stock values('" + comboBox_product_name.Text + "','" + input_product_quantity.Text + "','" + Unit_display.Text + "')";
                cmd4.ExecuteNonQuery();
            }
            else
            {
                //INSERT IN PURCHASED
                SqlCommand cmd5 = con.CreateCommand();
                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "insert into purchase_master values('" + comboBox_product_name.Text + "','" + input_product_quantity.Text + "','" + Unit_display.Text + "','"
                    + input_product_price.Text + "','" + input_total.Text + "','" + input_purchase_date.SelectedDate.Value.ToString("dd-MM-yyyy") + "','" + comboBox_dealer_name.Text +
                    "','" + comboBox_purchase_type.Text + "','" + input_expiry_date.SelectedDate.Value.ToString("dd-MM-yyyy") + "','" + input_profit.Text + "')";

                cmd5.ExecuteNonQuery();
                MessageBox.Show("Item purchased successfully!");

                //INSERT IN STOCK
                SqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "update stock set product_qty=product_qty + " +Convert.ToInt32(input_product_quantity.Text)+ " where product_name='" + comboBox_product_name.Text + "'";
                cmd6.ExecuteNonQuery();
            }
        }
    }
}

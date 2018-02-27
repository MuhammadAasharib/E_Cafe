using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace E_Cafe
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String sqlConName = "datasource = localhost; port=3306;username=root;password=";
        int bill = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            TableCell tbCell3 = new TableCell();
            TableCell tbCell4 = new TableCell();
            TableCell tbCell5 = new TableCell();

            tbCell3.Text = "Product Name";
            tbCell4.Text = "Quanitity";
            tbCell5.Text = "Cost Per Unit";

            TableRow tbRow1 = new TableRow();
            tbRow1.Cells.Add(tbCell3);
            tbRow1.Cells.Add(tbCell4);
            tbRow1.Cells.Add(tbCell5);

            Table1.Rows.Add(tbRow1);

            Dictionary<String,String> order = Page.Session["MyArray"] as Dictionary<String,String>;
            foreach(String item in order.Keys)
            {
                String productName = item;
                String receviedDescription = order[item];
                String[] quantityPrice = receviedDescription.Split(',');
                //lv.Items.Add(quantityPrice);
                

                TableCell tbCell = new TableCell();
                TableCell tbCell1 = new TableCell();
                TableCell tbCell2 = new TableCell();

                tbCell.Text = productName;
                tbCell1.Text = quantityPrice[0];
                tbCell2.Text = quantityPrice[1];

                String deliverOrder = quantityPrice[2]; //if true then deliver else pickup

                bill += Convert.ToInt32(quantityPrice[0]) * Convert.ToInt32(quantityPrice[1]);

                TableRow tbRow = new TableRow();
                tbRow.Cells.Add(tbCell);
                tbRow.Cells.Add(tbCell1);
                tbRow.Cells.Add(tbCell2);
                
                String cusName = quantityPrice[3];
                String contact = quantityPrice[4];
                String addOrTime = quantityPrice[5];

                Label1.Text = cusName;
                Label2.Text = contact;
                Label3.Text = addOrTime;

                if (deliverOrder == "true")
                {
                    Label4.Text = "Delivery Address";
                }
                else
                {
                    Label4.Text = "Time of Pickup";
                }
                
                
                Table1.Rows.Add(tbRow);

                int i = 0;
            }
            Label5.Text = "Rs. " + bill.ToString()+"/-";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connectToDb();
            String query1 = "";

            if (Label4.Text == "Delivery Address")
            {
                query1 = "insert into " + "e_cafe" + "." + "order_delivery (" + "customer_name,order_time,contact_no,order_status,bill" + ")" + "values ('" + Label1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Label2.Text + "','" + "Pending" + "','" + bill + "');";
            }
            else
            {
                query1 = "insert into " + "e_cafe" + "." + "order_pickup (" + "customer_name,contact_no,order_time,pickup_time,order_status,bill" + ")" + "values ('" + Label1.Text + "','" + Label2.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + Label3.Text + "','" + "Pending" + "','" + bill + "');";
            }
            MySqlCommand command1 = new MySqlCommand(query1, con);
            try
            {
                MySqlDataReader sqd = command1.ExecuteReader();
            }
            catch (Exception ex)
            {
                
            }
            closeDbConnection(con);
            Response.Redirect("~/WebForm1.aspx");
        }

        private MySqlConnection connectToDb()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(sqlConName);
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                }
                return con;
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void closeDbConnection(MySqlConnection con)
        {
            con.Close();
        }
    }
}
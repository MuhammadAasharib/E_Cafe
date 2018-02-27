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
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<TextBox> textBoxList = new List<TextBox>();
        List<Label> labelList= new List<Label>();
        List<Label> priceList = new List<Label>();
        String sqlConName = "datasource = localhost; port=3306;username=root;password=";
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox txBox= null;
            Label label = null;
            Panel panel = null;
            CheckBox checkBox = null;
            Label txPrice = null;

            
            List<CheckBox> checkBoxList = new List<CheckBox>();
            PickupCheckBox.Checked = true;
            string query = "select * from e_cafe.food_items";
            try
            {
                MySqlConnection con = connectToDb();
                MySqlCommand com = new MySqlCommand(query, con);
                MySqlDataReader reader;
                reader = com.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {

                        panel = new Panel();
                        label = new Label();
                        txBox = new TextBox();
                        checkBox = new CheckBox();
                        txPrice = new Label();
                        String foodItemId = reader.GetString(0);
                        String foodItemName = reader.GetString(1);
                        String foodItemPrice = reader.GetString(2);

                        checkBox.ID = "checkBox" + foodItemId;
                        checkBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                        checkBox.AutoPostBack = true;
                        panel.Controls.Add(checkBox);
                        label.ID = "labelItem" + foodItemId;
                        label.Text = foodItemName;
                        label.CssClass = "label";
                        panel.Controls.Add(label);
                        txBox.ID = "textItem" + foodItemId;
                        txBox.Text = "";
                        txBox.Width = 15;
                        
                        
                        txBox.CssClass="textBox";
                        txBox.Enabled = false;

                        txPrice.ID ="priceItem"+foodItemId;
                        txPrice.Text =foodItemPrice;
                        
                        panel.Controls.Add(txBox);
                        panel.Controls.Add(txPrice);
                        panel.CssClass = "panelBox";
                        Panel1.Controls.Add(panel);

                        labelList.Add(label);
                        checkBoxList.Add(checkBox);
                        textBoxList.Add(txBox);
                        priceList.Add(txPrice);

                        TextBox4.Enabled = false;
                        TextBox5.Enabled = false;
                        TextBox6.Enabled = false;

                    }
                }
            }
            catch {

            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            String checkBoxName = sender.GetType().Name;
            CheckBox chk = (CheckBox)sender;
            String chkId = chk.ID;
            String index = chkId.Substring(chkId.Length - 1, 1);
            String textBoxId = "textItem" + index;
            TextBox textBoxFound = textBoxFind(textBoxList, textBoxId);
            if (textBoxFound != null) {
                if (textBoxFound.Enabled == true) {
                    textBoxFound.Enabled = false;
                    textBoxFound.Text = "";
                }
                else
                {
                    textBoxFound.Enabled = true;
                    textBoxFound.Text = "1";
                }
            }
            int d = 0;
            //Panel1.FindControl()
            //throw new NotImplementedException();
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

        public TextBox textBoxFind(List<TextBox> box,String txtbox) {
            foreach (TextBox t in box) {
                if(t.ID == txtbox)
                {
                    return t;
                }
                else
                {
                    continue;
                }
            }
            return null;
        }

        protected void checkout_button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Dictionary<String, String> order = new Dictionary<String, String>();
            foreach(TextBox t in textBoxList)
            {
                if (t.Text != null && t.Text!="")
                {
                    count++;
                    String index = t.ID.Substring(t.ID.Length-1, 1);
                    String labelName = "labelItem" + index;
                    Label tempLabel = labelList.Find(x => x.ID == labelName);
                    String priceLabel = "priceItem" + index;
                    String quantity = t.Text;
                    String unitPrice = priceList.Find(y => y.ID == priceLabel).Text;

                    String deliverOrder = "";

                    String name = "";
                    String contact = "";
                    String addOrTime = "";
                    if (DeliverCheckBox.Checked == true)
                    {
                        deliverOrder = "true";
                        name = TextBox4.Text;
                        contact = TextBox5.Text;
                        addOrTime = TextBox6.Text;
                    }
                    else
                    {
                        deliverOrder = "false";
                        
                        name = TextBox1.Text;
                        contact = TextBox2.Text;
                        addOrTime = TextBox3.Text;
                    }
                    
                    String toPass = quantity + "," + unitPrice + "," + deliverOrder + "," + name + "," + contact + "," + addOrTime;

                    order.Add(tempLabel.Text, toPass);
                }
            }
            if (count > 0)
            {
                Page.Session["MyArray"] = order;
                Response.Redirect("~/WebForm2.aspx");
            }
            //Server.Transfer("WebForm2.aspx");
        }


        protected void Deliver_CheckedChanged(object sender, EventArgs e)
        {
            if(DeliverCheckBox.Checked == true)
            {
                PickupCheckBox.Checked = false;
                TextBox4.Enabled = true;
                TextBox5.Enabled = true;
                TextBox6.Enabled = true;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
            }
            else
            {
                PickupCheckBox.Checked = true;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
            }
        }

        protected void Pickup_CheckedChanged(object sender, EventArgs e)
        {
            if (PickupCheckBox.Checked == true)
            {
                DeliverCheckBox.Checked = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
            }
            else
            {
                DeliverCheckBox.Checked = true;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = true;
                TextBox5.Enabled = true;
                TextBox6.Enabled = true;
            }
        }

    }
}
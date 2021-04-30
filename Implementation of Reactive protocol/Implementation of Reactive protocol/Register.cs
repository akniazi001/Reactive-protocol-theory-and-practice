using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Implementation_of_Reactive_protocol
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        protected void Database_conn()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Password_sc;Integrated Security=True");
                if (cn.State.ToString() == "Closed")
                    {
                        cn.Open();
                    }
                    SqlCommand cmd1 = new SqlCommand("SELECT UserName FROM User_Table WHERE UserName='" + txtname.Text + "'", cn);
                    SqlDataReader usernameRdr = null;
                    string user = null;
                    usernameRdr = cmd1.ExecuteReader();
                while (usernameRdr.Read())
                    {
                        user = usernameRdr["UserName"].ToString();
                    }
                    cn.Close();
                if (user != null)
                    {
                        MessageBox.Show("User Name already Exist!");
                    }
                else
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO User_Table  values('" + txtname.Text + "','" + txtpassword.Text + "')", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        var Form2 = new Form2(txtname.Text,txtpassword.Text);
                        Form2.ShowDialog();
                        Close();
                    }
                }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message);
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
            {  
            if (txtname.Text == "" || txtpassword.Text == ""|| txtreptpasswrd.Text=="")
                {
                    lblshow.Visible = true;
                    lblshow.Text = "Enter user name and password ";
                    lblshow.ForeColor = System.Drawing.Color.Red;
                }
            else if (txtpassword.Text.Length < 8)
                {
                    lblshow.Visible = true;
                    lblshow.Text = "Password should be atleast 8 characters";
                    lblshow.ForeColor = System.Drawing.Color.Red;
                }
            else if (txtpassword.Text !=  txtreptpasswrd.Text )
                {
                    lblshow.Visible = true;
                    lblshow.Text = "Password and Repeat password should must be matched ";
                    lblshow.ForeColor = System.Drawing.Color.Red;
                }
            else
                {
                    lblshow.Text = "";
                    Database_conn();
                }
        }
            private void btnExit_Click(object sender, EventArgs e)
                {
                this.Close();
                }
           private void btnreset_Click(object sender, EventArgs e)
                {
                    lblshow.Text = "";
                    txtpassword.Text = "";
                    txtreptpasswrd.Text = "";
                    txtname.Text = "";
                }
        }
}


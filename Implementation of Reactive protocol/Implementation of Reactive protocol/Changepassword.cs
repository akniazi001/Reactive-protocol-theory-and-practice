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
    public partial class Changepassword : Form
    {
        public string username,oldpass;
        public Changepassword(string uname,string pass)
        {
            oldpass = pass;
            username = uname;
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
                SqlCommand cmd = new SqlCommand(" update User_Table SET Password='" + txtnewpass.Text + "'where UserName='" + username + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                   lblshow.Text="Password has been successfully changed";
                }
            
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message);
            }
        }
    
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtoldpass.Text != oldpass) 
            {
                lblshow.Text = "old password is not correct!";
                lblshow.ForeColor = System.Drawing.Color.Red;
            }
            if (txtoldpass.Text == "" || txtnewpass.Text == "" || txtreptpasswrd.Text == "")
            {
                lblshow.Visible = true;
                lblshow.Text = "Enter password in text field";
                lblshow.ForeColor = System.Drawing.Color.Red;
            }
            else if ( txtnewpass.Text.Length < 8)
            {
                lblshow.Visible = true;
                lblshow.Text = "Password should be atleast 8 characters";
                lblshow.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtnewpass.Text != txtreptpasswrd.Text)
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
    }
}

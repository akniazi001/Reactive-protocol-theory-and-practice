using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Implementation_of_Reactive_protocol
{
    public partial class ReactivePassword : Form
    {
        DB_access access = new DB_access();
             public ReactivePassword()
                {
                    InitializeComponent();
                }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            if (txtname.Text == "" || txtpassword.Text == "")
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
            else
                {
                    lblshow.Text = "";
                    Database_conn();   
                }      
                    lblshow.Visible = true; 
                    lblshow.ForeColor = System.Drawing.Color.Red;
       }

    private void btnreset_Click(object sender, EventArgs e)
      {
                txtname.Text = "";
                txtpassword.Text = "";
               lblshow.Visible = false;
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
                    SqlCommand cmd1 = new SqlCommand("SELECT UserName FROM User_Table WHERE UserName='"+txtname.Text+"'and Password='"+txtpassword.Text+"'", cn);
                    SqlDataReader usernameRdr = null;
                    string user=null;
                    usernameRdr = cmd1.ExecuteReader();
                    while (usernameRdr.Read())
                        {
                            user = usernameRdr["UserName"].ToString(); 
                         }
                        cn.Close();
                        if (user!=null)
                        {
                            var Form2 = new Form2(txtname.Text, txtpassword.Text);
                            Form2.ShowDialog();  
                        }
                        else
                        {
                            MessageBox.Show("User Name and password not correct! ");
                        }
                }
                catch (Exception xe)
                {
                    MessageBox.Show(xe.Message);
                }
     }

     private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     private void lnkregister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var Register = new Register();            
            Register.ShowDialog();
        }


   }
}

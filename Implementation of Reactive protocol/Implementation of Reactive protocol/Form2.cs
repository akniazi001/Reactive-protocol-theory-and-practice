using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Implementation_of_Reactive_protocol
{
    public partial class Form2 : Form
    {
        string txtpasswrd;
     public Form2(string Uid, string upass)
        {       
            InitializeComponent();
            lbluser.Text = Uid;
            txtpasswrd = upass;
            check_password(upass);
            Timer _timer = new Timer();
            _timer.Interval = 10000; // Time in milliseconds.
            _timer.Tick += Timer_Tick;
            if (lblshow.Text == "1")
            {
                panel_show.Visible = true;
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            
            }
        }
     void Timer_Tick(object sender, EventArgs e)
     {
         panel_show.Visible = true;
     }
    protected void check_password(string pass)
        {
        int countalphabet = 0, countnum = 0, countspchar = 0;
            lblshowspcial.Visible = true;
            lblshownum.Visible = true;
            lblshowalfabet.Visible = true;
            lblshow.Visible = false;
            lblshow.Text = "";
            lbltotal.Visible = true;
            lblpasswordstrg.Visible = true;
        string[] str = new string[pass.Length];
        for (int i = 0; i < pass.Length; i++)
        if (pass[i] >= 'a' && pass[i] <= 'z' || pass[i] >= 'A' && pass[i] <= 'Z')
                {
                    countalphabet++;
                }
        else if (pass[i] >= '0' && pass[i] <= '9')
                {
                    countnum++;
                }
        else if (pass[i] >= '!' || pass[i] <= '@' || pass[i] <= '#' || pass[i] <= '$' || pass[i] <= '%'
                    || pass[i] <= '^' || pass[i] <= '&' || pass[i] <= '*' || pass[i] <= '(' || pass[i] <= ')'
                    || pass[i] <= '-' || pass[i] <= '_' || pass[i] <= '+' || pass[i] <= '=' || pass[i] <= '~'
                    || pass[i] <= '`' || pass[i] <= '[' || pass[i] <= ']' || pass[i] <= '{' || pass[i] <= '}'
                    || pass[i] <= ';' || pass[i] <= ':' || pass[i] <= '"' || pass[i] <= '<' || pass[i] <= '>'
                    || pass[i] <= ',' || pass[i] <= '.' || pass[i] <= '/' || pass[i] <= '?' || pass[i] <= '|'
                    || pass[i] <= ' ')
                {
                countspchar++;
                }

            lbltotal.Text = "Length of password: " + pass.Length.ToString();
            lblshowalfabet.Text = "Charaters in Password: " + countalphabet.ToString();
            lblshownum.Text = "Numbers in Password: " + countnum.ToString();
            lblshowspcial.Text = "Special characters in Password: " + countspchar.ToString();

         if (Regex.IsMatch(pass, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d])(?=.*[@#$%&*-_^]*$).{8,}$") == true)
             {
                lblpasswordstrg.Text = "Password is very strong";
                lblpasswordstrg.ForeColor = System.Drawing.Color.Green;
                lblshow.Text = "1";
                
            }
    else if (Regex.IsMatch(pass, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[@#$%&*-_^]*$).{8,}$") == true)
            {
                lblpasswordstrg.Text = "Password strength is not strong, intruder can access";
                lblpasswordstrg.ForeColor = System.Drawing.Color.Orange;
                btnchngepass.Visible = true;
            }
    else if (Regex.IsMatch(pass, @"^(?=(.*\d){2})(?=.*[a-z]).{8,}$") == true)
            {
                lblpasswordstrg.Text = "Password strength is so weak";
                lblpasswordstrg.ForeColor = System.Drawing.Color.Red;
                btnchngepass.Visible = true;
            }
    else if (Regex.IsMatch(pass, @"^(?=(.*\d)).{8,}$") == true)
            {
                lblpasswordstrg.Text = "Password strength is so weak";
                lblpasswordstrg.ForeColor = System.Drawing.Color.Red;
                btnchngepass.Visible = true;
            }
        else
            {
                lblpasswordstrg.Text = "Password strength is so weak";
                lblpasswordstrg.ForeColor = System.Drawing.Color.Red;
                btnchngepass.Visible = true;
            }
    }
        private void btnlogout_Click(object sender, EventArgs e)
           {      
            Close();
           }

        private void btnclosepanel_Click(object sender, EventArgs e)
        {
            panel_show.Visible = false;
        }

        private void btnchngepass_Click(object sender, EventArgs e)
        {
            Changepassword chpass = new Changepassword(lbluser.Text, txtpasswrd);
            chpass.ShowDialog();
            Close();
        } 
    }
}

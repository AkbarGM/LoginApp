using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public bool auth(string login, string password)
        {
            string Login = "User";
            string Password = "81DC9BDB52D04DC20036DBD8313ED055";
            MD5 md5 = MD5.Create();
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = md5.ComputeHash(encodedPassword);
            StringBuilder hashPass = new StringBuilder();
            foreach (byte b in hash)
                hashPass.Append(b.ToString("X2"));

            if (login == Login && hashPass.ToString() == Password)
                return true;
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            if(auth(Login,Password))
            {
                this.Hide();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            else if(Login=="" || Password=="")
            {
                label3.Text = "Don\'t leave fields empty!!!";
                label3.Visible = true;
            }
            else
            {
                label3.Text = "Invalid Login or Password!";
                label3.Visible = true;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label3.Visible = false;

        }
    }
}

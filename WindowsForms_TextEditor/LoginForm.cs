using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TextEditor
{
    public partial class LoginForm : Form
    {
        bool loginflag;
        public LoginForm()
        {
            loginflag = false;
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string[] logindata = File.ReadAllLines("login.txt");

            foreach(string set in logindata)
            {
                string[] splits = set.Split(',');
                if(splits[0]==username_box.Text && splits[1] == password_Box.Text)
                {
                    DialogResult result = MessageBox.Show("Login Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginflag = true;
                    if (result == DialogResult.OK)
                    {
                        this.Hide();
                    }
                    break;
                }
            }
            if (loginflag == false)
            {
                 DialogResult result = MessageBox.Show("Login Unsuccessful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    username_box.Clear();
                    password_Box.Clear();
                }
            }
        }
    }
}

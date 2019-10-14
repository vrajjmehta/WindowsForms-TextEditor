using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsForms_TextEditor
{
    public partial class LoginForm : Form
    {
        bool loginflag;
        public static string username { get; set; }         //define username variable
        public static string userType { get; set; }         //define usertpe variable
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
            try
            {
                string[] logindata = File.ReadAllLines("login.txt");

                foreach (string set in logindata)
                {
                    string[] splits = set.Split(',');
                    if (splits[0] == username_box.Text && splits[1] == password_Box.Text)   //match username and password with the login file
                    {
                        DialogResult result = MessageBox.Show("Login Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loginflag = true;
                        if (result == DialogResult.OK)
                        {
                            this.Hide();
                            username = username_box.Text;   
                            userType = splits[2];
                            Editor textEditor = new Editor();       //show text editor
                            textEditor.Show();
                        }
                        break;
                    }
                }

                if (loginflag == false)
                {
                    DialogResult result = MessageBox.Show("Login Unsuccessful. Incorrect Username/Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        username_box.Clear();
                        password_Box.Clear();
                    }
                }
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void newuser_Click(object sender, EventArgs e)
        {
            this.Hide();
            newUserForm register = new newUserForm();       //show register form if clicked
            register.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {   
            Application.Exit();                             //exit the application
        }
    }
}

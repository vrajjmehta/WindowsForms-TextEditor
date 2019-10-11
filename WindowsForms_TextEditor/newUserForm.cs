using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsForms_TextEditor
{
    public partial class newUserForm : Form
    {
        public newUserForm()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            //hide this form if cancel is clicked
            this.Hide();
        }

        private void newUserForm_Load(object sender, EventArgs e)
        {
            //Sets when the form loads
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            label8.Visible = false;
            string[] items = { "View", "Edit" };
            usertype.Items.AddRange(items);
        }

        private void repassword_TextChanged_1(object sender, EventArgs e)
        {
            //display label whether the password is correct or not
            if (repassword.Text != "")
            {
                if (password.Text != repassword.Text)
                {
                    label8.Text = "Incorrect Password";
                    label8.Visible = true;
                }
                else if (password.Text == repassword.Text)
                {
                    label8.Text = "Password Matched!";
                    label8.Visible = true;
                }
            }
            else { label8.Visible = false; }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkUniqueUser())
                {
                    //check if not null
                    if (!String.IsNullOrEmpty(username.Text) && !String.IsNullOrEmpty(password.Text) && !String.IsNullOrEmpty(usertype.Text) && !String.IsNullOrEmpty(firstname.Text) && !String.IsNullOrEmpty(lastname.Text) && !String.IsNullOrEmpty(usertype.Text))
                    {
                        if (password.Text == repassword.Text)
                        {
                            //check if password matches
                            StreamWriter sw = new StreamWriter("login.txt", append: true);
                            sw.WriteLine("\n" + username.Text + "," + password.Text + "," + usertype.Text + "," + firstname.Text + "," + lastname.Text + "," + dateTimePicker1.Text);
                            sw.Close();
                            DialogResult result = MessageBox.Show("New User Registeration Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        else if (password.Text != repassword.Text)
                        {
                            DialogResult result = MessageBox.Show("Password do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Please enter the remaining field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                //if login file does not exits
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkUniqueUser()
        {
            //function to check unique user
            try
            {
                string[] logindata = File.ReadAllLines("login.txt");

                foreach (string set in logindata)
                {
                    string[] splits = set.Split(',');
                    if (splits[0] == username.Text)
                    {
                        MessageBox.Show("UserName already exists! Enter a different UserName.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return true;
        }
    }
}

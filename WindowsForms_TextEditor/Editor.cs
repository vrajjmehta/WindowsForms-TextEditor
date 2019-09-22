using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsForms_TextEditor
{
    public partial class Editor : Form
    {
        private bool textChanged;
        private string fileName;
        public Editor()
        {
            InitializeComponent();
            this.textChanged = false;
            this.fileName = "Untitled";
            this.Text = this.fileName;
        }
        private void TextHasChanged(object sender, EventArgs e)
        {
            this.textChanged = true;
        }
        private string GetFileName(string path)
        {
            string[] pathArray = path.Split('\\');
            return pathArray[pathArray.Length - 1];
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = this.Text;
            string[] fontsize = { "8","9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            toolStripComboBox1.Items.AddRange(fontsize);
            
            userLabel.Visible = true;
            this.userLabel.Text = "Username: " + LoginForm.username;

            string usertype = LoginForm.userType;
            if (usertype == "View")
            {
                newToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = false;
                saveAsToolStripButton.Enabled = false;
                bold.Enabled = false;
                italic.Enabled = false;
                underline.Enabled = false;
                toolStripComboBox1.Enabled = false;
                Cut.Enabled = false;
                Copy.Enabled = false;
                Paste.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
            }
        }

        private void OpenFile()
        {
            try
            {
                if (this.CheckIfFileIsRtf(this.fileName) == true)
                {
                    this.richTextBox1.Text = File.ReadAllText(this.fileName);
                }
                else
                {
                    this.richTextBox1.LoadFile(this.fileName, RichTextBoxStreamType.PlainText);
                }

                this.textChanged = false;
                this.Text = this.GetFileName(this.fileName);
                this.openFileDialog1.FileName = string.Empty;
                this.toolStripTextBox1.Text = this.Text;
            }
            catch
            {
                MessageBox.Show("An error occured! The file couldn't be opened!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool CheckIfFileIsRtf(string path)
        {
            string[] pathArray = path.Split('.');

            if (pathArray[pathArray.Length - 1] == "rtf")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveFile(bool saveAs)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.fileName == "Untitled" || saveAs == true)
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = this.saveFileDialog1.FileName;
                    File.WriteAllText(this.fileName, richTextBox1.Text);
                    this.toolStripTextBox1.Text = this.fileName;
                }
                else
                {
                    askIfSave = DialogResult.Cancel;
                }
            }

            if (askIfSave != DialogResult.Cancel)
            {
                try
                {
                    if (this.CheckIfFileIsRtf(this.fileName) == true)
                    {
                        File.WriteAllText(this.fileName, richTextBox1.Text);
                    }
                    else
                    {
                        this.richTextBox1.SaveFile(this.fileName, RichTextBoxStreamType.PlainText);
                    }

                    this.textChanged = false;
                }
                catch
                {
                    MessageBox.Show("An error occured! The changes couldn't be saved!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            this.saveFileDialog1.FileName = string.Empty;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void Cut_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.fileName = "Untitled";
            this.toolStripTextBox1.Text = this.fileName;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                this.SaveFile(false);
            }

            if (askIfSave != DialogResult.Cancel)
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = this.openFileDialog1.FileName;

                    this.OpenFile();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.SaveFile(false);
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            this.SaveFile(true);
        }

        private void bold_Click_1(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionFont.Bold)
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
            }
            else
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void italic_Click_1(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionFont.Italic)
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
            }
            else
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void underline_Click_1(object sender, EventArgs e)
        {

            if (this.richTextBox1.SelectionFont.Underline)
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
            }
            else
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont, this.richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripButton_Click(sender, e);
        }

        private void cutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cut_Click(sender,e);
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Copy_Click(sender, e);
        }

        private void pasteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Paste_Click(sender, e);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(toolStripComboBox1.Text);
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, size);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About info = new About();
            info.Show();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem_Click(sender, e);
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}

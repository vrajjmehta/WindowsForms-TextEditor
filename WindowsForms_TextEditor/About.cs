using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TextEditor
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeAbout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeAbout();
        }

        private void closeAbout()
        {
            this.Hide();
        }
    }
}

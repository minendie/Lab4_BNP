using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form6 : Form
    {
        public Form6(string url)
        {
            InitializeComponent();
            Show(url);
        }
        private void Show(string url)
        {
            try
            {
                // Create a WebClient to download the website content
                WebClient client = new WebClient();
                string htmlContent = client.DownloadString(url);

                // Display the website source code
                richTextBox1.Text = htmlContent;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the download
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

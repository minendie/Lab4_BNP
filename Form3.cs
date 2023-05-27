using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Show(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response. 
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server. 
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access. 
            StreamReader reader = new StreamReader(dataStream);
            // Read the content. 
            string responseFromServer = reader.ReadToEnd();
            // Close the response. 
            response.Close();
            richTextBox1.Text += responseFromServer;            //return responseFromServer;
        }

        private void Download(string szURL, string fileurl)
        {
            WebClient myclient = new WebClient();
            Stream response = myclient.OpenRead(szURL);
            myclient.DownloadFile(szURL, fileurl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string fileurl  = textBox2.Text;
            Download(url,fileurl);
            Show(url);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

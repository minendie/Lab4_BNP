using System.Net;
using System.Security.Policy;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string getHTML(string szURL)
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
            return responseFromServer;
        }


        private void button1_Click(object sender, EventArgs e)
        {            
            richTextBox1.Clear();
            string url = textBox1.Text;            
            richTextBox1.Text += getHTML(url);
            richTextBox1.Text += "\r\n";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
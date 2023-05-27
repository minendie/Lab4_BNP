using System.Collections;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Lab4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string content = textBox1.Text;
            string url = textBox2.Text;

            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string> {
                {"data", textBox1.Text}
            };
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(url, content);
            var responseFromserver = response.Result.Content.ReadAsStringAsync().Result;
            richTextBox1.Text = responseFromserver;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

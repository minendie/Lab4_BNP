using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            try
            {
                webView21.Source = new Uri(url);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine("Caught: {0}", ex.Message);
                return;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6(textBox1.Text);
            form6.Show();
        }
        private string GetDirectoryName(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text; // url của trang web

                // Tạo đối tượng WebClient để download nội dung trang
                WebClient client = new WebClient();
                string htmlContent = client.DownloadString(url);

                // Tạo đường dẫn thư mục để lưu trữ toàn bộ source code của trang web
                string rootDirectory = "E:\\source"; // Thay đổi đường dẫn thư mục gốc tại đây

                // Tạo thư mục gốc cho trang web
                string directoryPath = Path.Combine(rootDirectory, GetDirectoryName(url));
                Directory.CreateDirectory(directoryPath);

                // Lưu file HTML
                string htmlFilePath = Path.Combine(directoryPath, "index.html");
                File.WriteAllText(htmlFilePath, htmlContent);

                // Sử dụng HtmlAgilityPack để xử lý nội dung HTML
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);

                // Xử lý các thẻ <img> để download hình ảnh
                HtmlNodeCollection imgNodes = htmlDocument.DocumentNode.SelectNodes("//img");
                if (imgNodes != null)
                {
                    foreach (HtmlNode imgNode in imgNodes)
                    {
                        string imageUrl = imgNode.GetAttributeValue("src", string.Empty);

                        // Tạo đường dẫn đầy đủ cho hình ảnh
                        Uri baseUri = new Uri(url);
                        Uri imageUri = new Uri(baseUri, imageUrl);
                        string imageFileName = Path.GetFileName(imageUri.LocalPath);
                        string imagePath = Path.Combine(directoryPath, imageFileName);

                        // Download hình ảnh và lưu vào thư mục hiện tại
                        client.DownloadFile(imageUri, imagePath);

                        // Tùy chỉnh xử lý hình ảnh tại đây
                        // ...
                    }
                }

                // Xử lý các thẻ <link> để download các file CSS
                HtmlNodeCollection linkNodes = htmlDocument.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
                if (linkNodes != null)
                {
                    foreach (HtmlNode linkNode in linkNodes)
                    {
                        string cssUrl = linkNode.GetAttributeValue("href", string.Empty);

                        // Tạo đường dẫn đầy đủ cho file CSS
                        Uri baseUri = new Uri(url);
                        Uri cssUri = new Uri(baseUri, cssUrl);
                        string cssFileName = Path.GetFileName(cssUri.LocalPath);
                        string cssPath = Path.Combine(directoryPath, cssFileName);

                        // Download file CSS và lưu vào thư mục hiện tại
                        client.DownloadFile(cssUri, cssPath);

                        // Tùy chỉnh xử lý file CSS tại đây
                        // ...
                    }
                }

                // Xử lý các thẻ <script> để download các file JavaScript
                HtmlNodeCollection scriptNodes = htmlDocument.DocumentNode.SelectNodes("//script[@src]");
                if (scriptNodes != null)
                {
                    foreach (HtmlNode scriptNode in scriptNodes)
                    {
                        string jsUrl = scriptNode.GetAttributeValue("src", string.Empty);

                        // Tạo đường dẫn đầy đủ cho file JavaScript
                        Uri baseUri = new Uri(url);
                        Uri jsUri = new Uri(baseUri, jsUrl);
                        string jsFileName = Path.GetFileName(jsUri.LocalPath);
                        string jsPath = Path.Combine(directoryPath, jsFileName);

                        // Download file JavaScript và lưu vào thư mục hiện tại
                        client.DownloadFile(jsUri, jsPath);

                        // Tùy chỉnh xử lý file JavaScript tại đây
                        // ...
                    }
                }
                //Xử lý file pdf 
                HtmlNodeCollection pdfNodes = htmlDocument.DocumentNode.SelectNodes("//a");
                if (linkNodes != null)
                {
                    foreach (HtmlNode linkNode in linkNodes)
                    {
                        string fileUrl = linkNode.GetAttributeValue("href", string.Empty);

                        // Tạo đường dẫn đầy đủ cho file
                        Uri baseUri = new Uri(url);
                        Uri fileUri = new Uri(baseUri, fileUrl);
                        string fileName = Path.GetFileName(fileUri.LocalPath);
                        string filePath = Path.Combine(directoryPath, fileName);

                        // Download file và lưu vào thư mục hiện tại
                        client.DownloadFile(fileUri, filePath);

                        // Tùy chỉnh xử lý file tại đây
                        // ...
                    }
                }
                // Xử lý các thẻ <video> để download các file video
                HtmlNodeCollection videoNodes = htmlDocument.DocumentNode.SelectNodes("//video/source");
                if (videoNodes != null)
                {
                    foreach (HtmlNode videoNode in videoNodes)
                    {
                        string videoUrl = videoNode.GetAttributeValue("src", string.Empty);

                        // Tạo đường dẫn đầy đủ cho file video
                        Uri baseUri = new Uri(url);
                        Uri videoUri = new Uri(baseUri, videoUrl);
                        string videoFileName = Path.GetFileName(videoUri.LocalPath);
                        string videoPath = Path.Combine(directoryPath, videoFileName);

                        // Tải xuống nội dung video và lưu vào thư mục hiện tại
                        byte[] videoContent = client.DownloadData(videoUri);
                        File.WriteAllBytes(videoPath, videoContent);

                        // Tùy chỉnh xử lý video tại đây
                        // ...
                    }
                }
                // Xử lý các thẻ <audio> để download các file audio
                HtmlNodeCollection audioNodes = htmlDocument.DocumentNode.SelectNodes("//audio/source");
                if (audioNodes != null)
                {
                    foreach (HtmlNode audioNode in audioNodes)
                    {
                        string audioUrl = audioNode.GetAttributeValue("src", string.Empty);

                        // Tạo đường dẫn đầy đủ cho file audio
                        Uri baseUri = new Uri(url);
                        Uri audioUri = new Uri(baseUri, audioUrl);
                        string audioFileName = Path.GetFileName(audioUri.LocalPath);
                        string audioPath = Path.Combine(directoryPath, audioFileName);

                        // Tải xuống nội dung audio và lưu vào thư mục hiện tại
                        byte[] audioContent = client.DownloadData(audioUri);
                        File.WriteAllBytes(audioPath, audioContent);

                        // Tùy chỉnh xử lý audio tại đây
                        // ...
                    }
                }


                MessageBox.Show("Download completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            /*
                        string savePath = "E:\\source.html";
                        WebClient client = new WebClient();
                        string htmlContent = client.DownloadString(url);

                        // Save the downloaded HTML source code to a file
                        File.WriteAllText(savePath, htmlContent);
            */
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string url = "http://google.com";
            try
            {
                webView21.Source = new Uri(url);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine("Caught: {0}", ex.Message);
                return;
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}

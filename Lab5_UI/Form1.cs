using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace Lab5_Server
{
    public partial class Form1 : Form
    {
        const string folderPath = "D:\\Uni\\Year4\\AZIR\\AzirRepo\\Lab4_Server\\bin\\Debug\\net8.0\\packets";
        public string[] jsonFiles;
        public Form1()
        {
            InitializeComponent();
            ProcessDirectory();
        }



        void ProcessDirectory()
        {
            packetsList.Items.Clear();
            jsonFiles = Directory.GetFiles(folderPath);
            foreach (string jsonFile in jsonFiles)
            {

                JObject packet = JObject.Parse(File.ReadAllText(jsonFile));
                packetsList.Items.Add((string)packet["PacketId"]);
            }
        }
        Image ConvertBase64ToImage(string base64ImageString)
        {
            try
            {

                byte[] imageBytes = Convert.FromBase64String(base64ImageString);


                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {

                    Image generatedImage = Image.FromStream(memoryStream);
                    return generatedImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting base64 to image: " + ex.Message);
                return null;
            }
        }
        Image UpscaleImage(Bitmap originalImage, int targetWidth, int targetHeight)
        {
            Bitmap upscaledImage = new Bitmap(targetWidth, targetHeight);

            float scaleX = (float)targetWidth / originalImage.Width;
            float scaleY = (float)targetHeight / originalImage.Height;

            for (int x = 0; x < targetWidth; x++)
            {
                for (int y = 0; y < targetHeight; y++)
                {
                    int originalX = (int)(x / scaleX);
                    int originalY = (int)(y / scaleY);

                    Color nearestColor = originalImage.GetPixel(originalX, originalY);

                    upscaledImage.SetPixel(x, y, nearestColor);
                }
            }

            return upscaledImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessDirectory();
        }
        private void packetsList_Click(object sender, EventArgs e)
        {


        }

        private void packetsList_DoubleClick(object sender, EventArgs e)
        {
            int id = packetsList.SelectedIndex;
            packetsList.ClearSelected();
            JObject json = JObject.Parse(File.ReadAllText(jsonFiles[id]));

            packetIdLabel.Text = (string)json["PacketId"];
            dateLabel.Text = (string)json["DateTimeStamp"];
            string test = (string)json["Base64Image"];

            Image generatedImage = ConvertBase64ToImage((string)json["Base64Image"]);
            Image upscaledImage = UpscaleImage((Bitmap)generatedImage, 512, 512);
            //Image generatedImage = ConvertBase64ToImage((string)json["Base64Image"]);
            packetImage.Image = upscaledImage;
        }


    }
}

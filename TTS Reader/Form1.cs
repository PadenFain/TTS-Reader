using System;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace TTS_Reader
{
    public partial class Form1 : Form
    {
        public bool fileLoaded = false;
        public bool isReading = false;
        public bool paused = false;
        public SpeechSynthesizer synth = new SpeechSynthesizer();
        OpenFileDialog ofd = new OpenFileDialog();
        public string filePath = "";
        public string readText = "";
        public string[] txtArray;
        public string txtFile;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ofd.Title = "Select File";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Text File (*.txt)|*.txt";
            ofd.FilterIndex = 1;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                filePath = Path.GetFullPath(ofd.FileName);
                var fileName = Path.GetFileName(ofd.FileName);
                textBox1.Text = fileName;
                txtArray = File.ReadAllLines(filePath);
                fileLoaded = true;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileLoaded && isReading == false)
            {

                synth.SetOutputToDefaultAudioDevice();
                string readText = File.ReadAllText(filePath);
                isReading = true;
                button3.Text = "Stop";
                foreach (string txtArray in txtArray)
                {
                    synth.SpeakAsync(txtArray);
                }

            }
            else if (fileLoaded && isReading)
            {

            }
            else
            {
                textBox1.Text = "No file loaded";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (isReading)
            {
                synth.SpeakAsyncCancelAll();
                isReading = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

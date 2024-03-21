using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;
using ObjectDetection.ScrapedImages;

namespace ObjectDetection
{
    public partial class Form1 : Form
    {
        internal Keyword keyword = Keyword.face_frontal;
        internal Color color = Color.Blue;
        public static int thickness = 2;
        private CascadeClassifier _faceCascade;
        private bool msg = false;
        private string dbPath; //database path
        private string cPath; //cascade path

        internal enum Keyword
        {
            face_frontal,
            eye_left,
            eye_right,
            eye_pair,
            ear_left,
            ear_right,
            nose,
            mouth,
            smile,
            body_upper,
            body_lower,
            body_full
        }

        public Form1()
        {
            InitializeComponent();
        }


        //This method is used for error handling the database path.
        private void button1_Click(object sender, EventArgs e)
        {
            if (dbPath == null)
            {
                MessageBox.Show("Source folder has not been selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LocateObject(keyword);
            }
        }

        //This method is used to select an image.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;|All Files|*.*";
            openFile.Title = "Select an image";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var image = new Bitmap(openFile.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        //This method handles the Emgu.CV logic and different training files.
        private void LocateObject(Keyword keyword)
        {
            switch (keyword)
            {
                case Keyword.eye_pair:
                    cPath = dbPath + @"\haarcascade_eye.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.eye_right:
                    cPath = dbPath + @"\haarcascade_mcs_righteye.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.eye_left:
                    cPath = dbPath + @"\haarcascade_mcs_lefteye.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.ear_right:
                    cPath = dbPath + @"\haarcascade_mcs_rightear.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.ear_left:
                    cPath = dbPath + @"\haarcascade_mcs_leftear.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.nose:
                    cPath = dbPath + @"\haarcascade_mcs_nose.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.mouth:
                    cPath = dbPath + @"\haarcascade_mcs_mouth.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.smile:
                    cPath = dbPath + @"\haarcascade_smile.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.body_upper:
                    cPath = dbPath + @"\haarcascade_upperbody.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.body_lower:
                    cPath = dbPath + @"\haarcascade_lowerbody.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                case Keyword.body_full:
                    cPath = dbPath + @"\haarcascade_fullbody.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
                default:
                    cPath = dbPath + @"\haarcascade_frontalface_default.xml";
                    _faceCascade = new CascadeClassifier(cPath);
                    break;
            }

            Image<Bgr, byte> capturedImage;
            if (pictureBox1.Image == null)
            {
                var error = MessageBox.Show("No image has been selected.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                capturedImage = bitmap.ToImage<Bgr, byte>();
                Rectangle[] faces = _faceCascade.DetectMultiScale(capturedImage, 1.1f, 3, Size.Empty, Size.Empty);

                foreach (Rectangle face in faces)
                {
                    capturedImage.Draw(face, new Bgr(color), thickness);
                }

                pictureBox1.Image = capturedImage.ToBitmap();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //This method handles color changing
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = true;
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
        }

        //This method handles thickness changing with a custom form popup.
        private void button4_Click(object sender, EventArgs e)
        {
            NumericInputForm dialog = new NumericInputForm();
            dialog.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyword = (Keyword)comboBox1.SelectedIndex;
        }

        //This method selects the database folder.
        private void button5_Click(object sender, EventArgs e)
        {
            if (msg == false)
            {
                var msg = MessageBox.Show("Please select a folder containing the trained databases.", "Select database folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.msg = true;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = @"C:\";

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                dbPath = dialog.SelectedPath;
                MessageBox.Show("Selected path: " + dbPath);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software was made by Vittorio Pivarci (2024) using Windows Forms + C#. " +
                "\n The source code is free to use, however, I do not own any of the training .xml files. \n I intend to update this project in the future to " +
                "allow the creation of custom training files.", "Info", MessageBoxButtons.OK);
        }
    }

}

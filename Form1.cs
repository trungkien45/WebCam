using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Webcam;
using WebCam_Capture;
using Accord.Vision;
using Accord.Vision.Detection;
using Accord.Imaging.Filters;
using Accord.Vision.Detection.Cascades;

namespace WebcamEffect
{
    public partial class Form1 : Form
    {
        //private HaarCascade haarCascade;
        FaceHaarCascade face;
        HaarObjectDetector DetectorFace;

        public Form1()
        {
            InitializeComponent();
        }
        CustomShapeCollection Shapes = new CustomShapeCollection();
        bool invertColor = false;
        List<Image> ListFrame;
        List<Image> ListMask;
        //List<Image> ListFrameBW;
        //Form3 frmFrameBW;
        Image Mask;
        Form2 frmFrame;
        WebCam webcam; //= new WebCam();
        Webcam.ImgColorFilter ColorFilter = ImgColorFilter.NoFlter;
        Bitmap FrameBitmap;
        private void Form1_Load(object sender, EventArgs e)
        {
            //CustomShape shape = new CustomShape(new Point(10,10),new Size(30,30));
            //shape.BackgroundImage= Properties.Resources._153B92F95056900B10B62F175F5ABBAF;
            //Shapes.Add(shape);
            ////shape = new CustomShape(new Point(10, 10), Properties.Resources._41ESvJaeuNL__SY300__copy);
            ////shape.BackgroundImage = Properties.Resources._41ESvJaeuNL__SY300__copy;
            //Shapes.Add(shape);
            //Mask = Properties.Resources._41ESvJaeuNL__SY300__copy;
            webcam = new WebCam();
            webcam.InitializeWebCam(ref pictureBox1);
            webcam.Start();
            face = new FaceHaarCascade();
            DetectorFace = new HaarObjectDetector(face, 75);
            //haarCascade = new HaarCascade(@"haarcascade_frontalface_default.xml");
            redToolStripMenuItem.SelectedIndex = 0;
            ListFrame = new List<Image>();
            string x = Application.StartupPath + "\\Frames\\";
            string[] filepath = System.IO.Directory.GetFiles(x, "*.png");
            string NoFramePath = Application.StartupPath + "\\Frames\\No Frame.png";
            Image NoFrame = Image.FromFile(NoFramePath);
            ListFrame.Add(NoFrame);
            foreach (string xx in filepath)
            {
                string xt = System.IO.Path.GetFileNameWithoutExtension(xx);
                if (xt != "No Frame")
                {
                    Image ccc = Image.FromFile(xx);
                    ListFrame.Add(ccc);
                    //imageList1.Images.Add(ccc);
                    //ListViewItem lvi1 = new ListViewItem(xt, index++);
                    //listView1.Items.Add(lvi1);
                }
            }
            ListMask = new List<Image>();
            x = Application.StartupPath + "\\Masks\\";
            filepath = System.IO.Directory.GetFiles(x, "*.png");
            foreach (string xx in filepath)
            {
                string xt = System.IO.Path.GetFileNameWithoutExtension(xx);
                if (xt != "No Mask")
                {
                    Image ccc = Image.FromFile(xx);
                    ListMask.Add(ccc);
                }
            }
            frmFrame = new Form2();
            //frmFrameBW = new Form3();
            FrameBitmap = Properties.Resources.Blank;
        }
        public void AddShape(CustomShape Shape)
        {
            Shapes.Add(Shape);
        }
        public void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            Graphics g = Graphics.FromImage(e.WebCamImage);
            if (Mask != null)
            {
                Rectangle[] rec = DetectorFace.ProcessFrame(new Bitmap(e.WebCamImage));
                //RectanglesMarker a = new RectanglesMarker(rec, Color.Red);
                for (int i = 0; i < rec.Length; i++)
                {
                    //g = Graphics.FromImage(e.WebCamImage);
                    //g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), rec[i]);
                    g.DrawImage(Mask, rec[i].Left - rec[i].Width / 8, rec[i].Top - rec[i].Height / 2 + rec[i].Height / 8, rec[i].Width + rec[i].Width / 4, rec[i].Height + rec[i].Height / 2);
                }
            }
            Shapes.Draw(g);
            g.DrawImage(FrameBitmap, 0, 0);

            if (invertColor)
                e.WebCamImage = ImgProcessing.SetInvert(ImgProcessing.ColorFilter(e.WebCamImage, ColorFilter));
            e.WebCamImage = ImgProcessing.ColorFilter(e.WebCamImage, ColorFilter);
            //Image<Bgr, Byte> currentFrame = new Image<Bgr, Byte>(new Bitmap(e.WebCamImage));
            //Image<Gray, Byte> grayFrame = currentFrame.Convert<Gray, Byte>();

            //var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0];

            //foreach (var face in detectedFaces)
            //currentFrame.Draw(face.rect, new Bgr(0, ;8double.MaxValue, 0), 3);

            pictureBox1.Image = e.WebCamImage;

        }
        public void SetFrame(int index)
        {
            FrameBitmap = new Bitmap(ListFrame[index]);
        }
        public void SetMask(int index)
        {
            if (index >= 0)
                Mask = ListMask[index];
            else
                Mask = null;
        }
        private void btTake_Click(object sender, EventArgs e)
        {
            if (btTake.Text == "Take Picture")
            {
                //Image imgCap = pictureBox1.Image;
                if (!frmFrame.IsDisposed)
                    frmFrame.Close();
                webcam.Stop();
                btTake.Text = "Start Capture";
                btSave.Visible = true;
            }
            else
            {
                FrameBitmap = new Bitmap(ListFrame[0]);
                SetMask(-1);
                btSave.Visible = false;
                btTake.Text = "Take Picture";
                webcam.Start();

            }
        }

        private void btFormat_Click(object sender, EventArgs e)
        {
            webcam.ResolutionSetting();
        }

        private void btSource_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }


        private void Save_Click(object sender, EventArgs e)
        {
            Webcam.Helper.SaveImageCapture(pictureBox1.Image);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcam.Stop();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void redToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (frmFrame!=null&&!frmFrame.IsDisposed)
            //frmFrame.Close();
            if (redToolStripMenuItem.SelectedIndex == 0)
                ColorFilter = ImgColorFilter.NoFlter;
            if (redToolStripMenuItem.SelectedIndex == 1)
                ColorFilter = ImgColorFilter.BlackWhite;
            if (redToolStripMenuItem.SelectedIndex == 2)
                ColorFilter = ImgColorFilter.Red;
            if (redToolStripMenuItem.SelectedIndex == 3)
                ColorFilter = ImgColorFilter.Green;
            if (redToolStripMenuItem.SelectedIndex == 4)
                ColorFilter = ImgColorFilter.Blue;
            invertColor = invertColorToolStripMenuItem.Checked = false;
            //if (webcam.Stoped)

            //    pictureBox1.Image = ImgProcessing.SetInvert(ImgProcessing.ColorFilter(pictureBox1.Image, ColorFilter));

            //g.DrawImage(FrameBitmap, 0, 0);

        }

        private void invertColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //redToolStripMenuItem.SelectedIndex = 0;
            //ColorFilter = ImgColorFilter.NoFlter;
            invertColor = invertColorToolStripMenuItem.Checked = !invertColorToolStripMenuItem.Checked;
            //if (webcam.Stoped)

            //    pictureBox1.Image = ImgProcessing.SetInvert(ImgProcessing.ColorFilter(pictureBox1.Image, ColorFilter));

        }
        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //redToolStripMenuItem.SelectedIndex = 0;
            //ColorFilter = ImgColorFilter.NoFlter;
            invertColor = invertColorToolStripMenuItem.Checked = false;
            if (frmFrame.IsDisposed)
                frmFrame = new Form2();
            frmFrame.Show();
            frmFrame.Left = this.Right;
            frmFrame.Top = this.Top;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Shapes.MouseDown(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Shapes.MouseMove(sender, e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Shapes.MouseUp(sender, e);
        }
    }
}

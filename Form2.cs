using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebcamEffect
{
    public partial class Form2 : Form
    {
        Form1 frmMain;
        public Form2()
        {
            InitializeComponent();
        }
        CustomShapeCollection Shapes;
        private void Form2_Load(object sender, EventArgs e)
        {
            Shapes = new CustomShapeCollection();
            frmMain = (Form1)Application.OpenForms[0];
            string x = Application.StartupPath + "\\Frames\\";
            string[] filepath = Directory.GetFiles(x, "*.png");
            string NoFramePath = Application.StartupPath + "\\Frames\\No Frame.png";
            Image NoFrame = Image.FromFile(NoFramePath);
            imageList1.Images.Add(NoFrame);
            ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(NoFramePath), 0);
            listView1.Items.Add(lvi);
            int index = 1;
            foreach (string xx in filepath)
            {
                string xt = Path.GetFileNameWithoutExtension(xx);
                if (xt != "No Frame")
                {
                    Image ccc = Image.FromFile(xx);
                    imageList1.Images.Add(ccc);
                    ListViewItem lvi1 = new ListViewItem(xt, index++);
                    listView1.Items.Add(lvi1);
                }
            }
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
            }
            x = Application.StartupPath + "\\Masks\\";
            filepath = Directory.GetFiles(x, "*.png");
            index = 0;
            foreach (string xx in filepath)
            {
                string xt = Path.GetFileNameWithoutExtension(xx);
                if (xt != "No Frame")
                {
                    Image ccc = Image.FromFile(xx);
                    imageList2.Images.Add(ccc);
                    ListViewItem lvi1 = new ListViewItem(xt, index++);
                    listView2.Items.Add(lvi1);
                }
            }
            x = Application.StartupPath + "\\Objects\\";
            filepath = Directory.GetFiles(x, "*.png");
            index = 0;
            foreach (string xx in filepath)
            {
                string xt = Path.GetFileNameWithoutExtension(xx);
                if (xt != "No Frame")
                {
                    Image ccc = Image.FromFile(xx);
                    CustomShape shape = new CustomShape(new Point(5, 5), new Bitmap(ccc));
                    Shapes.Add(shape);
                    Image xxx = Webcam.ImgProcessing.getThumbnaiImage(90, ccc);
                    imageList3.Images.Add(xxx);
                    ListViewItem lvi1 = new ListViewItem(xt, index++);
                    listView3.Items.Add(lvi1);
                }
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                frmMain.SetFrame(intselectedindex);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count <= 0)
            {
                frmMain.SetMask(-1);
                return;
            }
            int intselectedindex = listView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                frmMain.SetMask(intselectedindex);
            }
            //listView2.Name = "";
        }

        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            //MessageBox.Show("ddddddddddddddddddddđ");
            {
                if (listView3.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = listView3.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    frmMain.AddShape(new CustomShape(Shapes[intselectedindex]));
                }
            }
        }


        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView3.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                frmMain.AddShape(new CustomShape(Shapes[intselectedindex]));
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms.Layout;
using System.Windows.Forms;
using System.Drawing;

namespace WebcamEffect
{
    class CustomShapeCollection : IList<CustomShape>
    {
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleleToolStripMenuItem;

        //CustomShape currentShape;
        public CustomShapeCollection()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.contextMenuStrip1.SuspendLayout();


            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipToolStripMenuItem,
            this.rotate90ToolStripMenuItem,
            this.deleleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.flipToolStripMenuItem.Text = "Flip Horizontal";
            this.flipToolStripMenuItem.Click += new System.EventHandler(this.flipToolStripMenuItem_Click);
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rotate90ToolStripMenuItem.Text = "Rotate 90";
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.rotate90ToolStripMenuItem_Click);
            // 
            // deleleToolStripMenuItem
            // 
            this.deleleToolStripMenuItem.Name = "deleleToolStripMenuItem";
            this.deleleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleleToolStripMenuItem.Text = "Delele";
            this.deleleToolStripMenuItem.Click += new System.EventHandler(this.deleleToolStripMenuItem_Click);

        }
        private readonly IList<CustomShape> _list = new List<CustomShape>();
        public int IndexOf(CustomShape item)
        {
            return _list.IndexOf(item);
            //throw new NotImplementedException();
        }

        public void Insert(int index, CustomShape item)
        {
            _list.Insert(index, item);
            //throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            //throw new NotImplementedException();
        }

        public CustomShape this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
                //throw new NotImplementedException();
            }
        }

        public void Add(CustomShape item)
        {
            _list.Add(item);
            ////throw new NotImplementedException();
        }

        public void Clear()
        {
            _list.Clear();
            //throw new NotImplementedException();
        }

        public bool Contains(CustomShape item)
        {
            return _list.Contains(item);
            //throw new NotImplementedException();
        }

        public void CopyTo(CustomShape[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
            //throw new NotImplementedException();
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public bool Remove(CustomShape item)
        {
            return _list.Remove(item);
            //throw new NotImplementedException();
        }

        public IEnumerator<CustomShape> GetEnumerator()
        {
            ////throw new NotImplementedException();
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
            ////throw new NotImplementedException();
        }
        public void Draw(System.Drawing.Graphics g)
        {
            foreach (CustomShape e in _list)
            {
                e.Draw(g);
            }
        }

        CustomShape shnape;
        public void MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox1 = (PictureBox)sender;
            this.Draw(Graphics.FromImage(pictureBox1.Image));
            MouseButtons s = e.Button;
            Point MouseLocation = e.Location;
            if (s == MouseButtons.Right)
            {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    shnape = this[i];
                    if (shnape.Contain(pictureBox1, MouseLocation))
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                        break;
                    }

                }
                //this.Remove(shnape);
                //this.Cursor = Cursors.Default;
                //shnape = null;
            }
            for (int i = this.Count - 1; i >= 0; i--)
            {
                shnape = this[i];
                if (shnape.Contain(pictureBox1, MouseLocation))
                    break;

            }
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i] != shnape)
                    this[i].Clicked = false;

            }
            if (shnape != null)
                shnape.MouseDown(sender, e);
        }
        public void MouseMove(object sender, MouseEventArgs e)
        {
            Point MouseLocation = e.Location;
            PictureBox pictureBox1 = (PictureBox)sender;
            //userControl11.p
            //pictureBox1.Image = Properties.Resources.My_Snapshot2;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                shnape = this[i];
                if (shnape != null)
                    shnape.MouseMove(sender, e);
            }
            if (shnape != null)
                shnape.MouseMove(sender, e);
            if(pictureBox1.Image!=null)
                this.Draw(Graphics.FromImage(pictureBox1.Image));
        }
        public void MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox1 = (PictureBox)sender;
            Point MouseLocation = e.Location;
            //userControl11.p
            for (int i = this.Count - 1; i >= 0; i--)
            {
                shnape = this[i];
                if (shnape != null)
                    shnape.MouseUp(sender, e);
            }
            this.Draw(Graphics.FromImage(pictureBox1.Image));

        }
        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shnape.Flip();
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shnape.Rotate();
        }

        private void deleleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove(shnape);
        }
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (shnape != null && shnape.Clicked)
                    Remove(shnape);
        }
    }
}

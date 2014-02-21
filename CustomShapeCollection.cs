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
    //class B { }
    class CustomShapeCollection : IList<CustomShape>
    {
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
        public void MouseDown(object sender, MouseEventArgs e) {
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
                        break;
                }
                this.Remove(shnape);
                //this.Cursor = Cursors.Default;
                shnape = null;
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
        public void MouseMove(object sender, MouseEventArgs e) {
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
    }
}

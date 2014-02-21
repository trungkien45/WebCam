using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WebcamEffect
{
    public class CustomShape
    {
        class Pivot
        {
            public Rectangle pivot;
            public Pivot()
            {
                pivot = new Rectangle();
            }
        }
        Pivot TopLeft;
        Pivot TopRight;
        Pivot BottomLeft;
        Pivot BottomRight;
        //bool Selected=false;
        Bitmap _BackgroundImage;
        public Bitmap BackgroundImage
        {
            get { return _BackgroundImage; } 
            set{
            //SizeThis = new Size(value.Width,value.Height);
            _BackgroundImage=value;
        } }
        private Point _location;
        public Cursor cursor { get; set; }
        private Size _size;
        Rectangle rect;
        public Size SizeThis
        {
            get { return _size; }
            set
            {
                _size = value;
                rect.Size = value;
                TopLeft.pivot = new Rectangle(_location.X - 5, _location.Y - 5, 5, 5);
                TopRight.pivot = new Rectangle(_location.X + SizeThis.Width, _location.Y - 5, 5, 5);
                BottomLeft.pivot = new Rectangle(_location.X - 5, _location.Y + SizeThis.Height, 5, 5);
                BottomRight.pivot = new Rectangle(_location.X + SizeThis.Width, _location.Y + SizeThis.Height, 5, 5);
            }
        }

        public Point Location
        {
            get { return _location; }
            set
            {
                _location = value;
                rect.Location = value;
                TopLeft.pivot = new Rectangle(_location.X - 5, _location.Y - 5, 5, 5);
                TopRight.pivot = new Rectangle(_location.X + SizeThis.Width, _location.Y - 5, 5, 5);
                BottomLeft.pivot = new Rectangle(_location.X - 5, _location.Y + SizeThis.Height, 5, 5);
                BottomRight.pivot = new Rectangle(_location.X + SizeThis.Width, _location.Y + SizeThis.Height, 5, 5);
            }
        }
        //bool Selected = false;
        bool clicked = false;

        public bool Clicked
        {
            get { return clicked; }
            set { clicked = value; }
        }

        bool CDragDrop = false;
        public CustomShape(Point Location, Size Size)
        {
            //cursor = cur;
            TopLeft = new Pivot();
            TopRight = new Pivot();
            BottomLeft = new Pivot();
            BottomRight = new Pivot();
            this.Location = Location;
            this.SizeThis = Size;
            BackgroundImage = new Bitmap(SizeThis.Width, SizeThis.Height);
            rect = new Rectangle(this.Location, this.SizeThis);

        }
        public CustomShape(Point Location, Bitmap BackgroundImage)
        {
            TopLeft = new Pivot();
            TopRight = new Pivot();
            BottomLeft = new Pivot();
            BottomRight = new Pivot();
            this.Location = Location;
            this._BackgroundImage = BackgroundImage;
            this.SizeThis = new Size(BackgroundImage.Width, BackgroundImage.Height);
            rect = new Rectangle(this.Location, this.SizeThis);

        }
        private CustomShape()
        {

        }

        public CustomShape(CustomShape shnape)
        {
            // TODO: Complete member initialization
            //this.shnape = shnape;
            TopLeft = new Pivot();
            TopRight = new Pivot();
            BottomLeft = new Pivot();
            BottomRight = new Pivot();
            
            this.BackgroundImage = shnape.BackgroundImage;
            this.SizeThis = shnape.SizeThis;
            this.Location = shnape.Location;
        }
        public void Draw(Graphics g)
        {
            if (clicked)
            {
                g.DrawRectangle(new Pen(Color.Blue), rect);
                g.DrawRectangle(new Pen(Color.Red), BottomLeft.pivot);
                g.DrawRectangle(new Pen(Color.Red), BottomRight.pivot);
                g.DrawRectangle(new Pen(Color.Red), TopLeft.pivot);
                g.DrawRectangle(new Pen(Color.Red), TopRight.pivot);
            }
            g.DrawImage(this.BackgroundImage, Location.X, Location.Y, SizeThis.Width, SizeThis.Height);

        }
        int dx = 0;
        int dy = 0;
        bool tl = false, tr = false, bl = false, br = false;
        //private CustomShape shnape;
        public void MouseDown(object sender, MouseEventArgs e)
        {
            //bool tl=false, tr=false, bl=false, br=false;
            CDragDrop = rect.Contains(PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location));
            clicked = (CDragDrop || (tl = TopLeft.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location)))
                || (tr = TopRight.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location)))
                || (bl = BottomLeft.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location)))
                || (br = BottomRight.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location))));
            if (clicked && CDragDrop)
            {
                //cursor = Cursors.NoMove2D;
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                dx = MouseLocate.X - Location.X;
                dy = MouseLocate.Y - Location.Y;
            }
        }
        public bool Contain(PictureBox x, Point MouseLocation){
            return rect.Contains(PictureBoxUtility.TranslatePointToImageCoordinates(x, MouseLocation))
                || TopLeft.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates(x, MouseLocation))
                || TopRight.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates(x, MouseLocation))
                || BottomLeft.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates(x, MouseLocation))
                || BottomRight.pivot.Contains(PictureBoxUtility.TranslatePointToImageCoordinates(x, MouseLocation));
        }
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked && CDragDrop)
            {
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                Point NewLocate = new Point(MouseLocate.X - dx, MouseLocate.Y - dy);
                Location = NewLocate;
            }
            if (clicked && tl)
            {
                Point BottomRightPoint = new Point(Location.X + SizeThis.Width, Location.Y + SizeThis.Height);
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                Location = MouseLocate;
                Size newSize = Size.Empty;
                newSize.Width = BottomRightPoint.X - Location.X;
                newSize.Height = BottomRightPoint.Y - Location.Y;
                if (newSize.Width <= 3)
                    newSize.Width = 3;
                if (newSize.Height <= 3)
                    newSize.Height = 3;
                SizeThis = newSize;
                //Point NewLocate = new Point(MouseLocate.X - dx, MouseLocate.Y - dy);
                //cursor = Cursors.SizeAll;
            }
            if (clicked && tr)
            {
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                Size newSize = Size.Empty;
                int dx = MouseLocate.X - Location.X - SizeThis.Width;
                int dy = MouseLocate.Y - Location.Y;
                Location = new Point(Location.X, Location.Y + dy);
                //Size newSize = Size.Empty;
                newSize.Width = SizeThis.Width + dx;
                newSize.Height = SizeThis.Height - dy;
                if (newSize.Width <= 3)
                    newSize.Width = 3;
                if (newSize.Height <= 3)
                    newSize.Height = 3;
                SizeThis = newSize;
                //cursor = Cursors.SizeAll;
            }
            if (clicked && bl)
            {
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                Size newSize = Size.Empty;
                int dx = MouseLocate.X - Location.X;
                int dy = MouseLocate.Y - Location.Y - SizeThis.Height;
                Location = new Point(Location.X + dx, Location.Y);
                //Size newSize = Size.Empty;
                newSize.Width = SizeThis.Width - dx;
                newSize.Height = SizeThis.Height + dy;
                if (newSize.Width <= 3)
                    newSize.Width = 3;
                if (newSize.Height <= 3)
                    newSize.Height = 3;
                SizeThis = newSize;
                //cursor = Cursors.SizeAll;
            }
            if (clicked && br)
            {
                Point MouseLocate = PictureBoxUtility.TranslatePointToImageCoordinates((PictureBox)sender, e.Location);
                Size newSize = Size.Empty;
                newSize.Width = MouseLocate.X - Location.X;
                newSize.Height = MouseLocate.Y - Location.Y;
                if (newSize.Width <= 3)
                    newSize.Width = 3;
                if (newSize.Height <= 3)
                    newSize.Height = 3;
                SizeThis = newSize;

                //cursor = Cursors.SizeAll;
            }
        }
        public void MouseUp(object sender, MouseEventArgs e)
        {
            tl =  tr = bl = br = false;
            //if(e.X)
            //Clicked = false;
            cursor = Cursors.Default;
            CDragDrop = false;
            tl = tr = bl = br = false;
        }
    }
}

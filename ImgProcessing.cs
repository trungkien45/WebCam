using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Accord.Vision;
using Accord.Vision.Detection;
using Accord.Imaging.Filters;
using Accord.Vision.Detection.Cascades;

namespace Webcam
{
    public enum ImgColorFilter
    {
        Red, Green, Blue, BlackWhite, NoFlter
    }
    public class ImgProcessing
    {
        static public Image getThumbnaiImage(int width, Image img)
        {
            Image thumb = new Bitmap(width, width);
            Image tmp = null;
            if (img.Width < width && img.Height < width)
            {
                using (Graphics g = Graphics.FromImage(thumb))
                {
                    int xoffset = (int)((width - img.Width) / 2);
                    int yoffset = (int)((width - img.Height) / 2);
                    g.DrawImage(img, xoffset, yoffset, img.Width, img.Height);
                }
            }
            else
            {
                if (img.Width == img.Height)
                {
                    thumb = img.GetThumbnailImage(width, width, null, IntPtr.Zero);
                }
                else
                {
                    int k = 0;
                    int xoffset = 0;
                    int yoffset = 0;
                    if (img.Width < img.Height)
                    {
                        k = (int)(width * img.Width / img.Height);
                        tmp = img.GetThumbnailImage(k, width, null, IntPtr.Zero);
                        xoffset = (int)((width - k) / 2);
                    }
                    if (img.Width > img.Height)
                    {
                        k = (int)(width * img.Height / img.Width);
                        tmp = img.GetThumbnailImage(width, k, null, IntPtr.Zero);
                        yoffset = (int)((width - k) / 2);
                    }
                    using (Graphics g = Graphics.FromImage(thumb))
                    {
                        g.DrawImage(tmp, xoffset, yoffset, tmp.Width, tmp.Height);
                    }
                }
            }
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.DrawRectangle(Pens.Green, 0, 0, thumb.Width - 1, thumb.Height - 1);
            }
            return thumb;
        }
        public static Bitmap AddLayer(Image source, Image layer)
        {
            Bitmap Added = new Bitmap(source);
            Bitmap b1 = new Bitmap(source);
            Bitmap b2 = new Bitmap(layer);
            ImgeUtility.LockBitmap lb1 = new ImgeUtility.LockBitmap(b1);
            ImgeUtility.LockBitmap lb2 = new ImgeUtility.LockBitmap(b2);
            ImgeUtility.LockBitmap c = new ImgeUtility.LockBitmap(Added);
            lb1.LockBits();
            lb2.LockBits();
            c.LockBits();
            int w = lb1.Width > lb2.Width ? lb2.Width : lb1.Width;
            int h = lb1.Height > lb2.Height ? lb2.Height : lb1.Height;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color x = lb2.GetPixel(i, j);
                    if (x.A != 0x00 || x.B != 0x00 || x.G != 0x00 || x.R != 0x00)
                    {
                        c.SetPixel(i, j, lb2.GetPixel(i, j));
                    }
                }
            lb1.UnlockBits();
            lb2.UnlockBits();
            c.UnlockBits();
            return Added;
        }
        public static Bitmap SetInvert(Image source)
        {
            Bitmap ccc = new Bitmap(source);
            ImgeUtility.LockBitmap cx = new ImgeUtility.LockBitmap(ccc);
            cx.LockBits();
            int w = ccc.Width;
            int h = ccc.Height;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = cx.GetPixel(i, j);
                    cx.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            cx.UnlockBits();
            return ccc;
        }
        public static Bitmap ToBlackWhite(Image source)
        {
            Bitmap Added = new Bitmap(source);
            ImgeUtility.LockBitmap cx = new ImgeUtility.LockBitmap(Added);
            cx.LockBits();
            int w = Added.Width;
            int h = Added.Height;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = cx.GetPixel(i, j);
                    byte luma = (byte)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

                    cx.SetPixel(i, j, Color.FromArgb(luma, luma, luma));
                }
            cx.UnlockBits();
            return Added;
        }
        public static Bitmap ColorFilter(Image source, ImgColorFilter colorFilterType)
        {
            Bitmap xxx = new Bitmap(source);

            if (colorFilterType == ImgColorFilter.NoFlter)
                return xxx;
            if (colorFilterType == ImgColorFilter.BlackWhite)
                return ToBlackWhite(source);
            ImgeUtility.LockBitmap cx = new ImgeUtility.LockBitmap(xxx);
            cx.LockBits();
            int w = xxx.Width;
            int h = xxx.Height;
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    Color c = cx.GetPixel(i, j);
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    if (colorFilterType == ImgColorFilter.Red)
                    {
                        nPixelR = c.R;
                        nPixelG = c.G - 255;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ImgColorFilter.Green)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ImgColorFilter.Blue)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G - 255;
                        nPixelB = c.B;
                    }
                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);
                    cx.SetPixel(i, j, Color.FromArgb(nPixelR, nPixelG, nPixelB));
                }

            cx.UnlockBits();
            return xxx;
        }
    }
}

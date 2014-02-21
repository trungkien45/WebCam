using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace WebcamEffect
{
    class PictureBoxUtility
    {
        static public Point TranslatePointToImageCoordinates(PictureBox ptr, Point controlCoordinates)
        {
            switch (ptr.SizeMode)
            {
                case PictureBoxSizeMode.Normal:
                    return TranslateNormalMousePosition(ptr, controlCoordinates);
                case PictureBoxSizeMode.AutoSize:
                    return TranslateAutoSizeMousePosition(ptr, controlCoordinates);
                case PictureBoxSizeMode.CenterImage:
                    return TranslateCenterImageMousePosition(ptr, controlCoordinates);
                case PictureBoxSizeMode.StretchImage:
                    return TranslateStretchImageMousePosition(ptr, controlCoordinates);
                case PictureBoxSizeMode.Zoom:
                    return TranslateZoomMousePosition(ptr, controlCoordinates);
            }
            throw new NotImplementedException("PictureBox.SizeMode was not in a valid state");
        }
        static protected Point TranslateAutoSizeMousePosition(PictureBox ptr, Point coordinates)
        {
            //TODO: When we implement scrolling, we will have to make sure we test that properly. As of now, not sure how the rendering will take place
            return coordinates;
        }

        /// <summary>
        /// Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Zoom
        /// </summary>
        /// <param name="coordinates">Point to translate</param>
        /// <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
        /// If the Image is null, no translation is performed
        /// </returns>
        static protected Point TranslateZoomMousePosition(PictureBox ptr, Point coordinates)
        {
            //	test to make sure our image is not null
            if (ptr.Image == null) return coordinates;
            //	Make sure our control width and height are not 0 and our image width and height are not 0
            if (ptr.Width == 0 || ptr.Height == 0 || ptr.Image.Width == 0 || ptr.Image.Height == 0) return coordinates;
            //	This is the one that gets a little tricky.  Essentially, need to check the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)ptr.Image.Width / ptr.Image.Height;
            float controlAspect = (float)ptr.Width / ptr.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                //	This means that we are limited by width, meaning the image fills up the entire control from left to right
                float ratioWidth = (float)ptr.Image.Width / ptr.Width;
                newX *= ratioWidth;
                float scale = (float)ptr.Width / ptr.Image.Width;
                float displayHeight = scale * ptr.Image.Height;
                float diffHeight = ptr.Height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                //	This means that we are limited by height, meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)ptr.Image.Height / ptr.Height;
                newY *= ratioHeight;
                float scale = (float)ptr.Height / ptr.Image.Height;
                float displayWidth = scale * ptr.Image.Width;
                float diffWidth = ptr.Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }

        /// <summary>
        /// Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to StretchImage
        /// </summary>
        /// <param name="coordinates">Point to translate</param>
        /// <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
        /// If the Image is null, no translation is performed
        /// </returns>
        static protected Point TranslateStretchImageMousePosition(PictureBox ptr, Point coordinates)
        {
            //	test to make sure our image is not null
            if (ptr.Image == null) return coordinates;
            //	Make sure our control width and height are not 0
            if (ptr.Width == 0 || ptr.Height == 0) return coordinates;
            //	First, get the ratio (image to control) the height and width
            float ratioWidth = (float)ptr.Image.Width / ptr.Width;
            float ratioHeight = (float)ptr.Image.Height / ptr.Height;
            //	Scale the points by our ratio
            float newX = coordinates.X;
            float newY = coordinates.Y;
            newX *= ratioWidth;
            newY *= ratioHeight;
            return new Point((int)newX, (int)newY);
        }

        /// <summary>
        /// Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Center
        /// </summary>
        /// <param name="coordinates">Point to translate</param>
        /// <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
        /// If the Image is null, no translation is performed
        /// </returns>
        static protected Point TranslateCenterImageMousePosition(PictureBox ptr, Point coordinates)
        {
            //	Test to make sure our image is not null
            if (ptr.Image == null) return coordinates;
            //	First, get the top location (relative to the top left of the control) of the image itself
            // To do this, we know that the image is centered, so we get the difference in size (width and height) of the image to the control
            int diffWidth = ptr.Width - ptr.Image.Width;
            int diffHeight = ptr.Height - ptr.Image.Height;
            //	We now divide in half to accomadate each side of the image
            diffWidth /= 2;
            diffHeight /= 2;
            //	Finally, we subtract this numer from the original coordinates
            // In the case that the image is larger than the picture box, this still works
            coordinates.X -= diffWidth;
            coordinates.Y -= diffHeight;
            return coordinates;
        }

        /// <summary>
        /// Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Normal
        /// </summary>
        /// <param name="coordinates">Point to translate</param>
        /// <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see></returns>
        /// <remarks>
        /// In normal mode, the image is placed in the top left corner, and as such the point does not need to be translated.
        /// The resulting point is the same as the original point
        /// </remarks>
        static protected Point TranslateNormalMousePosition(PictureBox ptr, Point coordinates)
        {
            //	TODO: When we implement scrolling in this, we will need to test for scroll offset
            //	NOTE: As it stands now, this could be made static, but in the future we will be making this handle scaling
            return coordinates;
        }
    }
}

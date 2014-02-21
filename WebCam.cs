﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using WebCam_Capture;
using System.Collections.Generic;
using System.Windows.Forms;
using WebcamEffect;
namespace Webcam
{
    //Design by Pongsakorn Poosankam
    class WebCam
    {
        private WebCamCapture webcam;
        //public bool Stoped{get;private set;}
        private System.Windows.Forms.PictureBox _FrameImage;
        private int FrameNumber = 30;
        public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl)
        {
            webcam = new WebCamCapture();
            webcam.FrameNumber = ((ulong)(0ul));
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(((Form1)Application.OpenForms[0]).webcam_ImageCaptured);
            _FrameImage = ImageControl;

        }


        public void Start()
        {
            //Stoped = false;
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.Start(0); ;
        }

        public void Stop()
        {
            //Stoped = true;
            webcam.Stop();
        }

        public void Continue()
        {
            // change the capture time frame
            webcam.TimeToCapture_milliseconds = FrameNumber;

            // resume the video capture from the stop
            webcam.Start(this.webcam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            webcam.Config();
        }

        public void AdvanceSetting()
        {
            webcam.Config2();
        }

    }
}

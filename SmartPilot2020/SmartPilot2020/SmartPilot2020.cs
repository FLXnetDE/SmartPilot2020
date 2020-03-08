using SmartPilot2020;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using SmartPilot2020.Properties;

namespace SmartPilot2020
{
    public partial class SmartPilot2020 : Form
    {
        public JoystickHandler JoystickHandler;
        public FlightHandler FlightHandler;

        ///////////////////
        // Global config //
        ///////////////////

        public LogForm log;

        public bool Debug = false;
        public int SystemTickInterval = 50;

        public int[] ThrustPulse = new int[2] { 500, 2500 };
        public int[] PitchPulse = new int[2] { 500, 2500 };
        public int[] RollPulse = new int[2] { 500, 2500 };
        public int[] YawPulse = new int[2] { 500, 2500 };

        public SmartPilot2020()
        {
            InitializeComponent();
        }

        private void RCAutopilot_Load(object sender, EventArgs e)
        {
            log = new LogForm();
            log.Show();

            (new Thread(() => {
                JoystickHandler = new JoystickHandler(this);
            })).Start();

            FlightHandler = new FlightHandler(this);
        }

        ////////////////////////////////
        // FlightControlVisualization //
        ////////////////////////////////
        public void UpdateControlVisualization()
        {
            // Graphic based visualtization
            pbPitchRollVisualization.Refresh();
            pbMonitorVisualization.Refresh();

            pbSpeedVisualization.Refresh();
            pbAltitudeVisualization.Refresh();
            pbHeadingVisualization.Refresh();

            pbNavigation.Refresh();

            pbStationaryWindDirection.Refresh();

            // Text based visualization
            SetCurrentPitch(FlightHandler.CurrentPitchAngle);
            SetCurrentRoll(FlightHandler.CurrentRollAngle);
            SetCurrentHeading(FlightHandler.CurrentHeading);
            SetCurrentSpeed(FlightHandler.CurrentSpeed);
            SetCurrentAltitude(FlightHandler.CurrentAltitude);

            SetLatitude(FlightHandler.CurrentLatitude);
            SetLongitude(FlightHandler.CurrentLongitude);

            SetCurrentAircraftTemperature(FlightHandler.CurrentAircraftTemperature);
            SetCurrentAircraftHumidity(FlightHandler.CurrentAircraftHumidity);
            SetCurrentAircraftPressure(FlightHandler.CurrentAircraftPressure);

            SetCurrentStationaryTemperature(FlightHandler.CurrentStationaryTemperature);
            SetCurrentStationaryHumidity(FlightHandler.CurrentStationaryHumidity);
            SetCurrentStationaryPressure(FlightHandler.CurrentStationaryPressure);

            SetCurrentWindInformation(tbAngle.Value, 15);
        }

        private void pbPitchRollVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            /////////////////////////////////////////////////////////////////
            // Virtual horizon & Pitch/Roll current position visualization //
            /////////////////////////////////////////////////////////////////
            g.Clip = new Region(new Rectangle(0, 0, 300, 300));
            g.FillRegion(Brushes.Black, g.Clip);

            Bitmap bezel = Resources.bezel;
            Bitmap horizon = Resources.horizon;
            Bitmap wings = Resources.wings;

            Point ptBoule = new Point(-25, -210); //Ground-Sky initial location
            Point ptRotation = new Point(150, 150); // Point of rotation

            bezel.MakeTransparent(Color.Yellow);
            wings.MakeTransparent(Color.Yellow);
            horizon.MakeTransparent(Color.Yellow);

            double PitchAngleRadian = FlightHandler.CurrentPitchAngle;
            double RollAngleRadian = FlightHandler.CurrentRollAngle * Math.PI / 180;

            RotateAndTranslate(e, horizon, RollAngleRadian, 0, ptBoule, (double)(4 * PitchAngleRadian), ptRotation, 1);

            g.DrawImage(bezel, 0, 0);
            g.DrawImage(wings, 75, 125);

            ////////////////////////////////////////////
            // Pitch/Roll Control input visualization //
            ////////////////////////////////////////////
            int pitchValue = MapValue(FlightHandler.PitchValue, PitchPulse[0], PitchPulse[1], 260, 40) - 4;
            int rollValue = MapValue(FlightHandler.RollValue, RollPulse[0], RollPulse[1], 40, 260) - 4;

            g.DrawRectangle(new Pen(Brushes.Black, 4), new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));
            g.FillRectangle(Brushes.Gold, new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));

            g.DrawString("Pitch: " + FlightHandler.PitchValue + "µs", new Font("Arial", 8), Brushes.White, 210, 280);
            g.DrawString("Roll: " + FlightHandler.RollValue + "µs", new Font("Arial", 8), Brushes.White, 25, 280);
        }

        private void pbSpeedVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbSpeedVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");

            if (!FlightHandler.ControlsActiveChecked)
            {
                return;
            }

        }

        private void pbAltitudeVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbAltitudeVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");

            if (!FlightHandler.ControlsActiveChecked)
            {
                return;
            }

        }

        private void pbHeadingVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbHeadingVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");

            g.DrawLine(new Pen(Brushes.White, 2), 5, 30, 295, 30);
            g.DrawLine(new Pen(Brushes.White, 2), 150, 5, 150, 40);

            g.DrawLine(new Pen(Brushes.White, 2), 100, 15, 100, 40);
            g.DrawLine(new Pen(Brushes.White, 2), 50, 15, 50, 40);
            g.DrawLine(new Pen(Brushes.White, 2), 200, 15, 200, 40);
            g.DrawLine(new Pen(Brushes.White, 2), 250, 15, 250, 40);

            if (!FlightHandler.ControlsActiveChecked)
            {
                return;
            }

            int currentHeading = FlightHandler.CurrentHeading;

            int width = 0;
            if(FlightHandler.CurrentHeading < 10)
            {
                width = 144;
            } else if(currentHeading > 10 && currentHeading < 100)
            {
                width = 140;
            } else
            {
                width = 137;
            }

            g.DrawString(currentHeading.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.White, width, 40);

        }

        private void pbMonitorVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbMonitorVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");

            g.DrawLine(new Pen(Brushes.White, 1), 62.5F, 5, 62.5F, 55);

            if (!FlightHandler.ControlsActiveChecked)
            {
                g.DrawString("Flightcontrols unchecked", new Font("Arial", 12, FontStyle.Bold), Brushes.Red, 110, 20);
                return;
            }

            ///////////////////////////////
            // Thrust mode visualization //
            ///////////////////////////////
            if (FlightHandler.ThrustValue == ThrustPulse[0])
            {
                g.DrawString("IDLE", new Font("Arial", 12, FontStyle.Bold), Brushes.White, 9, 10);
            }
            else if (FlightHandler.ThrustValue == ThrustPulse[1])
            {
                g.DrawString("PWR", new Font("Arial", 12, FontStyle.Bold), Brushes.LimeGreen, 9, 10);
            }

            g.DrawString(FlightHandler.ThrustValue + "µs", new Font("Arial", 8, FontStyle.Bold), Brushes.White, 12, 35);

        }

        private void pbNavigation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbNavigation.BackColor = Color.Black;

            Image plane = Properties.Resources.YellowPlane;

            int a = (pbNavigation.Size.Width / 2) - (plane.Width / 2);
            int b = (pbNavigation.Size.Height / 2) - (plane.Height / 2);
            g.DrawImage(plane, a, b);

            g.DrawString("Latitude: " + FlightHandler.CurrentLatitude, new Font("Arial", 10, FontStyle.Bold), Brushes.Green, 10, 10);
            g.DrawString("Longitude: " + FlightHandler.CurrentLongitude, new Font("Arial", 10, FontStyle.Bold), Brushes.Green, 10, 30);
        }

        private void pbStationaryWindDirection_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int angle = tbAngle.Value;

            Image greenArrow = Properties.Resources.GreenArrow;
            g.DrawImage(RotateImage(greenArrow, angle), 0, 0);
        }

        //////////
        // Test //
        //////////

        private void tbAngle_Scroll(object sender, EventArgs e)
        {
            pbGaugeTest.Refresh();
        }

        private void pbGaugeTest_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = 118;
            int angle = tbAngle.Value;

            double radian = (angle * (Math.PI / 180));

            // Center
            int a = 60;
            int b = 60;

            g.DrawEllipse(new Pen(Brushes.Green, 2), new Rectangle(0, 0, diameter, diameter));
            g.FillEllipse(Brushes.Green, new Rectangle(a - 3, b - 3, 6, 6));

            // Point on circumfence
            int x = (int) (a + ((diameter / 2) * Math.Cos(radian)));
            int y = (int) (b + ((diameter / 2) * Math.Sin(radian)));
            g.DrawLine(new Pen(Brushes.Black, 2), a, b, x, y);

            /*
            int x2 = (int)(a - ((diameter / 2) * Math.Cos(radian)));
            int y2 = (int)(b - ((diameter / 2) * Math.Sin(radian)));
            g.DrawLine(new Pen(Brushes.Black, 2), a, b, x2, y2);
            */

            g.DrawString(angle + "°", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 50, 125);

        }

        //////////////////////
        // Helper functions //
        //////////////////////

        // Display in/out traffic to 2,4GHz module
        public void SetTraffic(String text)
        {
            lblTrafficMonnitor.Text = text;
        }

        // Set info to label at the top
        public void SetJoystickInfo(String info)
        {
            tsTop.Invoke((MethodInvoker)delegate
            {
                lblJoystick.Text = info;
            });
        }

        // Set ComPort state label
        public void SetComPortState(bool connected)
        {
            if(connected)
            {
                lblComPort.ForeColor = Color.LimeGreen;
                lblComPort.Text = "Online";
            } else
            {
                lblComPort.ForeColor = Color.Red;
                lblComPort.Text = "Offline";
            }
        }

        // Set latitude
        public void SetLatitude(double latitude)
        {
            lblLatitude.Invoke((MethodInvoker)delegate
           {
               lblLatitude.Text = "Latitude: " + latitude;
           });
        }

        // Set longitude
        public void SetLongitude(double longitude)
        {
            lblLongitude.Invoke((MethodInvoker)delegate
            {
                lblLongitude.Text = "Longitude: " + longitude;
            });
        }

        // Set current pitch (label text)
        public void SetCurrentPitch(int pitch)
        {
            lblCurrentPitch.Invoke((MethodInvoker)delegate
           {
               lblCurrentPitch.Text = "Pitch: " + pitch + "°";
           });
        }

        // Set current roll (label text)
        public void SetCurrentRoll(int roll)
        {
            lblCurrentRoll.Invoke((MethodInvoker)delegate
            {
                lblCurrentRoll.Text = "Roll: " + roll + "°";
            });
        }

        // Set current heading (label text)
        public void SetCurrentHeading(int heading)
        {
            lblCurrentHeading.Invoke((MethodInvoker)delegate
            {
                lblCurrentHeading.Text = "Heading: " + heading + "°";
            });
        }

        // Set current speed (label text)
        public void SetCurrentSpeed(int speed)
        {
            lblCurrentSpeed.Invoke((MethodInvoker)delegate
            {
                lblCurrentSpeed.Text = "Speed: " + speed + " ?";
            });
        }

        // Set current altitude (label text)
        public void SetCurrentAltitude(int altitude)
        {
            lblCurrentAltitude.Invoke((MethodInvoker)delegate
            {
                lblCurrentAltitude.Text = "Altitude: " + altitude + " ?";
            });
        }

        // Set current aircraft temperature (label text)
        public void SetCurrentAircraftTemperature(double temperature)
        {
            lblAircraftTemperature.Invoke((MethodInvoker)delegate
           {
               lblAircraftTemperature.Text = "Temperature: " + temperature + "°C";
           });
        }

        // Set current aircraft humidity (label text)
        public void SetCurrentAircraftHumidity(double humidity)
        {
            lblAircraftHumidity.Invoke((MethodInvoker)delegate
            {
                lblAircraftHumidity.Text = "Humidity: " + humidity + "%";
            });
        }

        // Set current aircraft pressure (label text)
        public void SetCurrentAircraftPressure(int pressure)
        {
            lblAircraftPressure.Invoke((MethodInvoker)delegate
            {
                lblAircraftPressure.Text = "Pressure: " + pressure + "hPa";
            });
        }

        // Set current stationary temperature (label text)
        public void SetCurrentStationaryTemperature(double temperature)
        {
            lblStationaryTemperature.Invoke((MethodInvoker)delegate
            {
                lblStationaryTemperature.Text = "Temperature: " + temperature + "°C";
            });
        }

        // Set current stationary humidity (label text)
        public void SetCurrentStationaryHumidity(double humidity)
        {
            lblStationaryHumidity.Invoke((MethodInvoker)delegate
            {
                lblStationaryHumidity.Text = "Humidity: " + humidity + "%";
            });
        }

        // Set current stationary pressure (label text)
        public void SetCurrentStationaryPressure(int pressure)
        {
            lblStationaryPressure.Invoke((MethodInvoker)delegate
            {
                lblStationaryPressure.Text = "Pressure: " + pressure + "hPa";
            });
        }

        // Set current wind information (label text)
        public void SetCurrentWindInformation(int angle, int windStrength)
        {
            lblCurrentWindInformation.Invoke((MethodInvoker)delegate
           {
               lblCurrentWindInformation.Text = "5KT / " + angle + "°";
           });
        }

        // Programm beenden
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        // Helper method to map values
        public static int MapValue(float value, float from1, float to1, float from2, float to2)
        {
            return (int)Math.Ceiling((value - from1) / (to1 - from1) * (to2 - from2) + from2);
        }

        // Create connection to ComPort manually
        private void btnConnectComPort_Click(object sender, EventArgs e)
        {
            this.FlightHandler.RemoteDataInterface.Connect();
        }

        // End connection to ComPort manually
        private void btnDisconnectComPort_Click(object sender, EventArgs e)
        {
            this.FlightHandler.RemoteDataInterface.Disconnect();
        }

        // Stop outgoing packets
        private void btnStopOutgoingPackets_Click(object sender, EventArgs e)
        {
            if(this.FlightHandler.RemoteDataInterface.PacketOutputState)
            {
                this.FlightHandler.RemoteDataInterface.PacketOutputState = false;
                SetPacketOutputState(false);
                log.Log("Remote packet output stopped!");
            } else
            {
                this.FlightHandler.RemoteDataInterface.PacketOutputState = true;
                SetPacketOutputState(true);
                log.Log("Remote packet output started!");
            }
        }

        public void SetPacketOutputState(bool active)
        {
            if(active)
            {
                lblPacketOutput.ForeColor = Color.LimeGreen;
                lblPacketOutput.Text = "Active";
            } else
            {
                lblPacketOutput.ForeColor = Color.Red;
                lblPacketOutput.Text = "Stopped";
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        protected void RotateAndTranslate(PaintEventArgs pe, Image img, Double alphaRot, Double alphaTrs, Point ptImg, double deltaPx, Point ptRot, float scaleFactor)
        {
            double beta = 0;
            double d = 0;
            float deltaXRot = 0;
            float deltaYRot = 0;
            float deltaXTrs = 0;
            float deltaYTrs = 0;

            // Rotation

            if (ptImg != ptRot)
            {
                // Internals coeffs
                if (ptRot.X != 0)
                {
                    beta = Math.Atan((double)ptRot.Y / (double)ptRot.X);
                }

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y));

                // Computed offset
                deltaXRot = (float)(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta)));
                deltaYRot = (float)(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)));
            }

            // Translation

            // Computed offset
            deltaXTrs = (float)(deltaPx * (Math.Sin(alphaTrs)));
            deltaYTrs = (float)(-deltaPx * (-Math.Cos(alphaTrs)));

            // Rotate image support
            pe.Graphics.RotateTransform((float)(alphaRot * 180 / Math.PI));

            // Dispay image
            pe.Graphics.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs) * scaleFactor, (ptImg.Y + deltaYRot + deltaYTrs) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor);

            // Put image support as found
            pe.Graphics.RotateTransform((float)(-alphaRot * 180 / Math.PI));
        }

    }
}

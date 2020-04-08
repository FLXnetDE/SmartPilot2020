﻿using System;
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

        public SmartPilot2020()
        {
            InitializeComponent();

            pbSpeedWheel.MouseHover += PbSpeedWheel_MouseHover;
            pbSpeedWheel.MouseWheel += PbSpeedWheel_MouseWheel;
            pbHeadingWheel.MouseHover += PbHeadingWheel_MouseHover;
            pbHeadingWheel.MouseWheel += PbHeadingWheel_MouseWheel;
            pbAltitudeWheel.MouseHover += PbAltitudeWheel_MouseHover;
            pbAltitudeWheel.MouseWheel += PbAltitudeWheel_MouseWheel;

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
            pbFlightEnvelopeToggle.Refresh();
            pbAutoPilotToggle.Refresh();
            pbAutoThrustToggle.Refresh();
            pbHeadingWheel.Refresh();

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

            SetRadioSignalInformation(FlightHandler.UsedRadioChannel);
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

            DrawingHelper.RotateAndTranslate(e, horizon, RollAngleRadian, 0, ptBoule, (double)(4 * PitchAngleRadian), ptRotation, 1);

            g.DrawImage(bezel, 0, 0);
            g.DrawImage(wings, 75, 125);

            ////////////////////////////////////////////
            // Pitch/Roll Control input visualization //
            ////////////////////////////////////////////
            int pitchValue = Util.MapValue(FlightHandler.PitchValue, FlightHandler.PitchPulse[0], FlightHandler.PitchPulse[1], 260, 40) - 4;
            int rollValue = Util.MapValue(FlightHandler.RollValue, FlightHandler.RollPulse[0], FlightHandler.RollPulse[1], 40, 260) - 4;

            g.DrawRectangle(new Pen(Brushes.Black, 4), new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));

            Brush b = FlightHandler.AutoPilotActive ? Brushes.LimeGreen : Brushes.Gold;
            g.FillRectangle(b, new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));

            g.DrawString("Pitch: " + FlightHandler.PitchValue + "µs", new Font("Arial", 8), Brushes.White, 210, 280);
            g.DrawString("Roll: " + FlightHandler.RollValue + "µs", new Font("Arial", 8), Brushes.White, 25, 280);

            ////////////////////////////////////
            /// FlightEnvelope visualization ///
            ////////////////////////////////////
            
            if(FlightHandler.ProtectionActive)
            {
                // Upper left
                g.DrawLine(new Pen(Brushes.White, 2), 40, 40, 60, 40);
                g.DrawLine(new Pen(Brushes.White, 2), 40, 40, 40, 60);

                // Upper right
                g.DrawLine(new Pen(Brushes.White, 2), 240, 40, 260, 40);
                g.DrawLine(new Pen(Brushes.White, 2), 260, 40, 260, 60);

                // Lower left
                g.DrawLine(new Pen(Brushes.White, 2), 40, 260, 40, 240);
                g.DrawLine(new Pen(Brushes.White, 2), 40, 260, 60, 260);

                // Lower right
                g.DrawLine(new Pen(Brushes.White, 2), 240, 260, 260, 260);
                g.DrawLine(new Pen(Brushes.White, 2), 260, 260, 260, 240);
            }

        }

        private void pbMonitorVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbMonitorVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");
            GraphicUtil.DrawMonitor(g, this);
        }

        private void pbSpeedVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbSpeedVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");
            GraphicUtil.DrawSpeed(g, this);
        }

        private void pbHeadingVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbHeadingVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");
            GraphicUtil.DrawHeading(g, this);
        }

        private void pbNavigation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbNavigation.BackColor = Color.Black;
            GraphicUtil.DrawNavigation(g, pbNavigation, this);
        }

        private void pbAltitudeVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            pbAltitudeVisualization.BackColor = ColorTranslator.FromHtml("#2B2B2B");

            if (!FlightHandler.ControlsActiveChecked)
            {
                g.DrawString("X", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, 10, 135);
                return;
            }

        }

        private void pbStationaryWindDirection_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int angle = tbAngle.Value;

            Image greenArrow = Properties.Resources.GreenArrow;
            g.DrawImage(DrawingHelper.RotateImage(greenArrow, angle), 0, 0);
        }

        ////////////////////
        // FlightEnvelope //
        ////////////////////
        private void pbFlightEnvelopeToggle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillRectangle(Brushes.DarkGray, new Rectangle(1, 1, 47, 47));
            g.DrawString("FE", new Font("Arial", 10, FontStyle.Bold), Brushes.White, 15, 28);

            if (FlightHandler.ProtectionActive)
            {
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 20, 40, 20);
            }
            else
            {
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 20, 40, 20);
            }

        }

        private void pbFlightEnvelopeToggle_MouseClick(object sender, MouseEventArgs e)
        {
            if (!FlightHandler.ControlsActiveChecked)
            {
                log.Log("FlightControls are not yet checked!");
                return;
            }

            if (FlightHandler.ProtectionActive)
            {
                FlightHandler.ProtectionActive = false;
                log.Log("FlightEnvelope has been disabled!");
            }
            else
            {
                FlightHandler.ProtectionActive = true;
                log.Log("FlightEnvelope has been enabled!");
            }

            pbFlightEnvelopeToggle.Refresh();
        }

        ///////////////
        // AutoPilot //
        ///////////////
        private void pbAutoPilotToggle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillRectangle(Brushes.DarkGray, new Rectangle(1, 1, 47, 47));
            g.DrawString("AP", new Font("Arial", 10, FontStyle.Bold), Brushes.White, 15, 28);

            if (FlightHandler.AutoPilotActive)
            {
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 20, 40, 20);
            }
            else
            {
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 20, 40, 20);
            }
        }

        private void pbAutoPilotToggle_Click(object sender, EventArgs e)
        {
            if (!FlightHandler.ControlsActiveChecked)
            {
                log.Log("FlightControls are not yet checked!");
                return;
            }

            if (FlightHandler.AutoPilotActive)
            {
                FlightHandler.AutoPilotActive = false;
                log.Log("AutoPilot has been disabled!");
            }
            else
            {
                FlightHandler.AutoPilotActive = true;

                if(FlightHandler.ProtectionActive)
                {
                    log.Log("AutoPilot has been enabled!");
                } else
                {
                    FlightHandler.ProtectionActive = true;
                    log.Log("AutoPilot and FlightEnvelope has been enabled!");
                }
            }

            pbAutoPilotToggle.Refresh();
        }

        ////////////////
        // AutoThrust //
        ////////////////
        private void pbAutoThrustToggle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillRectangle(Brushes.DarkGray, new Rectangle(1, 1, 47, 47));
            g.DrawString("A/THR", new Font("Arial", 10, FontStyle.Bold), Brushes.White, 3, 28);

            if (FlightHandler.AutoThrustActive == true)
            {
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.LimeGreen, 3), 10, 20, 40, 20);
            }
            else
            {
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 10, 40, 10);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 15, 40, 15);
                g.DrawLine(new Pen(Brushes.Gray, 3), 10, 20, 40, 20);
            }
        }

        private void pbAutoThrustToggle_Click(object sender, EventArgs e)
        {
            if(!FlightHandler.ControlsActiveChecked)
            {
                log.Log("FlightControls are not yet checked!");
                return;
            }

            if (FlightHandler.AutoThrustActive)
            {
                FlightHandler.AutoThrustActive = false;
                log.Log("AutoThrust has been disabled!");
            }
            else
            {
                FlightHandler.AutoThrustActive = true;
                log.Log("AutoThrust has been enabled!");
            }

            pbAutoThrustToggle.Refresh();
        }

        /////////////////
        // SpeedButton //
        /////////////////
        private void PbSpeedWheel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 120)
            {
                FlightHandler.TargetSpeed++;
            }
            else if (e.Delta == -120)
            {
                if (FlightHandler.TargetSpeed != 0) FlightHandler.TargetSpeed--;
            }
        }

        private void PbSpeedWheel_MouseHover(object sender, EventArgs e)
        {
            pbSpeedWheel.Focus();
        }

        private void pbSpeedWheel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.DrawImage(Resources.SpeedButton, 0, 0);
        }

        ////////////////////
        // AltitudeButton //
        ////////////////////
        private void PbAltitudeWheel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 120)
            {
                FlightHandler.TargetAltitude++;
            }
            else if (e.Delta == -120)
            {
                if (FlightHandler.TargetAltitude != 0) FlightHandler.TargetAltitude--;
            }
        }

        private void PbAltitudeWheel_MouseHover(object sender, EventArgs e)
        {
            pbAltitudeWheel.Focus();
        }

        private void pbAltitudeWheel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.DrawImage(Resources.AltitudeButton, 0, 0);
        }

        ///////////////////
        // HeadingButton //
        ///////////////////
        private void PbHeadingWheel_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta == 120)
            {
                if(FlightHandler.TargetHeading == 350)
                {
                    FlightHandler.TargetHeading = 0;
                } else
                {
                    FlightHandler.TargetHeading += 10;
                }
            } else if(e.Delta == -120)
            {
                if (FlightHandler.TargetHeading == 0)
                {
                    FlightHandler.TargetHeading = 350;
                } else
                {
                    FlightHandler.TargetHeading -= 10;
                }  
            }
        }

        private void PbHeadingWheel_MouseHover(object sender, EventArgs e)
        {
            pbHeadingWheel.Focus();
        }

        private void pbHeadingWheel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Image HeadingButton = DrawingHelper.RotateImage(Resources.HeadingButton, FlightHandler.TargetHeading);

            g.DrawImage(HeadingButton, 0, 0);
        }

        //////////////////////
        // Helper functions //
        //////////////////////

        // Display in/out traffic to 2,4GHz module
        public void SetTraffic(String text)
        {
            lblTrafficMonnitor.Text = text;
        }

        // Set values regarding radio signal information (from Station device)
        public void SetRadioSignalInformation(int channel)
        {
            if(channel == 0)
            {
                lblCarrierTest.ForeColor = Color.DarkRed;
                lblCarrierTest.Text = "Station device not connected";
                return;
            }

            lblCarrierTest.ForeColor = Color.SteelBlue;
            lblCarrierTest.Text = "RF24 is using channel " + channel;
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
                lblCurrentSpeed.Text = "Speed: " + speed + " m/s";
            });
        }

        // Set current altitude (label text)
        public void SetCurrentAltitude(int altitude)
        {
            lblCurrentAltitude.Invoke((MethodInvoker)delegate
            {
                lblCurrentAltitude.Text = "Altitude: " + altitude + " m";
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
        public void SetCurrentAircraftPressure(double pressure)
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
            int x = (int)(a + ((diameter / 2) * Math.Cos(radian)));
            int y = (int)(b + ((diameter / 2) * Math.Sin(radian)));
            g.DrawLine(new Pen(Brushes.Black, 2), a, b, x, y);

            g.DrawString(angle + "°", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 50, 125);

        }

        private void btnAircraftMode_Click(object sender, EventArgs e)
        {
            int mode;

            if(FlightHandler.AircraftMode == 0)
            {
                mode = 1;
            } else
            {
                mode = 0;
            }

            FlightHandler.AircraftMode = mode;
            log.Log("AircraftMode has been manually set to " + mode);

        }

        private void btnAltitudeReference_Click(object sender, EventArgs e)
        {
            FlightHandler.RemoteDataInterface.SendAltitudeReferencePacket((int) nudBaroRef.Value);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                FlightHandler.CurrentHeading = Int32.Parse(txtbTest.Text);
                log.Log("Test value: " + txtbTest.Text);
            } catch(Exception)
            {
                log.Log("Malformed numeric value");
            }

        }

    }
}

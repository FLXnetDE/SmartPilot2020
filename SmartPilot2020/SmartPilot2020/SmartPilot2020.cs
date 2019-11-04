using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCAutopilot
{
    public partial class SmartPilot2020 : Form
    {
        public JoystickHandler JoystickHandler;
        public FlightHandler FlightHandler;

        ///////////////////
        // Global config //
        ///////////////////

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
            pbPitchRollVisualization.Refresh();
            pbThrustVisualization.Refresh();
            pbMonitorVisualization.Refresh();

            pbSpeedVisualization.Refresh();
            pbAltitudeVisualization.Refresh();
            pbHeadingVisualization.Refresh();
        }

        private void pbPitchRollVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            ///////////////////////////////////
            // Virtual horizon visualization //
            ///////////////////////////////////
            g.FillRectangle(Brushes.SkyBlue, new Rectangle(0, 0, 300, 150));
            g.FillRectangle(Brushes.SandyBrown, new Rectangle(0, 150, 300, 300));
            g.DrawLine(new Pen(Brushes.White, 2), 0, 150, 300, 150);

            // Pitch degree helper lines
            DrawPitchDegreeHelperLines(g);

            if (!FlightHandler.ControlsActiveChecked)
            {
                return;
            }

            ///////////////////////////////////////////////
            // Pitch/Roll current position visualization //
            ///////////////////////////////////////////////
            int currentPitchAngle = FlightHandler.CurrentPitchAngle;
            int pitchPosition = MapValue(currentPitchAngle, -60, 60, 275, 25);

            g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(150 - 5, pitchPosition - 5), new Size(10, 10)));
            g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(40 - 3, pitchPosition - 3), new Size(80, 6)));
            g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(185 - 3, pitchPosition - 3), new Size(80, 6)));

            ////////////////////////////////////////////
            // Pitch/Roll Control input visualization //
            ////////////////////////////////////////////
            int pitchValue = MapValue(FlightHandler.PitchValue, PitchPulse[0], PitchPulse[1], 275, 25) - 4;
            int rollValue = MapValue(FlightHandler.RollValue, RollPulse[0], RollPulse[1], 25, 275) - 4;

            g.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));
            g.FillRectangle(Brushes.LimeGreen, new Rectangle(new Point(rollValue, pitchValue), new Size(8, 8)));

            g.DrawString(FlightHandler.PitchValue + "µs", new Font("Arial", 8), Brushes.Black, 135, 280);
            g.DrawString(FlightHandler.RollValue + "µs", new Font("Arial", 8), Brushes.Black, 1, 155);

        }

        private void pbSpeedVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pbSpeedVisualization.BackColor = Color.Gray;

            // Border helper lines
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 0), new Point(60, 0));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(60, 0), new Point(60, 300));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 300), new Point(60, 300));
        }

        private void pbAltitudeVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pbAltitudeVisualization.BackColor = Color.Gray;

            // Border helper lines
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 0), new Point(60, 0));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(60, 0), new Point(60, 300));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 300), new Point(60, 300));

        }

        private void pbHeadingVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pbHeadingVisualization.BackColor = Color.Gray;

            // Border helper lines
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 60), new Point(0, 0));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(0, 0), new Point(300, 0));
            g.DrawLine(new Pen(Brushes.White, 6), new Point(300, 0), new Point(300, 60));

        }

        private void pbMonitorVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

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
                g.DrawString("IDLE", new Font("Arial", 12, FontStyle.Bold), Brushes.LightBlue, 5, 20);
            }
            else if (FlightHandler.ThrustValue == ThrustPulse[1])
            {
                g.DrawString("PWR", new Font("Arial", 12, FontStyle.Bold), Brushes.LimeGreen, 5, 20);
            }

        }

        private void pbThrustVisualization_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawArc(new Pen(new SolidBrush(Color.Black), 2), new Rectangle(0, 20, 150, 150), 180, 180);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), new Rectangle(75, 65, 2, 2));

            ////////////////////////////////////////
            // Thrust Control input visualization //
            ////////////////////////////////////////

            g.DrawRectangle(new Pen(Brushes.White, 2), new Rectangle(70, 75, 60, 20));
            g.DrawString(FlightHandler.ThrustValue + "µs", new Font("Arial", 10, FontStyle.Bold), Brushes.LimeGreen, 78, 77);

            g.DrawLine(new Pen(Brushes.LimeGreen, 2), 76, 65, 76, 12);

        }

        /////////////////////////////
        // Drawing helper function //
        /////////////////////////////
        public void DrawPitchDegreeHelperLines(Graphics g)
        {
            int degreeLine10Up = MapValue(10, 0, 60, 150, 25);
            int degreeLine20Up = MapValue(20, 0, 60, 150, 25);
            int degreeLine30Up = MapValue(30, 0, 60, 150, 25);
            int degreeLine40Up = MapValue(40, 0, 60, 150, 25);
            int degreeLine50Up = MapValue(50, 0, 60, 150, 25);
            int degreeLine60Up = MapValue(60, 0, 60, 150, 25);

            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine10Up, 160, degreeLine10Up);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine20Up, 180, degreeLine20Up);
            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine30Up, 160, degreeLine30Up);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine40Up, 180, degreeLine40Up);
            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine50Up, 160, degreeLine50Up);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine60Up, 180, degreeLine60Up);

            g.DrawString("20", new Font("Arial", 8), Brushes.White, 100, degreeLine20Up - 7);
            g.DrawString("20", new Font("Arial", 8), Brushes.White, 183, degreeLine20Up - 7);
            g.DrawString("40", new Font("Arial", 8), Brushes.White, 100, degreeLine40Up - 7);
            g.DrawString("40", new Font("Arial", 8), Brushes.White, 183, degreeLine40Up - 7);
            g.DrawString("60", new Font("Arial", 8), Brushes.White, 100, degreeLine60Up - 7);
            g.DrawString("60", new Font("Arial", 8), Brushes.White, 183, degreeLine60Up - 7);

            int degreeLine10Down = MapValue(10, 0, 60, 150, 275);
            int degreeLine20Down = MapValue(20, 0, 60, 150, 275);
            int degreeLine30Down = MapValue(30, 0, 60, 150, 275);
            int degreeLine40Down = MapValue(40, 0, 60, 150, 275);
            int degreeLine50Down = MapValue(50, 0, 60, 150, 275);
            int degreeLine60Down = MapValue(60, 0, 60, 150, 275);
            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine10Down, 160, degreeLine10Down);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine20Down, 180, degreeLine20Down);
            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine30Down, 160, degreeLine30Down);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine40Down, 180, degreeLine40Down);
            g.DrawLine(new Pen(Brushes.White, 2), 140, degreeLine50Down, 160, degreeLine50Down);
            g.DrawLine(new Pen(Brushes.White, 2), 120, degreeLine60Down, 180, degreeLine60Down);

            g.DrawString("20", new Font("Arial", 8), Brushes.White, 100, degreeLine20Down - 7);
            g.DrawString("20", new Font("Arial", 8), Brushes.White, 183, degreeLine20Down - 7);
            g.DrawString("40", new Font("Arial", 8), Brushes.White, 100, degreeLine40Down - 7);
            g.DrawString("40", new Font("Arial", 8), Brushes.White, 183, degreeLine40Down - 7);
            g.DrawString("60", new Font("Arial", 8), Brushes.White, 100, degreeLine60Down - 7);
            g.DrawString("60", new Font("Arial", 8), Brushes.White, 183, degreeLine60Down - 7);
        }

        //////////////////////
        // Helper functions //
        //////////////////////

        // Add message to CheckedListBox
        public void Log(String text)
        {
            clbLog.Invoke((MethodInvoker)delegate
           {
               clbLog.Items.Add("[" + DateTime.Now + "] " + text);
           });
        }

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

        // Clear log
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            clbLog.Items.Clear();
        }

        // Create connection to ComPort manually
        private void btnConnectComPort_Click(object sender, EventArgs e)
        {
            this.FlightHandler.RemoteDataOutputInterface.Connect();
        }

        // End connection to ComPort manually
        private void btnDisconnectComPort_Click(object sender, EventArgs e)
        {
            this.FlightHandler.RemoteDataOutputInterface.Disconnect();
        }

        // Stop outgoing packets
        private void btnStopOutgoingPackets_Click(object sender, EventArgs e)
        {
            if(this.FlightHandler.RemoteDataOutputInterface.PacketOutputState)
            {
                this.FlightHandler.RemoteDataOutputInterface.PacketOutputState = false;
                SetPacketOutputState(false);
                Log("Remote packet output stopped!");
            } else
            {
                this.FlightHandler.RemoteDataOutputInterface.PacketOutputState = true;
                SetPacketOutputState(true);
                Log("Remote packet output started!");
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

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPilot2020
{
    public class GraphicUtil
    {

        // Method to draw the selection display above the AutoPilot buttons
        public static void DrawSelectorDispaly(Graphics g, SmartPilot2020 main)
        {
            g.DrawString("SPD", new Font("Arial", 6), Brushes.Orange, 10, 5);
            g.DrawString(main.FlightHandler.TargetSpeed.ToString(), new Font("DS-Digital", 24), Brushes.Orange, 5, 15);

            g.DrawString("HDG", new Font("Arial", 6), Brushes.Orange, 120, 5);
            if(main.FlightHandler.TargetHeading < 100 && main.FlightHandler.TargetHeading != 0)
            {
                g.DrawString("0" + main.FlightHandler.TargetHeading, new Font("DS-Digital", 24), Brushes.Orange, 115, 15);
            } else if(main.FlightHandler.TargetHeading == 0)
            {
                g.DrawString("000", new Font("DS-Digital", 24), Brushes.Orange, 115, 15);
            } else
            {
                g.DrawString(main.FlightHandler.TargetHeading.ToString(), new Font("DS-Digital", 24), Brushes.Orange, 115, 15);
            }

            g.DrawString("ALT", new Font("Arial", 6), Brushes.Orange, 220, 5);
            g.DrawString(main.FlightHandler.TargetAltitude.ToString(), new Font("DS-Digital", 24), Brushes.Orange, 220, 15);

        }

        // Method to draw the heading band below the PFD
        public static void DrawHeading(Graphics g, SmartPilot2020 main)
        {
            if (!main.FlightHandler.ControlsActiveChecked)
            {
                g.DrawString("X", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, 135, 15);
                return;
            }

            g.DrawLine(new Pen(Brushes.White, 2), 0, 20, 300, 20);
            g.DrawLine(new Pen(Brushes.Gold, 5), 150, 0, 150, 20);

            g.DrawLine(new Pen(Brushes.White, 2), 50, 20, 50, 30);
            g.DrawLine(new Pen(Brushes.White, 2), 100, 20, 100, 30);
            g.DrawLine(new Pen(Brushes.White, 2), 150, 20, 150, 40);
            g.DrawLine(new Pen(Brushes.White, 2), 200, 20, 200, 30);
            g.DrawLine(new Pen(Brushes.White, 2), 250, 20, 250, 30);

            int currentHeading = main.FlightHandler.CurrentHeading;

            int width = 0;
            if (main.FlightHandler.CurrentHeading < 10)
            {
                width = 145;
            }
            else if (currentHeading >= 10 && currentHeading < 100)
            {
                width = 140;
            }
            else
            {
                width = 137;
            }

            g.DrawString(currentHeading.ToString(), Util.AirbusFont10(), Brushes.White, width, 42);
        }

        // Method to draw the speed display band on the left side of the PFD
        public static void DrawSpeed(Graphics g, SmartPilot2020 main)
        {
            g.DrawLine(new Pen(Brushes.White, 2), 40, 0, 40, 300);

            if (!main.FlightHandler.ControlsActiveChecked)
            {
                g.DrawString("X", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, 10, 135);
                return;
            }

            g.FillRectangle(Brushes.Gold, new Rectangle(0, 147, 6, 6));
            g.DrawLine(new Pen(Brushes.Gold, 2), 0, 150, 60, 150);
            g.DrawLine(new Pen(Brushes.Gold, 6), 40, 150, 60, 150);

            int CurrentSpeed = main.FlightHandler.CurrentSpeed;

            if (CurrentSpeed == 0)
            {
                g.DrawLine(new Pen(Brushes.White, 2), 30, 30, 40, 30);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 60, 40, 60);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 90, 40, 90);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 120, 40, 120);

                g.DrawString("4", Util.AirbusFont10(), Brushes.White, 7, 22);
                g.DrawString("3", Util.AirbusFont10(), Brushes.White, 7, 52);
                g.DrawString("2", Util.AirbusFont10(), Brushes.White, 7, 82);
                g.DrawString("1", Util.AirbusFont10(), Brushes.White, 7, 112);
            }
            else
            {
                g.DrawLine(new Pen(Brushes.White, 2), 30, 30, 40, 30);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 60, 40, 60);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 90, 40, 90);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 120, 40, 120);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 150, 40, 150); // mid
                g.DrawLine(new Pen(Brushes.White, 2), 30, 180, 40, 180);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 210, 40, 210);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 240, 40, 240);
                g.DrawLine(new Pen(Brushes.White, 2), 30, 270, 40, 270);

                g.DrawString((CurrentSpeed + 1).ToString(), Util.AirbusFont10(), Brushes.White, 7, 112);
                g.DrawString((CurrentSpeed + 2).ToString(), Util.AirbusFont10(), Brushes.White, 7, 82);
                g.DrawString((CurrentSpeed + 3).ToString(), Util.AirbusFont10(), Brushes.White, 7, 52);
                g.DrawString((CurrentSpeed + 4).ToString(), Util.AirbusFont10(), Brushes.White, 7, 22);
                g.DrawString(CurrentSpeed.ToString(), Util.AirbusFont10(), Brushes.White, 7, 142);
                g.DrawString((CurrentSpeed - 1) > 0 ? (CurrentSpeed - 1).ToString() : "", Util.AirbusFont10(), Brushes.White, 7, 172);
                g.DrawString((CurrentSpeed - 2) > 0 ? (CurrentSpeed - 2).ToString() : "", Util.AirbusFont10(), Brushes.White, 7, 202);
                g.DrawString((CurrentSpeed - 3) > 0 ? (CurrentSpeed - 3).ToString() : "", Util.AirbusFont10(), Brushes.White, 7, 232);
                g.DrawString((CurrentSpeed - 4) > 0 ? (CurrentSpeed - 4).ToString() : "", Util.AirbusFont10(), Brushes.White, 7, 262);

            }

            if (main.FlightHandler.AutoThrustActive)
            {
                if ((CurrentSpeed + 4) >= main.FlightHandler.TargetSpeed && (CurrentSpeed - 4) <= main.FlightHandler.TargetSpeed)
                {
                    if (CurrentSpeed == main.FlightHandler.TargetSpeed)
                    {
                        g.DrawLine(new Pen(Brushes.Cyan, 2), 40, 150, 55, 135);
                        g.DrawLine(new Pen(Brushes.Cyan, 2), 55, 135, 55, 165);
                        g.DrawLine(new Pen(Brushes.Cyan, 2), 55, 165, 40, 150);
                        return;
                    }

                    int dif = main.FlightHandler.TargetSpeed - CurrentSpeed;

                    g.DrawLine(new Pen(Brushes.Cyan, 2), 40, 150 - (dif * 30), 55, 135 - (dif * 30));
                    g.DrawLine(new Pen(Brushes.Cyan, 2), 55, 135 - (dif * 30), 55, 165 - (dif * 30));
                    g.DrawLine(new Pen(Brushes.Cyan, 2), 55, 165 - (dif * 30), 40, 150 - (dif * 30));
                }
            }
        }

        // Method to draw the navigation display
        public static void DrawNavigation(Graphics g, PictureBox pictureBox, SmartPilot2020 main)
        {
            Image plane = Properties.Resources.YellowPlane;

            int a = (pictureBox.Size.Width / 2) - (plane.Width / 2);
            int b = (pictureBox.Size.Height / 2) - (plane.Height / 2);
            g.DrawImage(plane, a, b);

            // Speed visualization
            g.DrawString("IAS", Util.AirbusFont10(), Brushes.White, 5, 5);
            g.DrawString(main.FlightHandler.CurrentSpeed + "m/s", Util.AirbusFont10(), Brushes.LimeGreen, 30, 5);

            // AircratfMode visualization
            g.DrawRectangle(Pens.White, new Rectangle(5, 30, 55, 25));
            g.DrawString("Mode: " + main.FlightHandler.AircraftMode, new Font("Arial", 8), Brushes.LimeGreen, 10, 36);

            // Latitude / Longitude visualization
            g.DrawString("LAT: ", new Font("Arial", 8), Brushes.White, 160, 10);
            g.DrawString(main.FlightHandler.CurrentLatitude.ToString(), new Font("Arial", 8), Brushes.LimeGreen, 190, 10);
            g.DrawString("LON: ", new Font("Arial", 8), Brushes.White, 160, 25);
            g.DrawString(main.FlightHandler.CurrentLongitude.ToString(), new Font("Arial", 8), Brushes.LimeGreen, 190, 25);

            // Protection visualization
            if (main.FlightHandler.ProtectionActive)
            {
                g.DrawRectangle(Pens.White, new Rectangle(335, 5, 90, 70));
                g.DrawString("Pitch: " + main.FlightHandler.ProtectedPitchDownAngle + "/" + main.FlightHandler.ProtectedPitchUpAngle + "°", new Font("Arial", 8), Brushes.LimeGreen, 340, 10);
                g.DrawString("Roll: " + main.FlightHandler.ProtectedRollAngle + "°", new Font("Arial", 8), Brushes.LimeGreen, 340, 25);
                g.DrawString("Speed: " + main.FlightHandler.ProtectedStallSpeed + "/" + main.FlightHandler.ProtectedOverSpeed + "m/s", new Font("Arial", 8), Brushes.LimeGreen, 340, 40);
                g.DrawString("Altitude: " + main.FlightHandler.ProtectedAltitude + "m", new Font("Arial", 8), Brushes.LimeGreen, 340, 55);
            }
        }

        // Method to draw the monitor band above the PFD
        public static void DrawMonitor(Graphics g, SmartPilot2020 main)
        {
            if (!main.FlightHandler.ControlsActiveChecked)
            {
                g.DrawString("Flightcontrols unchecked", new Font("Arial", 12, FontStyle.Bold), Brushes.Red, 110, 20);
                return;
            }

            g.DrawLine(new Pen(Brushes.White, 1), 62.5F, 5, 62.5F, 55);

            ///////////////////////////////
            // Thrust mode visualization //
            ///////////////////////////////

            if (main.FlightHandler.AutoThrustActive)
            {
                g.DrawString("A/THR", new Font("Arial", 12, FontStyle.Bold), Brushes.LimeGreen, 3, 10);
            }
            else
            {
                if (main.FlightHandler.ThrustValue == main.FlightHandler.ThrustPulse[0])
                {
                    g.DrawString("IDLE", new Font("Arial", 12, FontStyle.Bold), Brushes.White, 9, 10);
                }
                else if (main.FlightHandler.ThrustValue == main.FlightHandler.ThrustPulse[1])
                {
                    g.DrawString("PWR", new Font("Arial", 12, FontStyle.Bold), Brushes.LimeGreen, 10, 10);
                }
                else
                {
                    g.DrawString("M/THR", new Font("Arial", 12, FontStyle.Bold), Brushes.Orange, 3, 10);
                }
            }

            /////////////////////////////////
            /// Mode-Values visualization ///
            /////////////////////////////////

            if (main.FlightHandler.AutoThrustActive)
            {
                g.DrawString("SPD", new Font("Arial", 8, FontStyle.Bold), Brushes.Orange, 80, 12);
                g.DrawString(main.FlightHandler.TargetSpeed + "m/s", new Font("Arial", 12, FontStyle.Bold), Brushes.Cyan, 75, 25);
            }

            if (main.FlightHandler.AutoPilotActive)
            {
                g.DrawString("HDG", new Font("Arial", 8, FontStyle.Bold), Brushes.Orange, 145, 12);
                g.DrawString(main.FlightHandler.TargetHeading + "°", new Font("Arial", 12, FontStyle.Bold), Brushes.Cyan, 140, 25);

                g.DrawString("ALT", new Font("Arial", 8, FontStyle.Bold), Brushes.Orange, 200, 12);
                g.DrawString(main.FlightHandler.TargetAltitude + "m", new Font("Arial", 12, FontStyle.Bold), Brushes.Cyan, 195, 25);
            }

            g.DrawLine(new Pen(Brushes.White, 1), 250, 5, 250, 55);

            //////////////////////////
            /// Mode visualization ///
            //////////////////////////

            g.DrawLine(new Pen(Brushes.White, 1), 370, 5, 370, 55);

            if (main.FlightHandler.AutoPilotActive)
            {
                g.DrawString("AP", new Font("Arial", 10, FontStyle.Bold), Brushes.LimeGreen, 392, 5);
            }
            else
            {
                g.DrawString("AP", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, 392, 5);
            }

            if (main.FlightHandler.ProtectionActive)
            {
                g.DrawString("FE", new Font("Arial", 10, FontStyle.Bold), Brushes.LimeGreen, 392, 23);
            }
            else
            {
                g.DrawString("FE", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, 392, 23);
            }

            if (main.FlightHandler.AutoThrustActive)
            {
                g.DrawString("A/THR", new Font("Arial", 10, FontStyle.Bold), Brushes.LimeGreen, 380, 40);
            }
            else
            {
                g.DrawString("A/THR", new Font("Arial", 10, FontStyle.Bold), Brushes.Red, 380, 40);
            }
        }

    }
}

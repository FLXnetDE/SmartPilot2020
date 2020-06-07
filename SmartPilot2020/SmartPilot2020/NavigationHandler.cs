using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPilot2020
{
    public class NavigationHandler
    {
        private SmartPilot2020 main;

        public NavigationHandler(SmartPilot2020 main)
        {
            this.main = main;
            main.MonitoringHandler.AddMessageTimed("NavigationHandler has been loaded.", Color.LimeGreen, 4000);
        }

        public void DrawNavigationDisplay(Graphics g)
        {
            // Speed visualization
            g.DrawString("IAS", Util.AirbusFont10(), Brushes.White, 5, 5);
            g.DrawString(main.FlightHandler.CurrentSpeed + "m/s", Util.AirbusFont10(), Brushes.LimeGreen, 30, 5);

            // AircratfMode visualization
            g.DrawRectangle(Pens.White, new Rectangle(5, 30, 55, 25));
            g.DrawString("Mode: " + main.FlightHandler.AircraftMode, new Font("Arial", 8), Brushes.LimeGreen, 10, 36);

            // Latitude / Longitude visualization
            g.DrawString("LAT: ", new Font("Arial", 8), Brushes.White, 160, 10);
            g.DrawString(main.FlightHandler.CurrentGpsData.Latitude.ToString(), new Font("Arial", 8), Brushes.LimeGreen, 190, 10);
            g.DrawString("LON: ", new Font("Arial", 8), Brushes.White, 160, 25);
            g.DrawString(main.FlightHandler.CurrentGpsData.Longitude.ToString(), new Font("Arial", 8), Brushes.LimeGreen, 190, 25);

            // Protection visualization
            if (main.FlightHandler.ProtectionActive)
            {
                g.DrawRectangle(Pens.White, new Rectangle(335, 5, 90, 70));
                g.DrawString("Pitch: " + main.FlightHandler.ProtectedPitchDownAngle + "/" + main.FlightHandler.ProtectedPitchUpAngle + "°", new Font("Arial", 8), Brushes.LimeGreen, 340, 10);
                g.DrawString("Roll: " + main.FlightHandler.ProtectedRollAngle + "°", new Font("Arial", 8), Brushes.LimeGreen, 340, 25);
                g.DrawString("Speed: " + main.FlightHandler.ProtectedStallSpeed + "/" + main.FlightHandler.ProtectedOverSpeed + "m/s", new Font("Arial", 8), Brushes.LimeGreen, 340, 40);
                g.DrawString("Altitude: " + main.FlightHandler.ProtectedAltitude + "m", new Font("Arial", 8), Brushes.LimeGreen, 340, 55);
            }

            ///////////////////////////////////
            // Navigation / Position drawing //
            ///////////////////////////////////

            double resolution = 5;

            double aircraftLat = main.FlightHandler.CurrentGpsData.Latitude;
            double aircraftLon = main.FlightHandler.CurrentGpsData.Longitude;

            Image plane = Properties.Resources.YellowPlane;
            g.DrawImage(plane, 216 - (plane.Width / 2), 216 - (plane.Height / 2));

            // --------------------------

            NavigationPoint krl = main.FlightManagementHandler.GetNavigationPoint("KRL");

            double x = Math.Cos(krl.Latitude) * Math.Sin(Math.Abs(krl.Longitude - aircraftLon));
            double y = Math.Cos(aircraftLat) * Math.Sin(krl.Latitude) - Math.Sin(aircraftLat) * Math.Cos(krl.Latitude) * Math.Cos(krl.Longitude - aircraftLon);

            g.DrawString("X=" + x + "; Y=" + y, Util.AirbusFont10(), Brushes.White, 10, 100);

            // --------------------------

            double beta = Math.Abs(Math.Atan2(x, y)) * 180 / Math.PI;
            beta = Util.DegreeBearing(aircraftLat, aircraftLon, krl.Latitude, krl.Longitude);

            g.DrawString("BETA=" + beta, Util.AirbusFont10(), Brushes.White, 10, 120);

            // --------------------------

            double px = Util.MapValue2(x, x - resolution, x + resolution, 0, 432);
            double py = Util.MapValue2(y, y - resolution, y + resolution, 0, 432);
            g.DrawString("PX=" + px + "; PY=" + py, Util.AirbusFont10(), Brushes.White, 10, 140);
        }

    }
}

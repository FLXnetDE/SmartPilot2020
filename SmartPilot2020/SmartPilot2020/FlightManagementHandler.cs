using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System;

namespace SmartPilot2020
{
    public class FlightManagementHandler
    {
        private SmartPilot2020 main;
        public List<NavigationPoint> NavigationPoints;

        private FMCPage CurrentPage;

        public FlightManagementHandler(SmartPilot2020 main)
        {
            this.main = main;
            this.LoadNavigationDatabaseFromFile();

            main.MonitoringHandler.AddMessageTimed("NavigationDatabase has been loaded: " + NavigationPoints.Count + " entries", Color.LimeGreen, 4000);

            this.CurrentPage = FMCPage.INITIALIZATION;
        }

        public NavigationPoint GetNavigationPoint(string name)
        {
            foreach(NavigationPoint navigationPoint in NavigationPoints)
            {
                if (navigationPoint.Name == name) return navigationPoint;
            }

            return null;
        }

        public void LoadNavigationDatabaseFromFile()
        {
            StreamReader reader = new StreamReader("NavigationDatabase.json");
            string json = reader.ReadToEnd();
            this.NavigationPoints = JsonConvert.DeserializeObject<List<NavigationPoint>>(json);
        }

        /////////////////////////
        // Graphical functions //
        /////////////////////////

        public void DrawFMC(Graphics g, SmartPilot2020 main)
        {
            // Base lines
            g.DrawLine(new Pen(Brushes.Black, 4), 0, 0, 240, 0);
            g.DrawLine(new Pen(Brushes.Black, 4), 0, 0, 0, 380);
            g.DrawLine(new Pen(Brushes.Black, 4), 239, 0, 239, 380);
            g.DrawLine(new Pen(Brushes.Black, 4), 0, 379, 239, 379);

            // Monitor
            g.FillRectangle(Brushes.Black, new Rectangle(20, 20, 200, 280));

            // Button controls
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(20, 310, 40, 20));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(70, 310, 40, 20));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(120, 310, 40, 20));
            g.FillRectangle(Brushes.Green, new Rectangle(170, 310, 50, 20));
            g.DrawString("INIT", Util.MCUD10(), Brushes.White, 22, 314);
            g.DrawString("FMAN", Util.MCUD10(), Brushes.White, 72, 314);
            g.DrawString("CLR", Util.MCUD10(), Brushes.White, 126, 314);
            g.DrawString("EXC", Util.MCUD10(), Brushes.White, 181, 314);

            // Input buttons
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 90, 18, 15));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 110, 18, 15));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 130, 18, 15));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 150, 18, 15));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 170, 18, 15));
            g.FillRectangle(Brushes.CadetBlue, new Rectangle(220, 190, 18, 15));
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 91);
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 111);
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 131);
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 151);
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 171);
            g.DrawString("-", Util.MCUD10(), Brushes.White, 223, 191);

            switch (this.CurrentPage)
            {
                case FMCPage.INITIALIZATION:
                    g.DrawString("INITIALIZATION", Util.MCUD10(), Brushes.LimeGreen, 60, 30);

                    g.DrawString("PROTECTION", Util.MCUD10(), Brushes.LimeGreen, 35, 60);

                    g.DrawString("PITCH UP", Util.MCUD10(), Brushes.White, 45, 90);
                    g.DrawString(main.FlightHandler.ProtectedPitchUpAngle + "°", Util.MCUD10(), Brushes.Cyan, 160, 90);

                    g.DrawString("PITCH DOWN", Util.MCUD10(), Brushes.White, 45, 110);
                    g.DrawString(main.FlightHandler.ProtectedPitchDownAngle + "°", Util.MCUD10(), Brushes.Cyan, 160, 110);

                    g.DrawString("ROLL", Util.MCUD10(), Brushes.White, 45, 130);
                    g.DrawString(main.FlightHandler.ProtectedRollAngle + "°", Util.MCUD10(), Brushes.Cyan, 160, 130);

                    g.DrawString("ALTITUDE", Util.MCUD10(), Brushes.White, 45, 150);
                    g.DrawString(main.FlightHandler.ProtectedAltitude + "m", Util.MCUD10(), Brushes.Cyan, 160, 150);

                    g.DrawString("OVERSPEED", Util.MCUD10(), Brushes.White, 45, 170);
                    g.DrawString(main.FlightHandler.ProtectedOverSpeed + "m/s", Util.MCUD10(), Brushes.Cyan, 160, 170);

                    g.DrawString("STALLSPEED", Util.MCUD10(), Brushes.White, 45, 190);
                    g.DrawString(main.FlightHandler.ProtectedStallSpeed + "m/s", Util.MCUD10(), Brushes.Cyan, 160, 190);

                    break;
                case FMCPage.FLIGHTMANEUVER:
                    g.DrawString("FLIGHT MANEUVER", Util.MCUD10(), Brushes.LimeGreen, 55, 30);

                    g.DrawString("HOLDING R", Util.MCUD10(), Brushes.LimeGreen, 35, 90);
                    g.DrawString("HOLDING L", Util.MCUD10(), Brushes.LimeGreen, 35, 110);

                    break;
            }
        }

        public void HandleFMCClick(SmartPilot2020 main, TextBox inputBox, int posX, int posY)
        {
            // INITIALIZATION button pressed
            if (Util.IsWithin(posX, 20, 60) && Util.IsWithin(posY, 310, 330))
            {
                this.CurrentPage = FMCPage.INITIALIZATION;
            }

            // FLIGHTMANEUVER button pressed
            if (Util.IsWithin(posX, 70, 110) && Util.IsWithin(posY, 310, 330))
            {
                this.CurrentPage = FMCPage.FLIGHTMANEUVER;
            }

            // CLEAR button pressed
            if (Util.IsWithin(posX, 120, 160) && Util.IsWithin(posY, 310, 330))
            {
                inputBox.Clear();
            }

            // EXC button pressed
            if (Util.IsWithin(posX, 170, 220) && Util.IsWithin(posY, 310, 330))
            {
                switch(inputBox.Text)
                {
                    case "[?] JOIN RIGHT HOLDING":

                        if (!main.FlightHandler.AutoPilotActive)
                        {
                            inputBox.Text = "A/P IS NOT ENGAGED";
                            return;
                        }

                        main.Log("[!] JOINING RIGHT HOLDING");
                        break;
                    case "[?] JOIN LEFT HOLDING":

                        if (!main.FlightHandler.AutoPilotActive)
                        {
                            inputBox.Text = "A/P IS NOT ENGAGED";
                            return;
                        }

                        main.Log("[!] JOINING LEFT HOLDING");
                        break;
                }
            }

            // R1 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 90, 105))
            {
                if(this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedPitchUpAngle = Int32.Parse(inputBox.Text);
                }

                if (this.CurrentPage == FMCPage.FLIGHTMANEUVER)
                {
                    if (!main.FlightHandler.AutoPilotActive)
                    {
                        inputBox.Text = "A/P IS NOT ENGAGED";
                        return;
                    }

                    inputBox.Text = "[?] JOIN RIGHT HOLDING";
                }
            }

            // R2 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 110, 125))
            {
                if (this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedPitchDownAngle = Int32.Parse(inputBox.Text);
                }

                if (this.CurrentPage == FMCPage.FLIGHTMANEUVER)
                {
                    if (!main.FlightHandler.AutoPilotActive)
                    {
                        inputBox.Text = "A/P IS NOT ENGAGED";
                        return;
                    }

                    inputBox.Text = "[?] JOIN LEFT HOLDING";
                }
            }

            // R3 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 130, 145))
            {
                if (this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedRollAngle = Int32.Parse(inputBox.Text);
                }
            }

            // R4 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 150, 165))
            {
                if (this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedAltitude = Int32.Parse(inputBox.Text);
                }
            }

            // R5 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 170, 185))
            {
                if (this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedOverSpeed = Int32.Parse(inputBox.Text);
                }
            }

            // R6 button
            if (Util.IsWithin(posX, 220, 240) && Util.IsWithin(posY, 190, 205))
            {
                if (this.CurrentPage == FMCPage.INITIALIZATION)
                {
                    main.FlightHandler.ProtectedStallSpeed = Int32.Parse(inputBox.Text);
                }
            }

        }

        public enum FMCPage
        {
            INITIALIZATION,
            FLIGHTMANEUVER
        }

        ////////////////////////
        // Aviative functions //
        ////////////////////////

        

    }
}

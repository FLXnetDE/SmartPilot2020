using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace RCAutopilot
{
    public class FlightHandler
    {
        private SmartPilot2020 main;
        private Timer ProcessTimer;
        public RemoteDataInterface RemoteDataOutputInterface;

        public bool ControlsActiveChecked = false;

        // Calculated output pulse values
        public int ThrustValue;
        public int PitchValue;
        public int RollValue;
        public int YawValue;

        // Incoming plane location data
        public int CurrentSpeed;
        public int CurrentAltitude;
        public int CurrentHeading;
        public int CurrentPitchAngle;
        public int CurrentRollAngle;

        public FlightHandler(SmartPilot2020 main)
        {
            this.main = main;

            ProcessTimer = new Timer();
            ProcessTimer.Tick += new System.EventHandler(ProcessTimer_Tick);
            ProcessTimer.Interval = main.SystemTickInterval;
            ProcessTimer.Start();

            this.RemoteDataOutputInterface = new RemoteDataInterface(main);
            this.RemoteDataOutputInterface.Connect();

            main.Log("FlightHandler started!");
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            if (ControlsActiveChecked == false)
            {
                if (ThrustValue != 0 && PitchValue != 0 && RollValue != 0 && YawValue != 0)
                {
                    ControlsActiveChecked = true;
                    main.Log("Flight controls are active and checked!");
                }
                return;
            }

            RemoteDataOutputInterface.SendControlPacket(new RemoteControlPacket(ThrustValue, PitchValue, RollValue, YawValue));

            main.UpdateControlVisualization();
        }

        public void ProcessThrust(int ThrustValue)
        {
            this.ThrustValue = SmartPilot2020.MapValue(ThrustValue, 0, 65536, main.ThrustPulse[0], main.ThrustPulse[1]);
        }

        public void ProcessPitch(int PitchValue)
        {
            this.PitchValue = SmartPilot2020.MapValue(PitchValue, 0, 65536, main.PitchPulse[0], main.PitchPulse[1]);
        }

        public void ProcessRoll(int RollValue)
        {
            this.RollValue = SmartPilot2020.MapValue(RollValue, 0, 65536, main.RollPulse[0], main.RollPulse[1]);
        }

        public void ProcessYaw(int YawValue)
        {
            this.YawValue = SmartPilot2020.MapValue(YawValue, 0, 65536, main.YawPulse[0], main.YawPulse[1]);
        }

    }
}

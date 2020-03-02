using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace SmartPilot2020
{
    public class FlightHandler
    {
        private SmartPilot2020 main;
        private Timer ProcessTimer;
        public RemoteDataInterface RemoteDataInterface;

        public bool ControlsActiveChecked = false;

        // Calculated output pulse values
        public int ThrustValue;
        public int PitchValue;
        public int RollValue;
        public int YawValue;

        // Aircraft measured positioning and environmental properties
        public int CurrentPitchAngle;
        public int CurrentRollAngle;
        public int CurrentHeading;
        public int CurrentSpeed;
        public int CurrentAltitude;
        
        public double CurrentLatitude;
        public double CurrentLongitude;

        public double CurrentAircraftTemperature;
        public double CurrentAircraftHumidity;
        public int CurrentAircraftPressure;

        // Stationary measured environmental properties
        public double CurrentStationaryTemperature;
        public double CurrentStationaryHumidity;
        public int CurrentStationaryPressure;

        public FlightHandler(SmartPilot2020 main)
        {
            this.main = main;

            ProcessTimer = new Timer();
            ProcessTimer.Tick += new System.EventHandler(ProcessTimer_Tick);
            ProcessTimer.Interval = main.SystemTickInterval;
            ProcessTimer.Start();

            this.RemoteDataInterface = new RemoteDataInterface(main);
            this.RemoteDataInterface.Connect();

            main.log.Log("FlightHandler started!");
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            main.UpdateControlVisualization();

            if (ControlsActiveChecked == false)
            {
                if (ThrustValue != 0 && PitchValue != 0 && RollValue != 0 && YawValue != 0)
                {
                    ControlsActiveChecked = true;
                    main.log.Log("Flight controls are active and checked!");
                }
                return;
            }

            RemoteDataInterface.SendControlPacket(new RemoteControlPacket(ThrustValue, PitchValue, RollValue, YawValue));
            
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

using System;
using System.Windows.Forms;

namespace SmartPilot2020
{
    public class FlightHandler
    {
        private SmartPilot2020 main;
        private Timer ProcessTimer;
        public RemoteDataInterface RemoteDataInterface;

        public int UsedRadioChannel;

        public bool ControlsActiveChecked = false;

        // Default pulse width configuration
        public int[] ThrustPulse = new int[3] { 1000, 2000, 0 };
        public int[] PitchPulse = new int[3] { 1000, 2000, 0 };
        public int[] RollPulse = new int[3] { 1000, 2000, 0 };
        public int[] YawPulse = new int[3] { 1000, 2000, 0 };

        // Calculated output pulse values
        public int ThrustValue;
        public int PitchValue;
        public int RollValue;
        public int YawValue;

        // AircraftMode
        public int AircraftMode = 0; // 0 = GroundMode - 1 = AirMode

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
        public double CurrentAircraftPressure;

        // Stationary measured environmental properties
        public double CurrentStationaryTemperature;
        public double CurrentStationaryHumidity;
        public int CurrentStationaryPressure;

        // FlightEnvelope definition
        public bool ProtectionActive = false;
        public int ProtectedPitchUpAngle = 30;
        public int ProtectedPitchDownAngle = -15;
        public int ProtectedRollAngle = 60;
        public int ProtectedAltitude = 0;
        public int ProtectedOverSpeed = 20;
        public int ProtectedStallSpeed = 5;

        // AutoPilot definition
        public bool AutoPilotActive = false;
        public bool AutoThrustActive = false;
        public int TargetHeading;
        public int TargetSpeed = 10;
        public int TargetAltitude;

        // Value finalization / correction / check
        public int FinalThrustValue;
        public int FinalPitchValue;
        public int FinalRollValue;
        public int FinalYawValue;

        public FlightHandler(SmartPilot2020 main)
        {
            this.main = main;

            // Setup main system timer
            ProcessTimer = new Timer();
            ProcessTimer.Tick += new System.EventHandler(ProcessTimer_Tick);
            ProcessTimer.Interval = main.SystemTickInterval;
            ProcessTimer.Start();

            // Setup remote data interface (Serial port)
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

            // Enable air mode if aircraft is 2m above ground
            if (CurrentAltitude >= 2) AircraftMode = 1;

            ///////////////
            // AutoPilot //
            ///////////////
            if (AutoPilotActive)
            {
                if (AircraftMode == 0) return;
            }

            ////////////////
            // AutoThrust //
            ////////////////
            if (AutoThrustActive)
            {
                if (AircraftMode == 0) return;
            }

            ////////////////
            // Protection //
            ////////////////
            if (ProtectionActive)
            {
                if (AircraftMode == 0) return;
            }

            // Value finalization / correction / check
            FinalThrustValue = ThrustValue;
            FinalPitchValue = PitchValue + PitchPulse[2];
            FinalRollValue = RollValue + RollPulse[2];
            FinalYawValue = YawValue;

            RemoteDataInterface.SendControlPacket(new RemoteControlPacket(FinalThrustValue, FinalPitchValue, FinalRollValue, FinalYawValue));
        }

        public void ProcessThrust(int ThrustValue)
        {
            if(AutoThrustActive && ThrustValue <= 0)
            {
                AutoThrustActive = false;
            }

            if(!AutoThrustActive)
            this.ThrustValue = Util.MapValue(ThrustValue, 0, 65536, ThrustPulse[0], ThrustPulse[1]);
        }

        public void ProcessPitch(int PitchValue)
        {
            if (!AutoPilotActive)
                this.PitchValue = Util.MapValue(PitchValue, 0, 65535, PitchPulse[0], PitchPulse[1]);
        }

        public void ProcessRoll(int RollValue)
        {
            if (!AutoPilotActive)
                this.RollValue = Util.MapValue(RollValue, 0, 65535, RollPulse[0], RollPulse[1]);
        }

        public void ProcessYaw(int YawValue)
        {
            if (!AutoPilotActive)
                this.YawValue = Util.MapValue(YawValue, 0, 65535, YawPulse[0], YawPulse[1]);
        }

        public void ProccessTrim(int TrimValue)
        {
            if(!AutoPilotActive)
            {
                switch(TrimValue)
                {
                    case 0: // Stick forwards - trim pitch pulse down
                        this.PitchPulse[2] -= main.AdditionalTrimValue;
                        break;
                    case 18000: // Stick backwards - trim pitch pulse up
                        this.PitchPulse[2] += main.AdditionalTrimValue;
                        break;
                    case 27000: // Stick left - trim roll pulse down
                        this.RollPulse[2] -= main.AdditionalTrimValue;
                        break;
                    case 9000: // Stick left - trim roll pulse up
                        this.RollPulse[2] += main.AdditionalTrimValue;
                        break;
                }
            }
        }

    }
}

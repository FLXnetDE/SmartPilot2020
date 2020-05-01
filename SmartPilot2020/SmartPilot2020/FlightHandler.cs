using GeoCoordinatePortable;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace SmartPilot2020
{
    public class FlightHandler
    {
        private SmartPilot2020 main;
        private Timer ProcessTimer;
        public RemoteDataInterface RemoteDataInterface;

        public int UsedRadioChannel;

        public bool ControlsActiveChecked = false;
        private Guid ControlsActiveCheckedGuid;

        // Default pulse width configuration
        public int[] ThrustPulse = new int[3] { 500, 2500, 0 };
        public int[] PitchPulse = new int[3] { 1000, 2000, 0 };
        public int[] RollPulse = new int[3] { 1000, 2000, 0 };
        public int[] YawPulse = new int[3] { 1000, 2000, 0 };

        // AircraftMode
        public int AircraftMode = 0; // 0 = GroundMode - 1 = AirMode

        // Aircraft measured positioning and environmental properties
        public int CurrentPitchAngle;
        public int CurrentRollAngle;
        public int CurrentHeading;
        public int CurrentSpeed;
        public int CurrentAltitude;
        public int CurrentLaserAltitude;
        public GeoCoordinate CurrentGpsData;
        public double CurrentAircraftTemperature;
        public double CurrentAircraftHumidity;
        public double CurrentAircraftPressure;

        // Stationary measured environmental properties
        public double CurrentStationaryTemperature;
        public double CurrentStationaryHumidity;
        public int CurrentStationaryPressure;

        // Raw mapped input values from joystick
        public int RawThrustValue;
        public int RawPitchValue;
        public int RawRollValue;
        public int RawYawValue;

        // Calculated and modified output values
        public int ThrustValue;
        public int PitchValue;
        public int RollValue;
        public int YawValue;

        // AutoPilot
        public bool AutoPilotActive = false;
        public int TargetHeading;
        public int TargetAltitude = 30;

        // AutoThrust
        public bool AutoThrustActive = false;
        public int TargetSpeed = 20;

        // Protection
        public bool ProtectionActive = false;
        public int ProtectedPitchUpAngle = 30;
        public int ProtectedPitchDownAngle = -15;
        public int ProtectedRollAngle = 60;
        public int ProtectedAltitude = 0;
        public int ProtectedOverSpeed = 20;
        public int ProtectedStallSpeed = 5;

        // FlightDirector
        public bool FlightDirectorActive = false;

        public FlightHandler(SmartPilot2020 main)
        {
            this.main = main;
            this.CurrentGpsData = new GeoCoordinate();

            // Setup main system timer
            ProcessTimer = new Timer();
            ProcessTimer.Tick += new System.EventHandler(ProcessTimer_Tick);
            ProcessTimer.Interval = main.SystemTickInterval;
            ProcessTimer.Start();

            // Setup remote data interface (Serial port)
            this.RemoteDataInterface = new RemoteDataInterface(main);
            this.RemoteDataInterface.Connect();

            ControlsActiveCheckedGuid = main.MonitoringHandler.AddMessagePersistent("F/C UNCHECKED", System.Drawing.Color.Red);
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            main.UpdateControlVisualization();

            if (ControlsActiveChecked == false)
            {
                if (RawThrustValue != 0 && RawPitchValue != 0 && RawRollValue != 0 && RawYawValue != 0)
                {
                    ControlsActiveChecked = true;
                    main.MonitoringHandler.RemoveMessage(ControlsActiveCheckedGuid);
                }
                return;
            }

            // Enable air mode if aircraft is 2m above ground
            if (CurrentLaserAltitude >= 2) AircraftMode = 1;

            // Raw value assignment
            ThrustValue = RawThrustValue;
            PitchValue = RawPitchValue;
            RollValue = RawRollValue;
            YawValue = RawYawValue;

            // Manual Trim processing (if AutoPilot is disabled)
            if (!AutoPilotActive)
            {
                PitchValue = RawPitchValue + PitchPulse[2];
                RollValue = RawRollValue + RollPulse[2];
                YawValue = RawYawValue + YawPulse[2];
            }

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

            RemoteDataInterface.SendControlPacket(new RemoteControlPacket(ThrustValue, PitchValue, RollValue, YawValue));
        }

        public void ProcessThrust(int ThrustValue)
        {
            if(AutoThrustActive && ThrustValue <= 0)
            {
                AutoThrustActive = false;
            }

            if(!AutoThrustActive)
                this.RawThrustValue = Util.MapValue(ThrustValue, 0, 65536, ThrustPulse[0], ThrustPulse[1]);
        }

        public void ProcessPitch(int PitchValue)
        {
            if (!AutoPilotActive)
                this.RawPitchValue = Util.MapValue(PitchValue, 0, 65535, PitchPulse[0], PitchPulse[1]);
        }

        public void ProcessRoll(int RollValue)
        {
            if (!AutoPilotActive)
                this.RawRollValue = Util.MapValue(RollValue, 0, 65535, RollPulse[0], RollPulse[1]);
        }

        public void ProcessYaw(int YawValue)
        {
            if (!AutoPilotActive)
                this.RawYawValue = Util.MapValue(YawValue, 0, 65535, YawPulse[0], YawPulse[1]);
        }

        public void ProccessTrim(int TrimValue)
        {
            if(!AutoPilotActive)
            {
                switch (TrimValue)
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

        public double DistanceToNavigationPoint(NavigationPoint navigationPoint)
        {
            return this.CurrentGpsData.GetDistanceTo(new GeoCoordinate(navigationPoint.Latitude, navigationPoint.Longitude));
        }

    }
}

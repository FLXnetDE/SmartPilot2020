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

        public int UsedRadioChannel;

        public bool ControlsActiveChecked = false;

        // Default pulse width configuration
        public int[] ThrustPulse = new int[3] { 500, 2500, 1800 }; // [2] = InitialRegulatedThrustPulse
        public int[] PitchPulse = new int[2] { 500, 2500 };
        public int[] RollPulse = new int[2] { 500, 2500 };
        public int[] YawPulse = new int[2] { 500, 2500 };

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

        // Calculation variables
        private int LatestPitchValue;
        private int LatestRollValue;
        private int LatestThrustValue;

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

            if (CurrentAltitude >= 2) AircraftMode = 1; // Enable air mode if aircraft is 2m above ground

            ///////////////
            // AutoPilot //
            ///////////////
            if (AutoPilotActive)
            {

            }

            ////////////////
            // AutoThrust //
            ////////////////
            if (AutoThrustActive)
            {

                if(CurrentSpeed >= TargetSpeed) // CurrentSpeed is greater than TargetSpeed - DERATE THRUST / 2
                {
                    int derate = (LatestThrustValue / 100) * 15;
                    int value = LatestThrustValue - derate;

                    if (value < ThrustPulse[0])
                    {
                        this.ThrustValue = ThrustPulse[0];
                    } else
                    {
                        this.ThrustValue = value;
                    }

                }

                if(CurrentSpeed <= TargetSpeed) // CurrentSpeed is below TargetSpeed - SET THRUST InitialRegulatedThrustPulse
                {
                    int accel = (LatestThrustValue / 100) * 5;
                    int value = LatestThrustValue + accel;

                    if (value > ThrustPulse[1])
                    {
                        this.ThrustValue = ThrustPulse[1];
                    }
                    else
                    {
                        this.ThrustValue = value;
                    }
                }
            }

            ////////////////
            // Protection //
            ////////////////
            if (ProtectionActive)
            {

                if (AircraftMode == 0) return;

                // Speed protection
                if (CurrentSpeed < ProtectedStallSpeed)
                {
                    this.ThrustValue = ThrustPulse[1];

                    if (main.Debug) main.log.Log("Speed is lower than ProtectedStallSpeed -> FULL THRUST");
                }

                if (CurrentSpeed > ProtectedOverSpeed)
                {
                    this.ThrustValue = this.ThrustValue / 2;

                    if (main.Debug) main.log.Log("Speed is lower than ProtectedOverSpeed -> THRUST DERATED / 2");
                }

                // Pitch protection
                if (CurrentPitchAngle > ProtectedPitchUpAngle)
                {
                    int down = (LatestPitchValue / 100) * 15;
                    int value = LatestPitchValue - down;


                    if (value < PitchPulse[0])
                    {
                        this.PitchValue = PitchPulse[0];
                    }
                    else
                    {
                        this.PitchValue = value;
                    }

                    main.log.Log("Aircraft exceeded the maximum protected pitch up angle (" + ProtectedPitchUpAngle + ") -> CORRECTING");
                }

                if (CurrentPitchAngle < ProtectedPitchDownAngle)
                {
                    int up = (LatestPitchValue / 100) * 15;
                    int value = LatestPitchValue + up;

                    if(value > PitchPulse[1])
                    {
                        this.PitchValue = PitchPulse[1];
                    } else
                    {
                        this.PitchValue = value;
                    }

                    main.log.Log("Aircraft exceeded the maximum protected pitch down angle (" + ProtectedPitchDownAngle + ") -> CORRECTING");
                }

            }

            RemoteDataInterface.SendControlPacket(new RemoteControlPacket(ThrustValue, PitchValue, RollValue, YawValue));

            LatestPitchValue = PitchValue;
            LatestRollValue = RollValue;
            LatestThrustValue = ThrustValue;

        }

        public void ProcessThrust(int ThrustValue)
        {
            if(!AutoThrustActive)
                this.ThrustValue = SmartPilot2020.MapValue(ThrustValue, 0, 65536, ThrustPulse[0], ThrustPulse[1]);
        }

        public void ProcessPitch(int PitchValue)
        {
            if (!AutoPilotActive)
                this.PitchValue = SmartPilot2020.MapValue(PitchValue, 0, 65536, PitchPulse[0], PitchPulse[1]);
        }

        public void ProcessRoll(int RollValue)
        {
            if (!AutoPilotActive)
                this.RollValue = SmartPilot2020.MapValue(RollValue, 0, 65536, RollPulse[0], RollPulse[1]);
        }

        public void ProcessYaw(int YawValue)
        {
            if (!AutoPilotActive)
                this.YawValue = SmartPilot2020.MapValue(YawValue, 0, 65536, YawPulse[0], YawPulse[1]);
        }

    }
}

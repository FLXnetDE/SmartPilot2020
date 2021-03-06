﻿using SharpDX.DirectInput;
using System;

namespace SmartPilot2020
{
    public class JoystickHandler
    {
        private SmartPilot2020 main;

        public JoystickHandler(SmartPilot2020 main)
        {
            this.main = main;

            DirectInput directInput = new DirectInput();
            Guid joystickGuid = Guid.Empty;

            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }

            Joystick joystick = new Joystick(directInput, joystickGuid);

            main.SetJoystickInfo(joystick.Information.ProductName);

            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            while (true)
            {
                joystick.Poll();
                JoystickUpdate[] datas = joystick.GetBufferedData();
                foreach (JoystickUpdate state in datas)
                {
                    switch (state.Offset)
                    {
                        case JoystickOffset.X: // Roll input
                            main.FlightHandler.ProcessRoll(state.Value);
                            break;
                        case JoystickOffset.Y: // Pitch input
                            main.FlightHandler.ProcessPitch(state.Value);
                            break;
                        case JoystickOffset.Sliders0: // Thrust input
                            main.FlightHandler.ProcessThrust(Util.MapValue(state.Value, 65534, 0, 0, 65534));
                            break;
                        case JoystickOffset.RotationZ: // Yaw input
                            main.FlightHandler.ProcessYaw(state.Value);
                            break;
                        case JoystickOffset.PointOfViewControllers0: // Top knob/joystick input
                            main.FlightHandler.ProccessTrim(state.Value);
                            break;
                        case JoystickOffset.Buttons0:
                            if(main.FlightHandler.AutoPilotActive)
                            {
                                main.FlightHandler.AutoPilotActive = false;
                            }
                            break;
                    }
                }
            }
        }

    }
}

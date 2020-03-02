using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPilot2020
{
    public class JoystickHandler
    {
        private SmartPilot2020 main;

        public JoystickHandler(SmartPilot2020 main)
        {
            this.main = main;
            main.log.Log("JoystickHandler started!");

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
                        case JoystickOffset.Z: // Thrust input
                            main.FlightHandler.ProcessThrust(SmartPilot2020.MapValue(state.Value, 65534, 0, 0, 65534));
                            break;
                        case JoystickOffset.RotationZ: // Yaw input
                            main.FlightHandler.ProcessYaw(state.Value);
                            break;
                    }
                }
            }
        }

    }
}

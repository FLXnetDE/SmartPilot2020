using SmartPilot2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPilot2020
{
    public class RemoteControlPacket
    {
        public int id;
        public int thrust;
        public int pitch;
        public int roll;
        public int yaw;

        public RemoteControlPacket(int ThrustValue, int PitchValue, int RollValue, int YawValue)
        {
            this.id = 1;
            this.thrust = ThrustValue;
            this.pitch = PitchValue;
            this.roll = RollValue;
            this.yaw = YawValue;
        }

        public string Encode()
        {
            return this.id + ";" + this.thrust + ";" + this.pitch + ";" + this.roll + ";" + this.yaw;
        }

        public string GetName()
        {
            return "RemoteControlPacket";
        }

    }
}

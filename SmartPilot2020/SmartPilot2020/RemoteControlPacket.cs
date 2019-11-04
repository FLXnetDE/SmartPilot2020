using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCAutopilot
{
    public class RemoteControlPacket
    {
        public int id;
        public int t;
        public int p;
        public int r;
        public int y;

        public RemoteControlPacket(int ThrustValue, int PitchValue, int RollValue, int YawValue)
        {
            this.id = 1;
            this.t = ThrustValue;
            this.p = PitchValue;
            this.r = RollValue;
            this.y = YawValue;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SmartPilot2020
{
    public class Util
    {

        // Returns often used Airbus Font in size 10pt
        public static Font AirbusFont10()
        {
            return new Font("AirbusDisp2Standard", 10);
        }

        // Helper method to map values
        public static int MapValue(float value, float from1, float to1, float from2, float to2)
        {
            return (int)Math.Ceiling((value - from1) / (to1 - from1) * (to2 - from2) + from2);
        }

        // Helper method to determine if a value is within a min / max
        public static bool IsWithin(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }

    }
}

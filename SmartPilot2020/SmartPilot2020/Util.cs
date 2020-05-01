using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeoCoordinatePortable;

namespace SmartPilot2020
{
    public class Util
    {

        // Returns often used Airbus Font in size 10pt
        public static Font AirbusFont10()
        {
            return new Font("AirbusDisp2Standard", 10);
        }

        // Returns Airbus MCDU Font in size 10pt
        public static Font MCUD10()
        {
            return new Font("AirbusMCDUa", 10);
        }

        // Helper method to map values
        public static int MapValue(double value, double from1, double to1, double from2, double to2)
        {
            return (int)Math.Ceiling((value - from1) / (to1 - from1) * (to2 - from2) + from2);
        }

        public static double MapValue2(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        // Helper method to determine if a value is within a min / max
        public static bool IsWithin(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }

        public static double DegreeBearing(double lat1, double lon1, double lat2, double lon2)
        {
            var dLon = ToRad(lon2 - lon1);
            var dPhi = Math.Log(Math.Tan(ToRad(lat2) / 2 + Math.PI / 4) / Math.Tan(ToRad(lat1) / 2 + Math.PI / 4));

            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);

            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        public static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPilot2020
{
    public class MonitoringHandler
    {
        private SmartPilot2020 main;
        private List<Message> messages;

        public MonitoringHandler(SmartPilot2020 main)
        {
            this.main = main;
            this.messages = new List<Message>();
        }

        public void DrawMonitoringDisplay(Graphics g)
        {
            g.DrawLine(Pens.White, 8, 216, 424, 216);

            //////////////////////
            // Thrust pulse bar //
            //////////////////////
            int ThrustValue = main.FlightHandler.ThrustValue;
            int LinePositionY = Util.MapValue(ThrustValue, main.FlightHandler.ThrustPulse[0], main.FlightHandler.ThrustPulse[1], 200, 80);

            g.DrawRectangle(Pens.White, 50, 40, 60, 20);
            g.DrawRectangle(Pens.White, 70, 80, 20, 120);
            g.DrawLine(new Pen(Brushes.Red, 2), 60, 80, 100, 80);
            g.DrawLine(new Pen(Brushes.Gold, 2), 60, 90, 100, 90);

            if (main.FlightHandler.ControlsActiveChecked)
            {
                if(Util.IsWithin(ThrustValue, main.FlightHandler.ThrustPulse[0], main.FlightHandler.ThrustPulse[0] + 10))
                {
                    g.DrawString("IDLE", Util.AirbusFont10(), Brushes.White, 62, 20);
                }

                g.DrawString(ThrustValue + "µs", Util.AirbusFont10(), Brushes.White, ThrustValue > 1000 ? 57 : 61, 43);
                g.FillRectangle(Brushes.LightGray, 70, LinePositionY, 20, 200 - LinePositionY);
                Brush brush = main.FlightHandler.AutoThrustActive ? Brushes.LimeGreen : Brushes.Cyan;
                g.DrawLine(new Pen(brush, 2), 60, LinePositionY, 100, LinePositionY);

                int percentage = Util.MapValue(ThrustValue, main.FlightHandler.ThrustPulse[0], main.FlightHandler.ThrustPulse[1], 0, 100);
                g.DrawString("P1", Util.AirbusFont10(), Brushes.White, 110, 110);
                g.DrawString(percentage + "%", Util.AirbusFont10(), Brushes.White, 105, 127);
            }

            //////////////////////////
            // Message drawing area //
            //////////////////////////
            int startPosY = 224;
            foreach(Message m in messages)
            {
                if(m.time > DateTimeOffset.Now.ToUnixTimeMilliseconds() || m.time == -1)
                {
                    g.DrawString(m.message, new Font("AirbusDisp2Standard", 11, FontStyle.Bold), new SolidBrush(m.color), 8, startPosY);
                    startPosY += 20;
                }
            }

        }

        public Guid AddMessageTimed(string message, Color color, int duration)
        {
            Message m = new Message();
            m.guid = Guid.NewGuid();
            m.message = message;
            m.color = color;
            m.time = DateTimeOffset.Now.ToUnixTimeMilliseconds() + duration;

            this.messages.Add(m);
            return m.guid;
        }

        public Guid AddMessagePersistent(string message, Color color)
        {
            Message m = new Message();
            m.guid = Guid.NewGuid();
            m.message = message;
            m.color = color;
            m.time = -1;

            this.messages.Add(m);
            return m.guid;
        }

        public void RemoveMessage(Guid guid)
        {
            Message message = null;

            foreach(Message m in messages)
            {
                if (m.guid == guid) message = m;
                break;
            }

            if(message != null) messages.Remove(message);
        }

    }

    public class Message
    {
        public Guid guid;
        public string message;
        public Color color;
        public long time;
    }

}

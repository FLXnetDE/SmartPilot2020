using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCAutopilot
{
    public class RemoteDataInterface
    {
        private SmartPilot2020 main;
        private SerialPort SerialPort;

        public int tx = 0;
        public int rx = 0;
        public bool PacketOutputState = true;

        public RemoteDataInterface(SmartPilot2020 main)
        {
            this.main = main;

            main.SetPacketOutputState(PacketOutputState);

            this.SerialPort = new SerialPort("COM11", 9600);
            this.SerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        public void SendControlPacket(RemoteControlPacket remoteControlPacket)
        {
            String encoded = remoteControlPacket.id + ";" + remoteControlPacket.t + ";" + remoteControlPacket.p + ";" + remoteControlPacket.r + ";" + remoteControlPacket.y;

            if(SerialPort.IsOpen && PacketOutputState)
            {
                this.SerialPort.WriteLine(encoded);

                if (main.Debug)
                {
                    main.Log(encoded);
                }

                tx++;
                main.SetTraffic("RX " + rx + " / TX " + tx);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String input = SerialPort.ReadLine();

            // Current plane position input packet
            if (input.StartsWith("2;"))
            {
                try
                {
                    string[] inputPacket = input.Split(';');
                    main.FlightHandler.CurrentPitchAngle = Int32.Parse(inputPacket[1]);
                    main.FlightHandler.CurrentRollAngle = Int32.Parse(inputPacket[2]);
                    main.FlightHandler.CurrentHeading = Int32.Parse(inputPacket[3]);
                    main.FlightHandler.CurrentSpeed = Int32.Parse(inputPacket[4]);
                    main.FlightHandler.CurrentAltitude = Int32.Parse(inputPacket[5]);
                } catch(Exception)
                {
                    main.Log("Received faulty message...");
                }
            }

            main.Log(input);

            rx++;
            main.SetTraffic("RX " + rx + " / TX " + tx);
        }

        public void Connect()
        {
            try
            {
                this.SerialPort.Open();
                main.SetComPortState(true);
                main.Log("Successfully connected to serial port '" + SerialPort.PortName + "'!");
            }
            catch (Exception)
            {
                main.Log("Serial port '" + SerialPort.PortName + "' is not available!");
                main.SetComPortState(false);
            }
        }

        public void Disconnect()
        {
            try
            {
                if(!this.SerialPort.IsOpen)
                {
                    main.Log("Serial port '" + SerialPort.PortName + "' already disconnected!");
                    main.SetComPortState(false);
                    return;
                }

                this.SerialPort.Close();
                main.SetComPortState(false);
                main.Log("Successfully disconnected serial port '" + SerialPort.PortName + "'!");
            }
            catch (Exception)
            {
                main.Log("Serial port '" + SerialPort.PortName + "' already disconnected!");
                main.SetComPortState(false);
            }
        }

    }
}

#include <MOS.h>
#include <Servo.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include <TinyGPS++.h>
#include <SoftwareSerial.h>
#include <Wire.h>

#define MOTOR_PIN 10
#define ELEVATOR_PIN 3
#define AILERON_PIN 5
#define RUDDER_PIN 6

// Debugging
bool debug = true;

// Radio (2,4GHz)
RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";

// Flight controls
Servo MOTOR;
Servo ELEVATOR;
Servo AILERON;
Servo RUDDER;

// GPS
int rxPin = 4;
int txPin = 2;
int gpsBaud = 4800;
TinyGPSPlus gps;
SoftwareSerial softwareSerial(rxPin, txPin);

// Compass

const char *gpsStream =
  "$GPRMC,045103.000,A,3014.1984,N,09749.2872,W,0.67,161.46,030913,,,A*7C\r\n"
  "$GPGGA,045104.000,3014.1985,N,09749.2873,W,1,09,1.2,211.6,M,-22.5,M,,0000*62\r\n"
  "$GPRMC,045200.000,A,3014.3820,N,09748.9514,W,36.88,65.02,030913,,,A*77\r\n"
  "$GPGGA,045201.000,3014.3864,N,09748.9411,W,1,10,1.2,200.8,M,-22.5,M,,0000*6C\r\n"
  "$GPRMC,045251.000,A,3014.4275,N,09749.0626,W,0.51,217.94,030913,,,A*7D\r\n"
  "$GPGGA,045252.000,3014.4273,N,09749.0628,W,1,09,1.3,206.9,M,-22.5,M,,0000*6F\r\n";

void setup() {
  Serial.begin(9600);

  // Radio
  radio.begin();
  radio.openReadingPipe(0, address);
  radio.setPALevel(RF24_PA_MIN);
  radio.startListening();

  // Flight controls
  MOTOR.attach(MOTOR_PIN);
  ELEVATOR.attach(ELEVATOR_PIN);
  AILERON.attach(AILERON_PIN);
  RUDDER.attach(RUDDER_PIN);

  // GPS
  softwareSerial.begin(gpsBaud);

  // Compass

  Serial.println("[SmartPilot2020] Setup finished!");
}

void CompassTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    
  }
}

void GPSTask(PTCB tcb) // "Offline" test
{
  MOS_Continue(tcb);

  while(1)
  {
    MOS_WaitForCond(tcb, gps.encode(*gpsStream++));
    
    MOS_WaitForCond(tcb, gps.location.isValid());
    if(gps.location.isValid())
    {
      Serial.println();
      Serial.println("====== Test ========");
      Serial.print("Latitude: ");
      Serial.println(gps.location.lng(), 6);
      Serial.print("Longitude: ");
      Serial.println(gps.location.lat(), 6);
      Serial.println("====================");
      Serial.println();
    } else
    {
      Serial.println("NMEA string is invalid!");
    }

    MOS_Delay(tcb, 3000);
  }
}

/*
void GPSTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(softwareSerial.available())
  {
    Serial.println(gps.location.lng(), 6);
    Serial.println(gps.location.lat(), 6);
  }
}
*/

void DebugTask(PTCB tcb)
{
  MOS_Continue(tcb);
  
  while(debug)
  {
    Serial.println("This is a debug line!");

    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write("2;45;10;150;20;50", 32);
    radio.write("3;-97.821456;30.239772", 32);
    radio.openReadingPipe(0, address);
    radio.startListening();
    
    MOS_Delay(tcb, 3000);
  }
}

void ReceiveTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(radio.available())
  {
      char controlParams[32] = "";
      radio.read(&controlParams, sizeof(controlParams));
      String str(controlParams);
    
      Serial.println(str);
    
      int id = getValue(str, ';', 0).toInt();
      int thrust = getValue(str, ';', 1).toInt();
      int pitch = getValue(str, ';', 2).toInt();
      int roll = getValue(str, ';', 3).toInt();
      int yaw = getValue(str, ';', 4).toInt();
    
      MOTOR.writeMicroseconds(thrust);
      ELEVATOR.writeMicroseconds(pitch);
      AILERON.writeMicroseconds(roll);
      RUDDER.writeMicroseconds(yaw);
  }
}

void loop() {
  MOS_Call(ReceiveTask);
  //MOS_Call(GPSTask);
  //MOS_Call(CompassTask);
  MOS_Call(DebugTask);
}

// Helper function to split control parameters
String getValue(String data, char separator, int index)
{
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = data.length()-1;

  for(int i=0; i<=maxIndex && found<=index; i++){
    if(data.charAt(i)==separator || i==maxIndex){
        found++;
        strIndex[0] = strIndex[1]+1;
        strIndex[1] = (i == maxIndex) ? i+1 : i;
    }
  }

  return found>index ? data.substring(strIndex[0], strIndex[1]) : "";
}

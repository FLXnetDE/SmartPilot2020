#include <MOS.h>
#include <Servo.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include <Wire.h>
#include <HMC5883L.h>
#include <TinyGPS++.h>
#include <SoftwareSerial.h>

#define MOTOR_PIN 10
#define ELEVATOR_PIN 3
#define AILERON_PIN 5
#define RUDDER_PIN 6

// Radio (2,4GHz)
RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";

// Flight controls
Servo MOTOR;
Servo ELEVATOR;
Servo AILERON;
Servo RUDDER;

// Compass
int deviceConnectionFailedCounter = 0;
HMC5883L compass;

// GPS
static const int RXPin = 2;
static const int TXPin = 4;
static const int GPSBaud = 9600;
TinyGPSPlus gps;
SoftwareSerial gpsSerial(RXPin, TXPin);

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

  // Compass
  Serial.println("Initialize HMC5883L");
  while (!compass.begin())
  {
    deviceConnectionFailedCounter++;
    Serial.println("Could not find a valid HMC5883L sensor, check wiring!");
    
    delay(1000);
    
    if(deviceConnectionFailedCounter >= 5) {
      Serial.println("Could not find a valid HMC5883L sensor! Compass heading information is not available!");
      break;
    }
  }
  compass.setRange(HMC5883L_RANGE_1_3GA); // Set measurement range
  compass.setMeasurementMode(HMC5883L_CONTINOUS); // Set measurement mode
  compass.setDataRate(HMC5883L_DATARATE_30HZ); // Set data rate
  compass.setSamples(HMC5883L_SAMPLES_8); // Set number of samples averaged
  compass.setOffset(0, 0); // Set calibration offset. See HMC5883L_calibration.ino

  // GPS
  gpsSerial.begin(GPSBaud);
  
}

void ReceiveTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    if(radio.available())
    {
      char controlParams[32] = "";
      radio.read(&controlParams, sizeof(controlParams));
      String str(controlParams);
    
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
}

void CompassTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    Vector norm = compass.readNormalize();

    // Calculate heading
    float heading = atan2(norm.YAxis, norm.XAxis);
  
    // Set declination angle on your location and fix heading
    // You can find your declination on: http://magnetic-declination.com/
    // (+) Positive or (-) for negative
    // For Bytom / Poland declination angle is 4'26E (positive)
    // Formula: (deg + (min / 60.0)) / (180 / M_PI);
    float declinationAngle = (2.0 + (45.0 / 60.0)) / (180 / M_PI);
    heading += declinationAngle;

    /*
    // Correct for heading < 0deg and heading > 360deg
    if (heading < 0)
    {
      heading += 2 * PI;
    }
  
    if (heading > 2 * PI)
    {
      heading -= 2 * PI;
    }
    */
  
    // Convert to degrees
    float headingDegrees = heading * 180/M_PI; 
  
    // Output
    Serial.print(" Heading = ");
    Serial.print(heading);
    Serial.print(" Degress = ");
    Serial.print(headingDegrees);
    Serial.println();
  
    delay(100);
  }
}

void GPSTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(gpsSerial.available() > 0)
  {
    gps.encode(gpsSerial.read());
    MOS_WaitForCond (tcb, gps.location.isUpdated()){
      Serial.print("Latitude= "); 
      Serial.print(gps.location.lat(), 6);
      Serial.print(" Longitude= "); 
      Serial.println(gps.location.lng(), 6);
    }
  }
}

void AirspeedTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    Serial.println("Airspeed placeholder...");
    MOS_Delay(tcb, 3000);
  }
}

void loop() {
  MOS_Call(ReceiveTask);
  MOS_Call(CompassTask);
  MOS_Call(GPSTask);
  MOS_Call(AirspeedTask);
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

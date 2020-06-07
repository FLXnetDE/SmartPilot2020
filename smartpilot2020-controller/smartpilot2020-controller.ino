#include <MOS.h>
#include <Servo.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include <TinyGPS++.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <MechaQMC5883.h>
#include <MPU6050.h>
#include <EnvironmentCalculations.h>
#include <BME280I2C.h>

#define MOTOR_PIN 10
#define ELEVATOR_PIN 9
#define AILERON_PIN 5
#define RUDDER_PIN 6

// Debugging
bool debug = true;

// Radio (2,4GHz)
RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";
String input;

// Flight controls
Servo MOTOR;
Servo ELEVATOR;
Servo AILERON;
Servo RUDDER;

// GPS
int rxPin = 4;
int txPin = 3;
int gpsBaud = 4800;
TinyGPSPlus gps;
SoftwareSerial softwareSerial(rxPin, txPin);

// Compass
MechaQMC5883 compass;

// Gyro
MPU6050 gyro;
unsigned long timer = 0;
float timeStep = 0.01;
float pitch = 0;
float roll = 0;
float yaw = 0;

// BME280
BME280I2C bme;

// Pitot tube / differential pressure sensor
int PressureSensorPin = A1;

float V_0 = 5.0; // supply voltage to the pressure sensor
float rho = 1.204; // density of air 
// parameters for averaging and offset
int offset = 0;
int offset_size = 10;
int veloc_mean_size = 20;
int zero_span = 2;

// Aircraft data buffer
int CurrentPitch;
int CurrentRoll;
int CurrentHeading;
int CurrentSpeed;
int CurrentAltitude;
int CurrentTemperature;
int CurrentHumidity;
int CurrentPressure;
int BaroReference; // hPa

void setup() {
  Serial.begin(115200);

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
  Wire.begin();
  compass.init();

  // Gyro
  while(!gyro.begin(MPU6050_SCALE_2000DPS, MPU6050_RANGE_2G))
  {
    Serial.println("[SmartPilot2020] Could not find a valid MPU6050 sensor, check wiring!");
    delay(500);
  }
  gyro.calibrateGyro();
  gyro.setThreshold(3);

  // BME280
  bme.begin();
  switch(bme.chipModel()) {
     case BME280::ChipModel_BME280:
       Serial.println("[SmartPilot2020] Found BME280 sensor! Success.");
       break;
     case BME280::ChipModel_BMP280:
       Serial.println("[SmartPilot2020] Found BMP280 sensor! No Humidity available.");
       break;
     default:
       Serial.println("[SmartPilot2020] Found UNKNOWN sensor! Error!");
  }

  // Pitot tube / differential pressure sensor
  for (int ii = 0; ii < offset_size; ii++) {
    offset += analogRead(PressureSensorPin) - (1023 / 2);
  }
  offset /= offset_size;
  Serial.print("Offset: ");
  Serial.println(offset);
  
  Serial.println("[SmartPilot2020] Setup finished!");
}

void RemoteTelemetryPacketTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {    
    char telemetryPacket[32];
    sprintf(telemetryPacket, "%d;%d;%d;%d;%d;%d", 2, CurrentPitch, CurrentRoll, CurrentHeading, CurrentSpeed, CurrentAltitude);

    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write(telemetryPacket, 32);
    radio.openReadingPipe(0, address);
    radio.startListening();
    
    MOS_Delay(tcb, 100);
  }
}

void PitotTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    Serial.println("pitot");
    
    float adc_avg = 0;
    float veloc = 0.0;
    
    // average a few ADC readings for stability
    for (int ii=0; ii < veloc_mean_size; ii++){
      adc_avg += analogRead(PressureSensorPin) - offset;
    }
    adc_avg /= veloc_mean_size;

    Serial.println(adc_avg);

    // make sure if the ADC reads below 512, then we equate it to a negative velocity
    MOS_WaitForCond(tcb, adc_avg > 512-zero_span and adc_avg < 512 + zero_span);
    if (adc_avg > 512-zero_span and adc_avg < 512 + zero_span){
    }
    else
    {
      MOS_WaitForCond(tcb, adc_avg < 512);
      if (adc_avg < 512)
      {
        veloc = -sqrt((-10000.0*((adc_avg/1023.0)-0.5))/rho);
      }
      else
      {
        veloc = sqrt((10000.0*((adc_avg/1023.0)-0.5))/rho);
      }

      CurrentSpeed = (int) veloc;
      
      Serial.print(veloc);
      Serial.print(" - ");
      Serial.println(CurrentSpeed);
      
    }

    MOS_Delay(tcb, 500);
  }
}

void RemoteEnvironmentPacketTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    char environmentPacket[32];
    sprintf(environmentPacket, "%d;%d;%d;%d", 4, CurrentTemperature, CurrentHumidity, CurrentPressure);

    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write(environmentPacket, 32);
    radio.openReadingPipe(0, address);
    radio.startListening();
    
    MOS_Delay(tcb, 5000);
  }
}

void GyroTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    timer = millis();
    
    Vector norm = gyro.readNormalizeGyro();

    pitch = pitch + norm.YAxis * timeStep;
    roll = roll + norm.XAxis * timeStep;
    yaw = yaw + norm.ZAxis * timeStep;

    CurrentPitch = (int) pitch;
    CurrentRoll = (int) roll;
  
    MOS_Delay(tcb, (timeStep * 1000) - (millis() - timer));
  }
}

void EnvironmentTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    float temp(NAN), hum(NAN), pres(NAN);
  
    BME280::TempUnit tempUnit(BME280::TempUnit_Celsius);
    BME280::PresUnit presUnit(BME280::PresUnit_hPa);
    EnvironmentCalculations::AltitudeUnit envAltUnit  =  EnvironmentCalculations::AltitudeUnit_Meters;
    EnvironmentCalculations::TempUnit envTempUnit =  EnvironmentCalculations::TempUnit_Celsius;
    
    bme.read(pres, temp, hum, tempUnit, presUnit);

    CurrentTemperature = (int) temp;
    CurrentHumidity = (int) hum;
    CurrentPressure = (int) pres;
    
    // Altitude calculation
    float environmentTemp = temp; // °C - measured local temperature

    MOS_WaitForCond(tcb, BaroReference > 0);
    if(BaroReference > 0)
    {
      float altitude = EnvironmentCalculations::Altitude(pres, envAltUnit, BaroReference, environmentTemp, envTempUnit);
      CurrentAltitude = (int) altitude;
    }
    
    MOS_Delay(tcb, 500);
  }
}

void CompassTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    int x, y, z;
    int heading;
    compass.read(&x, &y, &z, &heading);
    CurrentHeading = heading;
    
    MOS_Delay(tcb, 500);
  }
}

void RemotePositionTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    char positionPacket[32];
    sprintf(positionPacket, "%d;%s;%s;%d", 3, "48.611640", "9.109360", 445);

    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write(positionPacket, 32);
    radio.openReadingPipe(0, address);
    radio.startListening();

    MOS_Delay(tcb, 6000);
  }

  /*
  while(softwareSerial.available() > 0)
  {   
    gps.encode(softwareSerial.read());

    Serial.print("GPS Longitude: ");
    Serial.println(gps.location.lng());

    Serial.print("GPS Latitude: ");
    Serial.println(gps.location.lat());

    Serial.print("GPS Altitude: ");
    Serial.print(gps.altitude.meters());
    Serial.println("m");

    Serial.print("GPS DateTime: ");
    Serial.print(gps.date.value());
    Serial.print(" ");
    Serial.println(gps.time.value());

    MOS_Delay(tcb, 5000);
  }
  */
}

void ReceiveTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(radio.available())
  {   
      char controlParams[32] = "";
      radio.read(&controlParams, sizeof(controlParams));

      input = String(controlParams);
    
      int id = getValue(input, ';', 0).toInt();

      if(id == 1) { // RemoteControlPacket
        int thrust = getValue(input, ';', 1).toInt();
        int pitch = getValue(input, ';', 2).toInt();
        int roll = getValue(input, ';', 3).toInt();
        int yaw = getValue(input, ';', 4).toInt();
      
        MOTOR.writeMicroseconds(thrust);
        ELEVATOR.writeMicroseconds(pitch);
        AILERON.writeMicroseconds(roll);
        RUDDER.writeMicroseconds(yaw);
      } else if(id == 7) { // AltitudeReferencePacket
        BaroReference = getValue(input, ';', 1).toInt();
      }

  }
}

void DebugTask(PTCB tcb)
{
  MOS_Continue(tcb);
  
  while(debug)
  {
    Serial.println("This is a debug line!");
    
    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write("3;-97.821456;30.239772", 32);
    radio.openReadingPipe(0, address);
    radio.startListening();
    
    MOS_Delay(tcb, 3000);
  }
}

void loop() {
  MOS_Call(ReceiveTask);
  MOS_Call(CompassTask);
  MOS_Call(GyroTask);
  MOS_Call(PitotTask);
  MOS_Call(EnvironmentTask);
  MOS_Call(RemoteTelemetryPacketTask);
  MOS_Call(RemotePositionTask);
  MOS_Call(RemoteEnvironmentPacketTask);
  //MOS_Call(DebugTask);
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

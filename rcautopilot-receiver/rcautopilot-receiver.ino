#include <Servo.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

#define MOTOR_PIN 10
#define ELEVATOR_PIN 3
#define AILERON_PIN 5
#define RUDDER_PIN 6

RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";

Servo MOTOR;
Servo ELEVATOR;
Servo AILERON;
Servo RUDDER;

void setup() {
  Serial.begin(9600);

  MOTOR.attach(MOTOR_PIN);
  ELEVATOR.attach(ELEVATOR_PIN);
  AILERON.attach(AILERON_PIN);
  RUDDER.attach(RUDDER_PIN);
  
  radio.begin();
  radio.openReadingPipe(0, address);
  radio.setPALevel(RF24_PA_MIN);
  radio.startListening();
}

void loop() {
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

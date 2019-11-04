#include <ArduinoJson.h>
#include <Servo.h>

#define MOTOR_PIN 10
#define ELEVATOR_PIN 3
#define AILERON_PIN 5
#define RUDDER_PIN 6

Servo MOTOR;
Servo ELEVATOR;
Servo AILERON;
Servo RUDDER;

void setup() {
  Serial.setTimeout(5);
  Serial.begin(115200);

  MOTOR.attach(MOTOR_PIN);
  ELEVATOR.attach(ELEVATOR_PIN);
  AILERON.attach(AILERON_PIN);
  RUDDER.attach(RUDDER_PIN);
}

void loop() {
  if(Serial.available())
  {
    DynamicJsonBuffer jsonBuffer;
    String flightParams = Serial.readString();
    JsonObject& root = jsonBuffer.parseObject(flightParams);

    int id = root["id"];
    int thrust = root["t"];
    int pitch = root["p"];
    int roll = root["r"];
    int yaw = root["y"];

    MOTOR.writeMicroseconds(thrust);
    ELEVATOR.writeMicroseconds(pitch);
    AILERON.writeMicroseconds(roll);
    RUDDER.writeMicroseconds(yaw);

    //Serial.print(flightParams);
    
  }
}

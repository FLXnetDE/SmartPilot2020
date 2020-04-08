#include <MOS.h>
#include <Wire.h>
#include <Servo.h>
#include <MPU6050.h>
#include <PIDController.h>

// Gyro
MPU6050 gyro;
unsigned long timer = 0;
float timeStep = 0.01;
float pitch = 0;
float roll = 0;
float yaw = 0;

// Servo
#define SERVO_PIN 24
Servo SERVO;

// PID
PIDController pid;

void setup() {
  Serial.begin(115200);
  
  // Gyro
  while(!gyro.begin(MPU6050_SCALE_2000DPS, MPU6050_RANGE_2G))
  {
    Serial.println("[SmartPilot2020] Could not find a valid MPU6050 sensor, check wiring!");
    delay(500);
  }
  gyro.calibrateGyro();
  gyro.setThreshold(3);

  // Servo
  SERVO.attach(SERVO_PIN);

  // PID
  pid.begin();
  pid.setpoint(0);
  pid.tune(1, 0, 0);
  pid.limit(500, 2500);
}

void ControllerTask(PTCB tcb)
{
  MOS_Continue(tcb);
  
  while(1)
  {
    timer = millis();
    
    Vector norm = gyro.readNormalizeGyro();

    pitch = pitch + norm.YAxis * timeStep;
    roll = roll + norm.XAxis * timeStep;
    yaw = yaw + norm.ZAxis * timeStep;

    int output = pid.compute(roll);
    SERVO.writeMicroseconds(output);
    
    Serial.print("Roll: ");
    Serial.print(roll);
    Serial.print("° - Output: ");
    Serial.println(output);
  
    MOS_Delay(tcb, (timeStep * 1000) - (millis() - timer));
  }
}

void loop() {
  MOS_Call(ControllerTask);
}

#include <Wire.h>
#include <MPU6050_tockn.h>

MPU6050 GYRO(Wire, 0.1, 0.9);

void setup() {
  Serial.begin(115200);
  Wire.begin();
  GYRO.begin();
  GYRO.calcGyroOffsets(true);
}

void loop() {
    GYRO.update();
    
    double pitch = GYRO.getAngleY();
    double roll = GYRO.getAngleX();
    double yaw = GYRO.getAngleX();     

    Serial.print("Pitch: ");
    Serial.print(pitch);
    Serial.print("° - Roll: ");
    Serial.print(roll);
    Serial.print("° - Yaw: ");
    Serial.print(yaw);
    Serial.println("°");

    delay(30);
}

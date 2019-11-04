#include <MagneticSensorLsm303.h>

MagneticSensorLsm303 compass;

void setup() {
  Serial.begin(9600);
  compass.init();
  compass.enable();
}

void loop() {
  compass.read();
  float heading = compass.getNavigationAngle();
  Serial.print("Navigation Angle:  ");
  Serial.println(heading,3);
  delay(1000);
}

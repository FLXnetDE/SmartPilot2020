
float result;
float kPa;

int avgValues = 10;
float avgSum = 0.0;

void setup() {
  Serial.begin(115200);
}

void loop() {

  for(int i = 0; i < avgValues; i++)
  {
    avgSum += analogRead(A0);
  }

  result = avgSum / avgValues;
  avgSum = 0.0;
  
  if (result < 102) {
    kPa = -2.0;
  } else {
    if (result > 921) {
      kPa = 2.0;
    } else { 
      kPa = map(result, 102, 921, -2000, 2000)/1000.0;
    }
  }
  Serial.println(result);
  //Serial.println(kPa);
  delay(50);
}

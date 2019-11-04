#include <MOS.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";

void setup() {
  Serial.setTimeout(5);
  Serial.begin(9600);

  radio.begin();
  radio.openWritingPipe(address);
  radio.setPALevel(RF24_PA_MIN);
  radio.stopListening();
}

void ExampleInputTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    Serial.print("2;");
    Serial.print(random(-60, 60));
    Serial.println(";10;150;20;50");

    MOS_Delay(tcb, 2000);
  }
}

void SendControlSignalTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(Serial.available())
  {
    String flightParams = Serial.readString();
    const char copy[32];
    flightParams.toCharArray(copy, 32);
    radio.write(&copy, 32);
  }
}

void loop() {
  MOS_Call(SendControlSignalTask);
  MOS_Call(ExampleInputTask);
}

#include <MOS.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

// Radio
RF24 radio(7, 8); // CE, CSN
const byte address[6] = "00001";

void setup() {
  Serial.setTimeout(5);
  Serial.begin(115200);

  // Radio
  radio.begin();
  radio.openReadingPipe(0, address);
  radio.setPALevel(RF24_PA_MIN);
  radio.startListening();
}

void ReceiveTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(radio.available())
  {
      char telemetry[32];
      radio.read(&telemetry, sizeof(telemetry));
      String telemetryString(telemetry);
    
      Serial.println(telemetryString);
  }
}

void SendControlSignalTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(Serial.available())
  {
    String flightParams = Serial.readString();
    char copy[32];
    flightParams.toCharArray(copy, 32);

    radio.stopListening();
    radio.openWritingPipe(address);
    radio.write(&copy, 32);
    radio.openReadingPipe(0, address);
    radio.startListening();
  }
}

void RemoteSignalInformationTask(PTCB tcb)
{
  MOS_Continue(tcb);

  while(1)
  {
    Serial.print("6;");
    Serial.print(radio.getChannel());
    Serial.print(";");
    Serial.print(radio.testCarrier());
    Serial.print(";");
    Serial.println(radio.testRPD());

    MOS_Delay(tcb, 5000);
  }
}

void loop() {
  MOS_Call(ReceiveTask);
  MOS_Call(SendControlSignalTask);
  MOS_Call(RemoteSignalInformationTask);
}

int ledpin=13;
void setup(){
  pinMode(ledpin, OUTPUT);
  Serial.begin(115200);
}

void loop(){
  digitalWrite(ledpin, HIGH);
  Serial.println("LED ON");
  delay(2000);
  digitalWrite(ledpin, LOW);
  Serial.println("LED OFF");
  delay(2000);
}

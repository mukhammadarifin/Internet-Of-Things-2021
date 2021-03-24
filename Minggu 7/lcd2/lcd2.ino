/* I2C LCD with Arduino example code. More info: https://www.makerguides.com */
// Include the libraries:
// LiquidCrystal_I2C.h: https://github.com/johnrickman/LiquidCrystal_I2C
#include <Arduino.h>
#include <Wire.h>              // Library for I2C communication
#include <LiquidCrystal_I2C.h> // Library for LCD
#include <DHT.h>
#define DHTTYPE DHT11
#define RED_LED D5   //led warna merah
#define GREEN_LED D6 //led warna hijau
//#define BLUE_LED D7  //led warnah biru

DHT dht(D4, DHTTYPE);
// Wiring: SDA pin is connected to A4 and SCL pin to A5.
// Connect to LCD via I2C, default address 0x27 (A0-A2 not jumpered)
LiquidCrystal_I2C lcd = LiquidCrystal_I2C(0x27, 16, 2); // Change to (0x27,20,4) for 20x4 LCD.
void setup()
{
  // Initiate the LCD:
  lcd.init();
  lcd.backlight();
  lcd.home();

  //DHT
  dht.begin();

  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(RED_LED, OUTPUT); //atur pin-pin digital sebagai output
  pinMode(GREEN_LED, OUTPUT);
  //pinMode(BLUE_LED, OUTPUT);
}
void loop()
{
  delay(2000);
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  float f = dht.readTemperature(true);

  if (isnan(h) || isnan(t) || isnan(f))
  {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }

  float hif = dht.computeHeatIndex(f, h);
  float hic = dht.computeHeatIndex(t, h, false);

  Serial.print(F("Humidity: "));
  Serial.print(h);
  Serial.print(F("%  Temperature: "));
  Serial.print(t);
  Serial.print(F("°C "));
  Serial.print(f);
  Serial.print(F("°F  Heat index: "));
  Serial.print(hic);
  Serial.print(F("°C "));
  Serial.print(hif);
  Serial.println(F("°F"));

  if (t <= 29.00)
  {
    digitalWrite(RED_LED, HIGH);
    digitalWrite(GREEN_LED, LOW);
    //digitalWrite(BLUE_LED, HIGH);
  }
  else if (t > 29.00 && t < 31.50)
  {
    digitalWrite(RED_LED, LOW);
    digitalWrite(GREEN_LED, HIGH);
    //digitalWrite(BLUE_LED, LOW);
  }
  else
  {
    digitalWrite(RED_LED, LOW);
    digitalWrite(GREEN_LED, LOW);
    //digitalWrite(BLUE_LED, HIGH);
  }
  // Print 'Hello World!' on the first line of the LCD:
  lcd.setCursor(2, 0); // Set the cursor on the third column and first row.
  lcd.print("Ingfo Suhu"); // Print the string "Hello World!"
  lcd.setCursor(2, 1); //Set the cursor on the third column and the second row (counting starts at 0!).
  lcd.print(t);
  lcd.write(B11011111); // Tulis simbol derajat
  lcd.print(F("C "));
}

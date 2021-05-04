/* ------------------------------------------------------------
 * Project: Socket 1, Author: doditsuprianto@polinema.ac.id
 * Kontrol LED dan menampilkan pesan ke LCD
 * berdasarkan instruksi dari C#.Net ke NodeMCU melalui socket
 *-------------------------------------------------------------*/

/*---------------------------------------------------------------------------------------------- 
 *  Skenario:
 *  - NodeMCU dihubungkan ke Access Point Network
 *  - Secara network NodeMCU bertindak sebagai station
 *  - Secara Socket NodeMCU bertindak sebagai server (listening)
 *  - NodeMCU menghidupkan atau mematikan 3 LED berdasarkan instruksi yang diterima dari socket 
 *  - NodeMCU menampilkan pesan string ke LCD yang diterima dari socket
 *  - String data bersifat serialize delimiter yang harus di split segement-nya mengacu tanda '#'
 *----------------------------------------------------------------------------------------------*/

#include <ESP8266WiFi.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <SimpleDHT.h>

// Mendefinisikan alamat pin
#define pinLedMerah   D0 
#define pinLedKuning  D3 
#define pinLedHijau   D4 
#define pinDHT        10 

int port = 1020;  //Port number
WiFiServer server(port);

//Koneksi ke network Wifi AccessPoint
const char *ssid = "node";  
const char *password = "10tkj123";  

//constructor object LCD  I2C
LiquidCrystal_I2C lcd(0x27, 16, 2);

//constructor object sensor dht11
SimpleDHT11 dht11(pinDHT);

//membuat karakter derajat custom
//https://maxpromer.github.io/LCD-Character-Creator/
byte derajat[] = {
  B01110,
  B10001,
  B10001,
  B10001,
  B01110,
  B00000,
  B00000,
  B00000
};

void setup() {
  Serial.begin(9600);

  pinMode(pinLedMerah, OUTPUT);
  pinMode(pinLedKuning, OUTPUT);
  pinMode(pinLedHijau, OUTPUT);
  pinMode(pinDHT, INPUT);

  KoneksiAP();

  lcd.init(); 
  lcd.createChar(0, derajat);
  lcd.backlight();
  lcd.home();
  lcd.setCursor(0, 0);
  lcd.print("Project 1");
  lcd.setCursor(0, 1);
  lcd.print("LED & LCD SOCKET");


  
  delay(3000);
  lcd.clear();
}

void loop() {
  WiFiClient client = server.available();
  
  String pesan = "";
  
  if (client) {
    while (client.connected()) {      
      while (client.available() > 0) {
        // Serial.write(client.read());
        // Membaca data dari client yang terhubung        
        // Data berupa character yang harus digabungkan menjadi string utuh
        delay(10);
        char c = client.read();
        pesan += String(c);
      }

      Serial.println(pesan);
      
      // Filter data string yang masuk unutk dilakukan tindakan lanjutan
      if (pesan == "Merah") {
        //LED merah hidup, lainnya mati
        digitalWrite(pinLedMerah, HIGH);
        digitalWrite(pinLedKuning, LOW);
        digitalWrite(pinLedHijau, LOW);
      } else if (pesan == "Kuning") {
        //LED kuning hidup, lainnya mati
        digitalWrite(pinLedMerah, LOW);
        digitalWrite(pinLedKuning, HIGH);
        digitalWrite(pinLedHijau, LOW);
      } else if (pesan == "Hijau") {
        //LED hijau hidup, lainnya mati
        digitalWrite(pinLedMerah, LOW);
        digitalWrite(pinLedKuning, LOW);
        digitalWrite(pinLedHijau, HIGH);
      } else if (getValue(pesan, '#', 0) == "LCD") {
        // Cek apakah kata sebelum penanda "#" pertama adalah "LCD"
        // Jika ya maka potong string sesuai delimiter "#" untuk baris 1 dan baris 2
        // untuk ditampilkan ke LCD I2C
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print(getValue(pesan, '#', 1));
        lcd.setCursor(0, 1);
        lcd.print(getValue(pesan, '#', 2));
      }     
    }
    client.stop(); //koneksi dengan client di putus    
  }
}

/*
 * Masih belum digunakan
 */
void KelembabanSuhu() {
  byte temperature = 0;
  byte humidity = 0;
  int err = SimpleDHTErrSuccess;
  if ((err = dht11.read(&temperature, &humidity, NULL)) != SimpleDHTErrSuccess)
  {
    Serial.print("Pembacaan DHT11 gagal, err=");
    Serial.println(err); delay(1000);
    return;
  }

  Serial.print("Sample OK: ");
  Serial.print((int)temperature);
  Serial.print(" *C, ");
  Serial.print((int)humidity);
  Serial.println(" H");

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Temperatur: " + String((int)temperature));
  lcd.write(0);
  lcd.print("C ");  
  lcd.setCursor(0, 1);
  lcd.print("Kelembaban: " + String((int)humidity) + "H");

  delay(1500);
}

/* 
 *  Fungsi KoneksiAP() adalah untuk membentuk koneksi jaringan
 *  antara NodeMCU dan Acces Point. NodeMCU berposisi sebagai station.
 *  Ditinjau dari socket, mala pada projek ini NodeMCU bertindak sebagai server
 *  atau me-listening jika ada incoming data dari client
 */
void KoneksiAP() {
  // Konfigurasi WIFI
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  // Menunggu koneksi dengan AP
  Serial.println("Connecting to Wifi");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    delay(500);
  }

  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);

  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  
  // Socket listening dimulai
  server.begin();
}

/*  Function getValue() berfungsi mendapatkan nilai string yang diterima.
 *  Data string bersifat serialize yang mengandung penanda/delimiter '#'
 *  yang harus dipisahkan untuk membaca data setiap segment
 *  sebagai acuan triger untuk dieksekusi lebih lanjut.
 */
String getValue(String data, char separator, int index)
{
  // Splitting string diantara penanda karakter "#"
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = data.length() - 2;

  for (int i = 0; i <= maxIndex && found <= index; i++) {
    if (data.charAt(i) == separator || i == maxIndex) {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }
  return found > index ? data.substring(strIndex[0], strIndex[1]) : "";
}

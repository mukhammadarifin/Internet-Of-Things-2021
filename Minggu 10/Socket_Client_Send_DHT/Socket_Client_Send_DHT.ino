/*
 * 
 * Socket pada NodeMCU dan C#
 * Dodit Suprianto, doditsuprianto@gmail.com
 * 
 */

#include <ESP8266WiFi.h>
#include <SimpleDHT.h>
#include <LiquidCrystal_I2C.h>
#include <SimpleTimer.h>

// SSD3 pin signal sensor DHT. perhatikan rancangan fritzing
#define pinDHT 10 

#ifndef STASSID
#define STASSID "node"     //sesuaikan
#define STAPSK  "10tkj123"  //sesuiakan
#endif

const char* ssid     = STASSID;
const char* password = STAPSK;

// ip socket server, sesuaikan alamat ip nya. 
// gunakan command 'ipconfig' pada laptop
const char* host = "192.168.43.174";
const uint16_t port = 16375;

//instan sensor dht11
SimpleDHT11 dht11(pinDHT);

//instan LCD  I2C
LiquidCrystal_I2C lcd(0x27, 16, 2);

//instance simple timer
SimpleTimer timeBacaDHT;

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

byte temperature = 0;
byte humidity = 0;

void setup() {
  // baudrate serial monitor, sesuaikan
  Serial.begin(9600);

  // penentuan interval pembacaan DHT, misal 1,5 detik
  timeBacaDHT.setInterval(1500);

  // set mode pin sensor DHT11
  pinMode(pinDHT, INPUT);

  // konfigurasi LCD
  KonfigurasiLCD();

  // Konfigurasi WiFi
  // Membentuk koneksi WIFI dengan AP
  KoneksiAP();
}

void loop() {
  Serial.print("connecting to "); Serial.print(host);
  Serial.print(':'); Serial.println(port);

  // Menggunakan class WiFiClient untuk membentuk koneksi TCP
  // ke server (192.168.0.101, 16375). Ulang koneksi jika gagal
  WiFiClient client;
  if (!client.connect(host, port)) {
    Serial.println("connection failed");
    delay(5000);
    return;
  }

  // cek apakah interval terpenuhi 1,5 detik
  if (timeBacaDHT.isReady()) {
    // Baca suhu dan kelembaban
    KelembabanSuhu();

    // bila koneksi telah terbentuk maka
    // kirim data suhu dan kelembaban ke server
    Serial.println("sending data to server");
    if (client.connected()) {
      client.println(String((int)temperature) + "#" +  String((int)humidity));
      client.stop();
    }
    
    // reset timer mulai dari 0
    timeBacaDHT.reset();
  }  
}

void KelembabanSuhu() {
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
}

void KoneksiAP() {
  Serial.println();
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void KonfigurasiLCD() {
  lcd.init();        
  lcd.createChar(0, derajat);
  lcd.backlight(); 
  lcd.setCursor(0, 0);
  lcd.print("Socket DHT");
  lcd.setCursor(0, 1);
  lcd.print("Menuju Server");
  delay(3000);
  lcd.clear();
}

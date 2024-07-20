#include <Wire.h>
#include <WiFi.h>

#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#include <ESPAsyncWebServer.h>

#include <AsyncJson.h>
#include <ArduinoJson.h>

#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64

Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, -1);
AsyncWebServer server(32455);

const char* ssid = "Hoppe";
const char* password = "guga@123";
const char* ipv4 = "192.168.3.111";

float GPU_USAGE = 0;
int GPU_TEMPERATURE = 0;

AsyncCallbackJsonWebHandler* updateGpuData = new AsyncCallbackJsonWebHandler("/update-gpu-data", [](AsyncWebServerRequest *request, JsonVariant &json) {

  const JsonObject& jsonObj = json.as<JsonObject>();
  
  float gpuUsage = jsonObj["gpu_usage"].as<float>();
  int gpuTemp = jsonObj["gpu_temperature"].as<int>();
  
  GPU_USAGE = gpuUsage;
  GPU_TEMPERATURE = gpuTemp;
  
  request->send(200, "text/plain;chartset=UTF-8", "OK");
});

void setup() {

  // ██████╗ ████████╗██╗  ██╗    ██████╗  ██████╗ ███████╗ ██████╗ 
  // ██╔══██╗╚══██╔══╝╚██╗██╔╝    ╚════██╗██╔═████╗╚════██║██╔═████╗
  // ██████╔╝   ██║    ╚███╔╝      █████╔╝██║██╔██║    ██╔╝██║██╔██║
  // ██╔══██╗   ██║    ██╔██╗      ╚═══██╗████╔╝██║   ██╔╝ ████╔╝██║
  // ██║  ██║   ██║   ██╔╝ ██╗    ██████╔╝╚██████╔╝   ██║  ╚██████╔╝
  // ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝   ╚═════╝ 
                                                                
  // ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗         
  // ██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║         
  // ██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║         
  // ██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║         
  // ╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║         
  // ╚═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝   

  // by: Hoppezera 
  // 2024-07-20

  Serial.begin(115200);


  // =================================================================== //
  // ============================= DISPLAY ============================= //
  Wire.begin(21, 22);

  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {

    Serial.println(F("SSD1306 não encontrado."));
    for(;;);
  
  }
  // ============================= DISPLAY ============================= //
  // =================================================================== //



  // =================================================================== //
  // ============================= WIFI ================================ //
  WiFi.mode(WIFI_STA);

  IPAddress local_IP(192, 168, 3, 111);
  IPAddress gateway(192, 168, 3, 1);
  IPAddress subnet(255, 255, 255, 0);
  IPAddress primaryDNS(8, 8, 8, 8);
  IPAddress secondaryDNS(8, 8, 4, 4);
  
  if (!WiFi.config(local_IP, gateway, subnet, primaryDNS, secondaryDNS)) {
    Serial.println("STA Failed to configure");
  }

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.println("Connecting WiFi...");
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  // ============================= WIFI ================================ //
  // =================================================================== //



  // ======================================================================= //
  // ============================= HTTP SERVER ============================= //
  server.addHandler(updateGpuData);
  server.begin();
  // ============================= HTTP SERVER ============================= //
  // ======================================================================= //

}

void loop() {

  display.clearDisplay();
  display.setTextColor(SSD1306_WHITE);

  display.setTextSize(2);
  display.setCursor(10, 10);
  display.println(F("RTX 3070"));

  display.setTextSize(1);
  display.setCursor(10, 35);
  display.println("Usage: " + String(GPU_USAGE * 100, 1) + "%");

  display.setTextSize(1);
  display.setCursor(10, 50);
  display.println("Temp: " + String(GPU_TEMPERATURE) + "C");

  display.display();

  Serial.print("GPU_USAGE: ");
  Serial.println(GPU_USAGE);

  Serial.print("GPU_TEMPERATURE: ");
  Serial.println(GPU_TEMPERATURE);

  delay(3000);
}

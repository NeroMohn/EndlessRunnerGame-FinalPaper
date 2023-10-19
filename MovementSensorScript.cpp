#include <Wire.h>
#include <I2Cdev.h>
#include <MPU6050.h>

MPU6050 mpu;

int16_t ax, ay, az, gx, gy, gz; 

void setup() {
  Serial.begin(9600); 
  Wire.begin(); 
  mpu.initialize();
  if(!mpu.testConnection()){ 
    while (1); 
    }
}
void loop() {
  mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz); 
  Serial.println(ax);
}
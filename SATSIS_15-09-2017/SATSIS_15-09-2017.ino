#define X_STEP_PIN        2
#define X_DIR_PIN         5
#define Y_STEP_PIN        3
#define Y_DIR_PIN         6
#define ENABLE_PIN        8
#define LED_PIN1          8//Back lighting Pin number
#define LED_PIN2          12//Front Lighting Pin number (not active)
#define NUMPIXELS         12
#define NUMPIXELS2        8
#define X                 stepper3
#define Y                 stepper1
#define Z                 stepper2
#define X_STOP_LOWER      9
#define X_STOP_HIGHER     10
#define Z_STOP            11


#include <AccelStepper.h>
#include <Adafruit_NeoPixel.h>
#include <TimerOne.h>


AccelStepper stepper3(AccelStepper::DRIVER, 2, 5); // lateral movement for mandrel (X)
AccelStepper stepper1(AccelStepper::DRIVER, 3, 6); // Rotation (Y)
AccelStepper stepper2(AccelStepper::DRIVER, 4, 7);//(Z)
Adafruit_NeoPixel pixels1 = Adafruit_NeoPixel(NUMPIXELS, LED_PIN1, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel pixels2 = Adafruit_NeoPixel(NUMPIXELS2, LED_PIN2, NEO_GRB + NEO_KHZ800);
//pin 9 (X-Stop)
//pin 11 (Z-Stop)

void setup()
{
pinMode(8, OUTPUT);
digitalWrite(8, LOW);
Serial.begin(9600);
pixels1.begin(); // This initializes the NeoPixel library.
pixels1.setBrightness(20); 
pixels2.begin(); // This initializes the NeoPixel library.
pixels2.setBrightness(20); 

stepper1.setSpeed(10);//for Y
stepper1.setMaxSpeed(2000);
stepper1.setAcceleration(200);

stepper3.setSpeed(100);//for X
stepper3.setMaxSpeed(2000);
stepper3.setAcceleration(2000);

stepper2.setSpeed(100);//for Z
stepper2.setMaxSpeed(2000);
stepper2.setAcceleration(1000);

//limiters
pinMode(9, INPUT);//X Stop Lower
digitalWrite(9, HIGH);

pinMode(10,INPUT);//X Stop Upper
digitalWrite(10,HIGH);
 

pinMode(11, INPUT);//Z stop
digitalWrite(11, HIGH);

Timer1.initialize(500);
Timer1.attachInterrupt(timerIsr);
}

void loop() //this loop is the loop that oscillates the 1 stage, while rotating the mandrel and running the syringe pump motor
{   
  
   for(int i=0;i<NUMPIXELS;i++){
    //pixels.setPixelColor(i,0,255,30); // Moderately bright green color.
    pixels1.setPixelColor(i,255,255,255); // White color.
    pixels1.show();// This sends the updated pixel color to the hardware.
    pixels2.setPixelColor(i,255,255,255); // White color.
    pixels2.show();// This sends the updated pixel color to the hardware.
   }

    if (Serial.available() > 0)  {
     String incomingByte = Serial.readStringUntil('!');
     pixels1.show();// This sends the updated pixel color to the hardware.
     pixels1.show();// This sends the updated pixel color to the hardware.
    
    
      if (incomingByte == "#Y"){
      stepper1.runToNewPosition(20);
      stepper1.setCurrentPosition(0);
      Serial.println("#OK!");
      }

      else if (incomingByte.substring(0,2)=="#Y"){
        String moveY = incomingByte.substring(2);
     long movedistance = moveY.toInt();
     stepper1.runToNewPosition(movedistance);
     stepper1.setCurrentPosition(0);
     Serial.println("#OK!");
      }
      
 if (incomingByte.substring(0,2) == "#X"){
     String moveX = incomingByte.substring(2);
     long movedistance = moveX.toInt();
     stepper3.runToNewPosition(movedistance);
     stepper3.setCurrentPosition(0);
     Serial.println("#OK!");
   }
 if (incomingByte == "#L"){
    stepper3.runToNewPosition(-1600);
    stepper3.setCurrentPosition(0);
    Serial.println("#OK!");
    }
      
 if (incomingByte == "#R"){
    stepper3.runToNewPosition(1600);
    stepper3.setCurrentPosition(0);
    Serial.println("#OK!");
    }  

 if (incomingByte == "#U"){
    stepper1.runToNewPosition(27);
    stepper1.setCurrentPosition(0);
    //Serial.write("#OK!");
    //pixels.setBrightness(10);
    }
      
 if (incomingByte == "#D"){
    stepper1.runToNewPosition(-27);
    stepper1.setCurrentPosition(0);
    //Serial.write("#OK!");
    }

 if (incomingByte == "#J"){
    stepper1.runToNewPosition(1);
    stepper1.setCurrentPosition(0);
    //Serial.write("#OK!");
    }

 if (incomingByte == "#K"){
    stepper1.runToNewPosition(-1);
    stepper1.setCurrentPosition(0);
    //Serial.write("#OK!");
    }

 if (incomingByte == "#M"){
    stepper3.runToNewPosition(20);
    stepper3.setCurrentPosition(0);
    //Serial.write("#OK!");
    }

 if (incomingByte == "#N"){
    stepper3.runToNewPosition(-20);
    stepper3.setCurrentPosition(0);
    //Serial.write("#OK!");
    }
    
 if (incomingByte == "#C"){
    stepper3.runToNewPosition(106);
    stepper3.setCurrentPosition(0);
//Serial.write("#OK!");
   }

   if (incomingByte.substring(0,2) == "#P"){
     String brightness = incomingByte.substring(2);
     int bright = brightness.toInt();
     pixels1.setBrightness(bright); 
   }
   
    if (incomingByte.substring(0,2) == "#Q"){
     String brightness = incomingByte.substring(2);
     int bright = brightness.toInt();
     pixels2.setBrightness(bright); 
   }
  
  if (incomingByte.substring(0,2) == "#B"){ 
     String back = incomingByte.substring(2);
     int backwards = back.toInt();
     stepper2.runToNewPosition(-1*backwards);
     //stepper2.runToNewPosition(-1600);
     stepper2.setCurrentPosition(0);
     //Serial.write("yebo");
   }

  if (incomingByte.substring(0,2) == "#F"){
     String forw = incomingByte.substring(2);
     int forwards = forw.toInt();
     stepper2.runToNewPosition(forwards);
     //stepper2.runToNewPosition(1600);
     stepper2.setCurrentPosition(0);
   }

   if (incomingByte.substring(0,2)=="#H"){
    //Homing sequence
    X.setCurrentPosition(0);
    X.moveTo(200000);
    Z.setCurrentPosition(0);
    Z.moveTo(-200000);
    boolean  homeComplete=false;
    while (!homeComplete){
      if (!digitalRead(X_STOP_HIGHER)){
        X.run();
        
      }
      if (!digitalRead(Z_STOP)){
        Z.run();
      }
      if (digitalRead(X_STOP_HIGHER)){//&&digitalRead(Z_STOP)){
        homeComplete=true;
      }

    }
    
    Z.runToNewPosition(-1*Z.currentPosition());
    X.runToNewPosition(-1*X.currentPosition());
    X.setCurrentPosition(0);
    Z.setCurrentPosition(0);
    
   }

    if (incomingByte.substring(0,2) == "#G"){
    int comma=incomingByte.indexOf(",");
    String moveX=incomingByte.substring(2,comma);
    String moveY=incomingByte.substring(comma+1);
     X.setCurrentPosition(0);
    X.moveTo(moveX.toInt());
    Y.setCurrentPosition(0);
    Y.moveTo(moveY.toInt());
    boolean Complete=false;
    
    while (!Complete){
        X.run();
        Y.run();
      if (X.currentPosition()==X.targetPosition()&&Y.currentPosition()==Y.targetPosition()){
        Complete=true;
      }

    }
    X.setCurrentPosition(0);
    Z.setCurrentPosition(0);
    X.moveTo(0);
    Z.moveTo(0);
   }

  if (incomingByte.substring(0,2)=="#C"){//continous movement function
    boolean go=true;
    String command=incomingByte.substring(2,3); 
    if (command=="L"){
    X.moveTo(-100000);
    }
    else if (command=="R"){
      X.moveTo(100000);
    }
    Timer1.initialize(20);
    Timer1.attachInterrupt(cont);
    while (go){//run along x axis until command given
        if (Serial.readStringUntil('!')=="#S"){
          go=false;
        }
        if (digitalRead(X_STOP_HIGHER)&X.targetPosition()>0){
         X.setCurrentPosition(0);
         X.moveTo(0);
         go=false;
      }
    }//end while
    Serial.println("done");
    Timer1.detachInterrupt();
    Timer1.attachInterrupt(timerIsr);
    
  }
  }//end of commands 

  
}//end loop

void timerIsr() {
  if (digitalRead(X_STOP_HIGHER)&X.targetPosition()>0){
    X.setCurrentPosition(0);
    X.moveTo(0);
  }
  if (digitalRead(X_STOP_LOWER)&X.targetPosition()<0){
    X.setCurrentPosition(0);
    X.moveTo(0);
  }
  else if (digitalRead(Z_STOP)&&Z.targetPosition()<0){
    Z.setCurrentPosition(0);
    Z.moveTo(0);
    
  }
}

void cont(){
  X.run();
  Serial.println("x");
}
    





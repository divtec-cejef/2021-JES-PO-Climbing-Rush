// Allume les LEDs soit en rouge, bleu, vert, jaune ou magenta
// Unity gère quelle couleur doit s'afficher
// Ici on ne fait que de lire sur la console quelle couleur doit s'afficher et on l'affiche

#include "Adafruit_NeoPixel.h"
#ifdef __AVR__
#include <avr/power.h>
#endif

Adafruit_NeoPixel ring1 = Adafruit_NeoPixel(24, A0, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring2 = Adafruit_NeoPixel(24, 2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring3 = Adafruit_NeoPixel(24, 3, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring4 = Adafruit_NeoPixel(24, 4, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring5 = Adafruit_NeoPixel(24, 5, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring6 = Adafruit_NeoPixel(24, 6, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring7 = Adafruit_NeoPixel(24, 7, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel ring8 = Adafruit_NeoPixel(24, 8, NEO_GRB + NEO_KHZ800);


char myCol[20];
size_t color[8];
size_t byteReceived;
int indexColor = 0;
uint32_t colorOfRing;
bool inMenu = false;

void setup() {

  ring1.setBrightness(255);
  ring2.setBrightness(255);
  ring3.setBrightness(255);
  ring4.setBrightness(255);
  ring5.setBrightness(255);
  ring6.setBrightness(255);
  ring7.setBrightness(255);
  ring8.setBrightness(255);
  
  ring1.begin();
  ring2.begin();
  ring3.begin();
  ring4.begin();
  ring5.begin();
  ring6.begin();
  ring7.begin();
  ring8.begin();
  
  ring1.show();
  ring2.show();
  ring3.show();
  ring4.show();
  ring5.show();
  ring6.show();
  ring7.show();
  ring8.show();

  Serial.begin(9600);
}


void loop() {

  // Lis les données qui entre dans l'arduino avec certaines contraintes
  byteReceived = Serial.readBytesUntil('\n', myCol, 3);


  if (strcmp(myCol, "mmm") == 0) {
    inMenu = true;
  }
  if (strcmp(myCol, "ggg")== 0) {
    inMenu = false;
  }
  
  if (inMenu) {
    rainbow(50);
    rainbowCycle(20);
    
    
  } else {
    // Allume la Ring 1 en différente couleur
    if (strcmp(myCol, "1,r")==0) {
      lightUpRedRing1();
    }
    if (strcmp(myCol, "1,b")==0)  {
      lightUpBlueRing1();
    }
    if (strcmp(myCol, "1,g")==0) {
      lightUpGreenRing1();
    }
    if (strcmp(myCol, "1,y")==0) {
      lightUpYellowRing1();
    }
  
  
    // Allume la Ring 2 en différente couleur
    if (strcmp(myCol, "2,r")==0) {
      lightUpRedRing2();
    }
    if (strcmp(myCol, "2,b")==0)  {
      lightUpBlueRing2();
    }
    if (strcmp(myCol, "2,g")==0) {
      lightUpGreenRing2();
    }
    if (strcmp(myCol, "2,y")==0) {
      lightUpYellowRing2();
    }
  
  
    // Allume la Ring 3 en différente couleur
    if (strcmp(myCol, "3,r")==0) {
      lightUpRedRing3();
    }
    if (strcmp(myCol, "3,b")==0)  {
      lightUpBlueRing3();
    }
    if (strcmp(myCol, "3,g")==0) {
      lightUpGreenRing3();
    }
    if (strcmp(myCol, "3,y")==0) {
      lightUpYellowRing3();
    }
  
  
    // Allume la Ring 4 en différente couleur
    if (strcmp(myCol, "4,r")==0) {
      lightUpRedRing4();
    }
    if (strcmp(myCol, "4,b")==0)  {
      lightUpBlueRing4();
    }
    if (strcmp(myCol, "4,g")==0) {
      lightUpGreenRing4();
    }
    if (strcmp(myCol, "4,y")==0) {
      lightUpYellowRing4();
    }
  
  
    // Allume la Ring 5 en différente couleur
    if (strcmp(myCol, "5,r")==0) {
      lightUpRedRing5();
    }
    if (strcmp(myCol, "5,b")==0)  {
      lightUpBlueRing5();
    }
    if (strcmp(myCol, "5,g")==0) {
      lightUpGreenRing5();
    }
    if (strcmp(myCol, "5,y")==0) {
      lightUpYellowRing5();
    }
  
  
    // Allume la Ring 6 en différente couleur
    if (strcmp(myCol, "6,r")==0) {
      lightUpRedRing6();
    }
    if (strcmp(myCol, "6,b")==0)  {
      lightUpBlueRing6();
    }
    if (strcmp(myCol, "6,g")==0) {
      lightUpGreenRing6();
    }
    if (strcmp(myCol, "6,y")==0) {
      lightUpYellowRing6();
    }
  
  
    // Allume la Ring 7 en différente couleur
    if (strcmp(myCol, "7,r")==0) {
      lightUpRedRing7();
    }
    if (strcmp(myCol, "7,b")==0)  {
      lightUpBlueRing7();
    }
    if (strcmp(myCol, "7,g")==0) {
      lightUpGreenRing7();
    }
    if (strcmp(myCol, "7,y")==0) {
      lightUpYellowRing7();
    }
  
  
    // Allume la Ring 8 en différente couleur
    if (strcmp(myCol, "8,r")==0) {
      lightUpRedRing8();
    }
    if (strcmp(myCol, "8,b")==0)  {
      lightUpBlueRing8();
    }
    if (strcmp(myCol, "8,g")==0) {
      lightUpGreenRing8();
    }
    if (strcmp(myCol, "8,y")==0) {
      lightUpYellowRing8();
    }
  }

}

// Allume la Ring 1 en rouge
void lightUpRedRing1() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring1.setPixelColor(nbrLed, ring1.Color(255,0,0));
      ring1.show();
    }
}

// Allume la Ring 1 en bleu
void lightUpBlueRing1() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring1.setPixelColor(nbrLed, ring1.Color(0,0,255));
      ring1.show();
    }
}

// Allume la Ring 1 en vert
void lightUpGreenRing1() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring1.setPixelColor(nbrLed, ring1.Color(0,255,0));
      ring1.show();
    }
}

// Allume la Ring 1 en jaune
void lightUpYellowRing1() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring1.setPixelColor(nbrLed, ring1.Color(255,255,0));
      ring1.show();
    }
}



// Allume la Ring 2 en rouge
void lightUpRedRing2() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring2.setPixelColor(nbrLed, ring2.Color(255,0,0));
      ring2.show();
    }
}

// Allume la Ring 2 en bleu
void lightUpBlueRing2() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring2.setPixelColor(nbrLed, ring2.Color(0,0,255));
      ring2.show();
    }
}

// Allume la Ring 2 en vert
void lightUpGreenRing2() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring2.setPixelColor(nbrLed, ring2.Color(0,255,0));
      ring2.show();
    }
}

// Allume la Ring 2 en jaune
void lightUpYellowRing2() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring2.setPixelColor(nbrLed, ring2.Color(255,255,0));
      ring2.show();
    }
}





// Allume la Ring 3 en rouge
void lightUpRedRing3() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring3.setPixelColor(nbrLed, ring3.Color(255,0,0));
      ring3.show();
    }
}

// Allume la Ring 3 en bleu
void lightUpBlueRing3() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring3.setPixelColor(nbrLed, ring3.Color(0,0,255));
      ring3.show();
    }
}

// Allume la Ring 3 en vert
void lightUpGreenRing3() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring3.setPixelColor(nbrLed, ring3.Color(0,255,0));
      ring3.show();
    }
}

// Allume la Ring 3 en jaune
void lightUpYellowRing3() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring3.setPixelColor(nbrLed, ring3.Color(255,255,0));
      ring3.show();
    }
}




// Allume la Ring 4 en rouge
void lightUpRedRing4() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring4.setPixelColor(nbrLed, ring4.Color(255,0,0));
      ring4.show();
    }
}

// Allume la Ring 4 en bleu
void lightUpBlueRing4() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring4.setPixelColor(nbrLed, ring4.Color(0,0,255));
      ring4.show();
    }
}

// Allume la Ring 4 en vert
void lightUpGreenRing4() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring4.setPixelColor(nbrLed, ring4.Color(0,255,0));
      ring4.show();
    }
}

// Allume la Ring 4 en jaune
void lightUpYellowRing4() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring4.setPixelColor(nbrLed, ring4.Color(255,255,0));
      ring4.show();
    }
}





/*************************************/
/********** deuxième joueur **********/
/*************************************/




// Allume la Ring 5 en rouge
void lightUpRedRing5() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring5.setPixelColor(nbrLed, ring5.Color(255,0,0));
      ring5.show();
    }
}

// Allume la Ring 5 en bleu
void lightUpBlueRing5() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring5.setPixelColor(nbrLed, ring5.Color(0,0,255));
      ring5.show();
    }
}

// Allume la Ring 5 en vert
void lightUpGreenRing5() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring5.setPixelColor(nbrLed, ring5.Color(0,255,0));
      ring5.show();
    }
}

// Allume la Ring 5 en jaune
void lightUpYellowRing5() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring5.setPixelColor(nbrLed, ring5.Color(255,255,0));
      ring5.show();
    }
}



// Allume la Ring 6 en rouge
void lightUpRedRing6() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring6.setPixelColor(nbrLed, ring6.Color(255,0,0));
      ring6.show();
    }
}

// Allume la Ring 6 en bleu
void lightUpBlueRing6() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring6.setPixelColor(nbrLed, ring6.Color(0,0,255));
      ring6.show();
    }
}

// Allume la Ring 6 en vert
void lightUpGreenRing6() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring6.setPixelColor(nbrLed, ring6.Color(0,255,0));
      ring6.show();
    }
}

// Allume la Ring 6 en jaune
void lightUpYellowRing6() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring6.setPixelColor(nbrLed, ring6.Color(255,255,0));
      ring6.show();
    }
}





// Allume la Ring 7 en rouge
void lightUpRedRing7() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring7.setPixelColor(nbrLed, ring7.Color(255,0,0));
      ring7.show();
    }
}

// Allume la Ring 7 en bleu
void lightUpBlueRing7() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring7.setPixelColor(nbrLed, ring7.Color(0,0,255));
      ring7.show();
    }
}

// Allume la Ring 7 en vert
void lightUpGreenRing7() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring7.setPixelColor(nbrLed, ring7.Color(0,255,0));
      ring7.show();
    }
}

// Allume la Ring 7 en jaune
void lightUpYellowRing7() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring7.setPixelColor(nbrLed, ring7.Color(255,255,0));
      ring7.show();
    }
}




// Allume la Ring 8 en rouge
void lightUpRedRing8() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring8.setPixelColor(nbrLed, ring8.Color(255,0,0));
      ring8.show();
    }
}

// Allume la Ring 8 en bleu
void lightUpBlueRing8() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring8.setPixelColor(nbrLed, ring8.Color(0,0,255));
      ring8.show();
    }
}

// Allume la Ring 8 en vert
void lightUpGreenRing8() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring8.setPixelColor(nbrLed, ring8.Color(0,255,0));
      ring8.show();
    }
}

// Allume la Ring 8 en jaune
void lightUpYellowRing8() {
  for (int nbrLed = 0; nbrLed < 24; nbrLed++) {

      ring8.setPixelColor(nbrLed, ring8.Color(255,255,0));
      ring8.show();
    }
}



void checkIfWeAreNotAgainInMenu() {
  
  if (strcmp(myCol, "ggg")== 0) {
    inMenu = false;
  }
}



/*************************************/
/********* Animation du menu *********/
/*************************************/


// Fill the dots one after the other with a color
void colorWipe(uint32_t c, uint8_t wait) {
    byteReceived = Serial.readBytesUntil('\n', myCol, 3);

    for (uint16_t i = 0; i < ring1.numPixels() && inMenu; i++) {
        ring1.setPixelColor(i, c);
        ring1.show();
        ring2.setPixelColor(i, c);
        ring2.show();
        ring3.setPixelColor(i, c);
        ring3.show();
        ring4.setPixelColor(i, c);
        ring4.show();
        ring5.setPixelColor(i, c);
        ring5.show();
        ring6.setPixelColor(i, c);
        ring6.show();
        ring7.setPixelColor(i, c);
        ring7.show();
        ring8.setPixelColor(i, c);
        ring8.show();
        
        delay(wait);
    }
    checkIfWeAreNotAgainInMenu();
}


void rainbow(uint8_t wait) {
    uint16_t i, j;
  byteReceived = Serial.readBytesUntil('\n', myCol, 3);
    for (j = 0; j < 256 && inMenu; j++) {
        for (i = 0; i < ring1.numPixels() && inMenu; i++) {
          ring1.setPixelColor(i, Wheel1((i + j) & 255));
          ring2.setPixelColor(i, Wheel2((i + j) & 255));
          ring3.setPixelColor(i, Wheel3((i + j) & 255));
          ring4.setPixelColor(i, Wheel4((i + j) & 255));
          ring5.setPixelColor(i, Wheel5((i + j) & 255));
          ring6.setPixelColor(i, Wheel6((i + j) & 255));
          ring7.setPixelColor(i, Wheel7((i + j) & 255));
          ring8.setPixelColor(i, Wheel8((i + j) & 255));
          checkIfWeAreNotAgainInMenu();
        }

        if (j == 85) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        else if (j == 126) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        else if (j == 200) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        ring1.show();
        ring2.show();
        ring3.show();
        ring4.show();
        ring5.show();
        ring6.show();
        ring7.show();
        ring8.show();
        checkIfWeAreNotAgainInMenu();
        delay(wait);
    }
}



//Theatre-style crawling lights.
void theaterChase(uint32_t c, uint8_t wait) {
  byteReceived = Serial.readBytesUntil('\n', myCol, 3);
    for (int j = 0; j < 10 && inMenu; j++) { //do 10 cycles of chasing
        for (int q = 0; q < 3 && inMenu; q++) {
            for (uint16_t i = 0; i < ring1.numPixels() && inMenu; i = i + 3) {
                ring1.setPixelColor(i + q, c);  //turn every third pixel on
                ring2.setPixelColor(i + q, c);
                ring3.setPixelColor(i + q, c);
                ring4.setPixelColor(i + q, c);
                ring5.setPixelColor(i + q, c);  
                ring6.setPixelColor(i + q, c);
                ring7.setPixelColor(i + q, c);
                ring8.setPixelColor(i + q, c);
                //checkIfWeAreNotAgainInMenu();
            }
            ring1.show();
            ring2.show();
            ring3.show();
            ring4.show();
            ring5.show();
            ring6.show();
            ring7.show();
            ring8.show();
            delay(wait);
            checkIfWeAreNotAgainInMenu();

            for (uint16_t i = 0; i < ring1.numPixels() && inMenu; i = i + 3) {
                ring1.setPixelColor(i + q, 0);      //turn every third pixel off
                ring2.setPixelColor(i + q, 0);  
                ring3.setPixelColor(i + q, 0);  
                ring4.setPixelColor(i + q, 0);  
                ring5.setPixelColor(i + q, 0);      
                ring6.setPixelColor(i + q, 0);  
                ring7.setPixelColor(i + q, 0);  
                ring8.setPixelColor(i + q, 0);  
                checkIfWeAreNotAgainInMenu();
            }
        }
    }
}


//Theatre-style crawling lights with rainbow effect
void theaterChaseRainbow(uint8_t wait) {
  byteReceived = Serial.readBytesUntil('\n', myCol, 3);
    for (int j = 0; j < 128 && inMenu; j++) {   // cycle all 256 colors in the wheel

        if (j == 85) {
            byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        else if (j == 125) {
            byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        else if (j == 200) {
            byteReceived = Serial.readBytesUntil('\n', myCol, 3);
        }
        checkIfWeAreNotAgainInMenu();
        for (int q = 0; q < 2 && inMenu; q++) {
            for (uint16_t i = 0; i < ring1.numPixels() && inMenu; i = i + 3) {
                ring1.setPixelColor(i + q, Wheel1((i + j) % 255)); //turn every third pixel on
                ring2.setPixelColor(i + q, Wheel2((i + j) % 255));
                ring3.setPixelColor(i + q, Wheel3((i + j) % 255));
                ring4.setPixelColor(i + q, Wheel4((i + j) % 255));
                ring5.setPixelColor(i + q, Wheel5((i + j) % 255)); 
                ring6.setPixelColor(i + q, Wheel6((i + j) % 255));
                ring7.setPixelColor(i + q, Wheel7((i + j) % 255));
                ring8.setPixelColor(i + q, Wheel8((i + j) % 255));
                checkIfWeAreNotAgainInMenu();
            }
            ring1.show();
            ring2.show();
            ring3.show();
            ring4.show();
            ring5.show();
            ring6.show();
            ring7.show();
            ring8.show();
            checkIfWeAreNotAgainInMenu();
            delay(wait);

            for (uint16_t i = 0; i < ring1.numPixels() && inMenu; i = i + 3) {
                ring1.setPixelColor(i + q, 0);      //turn every third pixel off
                ring2.setPixelColor(i + q, 0);   
                ring3.setPixelColor(i + q, 0);   
                ring4.setPixelColor(i + q, 0);   
                ring5.setPixelColor(i + q, 0);      
                ring6.setPixelColor(i + q, 0);   
                ring7.setPixelColor(i + q, 0);   
                ring8.setPixelColor(i + q, 0);   
                checkIfWeAreNotAgainInMenu();
            }
        }
    }
}


// Input a value 0 to 255 to get a color value.
// The colours are a transition r - g - b - back to r.
uint32_t Wheel1(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring1.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring1.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring1.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}

uint32_t Wheel2(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring2.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring2.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring2.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}

uint32_t Wheel3(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring3.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring3.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring3.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}

uint32_t Wheel4(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring4.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring4.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring4.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


uint32_t Wheel5(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring5.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring5.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring5.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


uint32_t Wheel6(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring6.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring6.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring6.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


uint32_t Wheel7(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring7.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring7.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring7.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


uint32_t Wheel8(byte WheelPos) {
    WheelPos = 255 - WheelPos;
    if (WheelPos < 85) {
        return ring8.Color(255 - WheelPos * 3, 0, WheelPos * 3);
    }
    if (WheelPos < 170) {
        WheelPos -= 85;
        return ring8.Color(0, WheelPos * 3, 255 - WheelPos * 3);
    }
    WheelPos -= 170;
    return ring8.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


// Slightly different, this makes the rainbow equally distributed throughout
void rainbowCycle(uint8_t wait) {
    uint16_t i, j;

    byteReceived = Serial.readBytesUntil('\n', myCol, 3);
    for (j = 0; j < 256 * 1 && inMenu; j++) { // 1 cycles of all colors on wheel

        if (j == 85) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);;
        }
        
        else if (j == 128) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);;
        }

        else if (j == 200) {
          byteReceived = Serial.readBytesUntil('\n', myCol, 3);;
        }
        
        checkIfWeAreNotAgainInMenu();
        
        for (i = 0; i < ring1.numPixels() && inMenu; i++) {
            ring1.setPixelColor(i, Wheel1(((i * 256 / ring1.numPixels()) + j) & 255));
            ring2.setPixelColor(i, Wheel2(((i * 256 / ring2.numPixels()) + j) & 255));
            ring3.setPixelColor(i, Wheel3(((i * 256 / ring3.numPixels()) + j) & 255));
            ring4.setPixelColor(i, Wheel4(((i * 256 / ring4.numPixels()) + j) & 255));
            ring5.setPixelColor(i, Wheel5(((i * 256 / ring5.numPixels()) + j) & 255));
            ring6.setPixelColor(i, Wheel6(((i * 256 / ring6.numPixels()) + j) & 255));
            ring7.setPixelColor(i, Wheel7(((i * 256 / ring7.numPixels()) + j) & 255));
            ring8.setPixelColor(i, Wheel8(((i * 256 / ring8.numPixels()) + j) & 255));
            checkIfWeAreNotAgainInMenu();
        }
        ring1.show();
        ring2.show();
        ring3.show();
        ring4.show();
        ring5.show();
        ring6.show();
        ring7.show();
        ring8.show();
        checkIfWeAreNotAgainInMenu();
        delay(wait);
    }
}

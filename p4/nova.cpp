 //Sarah Nguyen
// Created by sarah on 4/5/2023.
// CPSC3200
//nova.cpp
//updated on 5/18/2023

#include <iostream>
#include <iomanip>
#include <ostream>
#include <string>
#include "nova.h"

using namespace std;

nova::nova(int *b, int *p, int *s, int l) {
    brightnessLumen = b;
    powerLumen = p;
    sizeLumen = s;
    len = l;
    lumenObjs = new lumen[len];
    currentGlows = new int[len];
    instability = new int[len];
    for(int x = 0; x < l; x++){
        lumenObjs[x] = lumen(brightnessLumen[x],sizeLumen[x],powerLumen[x]);
    }

}

nova::~nova()
{
    destroy();
}

void nova::copy(const nova &orig) {
    lumenObjs = new lumen[orig.len];
    for(int x = 0; x < orig.len; x++){
        lumenObjs[x] = orig.lumenObjs[x];
    }
    currentGlows = new int[orig.len];
    for(int x = 0; x < orig.len; x++){
        currentGlows[x] = orig.currentGlows[x];
    }
    instability = new int[orig.len];
    for(int x = 0; x < orig.len; x++){
        instability[x] = orig.instability[x];
    }
    brightnessLumen = orig.brightnessLumen;
    powerLumen = orig.powerLumen;
    sizeLumen = orig.sizeLumen;
    len = orig.len;
    inactive = orig.inactive;

}

void nova::destroy() {
    delete[] lumenObjs;
    delete[] currentGlows;
    delete[] instability;
    lumenObjs = nullptr;
    currentGlows = nullptr;
    instability = nullptr;
}

nova::nova(const nova &orig)
{
    copy(orig);
}
nova &nova::operator=(const nova &orig)
{
    if(this == &orig){
        return* this;
    }
    destroy();
    copy(orig);
    return *this;
}
//move copy
nova::nova(nova&& orig) noexcept
{
    len = orig.len;
    lumenObjs = orig.lumenObjs;
    brightnessLumen = orig.brightnessLumen;
    powerLumen = orig.powerLumen;
    sizeLumen = orig.sizeLumen;
    currentGlows = orig.currentGlows;
    instability = orig.instability;

    orig.len = 0;
    orig.lumenObjs = nullptr;
    orig.brightnessLumen = nullptr;
    orig.powerLumen = nullptr;
    orig.sizeLumen = nullptr;
    orig.currentGlows = nullptr;
    orig.instability = nullptr;
}

//move assignment
nova& nova::operator=(nova&& orig)
{
    swap(len, orig.len);
    swap(lumenObjs, orig.lumenObjs);
    swap(brightnessLumen, orig.brightnessLumen);
    swap(powerLumen, orig.powerLumen);
    swap(sizeLumen, orig.sizeLumen);
    swap(currentGlows, orig.currentGlows);
    swap(instability, orig.instability);
    inactive = orig.inactive;
    return *this;
}

int* nova::glow(int x){
    int* temp = new int[x];
    for (int j = 0; j < x; j++){
        int g = lumenObjs[j].glow();
        temp[j] = g;
        currentGlows[j] = g;
        if(!lumenObjs[j].isActive()) {inactive++;}
        if(!lumenObjs[j].isStable()) {instability[j]++;}
    }
    novaGlow++;
    return temp;
}

int nova::maxGlow(){
    int temp = -1;
    if(novaGlow == 0){ return temp; }
    for(int x = 0; x < len; x++){
        if(currentGlows[x] > temp){ temp = currentGlows[x];}
    }
    return temp;
}

int nova::minGlow(){
    int temp = -1;
    if(novaGlow == 0) {return temp;}
    temp = currentGlows[0];
    for(int x = 1; x < len; x++){
        if(temp > currentGlows[x]){temp = currentGlows[x];}
    }
    return temp;
}

void nova::recharge()
{
    if(inactive >= len/2){
        for(int x = 0; x < len; x++){
            lumenObjs[x].recharge();
        }
        inactive = 0;
    }
}

void nova::unstable(){
    for(int x = 0; x < len; x++){
        if(instability[x] > (novaGlow/2) && !(lumenObjs[x].isStable())){
            lumenObjs[x].stablize();
            instability[x] = 0;
        }
    }
}

int nova::getBrightness() const{
    return *brightnessLumen;
}

int nova::getPower() const{
    return *powerLumen;
}

int nova::getSize() const{
    return *sizeLumen;
}

int nova::getNumLumens() const
{
    return len;
}

 lumen* nova::getLumenObjs(){
     return lumenObjs;
 }


 nova nova::operator+(const nova &rhs)
 {
     int totalLen = len + rhs.len;
     int *combinedBrightness = new int[totalLen];
     int *combinedPower = new int[totalLen];
     int *combinedSize = new int[totalLen];

     for (int i = 0; i < len; i++) {
         combinedBrightness[i] = brightnessLumen[i];
         combinedPower[i] = powerLumen[i];
         combinedSize[i] = sizeLumen[i];
     }

     for (int i = 0; i < rhs.len; i++) {
         combinedBrightness[len + i] = rhs.brightnessLumen[i];
         combinedPower[len + i] = rhs.powerLumen[i];
         combinedSize[len + i] = rhs.sizeLumen[i];
     }

     nova result(combinedBrightness, combinedPower, combinedSize, totalLen);
     delete[] combinedBrightness;
     delete[] combinedPower;
     delete[] combinedSize;
     return result;
 }

 //precondition: nova and lumen object must exist
 //postcondition: the total number of lumens in increased and could also
 nova nova::operator+(int n) const
 {
     int totalLen = len + n;
     int *combinedBrightness = new int[totalLen];
     int *combinedPower = new int[totalLen];
     int *combinedSize = new int[totalLen];

     for (int i = 0; i < len; i++) {
         combinedBrightness[i] = brightnessLumen[i];
         combinedPower[i] = powerLumen[i];
         combinedSize[i] = sizeLumen[i];
     }

     for (int i = len; i < totalLen; i++) {
         combinedBrightness[i] = 0;
         combinedPower[i] = 0;
         combinedSize[i] = 0;
     }

     nova result(combinedBrightness, combinedPower, combinedSize, totalLen);
     delete[] combinedBrightness;
     delete[] combinedPower;
     delete[] combinedSize;
     return result;
 }

 //precondition: two nova objects must exist
 //postcondition: the total number of lumens in increased and could also
 nova& nova::operator+=(lumen& rhs) {
     // Create a new lumen object with the values from rhs
     lumen newLumen(rhs.getBrightness(), rhs.getPower(), rhs.getSize());

     // Increase the length of the lumenObjs array by 1
     lumen* temp = new lumen[len + 1];
     for (int i = 0; i < len; i++) {
         temp[i] = lumenObjs[i];
     }
     delete[] lumenObjs;
     lumenObjs = temp;
     len++;

     // Add the new lumen object to the lumenObjs array
     lumenObjs[len - 1] = newLumen;

     // Update the inactive count and novaGlow
     if (!newLumen.isActive()) {
         inactive++;
     }
     novaGlow++;

     // Return the updated nova object
     return *this;
 }

 //precondition: nova and lumen object must exist
 //postcondition: the total number of gridFleas in increased and could also
 //  increase the number of active gridFleas
 nova &nova::operator+=(int rhs) {
     for (int i = 0; i < len; i++) {
         brightnessLumen[i] += rhs;
     }
     return *this;
 }

 //precondition: two nova objects must exist
 //postcondition: no state change
 bool nova::operator==(const nova &rhs)
 {
     if (len != rhs.len)
         return false;

     for (int i = 0; i < len; i++) {
         if (brightnessLumen[i] != rhs.brightnessLumen[i] ||
             powerLumen[i] != rhs.powerLumen[i] ||
             sizeLumen[i] != rhs.sizeLumen[i] ||
             currentGlows[i] != rhs.currentGlows[i] ||
             instability[i] != rhs.instability[i]) {
             return false;
         }
     }

     return true;
 }

 //precondition: nova object must exist
 //postcondition: no state change
 bool nova::operator==(int rhs)
 {
     return len == rhs;
 }

 bool nova::operator!=(nova &rhs)
 {
     return !(*this == rhs);
 }

 bool nova::operator!=(int rhs)
 {
     return len != rhs;
 }

 bool nova::operator>(nova &rhs)
 {
     return maxGlow() > rhs.maxGlow();
 }

 bool nova::operator>(int rhs)
 {
     return maxGlow() > rhs;
 }

 bool nova::operator<(nova &rhs)
 {
     return minGlow() < rhs.minGlow();
 }

 bool nova::operator<(int rhs)
 {
     return minGlow() < rhs;
 }

 bool nova::operator>=(nova &rhs)
 {
     return maxGlow() >= rhs.maxGlow();
 }

 bool nova::operator>=(int rhs)
 {
     return maxGlow() >= rhs;
 }

 bool nova::operator<=(nova &rhs)
 {
     return minGlow() <= rhs.minGlow();
 }

 bool nova::operator<=(int rhs)
 {
     return minGlow() <= rhs;
 }

 //mix mode
 nova operator+(lumen &lhs, nova &rhs)
 {
     nova result = rhs;  // Create a copy of the rhs nova object

     // Add the lumen object to the result nova object
     result += lhs;

     return result;
 }

//precondition: nova object must exist
//postcondition: no state change
 bool operator==(int lhs, nova &rhs)
 {
     return rhs.getBrightness() == lhs;
 }

//precondition: nova object must exist
//postcondition: no state change
 bool operator!=(int lhs, nova &rhs)
 {
     return rhs.getBrightness() != lhs;
 }

//precondition: inFest object must exist
//postcondition: no state change
 bool operator>(int lhs, nova &rhs)
 {
     return rhs.maxGlow() > lhs;
 }

//precondition: nova object must exist
//postcondition: no state change
 bool operator<(int lhs, nova &rhs)
 {
     return rhs.minGlow() < lhs;
 }

 bool operator>=(int lhs, nova &rhs)
 {
     return rhs.maxGlow() >= lhs;
 }

 bool operator<=(int lhs, nova &rhs)
 {
     return rhs.minGlow() <= lhs;
 }

ostream& operator<<(std::ostream& os, nova& n)
{
     os << "Number of Lumens: " << n.getNumLumens() << std::endl;

     const lumen* lumenObjs = n.getLumenObjs();
     for (int i = 0; i < n.getNumLumens(); i++) {
         os << "Lumen " << (i + 1) << ": " << lumenObjs[i] << std::endl;
     }

     return os;
 }
/* Implementation Invariant
 * glow(int x) -
 * should return an array of integers with length x. The function should modify the currentGlows and instability
 * arrays according  * to the glow intensity of each lumen object. The function should not cause any memory leaks
 * or access violations during its execution.
 *maxGlow() -
 * should return the maximum glow intensity among all lumen objects. If there are no active lumen objects,
 * the function should return -1.
 * minGlow() - should return the minimum glow intensity among all lumen objects. If there are no active lumen objects,
 * the function should return -1.
 * recharge() - should recharge all lumen objects if the number of inactive lumen objects is greater than or equal
 * to half of the total number of lumen objects. The function should not cause any memory leaks or access violations
 * during its execution.
 * unstable() -
 * should stabilize all unstable lumen objects if their instability count is greater than half of the total
 * number of novaGlow counts. The function should not cause any memory leaks or access violations during its execution.
 * The nova object should always maintain a non-negative total number of lumens. It should not be possible for the total
 * number of lumens to become negative at any point during the execution.
 * The friend operator<< should correctly output the total number of lumens in the nova object when used with the ostream object.
 * The comparison operations (==, !=, >, <, >=, <=) should consistently compare the total number of lumens in the nova
 * object with another nova object or an integer value. The comparisons should adhere to the expected behavior of these operators.
 */
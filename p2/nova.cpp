//Sarah Nguyen
// Created by sarah on 4/5/2023.
// CPSC3200
//nova.cpp

#include <iostream>
#include <iomanip>
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
nova::nova(nova&& orig)
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
 */
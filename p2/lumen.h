/*Sarah Nguyen
 * CPSC3200 - P2
 * lumen.h
 */

/* Class Invariant:
 * the 'brightness' and 'power' variables must always be greater than 0. The 'size'
 * variable is a read only since it never changes or doesnt have the ability to change. The size
 * variable must always be greater than or equal to the current value of 'power'.
 * This is because the method 'glow()' uses these variables in order to calculate the 'light' output.
 */
#ifndef LUMEN_H
#define LUMEN_H

#include <iostream>
#include <iomanip>
#include <string>

class lumen
{
private:
    int brightness;
    int brightnessBackup;
    int power;
    int powerBackup;
    int size;
    int light;
    bool active = true;
    int requests;
    const int maxRequests = 4;
    int powerThreshold;

public:
    lumen(int b, int p, int s);
    lumen();
    lumen &operator=(const lumen &orig);
    // pre: none
    // post: 'power' is decremented by 1 and 'requests' is incremented by 1. if the lumen isnt active then
    // it would set the value of 'light' to half the brightness. if it is active and not stable then it sets
    //'light' to the value of all three parameters of a lumen obj is multiplied to each other. else set
    // light to a value of brightness multiplied by size. then you would return the value of 'light'
    int glow();
    bool isActive();
    bool isStable();
    // pre: none
    // post: if requests is greater than o equal to 'maxRequests' and 'power' is greater than
    // or equal to 0 then 'requests' is reset to 0, 'brightness' is set to 'brightnessBackup', 'power' is set to
    //'powerBackup', and 'active' is set to true. The lumen object returns back to its orginal state
    void reset();
    //recharge()
    //pre: none
    //post: recharges lumen objects that are inactive
    // (when amount of inactive lumen in arr >= len/2), update inactive integer
    void recharge();
    void stablize();
};

#endif // LUMEN_H
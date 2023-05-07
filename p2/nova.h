//Sarah Nguyen
// Created by sarah on 4/5/2023.
//nova.h

#ifndef NOVA_H
#define NOVA_H

#include <iostream>
#include <iomanip>
#include <string>
#include "lumen.h"
/*class invariant
 * The len member variable is equal to the number of lumen objects stored in the lumenObjs array
 * lumenObjs arry contains len lumen objs initialized with brightness, power, and size
 * currentglows and instability has len elements
 * inactive member variable represents the number of inactive lumen objs
 * novglow variable represents the number of times the flow method has been called
 * glow method returns an arry of int values representing current glow of lumen obj & updates currentglows
 * and instability arrays accordingly
 * max glow & minglow methods return the maximum glow values among lumen objs
 * recharge recharges all inactive lumen objects if the number of inactive lumen objs is >= len/2
 * unstable stabilizes all lumen objects that have become unstable or were not already stable
 *
 *
 */

class nova {
private:
    lumen *lumenObjs;
    int len;
    int inactive = 0;
    int *brightnessLumen;
    int *powerLumen;
    int *sizeLumen;
    int *currentGlows;
    int *instability;
    int novaGlow = 0;
    //Copy Helper Function
    //pre: none
    //post: copy data from right to left
    //helper function for assignment operator and move assignment operator
    void copy(const nova& orig);
    //Helper Function destroy()
    //pre: none
    //post: deletes all dynamically allocated memory
    void destroy();
public:
    nova(int *b, int *p, int *s, int l);
    ~nova();
    nova(const nova &orig);
    nova &operator=(const nova &orig);
    //Move Constructor
    //pre: right is a expiring temporary
    //post: initialize left with right, update right dynamic memory to nullpointer (no aliasing)
    nova(nova&& orig);
    //Move Assignment Operator
    //pre: right nova is an expiring temporary
    //post: swap right dynamic with left dynamic,
    // update inactive and novaGlowCall with right values, return updated nova
    nova& operator=(nova&& orig);
    //minGlow()
    //pre: none
    //post: return int minGlow value out of lumens in arr greater than 0 (if 0, that means glow has not been
    // inacted upon lumen object in array), error code is -1 (occurs if no glow() calls have occured)
    int minGlow();
    //maxGlow()
    //pre: none
    //post: return maxGlow value out of lumens in arr, error code is -1 (occurs if no glow() calls have occured)
    int maxGlow();
    //glow(int x) Function
    //pre: none
    //post: updated inactive value, instability array, currentGlow array, and nova glow. Returns array of
    // currentGlows (values of current glow returns for lumens that have used glow() function)
    int* glow(int x);
    //unstable()
    //pre: none
    //post: stabalizes persistently unstable
    // lumen objects through lumen stabilize(), update instability array
    void unstable();
    //recharge()
    //pre: none
    //post: recharges lumen objects that are inactive
    // (when amount of inactive lumen in arr >= len/2), update inactive integer
    void recharge();
};


#endif //NOVA_H

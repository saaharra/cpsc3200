/*Sarah Nguyen
 * CPSC3200 - P4
 * lumen.h
 * updated on 5/18/2023
 */

/* Class Invariant:
 * the 'brightness' and 'power' variables must always be greater than 0. The 'size'
 * variable is a read only since it never changes or doesnt have the ability to change. The size
 * variable must always be greater than or equal to the current value of 'power'.
 * This is because the method 'glow()' uses these variables in order to calculate the 'light' output.
 * The object state should remain consistent after any operation,
 * such as increment, decrement, addition, subtraction, etc.
 * The equality and comparison operators should provide consistent results and follow the expected
 * behavior, such as reflexivity, transitivity, and symmetry.
 */
#ifndef LUMEN_H
#define LUMEN_H

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

class lumen
{
protected:
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
    int getBrightness()const;
    int getPower()const;
    int getSize()const;

    //precondition: lumen object exists
    //poscondition: does not change the state of the object
    lumen& operator++();

    //precondition: lumen object exists
    //poscondition: does not change the state of the object
    lumen operator++(int);

    //precondition: lumen object exists
    //poscondition: if there are zero moves and lumen tries to move,
    // it will be set inactive
    lumen& operator--();

    //precondition: lumen object exists
    //poscondition: if there are zero moves and lumen tries to move,
    // it will be set inactive
    lumen operator--(int);

    //precondition: lumen object exists
    //poscondition: does not change the state of the object
    lumen operator+(int rhs) const;

    //precondition: lumen object exists
    //poscondition: does not change the state of the object
    lumen operator+(const lumen& rhs) const;

    //precondition: lumen object exists
    //poscondition: if there are zero moves and lumen tries to move,
    // it will be set inactive
    lumen operator-(int rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    lumen &operator+=(int rhs);

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    lumen &operator+=(lumen &rhs);

    //precondition: lumen object exists
    //postcondition: if there are zero moves and lumen tries to move,
    // it will be set inactive
    lumen &operator-=(int rhs);

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator==(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator==(int rhs) const;

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator!=(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator!=(int rhs) const;

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator>(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator>(int rhs) const;

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator<(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator<(int rhs) const;

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator>=(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator>=(int rhs) const;

    //precondition: lumen objects exists
    //postcondition: does not change the state of the object
    bool operator<=(lumen &rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    bool operator<=(int rhs) const;

    //precondition: lumen object exists
    //postcondition: does not change the state of the object
    friend ostream& operator<<(std::ostream& os, const lumen& l);

};
//precondition: lumen objects exists
//postcondition: does not change the state of the object
lumen operator+(int lhs, lumen const &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
lumen operator-(int lhs, lumen const &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
bool operator==(int lhs, lumen &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
bool operator!=(int lhs, lumen &rhs);

//precondition: lumen objects exists
//postcondition:does not change the state of the object
bool operator>(int lhs, lumen &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
bool operator<(int lhs, lumen &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
bool operator>=(int lhs, lumen &rhs);

//precondition: lumen objects exists
//postcondition: does not change the state of the object
bool operator<=(int lhs, lumen &rhs);

#endif // LUMEN_H
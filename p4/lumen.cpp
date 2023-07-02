//Sarah Nguyen
//Created by sarah on 4/5/2023.
//CPSC3200
//lumen.cpp
//updated on 5/18/2023

#include <iostream>
#include <ostream>
#include "lumen.h"

using namespace std;

lumen::lumen(int b, int p, int s)
{
    if (b <= 0 || p <= 0 || s <= 0)
    {
        throw std::invalid_argument("the values you passed in must be greater than 0");
    }
    brightnessBackup = b;
    powerBackup = p;
    brightness = b;
    power = p;
    size = s;
    powerThreshold = brightness / s;
    requests = 0;
    light = 0;
}

lumen::lumen()
{
    brightnessBackup = 1;
    powerBackup = 1;
    brightness = 1;
    power = 1;
    size = 1;
    powerThreshold = brightness / size;
    requests = 0;
    light = 0;
}


lumen &lumen::operator=(const lumen &orig)
{
    if (this == &orig)
    {
        return *this;
    }
    brightness = orig.brightness;
    brightnessBackup = orig.brightnessBackup;
    power = orig.power;
    powerBackup = orig.powerBackup;
    size = orig.size;
    powerThreshold = orig.powerThreshold;
    requests = orig.requests;
    active = orig.active;
    return *this;
}


int lumen::glow()
{
    requests++;
    if (!isActive())
    {
        light = brightness / 2;
    }
    else if (!isStable())
    {
        light = power * (brightness * size);
    }
    else if (isActive() && isStable())
    {
        light = brightness * size;
    }
    power--;
    return light;
}

bool lumen::isActive()
{
    if (power < powerThreshold)
    {
        active = false;
    }
    else
    {
        active = true;
    }
    return active;
}

bool lumen::isStable()
{

    return power >= size;
}

void lumen::reset()
{
    if (requests <= maxRequests && power >= 0)
    {
        requests = 0;
        brightness = brightnessBackup;
        power = powerBackup;
        active = true;
    }
    else
    {
        brightness--;
    }
}

//this works with stable objs
void lumen::recharge()
{
    if(!isActive()){
        power = powerThreshold * power;
        active = true;

    }
}

void lumen::stablize(){
    if(!isStable()){
        power = power - size;
    }
}

int lumen::getBrightness() const{
    return brightness;
}

int lumen::getPower() const{
    return power;
}

int lumen::getSize() const{
    return size;
}

// Prefix increment operator
lumen& lumen::operator++()
{
    ++brightness;
    return *this;
}

// Postfix increment operator
lumen lumen::operator++(int)
{
    lumen temp = *this;
    ++brightness;
    return temp;
}


// Prefix decrement operator
lumen& lumen::operator--()
{
    --brightness;
    return *this;
}

// Postfix decrement operator
lumen lumen::operator--(int)
{
    lumen temp = *this;
    --brightness;
    return temp;
}

// Addition operator
lumen lumen::operator+(int rhs) const
{
    lumen result = *this;
    result.brightness += rhs;
    return result;
}

lumen lumen::operator+(const lumen& rhs) const {
    lumen result;
    result.brightness = brightness + rhs.brightness;
    result.power = power + rhs.power;
    result.size = size + rhs.size;
    return result;
}


// Subtraction operator
lumen lumen::operator-(int rhs) const
{
    lumen result = *this;
    result.brightness -= rhs;
    return result;
}

// Compound addition assignment operator
lumen& lumen::operator+=(int rhs)
{
    brightness += rhs;
    return *this;
}

lumen& lumen::operator+=(lumen& rhs) {
    brightness += rhs.brightness;
    power += rhs.power;
    size += rhs.size;
    return *this;
}

// Compound subtraction assignment operator
lumen& lumen::operator-=(int rhs)
{
    brightness -= rhs;
    return *this;
}

// Equality operator (lumen object == lumen object)
bool lumen::operator==(lumen& rhs) const
{
    return brightness == rhs.brightness;
}

// Equality operator (lumen object == integer)
bool lumen::operator==(int rhs) const
{
    return brightness == rhs;
}

// Inequality operator (lumen object != lumen object)
bool lumen::operator!=(lumen& rhs) const
{
    return brightness != rhs.brightness;
}

// Inequality operator (lumen object != integer)
bool lumen::operator!=(int rhs) const
{
    return brightness != rhs;
}

// Greater than operator (lumen object > lumen object)
bool lumen::operator>(lumen& rhs) const
{
    return brightness > rhs.brightness;
}

// Greater than operator (lumen object > integer)
bool lumen::operator>(int rhs) const
{
    return brightness > rhs;
}

// Less than operator (lumen object < lumen object)
bool lumen::operator<(lumen& rhs) const
{
    return brightness < rhs.brightness;
}

bool lumen::operator<(int rhs) const
{
    return brightness < rhs;
}

bool lumen::operator>=(lumen &rhs) const
{
    return brightness >= rhs.brightness;
}


bool lumen::operator>=(int rhs) const
{
    return brightness >= rhs;
}

bool lumen::operator<=(lumen &rhs) const
{
    return brightness <= rhs.brightness && power <= rhs.power;
}

bool lumen::operator<=(int rhs) const
{
    return brightness <+ rhs;
}


lumen operator+(int lhs, lumen const &rhs)
{
    int newBrightness = lhs + rhs.getBrightness();
    int newPower = lhs + rhs.getPower();
    int newSize = lhs + rhs.getSize();

    return lumen(newBrightness, newPower, newSize);
}


lumen operator-(int lhs, lumen const &rhs)
{
    int newBrightness = lhs - rhs.getBrightness();
    int newPower = lhs - rhs.getPower();
    int newSize = lhs - rhs.getSize();

    return lumen(newBrightness, newPower, newSize);
}

bool operator==(int lhs, lumen &rhs)
{
    return (lhs == rhs.getBrightness()) && (lhs == rhs.getPower()) && (lhs == rhs.getSize());
}

bool operator!=(int lhs, lumen &rhs)
{
    return (lhs != rhs.getBrightness()) && (lhs != rhs.getPower()) && (lhs != rhs.getSize());
}

bool operator>(int lhs, lumen &rhs)
{
    return (lhs > rhs.getBrightness()) && (lhs > rhs.getPower()) && (lhs > rhs.getSize());
}

bool operator<(int lhs, lumen &rhs)
{
    return (lhs < rhs.getBrightness()) && (lhs < rhs.getPower()) && (lhs < rhs.getSize());

}

bool operator>=(int lhs, lumen &rhs)
{
    return (lhs >= rhs.getBrightness()) && (lhs >= rhs.getPower()) && (lhs >= rhs.getSize());
}
bool operator<=(int lhs, lumen &rhs)
{
    return (lhs <= rhs.getBrightness()) && (lhs <= rhs.getPower()) && (lhs <= rhs.getSize());

}

std::ostream& operator<<(std::ostream& os, const lumen& l) {
    os << "Brightness: " << l.getBrightness() << ", ";
    os << "Power: " << l.getPower() << ", ";
    os << "Size: " << l.getSize();
    return os;
}

/*Implementation Invariants
 * glow method - this should only be called 'maxRequests' times before a reset method would be required
 * this calls to the isActive method and the isStable method to make sure that the lumen is in a state that would
 * be able to produce light rather than a value relating to dimness
 *
 * isActive method - the 'active' variable must be set to 'true' if the power is greater than o equal to
 * 'powerThreshold', otherwise it would be false.
 *
 * isStable method - in order for the lumen the size must always be greater than or equal to the
 * current value of 'power' otherwise the lumen would be unstable
 *
 * reset method - the reset method would only work if 'requests' exceed the 'maxRequests' and the current 'power' is larger than or equal to 0
 * otherwise your brightness would dim each time an invalid reset request is asked for
 *
 * recharge method - this method only works for stable objects
 *
 * The overloaded operators should handle edge cases and potential errors gracefully, such as avoiding arithmetic
 * overflow/underflow, considering data type compatibility, and maintaining data consistency.
 * The output stream insertion operator (<<) should correctly format and display
 * the lumen object's properties when used with ostream.
 */
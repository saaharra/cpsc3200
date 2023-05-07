//Sarah Nguyen
//CPSC3200 - P1
//lumen.cs

/* Class Invariant:
 * the 'brightness' and 'power' variables must always be greater than 0. The 'size' 
 * variable is a read only since it never changes or doesnt have the ability to change. The size 
 * variable must always be greater than or equal to the current value of 'power'. 
 * This is because the method 'glow()' uses these variables in order to calculate the 'light' output.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class lumen
    {
        //variables to hold
        private int brightness;
        private readonly int brightnessBackup;
        private int power;
        private readonly int powerBackup;
        private readonly int size;
        private int light;
        private bool active = true;
        private int requests;
        private const int maxRequests = 4;
        private int powerThreshold;

        public lumen(int b, int p, int s)
        {
            
            if (b <= 0 || p <= 0 || s <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
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

        //pre: none
        //post: 'power' is decremented by 1 and 'requests' is incremented by 1. if the lumen isnt active then 
        //it would set the value of 'light' to half the brightness. if it is active and not stable then it sets
        //'light' to the value of all three parameters of a lumen obj is multiplied to each other. else set 
        //light to a value of brightness multiplied by size. then you would return the value of 'light'
        public int glow()
        {
            
            requests++;
            if (!isActive())
            {
                light = brightness / 2;
                power--;
            }
            else if (!isStable())
            {
                light = power * (brightness * size);
                power--;
            }
            else if(isActive() && isStable())
            {
                light = brightness * size;
                power--;
            }
            return light;
        }

        public bool isActive()
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

        public bool isStable()
        {
            if (power >= size)
            {
                return true;
            }
            return false;
        }

        //pre: none
        //post: if requests is greater than o equal to 'maxRequests' and 'power' is greater than 
        //or equal to 0 then 'requests' is reset to 0, 'brightness' is set to 'brightnessBackup', 'power' is set to
        //'powerBackup', and 'active' is set to true. The lumen object returns back to its orginal state
        public void reset()
        {
            if (requests >= maxRequests && power >= 0)
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
    }
}

/*Implementation Invariants
 * glow method - this should only be called 'maxRequests' times before a reset method would be required
 * this calls to the isActive method and the isStable method to make sure that the lumen is in a state that would 
 * be able to produce light rather than a value relating to dimness
 * 
 * isActive method - the 'active' variable must be set to 'true' if the power is greater than o equal to 
 * 'powerThreashold', otherwise it would be false.
 * 
 * isStable method - in order for the lumen the size must always be greater than or equal to the 
 * current value of 'power' otherwise the lumen would be unstable
 * 
 * reset method - the reset method would only work if 'requests' exceed the 'maxRequests' and the current 'power' is larger than or equal to 0
 * otherwise you brightness would dim each time an invalid reset request is asked for
 */

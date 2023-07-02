/* Sarah Nguyen
 * CPSC3200 - 01
 * guard.cs
 * 05/20/2023
 */

/* Class Invariant -
 * The shields array must not be null.
 * The shields array should contain non-negative integers representing the shield strength.
 * The viableCount variable should accurately represent the number of shields with non-zero strength.
 * The number of viable shields (viableCount) should be greater than half of the total number of shields (shields.Length / 2) 
 * for the guard to be considered alive.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public class guard : IGuard
    {
        protected uint[] shields;
        protected int viableCount = 0;

        public guard(uint[] s)
        {
            if (s == null)
            {
                throw new System.ArgumentException("Invalid Array Passed. Null.");
            }
            shields = s;
            for (int i = 0; i < shields.Length; i++)
            {
                if (shields[i] != 0) { viableCount++; }
            }
        }

        //pre:The guard must be alive (isAlive() returns true).
        //The index x should be a non-negative integer.
        //The index x should be within the valid range (0 <= x<shields.Length).
        //The shield strength at index x should be greater than 0.
        //post:the guard is in the up mode (checkMode() returns true), the shield strength at index x is decremented by 1.
        // if  the guard is in the down mode (checkMode() returns false), the shield strength at index x is set to 0.
        //If the shield strength at index x becomes 0 after the block operation, the viableCount variable is decremented by 1.
        public virtual void block(int x)
        {
            if (x < 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            if (isAlive() && x >= 0 && x < shields.Length && shields[x] > 0)
            {
                if (checkMode())
                    shields[x]--; // up mode
                else
                    shields[x] = 0; // down mode

                if (shields[x] == 0)
                    viableCount--;
            }
        }

        public bool isAlive()
        {
            return viableCount > (shields.Length / 2);
        }
        public bool checkMode()
        {
            return (viableCount % 2 == 0);
            //true -> up, false -> down
        }

        public int getViableCount()
        { return viableCount; }
    }
}

/*Implementation Invariants - 
 * The block method should decrement the shield strength at the specified index (x) if the guard is alive and the index is within the valid range (0 <= x < shields.Length).
 * If the guard is in the up mode (as determined by the checkMode method), the shield strength at the specified index (x) should be decremented by 1.
 * If the guard is in the down mode (as determined by the checkMode method), the shield strength at the specified index (x) should be set to 0.
 * If the shield strength at the specified index (x) reaches 0, the viableCount variable should be decremented.
*/

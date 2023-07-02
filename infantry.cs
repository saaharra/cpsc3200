/* Sarah Nguyen
 * CPSC3200 - 01
 * infantry.cs
 * 04/20/2023
 * updated 05/25/2023
 */

/*class invariant
 * the constructor calls the base class, so you can look at fighter.cs to 
 * see more details of what needed to be done. this is the child class for fighter
 * in addition, canRest and hasReverse are set to their bool states.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public class infantry : fighter
    {
        private bool canReset = true;
        private bool hasReversed = false;
        public infantry(int x, int y, int s, int r, uint[] a) : base(x, y, s, r, a) { }
        public infantry() : base() { }
        //pre: see the pre condition in fighter.cs
        //post: state of hasreverse is changed based on if it has moved back 
        public override void move(int x, int y)
        {
            if (canReset)
            {
                canReset = false;
            }

            if (hasReversed && y < column)
            {
                return;
            }
            base.move(x, y);
            hasReversed = y < column;
        }

        //pre: p must be greater than 0 & fighter obj must be alive
        //post: The artillery array of the fighter object is updated by subtracting the fighter's
        //strength value from the values in the artillery array
        //at positions that are a distance of p away from the fighter's current row position.
        //If the updated value of an artillery position becomes negative, it is set to zero.
        public override void shift(int p)
        {
            if (p < 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            row += p;
        }

        //see the pre and post for fighter.cs
        //post: canrest is changed to false if canreset is true
        public override bool target(int x, int y, int q)
        {
            if (!canReset || !isAlive)
            {
                return false;
            }

            bool result = base.target(x, y, q);

            if (!result)
            {
                canReset = false;
            }

            return result;
        }



        //pre: The fighter object must be alive.
        //post: If the fighter object is alive, the canReset variable is set to
        //true and hasReversed is set to false. If the fighter object is not alive, an exception is thrown.
        public void reset()
        {
            if (isAlive)
            {
                canReset = true;
                hasReversed = false;
            }
            else
            {
                throw new Exception("Cannot reset a dead infantry object");
            }
        }
    }
}

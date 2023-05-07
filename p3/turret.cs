/* Sarah Nguyen
 * CPSC3200 - 01
 * turret.cs
 * 04/20/2023
 */

/*class invariant
 * the constructor calls the base class, so you can look at fighter.cs to 
 * see more details of what needed to be done. this is the child class for fighter
 * in addition, has the value of numfailed requests and the maxfailed requests that
 * are initalized in the turret constructor 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3
{
    public class turret : fighter
    {
        private int numFailedRequests;
        private int maxFailedRequests;

        public turret() : base() { }
        public turret(int x, int y, int s, int r, int[] a) : base(x, y, s, r, a)
        {
            numFailedRequests = 0;
            maxFailedRequests = 3;
        }
        
        //pre: none
        //post: none
        //move just does a return cause it doesnt do anything for this class
        public override void move(int x, int y)
        {
            //turrets may not move
            return;
        }

        //pre: none
        //post: If p is less than 0, an exception is thrown with the message
        //"Your set value must be greater than zero".
        //If numFailedRequests is greater than or equal to maxFailedRequests,
        //the isAlive variable is set to false.
        //Otherwise, the column variable is incremented by p.
        public override void shift(int p)
        {
            if (p < 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }

            else if (numFailedRequests >= maxFailedRequests)
            {
                isAlive = false;
                return;
            }
            range += p;
        }

        //pre: x, y, and q must be non-negative integers
        //post: If the target is successfully hit (i.e. base.target(x, y, q) returns true),
        //numFailedRequests is set to 0.
        //If the target is not hit, numFailedRequests is incremented by 1.
        //If numFailedRequests is greater than or equal to maxFailedRequests,
        //isAlive is set to false.
        public override bool target(int x, int y, int q)
        {
            bool result = base.target(x, y, q);

            if (!result)
            {
                numFailedRequests++;
                if (numFailedRequests >= maxFailedRequests)
                {
                    isAlive = false;
                }
            }
            else
            {
                numFailedRequests = 0;
            }

            return result;
        }

        //pre: s must be a non-negative integer 
        //post: If isAlive is false, calling the revived method with a positive integer s
        //sets isAlive to true and adds s to the current value of strength.
        public void revived(int s)
        {
            if (!isAlive)
            {
                strength += s;
                isAlive = true;
            }
        }
    }
}

/*implementation invariants
 *  move - if the object is alive then you can move the piece based on the row and column 
 *  that is passed into through the parameters. This can be overriden by the child classes
 *  shift - child class overrides the base class, in shift it shifts the column value of the 
 *  infantry and moves it. 
 *  target - passes in row and col and strength q, if the obj at the row and col has a bigger strength
 *  then it kills the target if the request for target failed then the number of failed requests
 *  increases
 *  revive - brings back the turret from the dead and increases its strength 
 */
/* Sarah Nguyen
 * CPSC3200 - 01
 * infantryGuard.cs
 * 05/20/2023
 */

// Class Invariant:
// - The shields array should not be null and consists of nonnegative numbers
// - The length of the shields array should be greater than 0.
// - The infantryObj should not be null.
// - the client passes in the shields array and the infantry obj through the construtor

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public class infantryGuard : guard
    {
        infantry infantryObj;
        public infantryGuard(uint[] shields, infantry infantryInstance) : base(shields)
        {
            infantryObj = infantryInstance;
        }

        //pre: amount parametere should be a non-negative value
        //post: shields of infantry have been replenished to a certain amount
        //shields array remains unchange except for the increased values
        public void ReplenishShields(uint amount)
        {
            for(int i = 0; i < shields.Length; i++)
            {
                shields[i] = shields[i] + amount;
            }
        }

        //pre: x and y should be valid coordinates within range of the infantrys movement area
        //it should also be values greater than 0
        //post: infantry guard is in an offensive state and guard has blocked attack by deducting
        //the appropriate shield value. infatry shift values and has targeted an enemy
        //infantry state then gets reset
        public void PerformOffensiveMovement(int x, int y)
        {
            if(x <= 0 || y <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            if(isInOffense())
            {
                block(x + y);
                infantryObj.shift(x + y);
                infantryObj.target(x, y, x + y);
            }
            infantryObj.reset();
        }

        private bool isInOffense()
        {
            return infantryObj.getRow() > shields.Length;
        }
    }
}

/* Implementation Invariant:
 * replenishedShields - this should add the passed in value to the existing value of
 * the shield 
 * The values in the shields array should always be non-negative.
 * isInOffense -  The shields array length should be consistent with the number of shields assigned to the infantry guard.
 */


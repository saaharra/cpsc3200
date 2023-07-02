/* Sarah Nguyen
 * CPSC3200 - 01
 * infantrySkipGuard.cs
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
    public class infantrySkipGuard : skipGuard
    {
        private infantry infantryObj;
        public infantrySkipGuard(uint[] shields, int skipCount, infantry infantryInstance) : base(shields, skipCount)
        {
            infantryObj = infantryInstance;
        }

        //pre: x and y should be valid coordinates within range of the infantrys movement area
        //it should also be values greater than 0
        //post: infantry guard is in a defensive state infatry moves based on the values and has targeted an enemy
        //infantry shifts positions
        public void PerformDefensiveMovement(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            // Implement defensive movement logic here
            //if true then move positions if not then do nothing
            if (isInDefense())
            {
                infantryObj.move(x, y);
                infantryObj.target(x, y, x + y);
            }
            //else have it shift positions instead
            infantryObj.shift(x + y);
        }
        
        private bool isInDefense()
        {
            return shields.Length % viableCount == 0;
        }

        public uint[] GetShields()
        {
            return shields;
        }

        public infantry GetInfantry()
        {
            return infantryObj;
        }
    }
}

/*Implementation Invariant -
 * The shields array should contain non-negative shield values for each shield index.
 * The skipCount should be a non-negative integer representing the number of shields to skip in the block method.
 * The infantryObj should refer to a valid instance of the infantry class.
 * The viableCount should be a non-negative integer representing the number of shields with a value greater than zero.
 * The shields.Length should be greater than zero.
 * The shields.Length should be greater than or equal to viableCount.
 */

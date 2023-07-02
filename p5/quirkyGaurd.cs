/* Sarah Nguyen
 * CPSC3200 - 01
 * quirkyGuard.cs
 * 05/20/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*class invariant
 * The shields array contains the strength values of the guard's shields.
 * The viableCount represents the number of shields with non-zero strength.
 * The shieldIndex keeps track of the current shield index to block.
 */

namespace p5
{
    public class quirkyGuard : guard
    {
        private int shieldIndex;
        public quirkyGuard(uint[] shields) : base(shields)
        {
            shieldIndex = 0;
        }

        //pre: x in block should be a viable value
        //post: The shield at the current shield index is blocked, decrementing its strength or setting it to zero based on the guard's mode.
        //The shield index is incremented by one.
        public override void block(int x)
        {
            if (x <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            int currentShieldIndex = shieldIndex % shields.Length;
            base.block(currentShieldIndex);
            shieldIndex++;
        }
        public uint[] getShields()
        {
            return shields;
        }
    }

    
}

/*The quirkyGuard class extends the guard class and overrides the block method to implement a quirky behavior.
 * The block method blocks the shield at the current shield index (based on shieldIndex) by calling the base block method.
 * After blocking a shield, the shieldIndex is incremented by one, ensuring the next shield in the shields array will be blocked on the next call to block.
 */


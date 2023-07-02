/* Sarah Nguyen
 * CPSC3200 - 01
 * skipGuard.cs
 * 05/20/2023
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* class invariants - 
 * The shields array contains the strength values of the guard's shields.
 * The viableCount represents the number of shields with non-zero strength.
 * The skipCount represents the number of shields to skip before blocking.
 */

namespace p5
{
    public class skipGuard : guard
    {
        private int skipCount;

        public skipGuard(uint[] shields, int sk) : base(shields)
        {
            skipCount = sk;
        }

        //pre: The x parameter in the block method should be a valid integer value greater than zero.
        //post: The shield at the target shield index is blocked, decrementing its strength or setting it to zero based on the guard's mode.
        //The target shield index is determined by adding the skip count to x and taking the modulus of the shields' length.
        public override void block(int x)
        {
            if (x <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            // Skip the specified number of shields before blocking
            int targetShield = (x + skipCount) % shields.Length;
            base.block(targetShield);
        }
    }
}

/*The skipGuard class extends the guard class and overrides the block method to implement the skip behavior.
 * The block method first checks if x is greater than zero, throwing an exception if it's not.
 * It then calculates the target shield index by adding the skip count to x and taking the modulus of the shields' length.
 * Finally, it calls the base block method with the target shield index to perform the blocking operation.
 */
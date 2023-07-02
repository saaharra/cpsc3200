/* Sarah Nguyen
 * CPSC3200 - 01
 * turretGuard.cs
 * 05/20/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*class invariants -
 * The shields array contains the strength values of the guard's shields.
 * The viableCount represents the number of shields with non-zero strength.
 * The turretObj holds a reference to the turret object associated with the guard.
 */

namespace p5
{
    public class turretGuard : guard
    {
        private turret turretObj;

        public turretGuard(uint[] shields, turret tObj) : base(shields)
        {
            turretObj = tObj;
        }
        //similar to turret class
        public int GetRange()
        {
            return turretObj.getRange();
        }
        //similar to turret class
        public void Shift(int value)
        {
            turretObj.shift(value);
        }
        //similar to turret class
        public void move(int x, int y)
        {
            turretObj.move(x, y);
        }
        //similar to turret class
        public bool target(int x, int y, int q)
        {
            return turretObj.target(x, y, q);
        }

        //similar to turret class
        public void revived(int s)
        {
            turretObj.revived(s);
        }

        //pre: The x, y, and q parameters in the target method should be valid integer values.
        //The s parameter in the revived method should be a non-negative integer.
        //post: The changeTarget method updates the target coordinates of the turret if the guard is alive and the turret object exists.
        public bool changeTarget(int x, int y, int q)
        {
            // Check if the turret is currently active and able to change targets
            if (!isAlive() && turretObj == null)
            {
                // Call the turret's method to change the target coordinates
                return false;
            }
            return turretObj.target(x, y, q);
        }

    }
}

/* implementation invariant -
 * The turretGuard class extends the guard class and provides additional methods related to turret functionality.
 * The constructor initializes the turretObj with the provided turret object.
 * The GetRange method retrieves the range value from the turret object.
 * The Shift method delegates the shift operation to the turret object.
 * The move method delegates the movement operation to the turret object.
 * The target method delegates the targeting operation to the turret object and returns the result.
 * The revived method delegates the revival operation to the turret object.
 * The changeTarget method checks if the guard is alive and the turret object exists, and then calls the turret's target method to change the target coordinates.
 */

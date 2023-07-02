/* Sarah Nguyen
 * CPSC3200 - 01
 * turretQuirkyGuard.cs
 * 05/20/2023
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* The number of shields in the shields array is greater than half the length of the array.
 */


namespace p5
{
    public class turretQuirkyGuard : quirkyGuard
    {
        private turret turretObj;
        public turretQuirkyGuard(uint[] shields, turret turretInstance) : base(shields)
        {
            turretObj = turretInstance;
        }
        //same as turret
        public int GetRange()
        {
            return turretObj.getRange();
        }
        //same as turret
        public void Shift(int value)
        {
            turretObj.shift(value);
        }
        //same as turret
        public void Move(int x, int y)
        {
            turretObj.move(x, y);
        }
        //same as turret
        public bool Target(int x, int y, int q)
        {
            return turretObj.target(x, y, q);
        }
        //same as turret
        public void Revived(int s)
        {
            turretObj.revived(s);
        }

        public int getStrength()
        {
            return turretObj.getStrength();
        }
    }
}

/*implement invariants
 * The GetRange() method returns the range of the associated turret object.
 * The Shift() method shifts the turret object by the specified value.
 * The Move() method moves the turret object to the specified coordinates.
 * The Target() method sets the target coordinates of the turret object and returns a boolean indicating if the target was successfully set.
 * The Revived() method updates the strength of the turret object.
 */

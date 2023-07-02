/* Sarah Nguyen
 * CPSC3200 - 01
 * turretSkipGuard.cs
 * 05/20/2023
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* class invariants - 
 * The shields array should contain valid shield values.
 * The skipCount should be a non-negative integer.
 *  The turretObj should be a valid instance of the turret class.
 */

namespace p5
{
    public class turretSkipGuard : skipGuard
    {
        
        private turret turretObj;
        public turretSkipGuard(uint[] shields, int skipCount, turret turretInstance) : base(shields, skipCount)
        {
            if (skipCount <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            turretObj = turretInstance;
        }

        //pre: x and y should be valid coordinates within the range of the turret's movement area.
        // q should be a valid target index.
        //x, y, and q should be greater than or equal to 0.
        //post: The turret skip guard's target has been set to the specified coordinates x and y, with the target index q.
        // If the guard is in offense mode and the target was successfully set, the corresponding shield is blocked and the defensive movement is performed.
        //The method returns a boolean value indicating the success of setting the target.
        public bool tsGuardTarget(int x, int y, int q)
        {
            if (x <= 0 || y <= 0 || q <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            if (checkMode() && isInOffense()) 
            { 
                block(q);
                PerformDefensiveMovement(x, y);
            }
            
            return turretObj.target(x, y, q);
        }

        //pre: x and y should be valid coordinates within the range of the turret's movement area.
        //post: If the guard is in offense mode and the target was successfully set, the corresponding shield is blocked and the defensive movement is performed.
        public void PerformDefensiveMovement(int x, int y)
        {
            // Implement defensive movement logic here
            //if true then move positions if not then do nothing
            if (!isInOffense())
            {
                turretObj.move(x , y);
            }
            //else have it shift positions instead
            
        }

        private bool isInOffense()
        {
            return turretObj.getFailedRequests() % shields.Length == 0;
        }
    }
}

/*implementation invariant -
 * The tsGuardTarget method checks if the guard is in offense mode and if the target should be set based on the current shield count and failed requests count of the turret.
 * The PerformDefensiveMovement method performs defensive movement logic if the guard is not in offense mode, which involves moving the turret to the specified coordinates.
 * The isInOffense method checks if the guard is in offense mode based on the remainder of the shield count divided by the failed requests count of the turret.
 */

/* Sarah Nguyen
 * CPSC3200 - 01
 * fighter.cs
 * 04/20/2023
 * update - 05/25/2023
 */

/*class invariant
 * row and column must be non-negative integers.
 * strength must be a non-negative integer.
 * range must be a non-negative integer.
 * artillery must be an array of non-negative integers.
 * at first wanted to make it an abstract class but decided against it just soley because i 
 * unsure of how to go about unit testing it
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public class fighter
    {
        protected int row;
        protected int column;
        protected int totalTargetsVanquished;
        protected int strength;
        protected uint[] artillery;
        protected bool isAlive;
        protected bool isActive;
        protected int range;
        protected int numberArtillery;
        public fighter()
        {
            totalTargetsVanquished = 0;
            row = 0;
            column = 0;
            totalTargetsVanquished = 0;
            strength = 0;
            isAlive = true;
            isActive = true;
            range = 0;
            artillery = new uint[0];
            numberArtillery = artillery.Length;
        }
        public fighter(int x, int y, int s, int r, uint[] a)
        {
            if (x <= 0 || y <= 0 || s <= 0 || r <= 0 || a.Length <= 0)
            {
                throw new System.Exception("Your set value must be greater than zero");
            }
            row = x;
            column = y;
            totalTargetsVanquished = 0;
            strength = s;
            isAlive = true;
            range = r;
            artillery = a;
            numberArtillery = artillery.Length;
        }
        //pre: if the obj is alive then you would set the row and column for the passed in params
        //post: the obj moves to its new location
        public virtual void move(int r, int c)
        {
            if (isAlive)
            {
                row = r;
                column = c;
            }
        }
        //pre: none
        //post: none
        public virtual void shift(int p)
        {
            return;
        }

        //strength q 
        //pre: x, y, and q should be positive values that are returned 
        //if strength is larger than the strength being passed in then the target is dead
        //post: returns the status of if the target is hit or not
        public virtual bool target(int x, int y, int q)
        {
            bool targetHit = false;
            if (strength > q)
            {
                totalTargetsVanquished++;
                targetHit = true;
            }
            return targetHit;
        }
        public uint minimumStrength
        {
            get
            {
                if (artillery.Length > 0)
                {
                    return (uint) artillery[artillery.Length - 1];
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool isItActive()
        {
            return strength > 0 && numberArtillery > 0;
        }
        public int sum()
        {
            return totalTargetsVanquished;
        }
        public int getRow()
        {
            return row;
        }

        public int getColumn()
        {
            return column;
        }

        public uint[] getArtillery()
        {
            return artillery;
        }

        public int getStrength()
        {
            return strength;
        }

        public int getRange()
        {
            return range;
        }

    }
}

/*implementation invariants
 *  move - if the object is alive then you can move the piece based on the row and column 
 *  that is passed into through the parameters. This can be overriden by the child classes
 *  shift - based class does not get affected by shift so it is just a plain return, child classes
 *  override it
 *  target - passes in row and col and strength q, if the obj at the row and col has a bigger strength
 *  then it kills the target
 *  sum - returns the total value of the targets vanquished
 *  getRow, getColumn, getArtillery, and getStrength - return the values, this was for testing
 *  purposes to make it easier to unit test
 *  addObjs - adds different types of objects to the array of fighters
 */

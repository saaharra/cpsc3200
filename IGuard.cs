/* Sarah Nguyen
 * CPSC3200 - 01
 * IGuard.cs
 * 05/20/2023
 * this is the guard interface
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public interface IGuard
    {
        bool isAlive();
        bool checkMode();
        void block(int x);
    }
}

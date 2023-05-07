/* Sarah Nguyen
 * CPSC3200 - P1
 * P1.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    internal class P1
    {
        public static void Main()
        {
            Random number = new Random();
            int arrSize = number.Next(1,5);

            lumen[] obj = new lumen[arrSize];
            for(int i = 0; i < arrSize; i++)
            {
                int brightness = number.Next(100, 500);
                int power = number.Next(10, 100);
                int size = number.Next(10, 100);
                obj[i] = new lumen(brightness, power, size);
            }

            Console.WriteLine("This is to test the glow for objects of the array size " + arrSize);
            for(int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine(obj[i].glow().ToString());
            }   

            Console.WriteLine("This is to call the reset method on one lumen object");

            int obj2Brightness = number.Next(100, 500);
            int obj2Power = number.Next(10, 100);
            int obj2Size = number.Next(10, 100);
            lumen obj2 = new lumen(obj2Brightness, obj2Power, obj2Size);

            obj2.glow();
            Console.WriteLine("This is obj2 after the first glow method is called " + obj2.glow().ToString());
            for(int i = 0; i < arrSize; i++)
            {
                obj2.glow();
            }

            Console.WriteLine("This is obj2 before the reset call " + obj2.glow().ToString());

            obj2.reset();
            Console.WriteLine("This is obj2 calling the glow method after being reset ");
            obj2.glow();
            Console.WriteLine(obj2.glow().ToString());


        }
    }
}

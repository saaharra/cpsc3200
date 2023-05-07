/* Sarah Nguyen
 * CPSC3200 - 01
 * p3.cs
 * 04/20/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3
{
    public class p3
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int len = rnd.Next(1, 10);
            fighter[] fighters = new fighter[6];
            turret[] turrets = new turret[len];
            infantry[] infantries = new infantry[len];
            populateData(fighters, infantries, turrets);
            // move each fighter object to a random location
            Console.Write("This is to move the objs");
            Console.WriteLine();
            for (int i = 0; i < fighters.Length; i++)
            {
                fighters[i].move(rnd.Next(10), rnd.Next(10));
            }

            for (int i = 0; i < fighters.Length; i++)
            {
                bool result = fighters[i].target(rnd.Next(10), rnd.Next(10), rnd.Next(10));
                Console.WriteLine("Fighter {0} targeting (x={1}, y={2}, strength={3}): {4}", fighters[i].GetType(), rnd.Next(10), rnd.Next(10), rnd.Next(10), result);
            }

            for (int i = 0; i < fighters.Length; i++)
            {
                int sum = fighters[i].sum();
                Console.WriteLine("Fighter {0} vanquished {1} targets.", fighters[i].GetType(), sum);
            }
            //Commenting this out because it doesnt work 
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("this is the turret range before shift " + turrets[i].getRange());
                turrets[i].shift(rnd.Next(5));
                Console.WriteLine(turrets[i].getRange());
            }

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("this is the infantry row before shift " + infantries[i].getRow());
                infantries[i].shift(rnd.Next(5));
                Console.WriteLine(infantries[i].getRow());
            }

        }

        public static void populateData(fighter[] fighterObjs, infantry[] infantryObjs, turret[] turretObjs)
        {
            Random rnd = new Random();
            //int len = rnd.Next(1, 10);
            for (int x = 0; x < fighterObjs.Length; x++)
            {
                int[] artillery = { rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5) };
                fighterObjs[0] = new infantry(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
                fighterObjs[1] = new infantry(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
                fighterObjs[2] = new turret(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
                fighterObjs[3] = new turret(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
                fighterObjs[4] = new fighter(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
                fighterObjs[5] = new fighter(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
            }
            for (int i = 0; i < turretObjs.Length; i++)
            {
                int[] artillery = { rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5) };
                turretObjs[i] = new turret(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
            }

            for (int i = 0; i < infantryObjs.Length; i++)
            {
                int[] artillery = { rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5) };
                infantryObjs[i] = new infantry(rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), artillery);
            }

        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5
{
    public class p5
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            uint len = (uint)rnd.Next(1, 10);
            guard[] guards = new guard[5];
            turretQuirkyGuard[] turretsQG = new turretQuirkyGuard[len];
            infantrySkipGuard[] infantriesSG = new infantrySkipGuard[len];
            heterogenousCollection(guards, turretsQG, infantriesSG);

            Console.WriteLine("This is to test the heterogenous collection of guards");
            foreach(var guard in guards)
            {
                TestGuard(guard);
            }

            Console.WriteLine("This is to test everything else separately");
            guardTests();
            turretGaurdstuff();
            turretSkipGuardtest();
            turretQuirkyGuardtest();
            infantryGuardTests();
            infantrySkipGuardTest();
        }

        public static void guardTests()
        {
            Random rnd = new Random();

            Console.WriteLine("Testing the guard interface and class");
            // Create a QuirkyGuard object with an array of shields
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            quirkyGuard quirkyGuard = new quirkyGuard(shields);
            skipGuard skipGuard = new skipGuard(shields, rnd.Next(1, 10));

            // Perform block operations
            Console.WriteLine("Initial shield values: " + string.Join(", ", shields));
            for (int i = 1; i < shields.Length; i++)
            {
                quirkyGuard.block(i);
                Console.WriteLine("Block operation for quirky Guard {0}: Shield values: {1}", i + 1, string.Join(", ", shields));
                skipGuard.block(i);
                Console.WriteLine("Block operation for skip Guard {0}: Shield values: {1}", i + 1, string.Join(", ", shields));
            }

            Console.WriteLine();
        }

        public static void turretGaurdstuff()
        {
            Random rnd = new Random();

         
            // Create a QuirkyGuard object with an array of shields
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            Console.WriteLine("testing my turretGuard");
            // Create an instance of TurretGuard
            uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            turret tObj = new turret(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), artillery);
            turretGuard turretGuardObj = new turretGuard(shields, tObj);

            // Access guard-specific methods
            turretGuardObj.block(rnd.Next(1, 10));
            Console.WriteLine("Is Guard Alive? " + turretGuardObj.isAlive());

            // Access turret-specific methods
            Console.WriteLine("Turret Range: " + turretGuardObj.GetRange());
            turretGuardObj.Shift(rnd.Next(1, 50));
            turretGuardObj.move(rnd.Next(1, 10), rnd.Next(1, 10));
            Console.WriteLine("Turret Range: " + turretGuardObj.GetRange());

            // Targeting
            bool targetResult = turretGuardObj.target(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
            Console.WriteLine("Target Result: " + targetResult);

            //updateTarget
            turretGuardObj.changeTarget(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
            Console.WriteLine("Target Result: " + targetResult);

            // Reviving
            turretGuardObj.revived(100);

            // Check guard and turret status
            Console.WriteLine("Is Guard Alive? " + turretGuardObj.isAlive());
            Console.WriteLine("Turret Range: " + turretGuardObj.GetRange());
            Console.WriteLine();
        }

        public static void turretSkipGuardtest()
        {
            Console.WriteLine("testing the turret Skip Guard");
            Random rnd = new Random();
            // Create an array of shields
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            turret tObj = new turret(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), artillery);
            int skipAmount = 2; // Example skip amount

            turretSkipGuard TSguard = new turretSkipGuard(shields, skipAmount, tObj);
            bool targetResult = TSguard.tsGuardTarget(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
            Console.WriteLine("Target Result: " + targetResult);
        }

        public static void turretQuirkyGuardtest()
        {
            Console.WriteLine("testing the turret quirky Guard");
            Random rnd = new Random();
            // Create an array of shields
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            turret tObj = new turret(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), artillery);


            turretQuirkyGuard TSguard = new turretQuirkyGuard(shields, tObj);

            // Test turret-specific functionality
            TSguard.Move(rnd.Next(1, 10), rnd.Next(1, 10));
            TSguard.Target(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));

            // Test guard functionality
            TSguard.block(rnd.Next(1, 10));

            // Test accessing turret properties
            int range = TSguard.GetRange();
            Console.WriteLine("Turret range: " + range);
        }

        public static void infantryGuardTests()
        {
            Console.WriteLine("testing my infantry guard");
            Random rnd = new Random();
            // Create an instance of the Infantry class
            infantry infantryInstance = new infantry();

            // Create an instance of the infantryGuard class
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) }; infantryGuard guardInstance = new infantryGuard(shields, infantryInstance);

            // Test the methods of the infantryGuard class
            // Replenish the shields by an amount
            guardInstance.ReplenishShields((uint)rnd.Next(1, 6)); 
            // Perform the offensive movement
            guardInstance.PerformOffensiveMovement(rnd.Next(1, 10), rnd.Next(1, 10));

            // Output the shield values and infantry strength
            Console.WriteLine("Shields:");
            for (int i = 0; i < shields.Length; i++)
            {
                Console.WriteLine($"Shield {i}: {shields[i]}");
            }

            Console.WriteLine($"Infantry row: {infantryInstance.getRow()}");
            Console.WriteLine();
        }

        public static void infantrySkipGuardTest()
        {
            Console.WriteLine("testing my infantry guard");
            Random rnd = new Random();
            // Create an instance of the Infantry class
            infantry infantryInstance = new infantry();
            int skipCount = rnd.Next(2, 6);
            // Create an instance of the infantryGuard class
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) }; 
            infantrySkipGuard guardInstance = new infantrySkipGuard(shields, skipCount, infantryInstance);
            // Test the methods of the infantrySkipGuard class
            guardInstance.block(rnd.Next(2, 6)); // Perform blocking with skip logic
            guardInstance.PerformDefensiveMovement(rnd.Next(2, 6), rnd.Next(2, 6)); // Perform defensive movement with coordinates (3, 4)

            // Output the shield values and infantry strength
            Console.WriteLine("Shields:");
            for (int i = 0; i < shields.Length; i++)
            {
                Console.WriteLine($"Shield {i}: {shields[i]}");
            }

            Console.WriteLine($"Infantry row: {infantryInstance.getRow()}");

            Console.WriteLine();
        }

        public static void heterogenousCollection(guard[] guardObjs, turretQuirkyGuard[] tqgObj, infantrySkipGuard[] iskObj)
        {

            Random rnd = new Random();
            infantry infantries = new infantry();
            turret turrets = new turret();
            populateturret(turrets);
            populateinfantry(infantries);
            uint[] shields = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
            int skipCount = rnd.Next(2, 6);
            for (int x = 0; x < guardObjs.Length; x++)
            {
                
                guardObjs[0] = new turretQuirkyGuard(shields, turrets);
                guardObjs[1] = new turretQuirkyGuard(shields, turrets);
                guardObjs[2] = new infantrySkipGuard(shields, skipCount, infantries);
                guardObjs[3] = new infantrySkipGuard(shields, skipCount, infantries);
                guardObjs[4] = new guard(shields);
            }
            for (int i = 0; i < tqgObj.Length; i++)
            {
                uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
                tqgObj[i] = new turretQuirkyGuard(shields, turrets);
            }

            for (int i = 0; i < iskObj.Length; i++)
            {
                uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
                iskObj[i] = new infantrySkipGuard(shields, skipCount, infantries);
            }
        }

        public static void populateinfantry(infantry infantryObjs)
        {
            Random rnd = new Random();
            for(int i = 0; i < rnd.Next(1, 10); i++)
            {
                uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
                infantryObjs = new infantry(rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), artillery);
            }
            
        }

        public static void populateturret(turret turretObjs)
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                uint[] artillery = { (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6), (uint)rnd.Next(2, 6) };
                turretObjs = new turret(rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), rnd.Next(2, 6), artillery);
            }

        }

        public static void TestGuard(guard guard)
        {
            Random rnd = new Random();
            // Perform tests specific to the guard type
            if (guard is turretQuirkyGuard)
            {
                turretQuirkyGuard quirkyGuard = (turretQuirkyGuard)guard;
                // Test turret-specific functionality
                quirkyGuard.Move(rnd.Next(1, 10), rnd.Next(1, 10));
                quirkyGuard.Target(rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));

                // Test guard functionality
                quirkyGuard.block(rnd.Next(1, 10));

                // Test accessing turret properties
                int range = quirkyGuard.GetRange();
                Console.WriteLine("Turret range: " + range);

            }
            else if (guard is infantrySkipGuard)
            {
                infantrySkipGuard skipGuard = (infantrySkipGuard)guard;
                // Perform infantrySkipGuard-specific tests
                uint[] shields = skipGuard.GetShields(); // Get the shields from the infantrySkipGuard object
                skipGuard.block(rnd.Next(2, 6)); // Perform blocking with skip logic
                skipGuard.PerformDefensiveMovement(rnd.Next(2, 6), rnd.Next(2, 6)); // Perform defensive movement with coordinates (3, 4)

                // Output the shield values and infantry strength
                Console.WriteLine("Shields:");
                for (int i = 0; i < shields.Length; i++)
                {
                    Console.WriteLine($"Shield {i}: {shields[i]}");
                }

                infantry infantryGuard = skipGuard.GetInfantry(); // Get the infantry from the infantrySkipGuard object
                Console.WriteLine($"Infantry row: {infantryGuard.getRow()}");

                Console.WriteLine();

            }
        }
    }
}


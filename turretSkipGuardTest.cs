using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class turretSkipGuardTest
    {
        [TestMethod]
        public void TurretSkipGuard_Target_unsuccessful()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretSkipGuard skipGuard = new turretSkipGuard(shields, 2, turretInstance);
            int x = 1;
            int y = 2;
            int q = 1;

            // Act
            bool result = skipGuard.tsGuardTarget(x, y, q);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TurretSkipGuard_Target_Failed()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretSkipGuard skipGuard = new turretSkipGuard(shields, 2, turretInstance);
            int x = 1;
            int y = 2;
            int q = 5;

            // Act
            bool result = skipGuard.tsGuardTarget(x, y, q);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TurretSkipGuard_PerformDefensiveMovement_InOffenseMode()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretSkipGuard skipGuard = new turretSkipGuard(shields, 2, turretInstance);
            int x = 1;
            int y = 2;

            // Act
            skipGuard.PerformDefensiveMovement(x, y);

            // Assert
            Assert.AreNotEqual(x, turretInstance.getRow());
            Assert.AreNotEqual(y, turretInstance.getColumn());
        }

        [TestMethod]
        public void TurretSkipGuard_PerformDefensiveMovement_NotInOffenseMode()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretSkipGuard skipGuard = new turretSkipGuard(shields, 2, turretInstance);
            int x = 1;
            int y = 2;

            // Act
            skipGuard.PerformDefensiveMovement(x, y);

            // Assert
            Assert.AreEqual(0, turretInstance.getRow());
            Assert.AreEqual(0, turretInstance.getColumn());
        }


    }
}
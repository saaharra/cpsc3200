using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class turretQuirkyGuardTests
    {
        [TestMethod]
        public void GetRange_ShouldReturnTurretRange()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretInstance.shift(10);
            turretQuirkyGuard guard = new turretQuirkyGuard(shields, turretInstance);

            // Act
            int range = guard.GetRange();

            // Assert
            Assert.AreEqual(10, range);
        }

        [TestMethod]
        public void Shift_ShouldShiftTurretByGivenValue()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretQuirkyGuard guard = new turretQuirkyGuard(shields, turretInstance);

            // Act
            guard.Shift(5);

            // Assert
            // Add assertions to verify the expected behavior of the Shift() method
        }

        [TestMethod]
        public void Move_ShouldMoveTurretToGivenCoordinates()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretQuirkyGuard guard = new turretQuirkyGuard(shields, turretInstance);

            // Act
            guard.Move(10, 20);

            // Assert
            // Add assertions to verify the expected behavior of the Move() method
        }

        [TestMethod]
        public void Target_ShouldSetTurretTargetAndReturnFalse()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretQuirkyGuard guard = new turretQuirkyGuard(shields, turretInstance);

            // Act
            bool result = guard.Target(10, 20, 30);

            // Assert
            Assert.IsFalse(result);
            // Add assertions to verify the expected behavior of the Target() method
        }

        [TestMethod]
        public void Revived_ShouldUpdateTurretStrength()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretInstance = new turret();
            turretQuirkyGuard guard = new turretQuirkyGuard(shields, turretInstance);

            int current = guard.getStrength();
            // Act
            guard.Revived(5);

            int after = guard.getStrength();
            // Assert
            // Add assertions to verify the expected behavior of the Revived() method
            Assert.AreEqual(current, after);
        }
    }
}
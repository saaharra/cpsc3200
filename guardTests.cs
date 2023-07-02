using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class guardTests
    {
        [TestMethod]
        public void Block_ShouldDecrementShieldStrength_WhenGuardIsAliveAndValidIndex()
        {
            // Arrange
            uint[] shields = { 2, 3, 1 };
            guard guardInstance = new guard(shields);
            int index = 1;

            // Act
            guardInstance.block(index);

            // Assert
            Assert.AreEqual((uint)0, shields[index]);
        }

        [TestMethod]
        public void Block_ShouldSetShieldStrengthToZero_WhenGuardIsAliveAndValidIndexAndDownMode()
        {
            // Arrange
            uint[] shields = { 2, 3, 1 };
            guard guardInstance = new guard(shields);
            int index = 2;

            // Act
            guardInstance.block(index);

            // Assert
            Assert.AreEqual((uint)0, shields[index]);
        }

        [TestMethod]
        public void Block_ShouldDecrementViableCount_WhenShieldStrengthBecomesZero()
        {
            // Arrange
            uint[] shields = { 2, 0, 3 };
            guard guardInstance = new guard(shields);
            int index = 0;
            int expectedViableCount = 2;

            // Act
            guardInstance.block(index);

            // Assert
            Assert.AreEqual(expectedViableCount, guardInstance.getViableCount());
        }

        [TestMethod]
        public void Block_ShouldNotModifyShieldStrength_WhenGuardIsNotAlive()
        {
            // Arrange
            uint[] shields = { 2, 3, 1 };
            guard guardInstance = new guard(shields);
            //guardInstance.viableCount = 1; // Set guard as not alive
            int index = 0;
            uint expectedShieldStrength = 0;

            // Act
            guardInstance.block(index);

            // Assert
            Assert.AreEqual(expectedShieldStrength, shields[index]);
        }
    }
}
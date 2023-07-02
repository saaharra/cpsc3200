using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class infantryGuardTest
    {
        [TestMethod]
        public void ReplenishShields_ShouldIncreaseShieldsByGivenAmount()
        {
            // Arrange
            uint[] shields = { 5, 3, 7 };
            infantry infantryInstance = new infantry();
            infantryGuard guard = new infantryGuard(shields, infantryInstance);
            uint amount = 2;

            // Act
            guard.ReplenishShields(amount);

            // Assert
            Assert.AreEqual((uint)7, shields[0]);
            Assert.AreEqual((uint)5, shields[1]);
            Assert.AreEqual((uint)9, shields[2]);
        }

        [TestMethod]
        public void PerformOffensiveMovement_ShouldPerformMovementAndTargetEnemy()
        {
            // Arrange
            uint[] shields = { 3, 4, 5 };
            infantry infantryInstance = new infantry();
            infantryGuard guard = new infantryGuard(shields, infantryInstance);
            int x = 2;
            int y = 3;

            // Act
            guard.PerformOffensiveMovement(x, y);

            // Assert
            bool result = infantryInstance.target(2, 2, 4);
            Assert.IsFalse(result);
            Assert.AreEqual(0, infantryInstance.sum());
        }
    }
}
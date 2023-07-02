using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace p5
{
    [TestClass]
    public class infantrySkipGuardTests
    {
        [TestMethod]
        public void PerformDefensiveMovement_ShouldPerformMovementAndTargetEnemy()
        {
            // Arrange
            uint[] shields = { 3, 4, 5 };
            infantry infantryInstance = new infantry();
            infantrySkipGuard guard = new infantrySkipGuard(shields, 2, infantryInstance);
            int x = 2;
            int y = 3;

            // Act
            guard.PerformDefensiveMovement(x, y);

            // Assert
            bool result = infantryInstance.target(2, 2, 4);
            Assert.IsFalse(result);
        }
    }
}
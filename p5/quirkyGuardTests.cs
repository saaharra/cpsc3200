using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class quirkyGuardTests
    {
        [TestMethod]
        public void QuirkyGuard_Block_Successful()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            quirkyGuard guard = new quirkyGuard(shields);
            int x = 1;

            // Act
            guard.block(x);

            // Assert
            Assert.AreEqual((uint)2, shields[x]);
        }

        [TestMethod]
        public void QuirkyGuard_IsAlive_MoreThanHalfAlive()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            quirkyGuard guard = new quirkyGuard(shields);

            // Act
            bool result = guard.isAlive();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void QuirkyGuard_IsAlive_LessThanHalfAlive()
        {
            // Arrange
            uint[] shields = { 0, 1, 0 };
            quirkyGuard guard = new quirkyGuard(shields);

            // Act
            bool result = guard.isAlive();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void QuirkyGuard_CheckMode_EvenCount()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            quirkyGuard guard = new quirkyGuard(shields);

            // Act
            bool result = guard.checkMode();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void QuirkyGuard_CheckMode_OddCount()
        {
            // Arrange
            uint[] shields = { 1, 2, 3, 4 };
            quirkyGuard guard = new quirkyGuard(shields);

            // Act
            bool result = guard.checkMode();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
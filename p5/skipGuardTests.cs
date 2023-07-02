using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class skipGuardTests
    {
        [TestMethod]
        public void SkipGuard_Block_Successful()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            int skipCount = 2;
            skipGuard guard = new skipGuard(shields, skipCount);
            int x = 1;

            // Act
            guard.block(x);

            // Assert
            Assert.AreEqual((uint)2, shields[x]);
        }

        [TestMethod]
        public void SkipGuard_Block_SkipsShields()
        {
            // Arrange
            uint[] shields = { 1, 2, 3, 4, 5 };
            int skipCount = 2;
            skipGuard guard = new skipGuard(shields, skipCount);
            int x = 1;

            // Act
            guard.block(x);

            // Assert
            Assert.AreEqual((uint)0, shields[(x + skipCount) % shields.Length]);
        }

        [TestMethod]
        public void SkipGuard_Block_SkipsMultipleShields()
        {
            // Arrange
            uint[] shields = { 1, 2, 3, 4, 5 };
            int skipCount = 3;
            skipGuard guard = new skipGuard(shields, skipCount);
            int x = 2;

            // Act
            guard.block(x);

            // Assert
            Assert.AreEqual((uint)0, shields[(x + skipCount) % shields.Length]);
        }
    }
}
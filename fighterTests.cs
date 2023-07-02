using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class fighterTests
    {
        [TestMethod]
        public void TestTarget()
        {
            uint[] artillery = { 2, 3, 4 };
            fighter f = new fighter(1, 1, 5, 3, artillery);

            bool result = f.target(1, 1, 3);

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, f.sum());
        }

        [TestMethod]
        public void TestTargetDeadFighter()
        {
            uint[] artillery = { 2, 3, 4 };
            fighter f = new fighter(1, 1, 5, 3, artillery);
            f.target(2, 2, 3);
            f.target(2, 2, 3);

            bool result = f.target(2, 2, 3);

            Assert.AreEqual(true, result);
            Assert.AreEqual(3, f.sum());
        }

        [TestMethod]
        public void TestMove()
        {
            uint[] artillery = { 2, 3, 4 };
            fighter f = new fighter(1, 1, 5, 3, artillery);

            f.move(1, 1);

            Assert.AreEqual(1, f.getRow());
            Assert.AreEqual(1, f.getColumn());
        }

        [TestMethod]
        public void TestShift()
        {
            uint[] artillery = { 2, 3, 4 };
            fighter f = new fighter(1, 1, 5, 3, artillery);

            f.shift(2);

            Assert.AreEqual(artillery, f.getArtillery());
        }

        [TestMethod]
        public void MinimumStrength_CalculatedCorrectly()
        {
            // Arrange
            uint[] artillery = { 2, 4, 6, 8, 10 };
            fighter fighter = new fighter(1, 1, 5, 3, artillery);

            // Assert
            Assert.AreEqual((uint)10, fighter.minimumStrength);
        }

        [TestMethod]
        public void MinimumStrength_EmptyArtilleryArray_ReturnsZero()
        {
            // Arrange
            uint[] artillery = new uint[1];
            fighter fighter = new fighter(1, 1, 5, 3, artillery);


            // Assert
            Assert.AreEqual((uint)0, fighter.minimumStrength);
        }
    }
}
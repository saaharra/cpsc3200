using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class fighterTests
    {
        [TestMethod]
        public void TestTarget()
        {
            int[] artillery = { 2, 3, 4 };
            fighter f = new fighter(0, 0, 5, 3, artillery);

            bool result = f.target(1, 1, 3);

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, f.sum());
        }

        [TestMethod]
        public void TestTargetDeadFighter()
        {
            int[] artillery = { 2, 3, 4 };
            fighter f = new fighter(0, 0, 5, 3, artillery);
            f.target(1, 1, 3);
            f.target(1, 1, 3);

            bool result = f.target(1, 1, 3);

            Assert.AreEqual(true, result);
            Assert.AreEqual(3, f.sum());
        }

        [TestMethod]
        public void TestMove()
        {
            int[] artillery = { 2, 3, 4 };
            fighter f = new fighter(0, 0, 5, 3, artillery);

            f.move(1, 1);

            Assert.AreEqual(1, f.getRow());
            Assert.AreEqual(1, f.getColumn());
        }

        [TestMethod]
        public void TestShift()
        {
            int[] artillery = { 2, 3, 4 };
            fighter f = new fighter(0, 0, 5, 3, artillery);

            f.shift(2);

            Assert.AreEqual(artillery, f.getArtillery());
        }
    }

}
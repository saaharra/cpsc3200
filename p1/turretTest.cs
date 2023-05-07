using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class TurretTests
    {
        [TestMethod]
        public void TestShift()
        {
            int[] artillery = { 2, 3, 4 };
            turret t = new turret(1, 1, 5, 2, artillery);

            t.shift(1);
            Assert.AreEqual(3, t.getRange());
        }

        [TestMethod]
        public void TestTarget_Success()
        {
            int[] artillery = { 2, 3, 4 };
            turret t = new turret(1, 1, 5, 2, artillery);

            bool result = t.target(2, 2, 4);

            Assert.IsTrue(result);
            Assert.AreEqual(1, t.sum());
        }

        [TestMethod]
        public void TestTarget_Failure()
        {
            int[] artillery = { 2, 3, 4 };
            turret t = new turret(1, 1, 5, 2, artillery);

            bool result = t.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, t.sum());

            result = t.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, t.sum());
            result = t.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, t.sum());
        }
    }

}
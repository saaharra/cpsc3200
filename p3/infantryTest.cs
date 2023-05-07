using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class infantryTests
    {
        [TestMethod]
        public void TestShift()
        {
            int[] artillery = { 2, 3, 4 };
            infantry i = new infantry(1, 1, 5, 2, artillery);

            i.shift(1);
            Assert.AreEqual(1, i.getColumn());
        }

        [TestMethod]
        public void TestTarget_Success()
        {
            int[] artillery = { 2, 3, 4 };
            infantry i = new infantry(1, 1, 5, 2, artillery);

            bool result = i.target(2, 2, 4);

            Assert.IsTrue(result);
            Assert.AreEqual(1, i.sum());
        }
        [TestMethod]
        public void TestMove()
        {
            int[] artillery = { 2, 3, 4 };
            infantry i = new infantry(1, 1, 5, 2, artillery);

            i.move(1, 1);

            Assert.AreEqual(1, i.getRow());
            Assert.AreEqual(1, i.getColumn());
        }
        [TestMethod]
        public void TestTarget_Failure()
        {
            int[] artillery = { 2, 3, 4 };
            infantry i = new infantry(1, 1, 5, 2, artillery);

            bool result = i.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, i.sum());

            result = i.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, i.sum());
            result = i.target(2, 2, 6);

            Assert.IsFalse(result);
            Assert.AreEqual(0, i.sum());
        }
    }
}



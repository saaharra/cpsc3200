using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class turretGuardTests
    {
        [TestMethod]
        public void ChangeTarget_WhenGuardIsAliveAndTurretObjectExists_ShouldUpdateTargetCoordinates()
        {
            // Arrange
            uint[] shields = { 1, 2, 3 };
            turret turretObj = new turret();
            turretGuard guard = new turretGuard(shields, turretObj);

            int initialX = 10;
            int initialY = 20;
            int initialQ = 30;

            int newX = 45;
            int newY = 55;
            int newQ = 65;

            // Act
            //guard.target(initialX, initialY, initialQ);
            bool newTarget = guard.changeTarget(newX, newY, newQ); 
            Assert.AreEqual(guard.target(initialX, initialY, initialQ), newTarget);

        }
    }
}
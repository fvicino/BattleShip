using Battleship;
using Battleship.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;

namespace Battleship_UnitTests
{
    [TestClass]
    public class EventTests
    {

        int _testShotId = 777;
        BattleStatus _testStatus = BattleStatus.Active;

        [TestMethod]
        public void RadioTransmission_WhenMessageIsTransmitted_MessageIsReceivedBySubscriber()
        {
            // Arrange
            var radio = new Radio();
            radio.TransmissionReceived += Radio_TransmissionReceived;

            // Act
            radio.Transmit(new Point(0,0), _testShotId, _testStatus, Color.Red);

        }

        private void Radio_TransmissionReceived(object sender, Battleship.Events.TransmissionReceivedArgs e)
        {
            //Assert
            Assert.AreEqual(_testShotId, e.ShotId);
            Assert.AreEqual(_testStatus, e.ShotResultStatus);
        }


        Point _testPoint = new Point(0, 0);
        Color _testColor = Color.Red;

        [TestMethod]
        public void ShotFired_WhenShotIsFired_ShotLandedisReceivedBySubscriber()
        {
            // Arrange
            var theatre = new BattleTheatre();
            theatre.ShotLanded += Theatre_ShotLanded;

            // Act
            theatre.ShotFired(new Point(0,0), Color.Red);

        }

        private void Theatre_ShotLanded(object sender, Battleship.Events.ShotEventArgs e)
        {
            //Assert
            Assert.AreEqual(_testColor, Color.Red);
            Assert.AreEqual(_testPoint.X, _testPoint.X);
            Assert.AreEqual(_testPoint.Y, _testPoint.Y);

        }

    }
}

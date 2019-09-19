using Battleship.Abstraction;
using Battleship.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Battleship_UnitTests
{
    [TestClass]
    public class ShipCreationTests
    {
        IRadio _radio = new Mock<IRadio>().Object;

        [TestMethod]
        public void WhenShipIsCreatedWithValueRange_TheLengthValueIsCorrect()
        {
            // Arrange
            var ship1Len = 1;
            var ship2Len = 2;
            var ship5Len = 5;
            var ship10Len = 10;

            // Act
            var ship1 = new Ship(ship1Len, _radio);
            var ship2 = new Ship(ship2Len, _radio);
            var ship5 = new Ship(ship5Len, _radio);
            var ship10 = new Ship(ship10Len, _radio);
            
            // Assert
            Assert.AreEqual(ship1Len, ship1.Length);
            Assert.AreEqual(ship2Len, ship2.Length);
            Assert.AreEqual(ship5Len, ship5.Length);
            Assert.AreEqual(ship10Len, ship10.Length);
        }


        [TestMethod]
        public void WhenShipIsCreatedWithNonValidRange_AnExceptionIsThrown()
        {
            // Arrange
            var ship0Len = 0;
            var shipNeg1Len = -1;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Ship(ship0Len, _radio));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Ship(shipNeg1Len, _radio));
        }

    }
}

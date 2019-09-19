using Battleship;
using Battleship.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;

namespace Battleship_UnitTests
{
    [TestClass]
    public class ShipTests
    {
        IRadio _radio;
        IBattleTheatre _battleTheatre;

        [TestInitialize]
        public void Setup() {

            var battleTheatreMock = new Mock<IBattleTheatre>();
            battleTheatreMock.SetupGet(x => x.Height).Returns(10);
            battleTheatreMock.SetupGet(x => x.Width).Returns(10);

            _battleTheatre = battleTheatreMock.Object;
            _radio = new Mock<IRadio>().Object;
        }

        [TestMethod]
        public void ShipCreation_WhenLengthParamIsValidRange_LengthPropertyIsCorrect()
        {
            // Arrange
            var ship1Len = 1;
            var ship2Len = 2;
            var ship5Len = 5;
            var ship10Len = 10;

            // Act
            var ship1 = new Ship( _radio, _battleTheatre );
            var ship2 = new Ship( _radio, _battleTheatre );
            var ship5 = new Ship( _radio, _battleTheatre );
            var ship10 = new Ship( _radio, _battleTheatre );

            ship1.Length = ship1Len;
            ship2.Length = ship2Len;
            ship5.Length = ship5Len;
            ship10.Length = ship10Len;

            // Assert
            Assert.AreEqual(ship1Len, ship1.Length);
            Assert.AreEqual(ship2Len, ship2.Length);
            Assert.AreEqual(ship5Len, ship5.Length);
            Assert.AreEqual(ship10Len, ship10.Length);
        }


        [TestMethod]
        public void ShipCreation_WhenLengthParamIsNonValidRange_AnExceptionIsThrown()
        {
            // Arrange
            var ship0Len = 0;
            var shipNeg1Len = -1;

            // Act
            // Assert
            var ship1 = new Ship( _radio, _battleTheatre);
            var shipNeg1 = new Ship( _radio, _battleTheatre);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ship1.Length = ship0Len);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shipNeg1.Length = shipNeg1Len);
        }


        [TestMethod]
        public void ShipStatus_WhenAllSectionsAreInactive_ShipStatusIsInactive()
        {
            // Arrange
            //Create a ship with length of 4
            var ship4 = new Ship(_radio, _battleTheatre);
            ship4.Length = 4;

            //position the bow of the ship at (4,4) facing North
            ship4.MoveToPosition(new Point(4, 4), Battleship.Direction.North);

            // Act
            //simulate the ship taking fire on all sections
            ship4.BattleStatusUpdate(new Point(4, 4), 0);
            ship4.BattleStatusUpdate(new Point(4, 5), 0);
            ship4.BattleStatusUpdate(new Point(4, 6), 0);
            ship4.BattleStatusUpdate(new Point(4, 7), 0);

            // Assert
            Assert.AreEqual(BattleStatus.Inactive, ship4.Status);
        }

        [TestMethod]
        public void ShipStatus_WhenAnySectionIsActive_ShipStatusIsActive()
        {
            // Arrange
            //Create a ship with length of 4
            var ship4 = new Ship(_radio, _battleTheatre);
            ship4.Length = 4;

            //position the bow of the ship at (4,4) facing North
            ship4.MoveToPosition(new Point(4, 4), Battleship.Direction.North);

            // Act
            //simulate the ship taking fire on two sections
            ship4.BattleStatusUpdate(new Point(4, 5), 0);
            ship4.BattleStatusUpdate(new Point(4, 6), 0);

            // Assert
            Assert.AreEqual(BattleStatus.Active, ship4.Status);
        }

    }
}

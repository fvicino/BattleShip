using Battleship.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Battleship.Implementation
{
    public class Ship: IShip
    {
        IEnumerable<ShipSection> _sections;
        IRadio _radio;

        public Ship(int shipLength, IRadio radio)
        {
            if (shipLength < 1) throw new ArgumentOutOfRangeException("Ship length must be greater than 0");

            //add the appropriate number of ship sections based on length
            _sections = Enumerable.Range(0, shipLength).Select(x => new ShipSection() );

            _radio = radio;
        }

        public int Length { get { return _sections.Count(); } }

        public void MoveToPosition(Point location, Direction direction) {

        }

        public void BattleStatusUpdate(Point AttackLocation)
        {
            //check if we are at that location

            //update the section status

            //update the ship status

            //report the status
        }

        private class ShipSection
        {
            public ShipSection()
            {
                SectionStatus = BattleStatus.Active;
            }
            BattleStatus SectionStatus { get; set; }

            public Point Position { get; protected set; }
        }

    }

}

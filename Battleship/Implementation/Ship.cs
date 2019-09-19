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

        public Ship(int shipLength, IRadio radio, IBattleTheatre battleTheatre)
        {
            if (shipLength < 1) throw new ArgumentOutOfRangeException("Ship length must be greater than 0");

            //add the appropriate number of ship sections based on length
            _sections = Enumerable.Range(0, shipLength).Select(x => new ShipSection() );

            //subscribe to the batlefield shot events
            battleTheatre.ShotLanded += _battleTheatre_ShotLanded;

            _radio = radio;
        }

        public int Length { get { return _sections.Count(); } }

        public BattleStatus Status => _sections.Any(section=> section.Status == BattleStatus.Active) ? BattleStatus.Active: BattleStatus.Inactive;

        public void MoveToPosition(Point location, Direction direction) {

            //Move the ship to the location commanded
            //check if our location + length puts us off map
            //_battleTheatre.Width

        }

        public void BattleStatusUpdate(Point AttackLocation)
        {
            //check if we are at that location

            //update the section status

            //update the ship status

            //report the status
        }

        private void _battleTheatre_ShotLanded(object sender, ShotEventArgs e)
        {
            //trigger a battle status update to check the state of the ship
            BattleStatusUpdate(e.Location);
        }

        private class ShipSection
        {
            public ShipSection()
            {
                Status = BattleStatus.Active;
            }
            public BattleStatus Status { get; set; }

            public Point Position { get; protected set; }
        }

    }

}

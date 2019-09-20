using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Battleship
{
    
    public class Ship: IShip
    {
        IList<ShipSection> _sections;
        IRadio _radio;
        IBattleTheatre _battleTheatre;

        /// <summary>
        /// A ship, composed of any number of ship sections
        /// </summary>
        /// <param name="radio">A reference to the radio service</param>
        /// <param name="battleTheatre">A reference to the battle theatre</param>
        public Ship( IRadio radio, IBattleTheatre battleTheatre)
        {
            //subscribe to the batlefield shot events
            _battleTheatre = battleTheatre;
            _battleTheatre.ShotLanded += _battleTheatre_ShotLanded;

            _radio = radio;
        }
               
        /// <summary>
        /// Defines the length of the ship
        /// </summary>
        public int Length {
            get
            {
                return _sections.Count();
            }
            set {
                if (value < 1) throw new ArgumentOutOfRangeException("Ship length must be greater than 0");
                
                //add the appropriate number of ship sections based on length
                _sections = Enumerable.Range(0, value).Select(x => new ShipSection()).ToList();
            }
        }

        /// <summary>
        /// Reposts the status of the overall ship
        /// </summary>
        public BattleStatus Status => _sections.Any(section=> section.Status == BattleStatus.Active) ? BattleStatus.Active: BattleStatus.Inactive;

        /// <summary>
        /// Team color
        /// </summary>
        public Color Team { get; set ; }

        /// <summary>
        /// Moves the ship to a specified location on the battle theatre
        /// </summary>
        /// <param name="location">The point on the battel theatre (game board) that the ship bow (front end) will be placed</param>
        /// <param name="direction">The direction that the ship will be facing (North,South,East,West) </param>
        public void MoveToPosition(Point location, Direction direction) {

            //Check that we are still on the map if we move to this position
            //Otherwise move the ship to the location commanded by updating the position of each section
            bool outOfbounds = false;
            switch (direction) {
                case Direction.North:
                    if (location.Y + Length > _battleTheatre.Height ) { outOfbounds = true; }
                    else
                    {
                        for (var i = 0; i < _sections.Count(); i++)
                        {
                            _sections[i].Position = new Point(location.X, location.Y + i);
                        }
                    }
                    break;
                case Direction.South:
                    if (location.Y - Length < 0) { outOfbounds = true; }
                    else
                    {
                        for (var i = 0; i < _sections.Count(); i++)
                        {
                            _sections[i].Position = new Point(location.X, location.Y - i);
                        }
                    }
                    break;
                case Direction.East:
                    if (location.X - Length < 0) { outOfbounds = true; }
                    {
                        for (var i = 0; i < _sections.Count(); i++)
                        {
                            _sections[i].Position = new Point(location.Y, location.X - i);
                        }
                    }
                    break;
                case Direction.West:
                    if (location.X + Length > _battleTheatre.Width) { outOfbounds = true; }
                    {
                        for (var i = 0; i < _sections.Count(); i++)
                        {
                            _sections[i].Position = new Point(location.Y, location.X + i);
                        }
                    }
                    break;
            }

            if (outOfbounds) {
                throw new ArgumentOutOfRangeException("The ship cannot be positioned in this location");
            }
        }

        /// <summary>
        /// Process the shot messages that are received, update the section status appropriately and report status to the command centre
        /// </summary>
        /// <param name="attackLocation"> The point at which the attack was made</param>
        /// <param name="Id">Shot (attack) identifier</param>
        public void BattleStatusUpdate(Point attackLocation, int Id)
        {
            //check if we are at that location
            var hitSection = _sections.Where(section => section.Position.X == attackLocation.X
                                     && section.Position.Y == attackLocation.Y
                                     && section.Status == BattleStatus.Active);

            //update the section status and report the status
            if (hitSection.Count() > 0 ) {
                hitSection.FirstOrDefault().Status = BattleStatus.Inactive;
                _radio.Transmit(attackLocation, Id, BattleStatus.Inactive, Team);
            }
            else {
                _radio.Transmit(attackLocation, Id, BattleStatus.Active, Team);
            }

        }

        private void _battleTheatre_ShotLanded(object sender, ShotEventArgs e)
        {
            if (e.Team != Team) {
                //trigger a battle status update to check the state of the ship
                BattleStatusUpdate(e.Location, e.Id);
            }
        }

        /// <summary>
        /// private class used to represent the ship section status and position
        /// </summary>
        private class ShipSection
        {
            public ShipSection()
            {
                Status = BattleStatus.Active;
            }
            public BattleStatus Status { get; set; }

            public Point Position { get; set; }
        }

    }

}

using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Battleship
{
    public class CommandCentre : ICommandCentre
    {
        IRadio _radio;
        IShipyard _shipyard;
        IBattleTheatre _battleTheatre;
        IList<IShip> _ships = new List<IShip>();
        IDictionary<int, int> _reports = new Dictionary<int, int>();
        const int HIT = -1;

        /// <summary>
        /// The Command and control centre for a team (player)
        /// </summary>
        /// <param name="radio">A refernce to the readio service</param>
        /// <param name="shipyard">A reference to the shipyard service</param>
        /// <param name="battleTheatre">A reference to the battle theatre (game board)</param>
        public CommandCentre(IRadio radio, IShipyard shipyard, IBattleTheatre battleTheatre)
        {
            _shipyard = shipyard;
            _battleTheatre = battleTheatre;

            //subscribe to the radio events sent from ships
            radio.TransmissionReceived += Radio_TransmissionReceived;
        }

        public void AddShip(int length, Point location, Direction direction)
        {
            //call the shipyard service to create a new ship
            var newShip = _shipyard.CreateShip(length, Team);

            //intruct the ship to move into position on the board
            newShip.MoveToPosition(location, direction);

            //track the ship and its status
            _ships.Add(newShip);
        }

        public void AttackLocation(Point target)
        {
            //Attack the enemy at the specified location
            _battleTheatre.ShotFired(target, Team);
        }

        /// <summary>
        /// Pick a side, pick a team color 
        /// </summary>
        public Color Team { get; set; }

        /// <summary>
        /// Process a message received from a single ship
        /// </summary>
        /// <param name="shotId"></param>
        /// <param name="shotResultStatus"></param>
        public virtual void UpdateFleetStatus(int shotId, BattleStatus shotResultStatus)
        {
            int reportCount = 0;

            //check the status sent from the ship
            if (shotResultStatus == BattleStatus.Inactive)
            {
                //the message reports a Hit to a section of the ship
                Console.WriteLine("Hit!");

                //now set the reportCount to -1 so future messages foir this shout can be ignored
                _reports[shotId] = HIT;

                //now check if we have any active ships left
                if (!_ships.Any(ship => ship.Status == BattleStatus.Active))
                {
                    Console.WriteLine("\nAll ships have been sunk. {0} team loses!", Team.ToString());
                }
            }
            else
            {
                //no hit reported yet so track messages and check if all reports for this shotId have come in 
                _reports.TryGetValue(shotId, out reportCount);

                //We've already recorded a hit for this shotId so exit
                if (reportCount == HIT) return;

                //add the current message to the count
                reportCount++;

                //check if we have received all the messages we are going to get for this shotId
                if (reportCount < _ships.Count)
                {
                    _reports[shotId] = reportCount;
                }
                else
                {
                    //all messages have some in so its a miss
                    Console.WriteLine("Miss!");
                }
            }
        }

        private void Radio_TransmissionReceived(object sender, TransmissionReceivedArgs e)
        {
            //no eves dropping - only listen to your own teams messages
            if (e.Team == Team)
            {
                UpdateFleetStatus(e.ShotId, e.ShotResultStatus);
            }

        }

    }
}

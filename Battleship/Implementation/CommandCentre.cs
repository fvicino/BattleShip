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

        public CommandCentre(IRadio radio, IShipyard shipyard, IBattleTheatre battleTheatre)
        {
            //subscribe to the radio events
            radio.TransmissionReceived += Radio_TransmissionReceived;
            _battleTheatre = battleTheatre;
            _shipyard = shipyard ;
        }

        private void Radio_TransmissionReceived(object sender, TransmissionReceivedArgs e)
        {
            //no eves dropping
            if (e.Team == Team)
            {
                int reportCount=0;

                if (e.ShotResultStatus == BattleStatus.Inactive)
                {
                    _reports[e.ShotId] = HIT;
                    Console.WriteLine("Hit!");

                    //now check if we have any active ships left
                    if (!_ships.Any(ship => ship.Status == BattleStatus.Active))
                    {
                        Console.WriteLine("All ships have been sunk. {0} team loses!", Team.ToString());
                    }
                }
                else {
                    //no hit reported yet so track message responses and check if all reports for this shot have come in 
                    _reports.TryGetValue(e.ShotId, out reportCount);

                    if (reportCount < 0) return;

                    //add the new report to the count
                    reportCount++;

                    if (reportCount < _ships.Count)
                    {
                        _reports[e.ShotId] = reportCount;
                    }
                    else
                    {
                        Console.WriteLine("Miss!");
                    }
                }

            }

        }

        public void AddShip(int length, Point location, Direction direction) {

            var newShip = _shipyard.CreateShip(length, Team);
            newShip.MoveToPosition(location, direction);
            _ships.Add(newShip);
        }

        public void AttackLocation(Point target) {

            _battleTheatre.ShotFired(target,Team);
        }

        public Color Team { get; set; }
    }
}

using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship
{
    public class CommandCentre : ICommandCentre
    {
        IRadio _radio;
        IShipyard _shipyard;
        IBattleTheatre _battleTheatre;
        IList<IShip> _ships;

        public CommandCentre(IRadio radio, IShipyard shipyard, IBattleTheatre battleTheatre)
        {
            //subscribe to the radio events
            radio.TransmissionReceived += Radio_TransmissionReceived;
            _battleTheatre = battleTheatre;
            _shipyard = shipyard;
        }

        private void Radio_TransmissionReceived(object sender, TransmissionReceivedArgs e)
        {
            //track message responses and handle updates to the player

            //create an array to count the number of messages recioeved for each shot 
            //if a hit is received clean up the entry, other wise wait for all responses before resporting a miss

            Console.WriteLine(e.ShotId);
            Console.WriteLine(e.ShotResultStatus.ToString());

        }

        public void AddShip(int length, Point location, Direction direction) {

            var newShip = _shipyard.CreateShip(length);
            newShip.MoveToPosition(location, direction);
            _ships.Add(newShip);
        }

        public void AttackLocation(Point target) {

            _battleTheatre.ShotFired(target);

        }

        public Color Team { get; set; }
    }
}

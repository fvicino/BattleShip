using Battleship.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship
{
    public class Shipyard : IShipyard
    {

        IServiceProvider _provider;
        public Shipyard( IServiceProvider provider )
        {
            _provider = provider;
        }

        /// <summary>
        /// Factory class that abstracts away access to the service provider
        /// </summary>
        /// <param name="length">Length of the ship tp produce</param>
        /// <param name="team">Team color of the ship</param>
        /// <returns></returns>
        public IShip CreateShip(int length, Color team)
        {
            var ship = (IShip) _provider.GetService(typeof(IShip));
            ship.Length = length;
            ship.Team = team;
            return ship;
        }

    }
}

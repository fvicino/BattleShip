using Battleship.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Shipyard : IShipyard
    {
        //Factory class that abstracts away access to the service provider

        IServiceProvider _provider;
        public Shipyard( IServiceProvider provider )
        {
            _provider = provider;
        }

        public IShip CreateShip(int length)
        {
            var ship = (IShip) _provider.GetService(typeof(IShip));

            ship.Length = length;
            return ship;
        }

    }
}

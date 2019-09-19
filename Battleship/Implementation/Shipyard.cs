using Battleship.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Implementation
{
    public class Shipyard : IShipyard
    {
        IServiceProvider _provider;
        public Shipyard( IServiceProvider provider )
        {
            _provider = provider;
        }

        public IShip CreateShip(int length)
        {
            var ship = (IShip) _provider.GetService(typeof(IShip));

            return ship;
        }

    }
}

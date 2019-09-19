using Battleship;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Abstractions
{
    public interface IShipyard
    {
        IShip CreateShip(int length);
    }
}

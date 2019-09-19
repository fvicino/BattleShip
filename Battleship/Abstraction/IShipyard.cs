using Battleship.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Abstraction
{
    public interface IShipyard
    {
        IShip CreateShip(int length);
    }
}

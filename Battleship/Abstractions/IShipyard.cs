using Battleship;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Abstractions
{
    public interface IShipyard
    {
        IShip CreateShip(int length, Color team);
    }
}

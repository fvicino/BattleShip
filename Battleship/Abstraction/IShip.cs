using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Implementation
{
    public interface IShip
    {
        void MoveToPosition(Point location, Direction direction);
        int Length { get; }
    }
}

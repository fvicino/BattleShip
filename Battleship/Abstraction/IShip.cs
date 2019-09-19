using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Implementation
{
    public interface IShip
    {
        int Length { get; }

        BattleStatus Status { get; }

        void MoveToPosition(Point location, Direction direction);
    }
}

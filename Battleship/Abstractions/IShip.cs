using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Abstractions
{
    public interface IShip
    {
        int Length { get; set; }

        BattleStatus Status { get; }

        void MoveToPosition(Point location, Direction direction);

        Color Team { get; set; }

    }
}

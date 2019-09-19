using Battleship.Events;
using System;
using System.Drawing;

namespace Battleship.Abstractions
{
    public interface IBattleTheatre
    {
        int Height { get; }
        int Width { get; }

        event ShotLandedHandler ShotLanded;

        void ShotFired(Point location);
    }
}

using System;
using System.Drawing;

namespace Battleship.Abstraction
{
    public interface IBattleTheatre
    {
        int Height { get; }
        int Width { get; }

        event ShotLandedHandler ShotLanded;

        void ShotFired(Point location);
    }
}

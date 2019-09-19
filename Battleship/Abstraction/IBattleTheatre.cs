using System;

namespace Battleship.Abstraction
{
    public interface IBattleTheatre
    {
        int Height { get; }
        int Width { get; }

        event ShotLandedHandler ShotLanded;
    }
}

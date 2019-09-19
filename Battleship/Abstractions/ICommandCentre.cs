using System.Drawing;

namespace Battleship.Abstractions
{
    public interface ICommandCentre
    {
        void AddShip(int length, Point location, Direction direction);
        void AttackLocation(Point target);

        Color Team { get; set; }
    }
}
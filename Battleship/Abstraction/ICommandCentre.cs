using System.Drawing;

namespace Battleship.Abstraction
{
    public interface ICommandCentre
    {
        void AddShip(int length, Point location, Direction direction);
        void AttackLocation(Point target);
    }
}
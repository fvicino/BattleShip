using System.Drawing;

namespace Battleship.Abstractions
{
    public interface ICommandCentre
    {
        void AddShip(int length, Point location, Direction direction);
        void AttackLocation(Point target);
        void UpdateFleetStatus(int shotId, BattleStatus shotResultStatus);

        Color Team { get; set; }
    }
}
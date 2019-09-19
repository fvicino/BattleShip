namespace Battleship.Abstraction
{
    public interface IBattleTheatre
    {
        int Height { get; }
        int Width { set; }
        void Attack();
    }
}
using Battleship.Abstraction;

namespace Battleship.Implementation
{
    public class BattleTheatre : IBattleTheatre
    {
        public int Height => throw new System.NotImplementedException();

        public int Width { set => throw new System.NotImplementedException(); }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}
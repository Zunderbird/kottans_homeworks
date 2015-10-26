namespace Battleship
{
    public class Submarine: Ship
    {
        public Submarine(int x, int y) : base(x, y)
        {
            Length = (int) BattleshipsTypes.Submarine;
        }

        public Submarine(int x, int y, Direction directionInShip) : base(x, y, directionInShip)
        {
            Length = (int) BattleshipsTypes.Submarine;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Submarine)) return false;
            var comp = (Ship)obj;
            return comp == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int) BattleshipsTypes.Submarine;
        }
    }
}

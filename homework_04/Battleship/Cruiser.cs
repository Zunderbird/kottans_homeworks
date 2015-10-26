namespace Battleship
{
    public class Cruiser: Ship
    {
        public Cruiser(int x, int y) : base(x, y)
        {
            Length = (int) BattleshipsTypes.Cruiser; 
        }

        public Cruiser(int x, int y, Direction directionInShip) : base(x, y, directionInShip)
        {
            Length = (int) BattleshipsTypes.Cruiser;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Cruiser)) return false;
            var comp = (Ship)obj;
            return comp == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int)BattleshipsTypes.Cruiser;
        }
    }
}

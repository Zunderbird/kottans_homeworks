namespace Battleship
{
    public class AircraftCarrier: Ship
    {
        public AircraftCarrier(int x, int y) : base(x, y)
        {
            Length = (int) BattleshipsTypes.AircraftCarrier;
        }

        public AircraftCarrier(int x, int y, Direction directionInShip) : base(x, y, directionInShip)
        {
            Length = (int)BattleshipsTypes.AircraftCarrier;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AircraftCarrier)) return false;
            var comp = (Ship)obj;
            return comp == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int)BattleshipsTypes.AircraftCarrier;
        }
    }
}

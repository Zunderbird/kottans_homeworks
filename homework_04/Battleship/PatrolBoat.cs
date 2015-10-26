namespace Battleship
{
    public class PatrolBoat: Ship
    {
        public PatrolBoat(int x, int y) : base(x, y)
        {
            Length = (int) BattleshipsTypes.PatrolBoat;
        }

        public PatrolBoat(int x, int y, Direction directionInShip) : base(x, y, directionInShip)
        {
            Length = (int) BattleshipsTypes.PatrolBoat;
        }

        public static bool operator ==(PatrolBoat firstShip, PatrolBoat secondShip)
        {
            return (firstShip.X == secondShip.X
                 && firstShip.Y == secondShip.Y);
        }

        public static bool operator !=(PatrolBoat firstBoat, PatrolBoat secondBoat)
        {
            return !(firstBoat == secondBoat);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PatrolBoat)) return false;
            var comp = (PatrolBoat)obj;
            return comp == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int) BattleshipsTypes.PatrolBoat;
        }
    }
}

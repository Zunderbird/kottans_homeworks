using System.Text.RegularExpressions;

namespace Battleship
{
    public class Ship
    {
        public int X { get; }
        public int Y { get; }
        public int Length { get; protected set; }
        public Direction Direction { get; }

        public Ship(int x, int y)
        {
            X = x;
            Y = y;
            Length = 0;
        }

        public Ship(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Length = 0;
            Direction = direction;
        }

        public int EndX
        {
            get { return (Direction == Direction.Horizontal) ? X + Length - 1 : X; }
        }

        public int EndY
        {
            get { return (Direction == Direction.Vertical) ? Y + Length - 1 : Y; }
        }

        public static Ship Parse(string notation)
        {
            Ship pos;
            if (!TryParse(notation, out pos)) throw new NotAShipException("Not a ship exception!");
            return pos;
        }

        public static Ship CreateNewShip(int x, int y, int length, Direction direction)
        {
            switch (length)
            {
                case (int)BattleshipsTypes.PatrolBoat: return new PatrolBoat(x, y, direction);
                case (int)BattleshipsTypes.Cruiser: return new Cruiser(x, y, direction);
                case (int)BattleshipsTypes.Submarine: return new Submarine(x, y, direction);
                case (int)BattleshipsTypes.AircraftCarrier: return new AircraftCarrier(x, y, direction);
                default: return new Ship(x, y, direction);
            }
        }

        public static bool TryParse(string notation, out Ship pos)
        {
            if (RegexExprShip.FullExpression.Match(notation) == Match.Empty)
            {
                pos = null;
                return false;
            }      
            var x = RegexExprShip.GetX(notation);
            var y = RegexExprShip.GetY(notation);
            var length = RegexExprShip.GetLength(notation);
            var direction = RegexExprShip.GetDirection(notation);

            pos = CreateNewShip(x, y, length, direction);
            return true;
        }

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            return EndY <= squareHeight && EndX <= squareWidth;
        }

        public bool OverlapsWith(Ship ship)
        {
            return (X - 1 <= ship.EndX && EndX + 1 >= ship.X && Y - 1 <= ship.EndY && EndY + 1 >= ship.Y);
        }

        public static bool operator ==(Ship firstShip, Ship secondShip)
        {
            return (firstShip.X == secondShip.X
                 && firstShip.Y == secondShip.Y 
                 && firstShip.Direction == secondShip.Direction);
        }

        public static bool operator !=(Ship firstBoat, Ship secondBoat)
        {
            return !(firstBoat == secondBoat);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ship)) return false;
            var comp = (Ship)obj;
            return comp == this;
        }

        public override int GetHashCode()
        {
            return X ^ Y ^ (int)Direction;
        }

        public override string ToString()
        {
            return "Ship coordinates: (" + X + ", " + Y + ")";
        }
    }
}

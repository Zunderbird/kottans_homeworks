using System;
using System.Text.RegularExpressions;

namespace Battleship
{
    public static class RegexExprShip
    {
        public static readonly Regex FindX = new Regex(@"^[A-J]");
        public static readonly Regex FindY = new Regex(@"(([1][0])|[1-9])");
        public static readonly Regex FindLength = new Regex(@"([x][1-4])");
        public static readonly Regex FindDirection = new Regex(@"([-]|[|])");
        public static readonly Regex FullExpression = new Regex(@"^[A-J](([1][0])|[1-9])([x][1-4])?([-]|[|])?$");


        public static int GetX(string notation)
        {
            var matchX = FindX.Match(notation);
            return matchX.ToString()[0] - 'A' + 1;
        }

        public static int GetY(string notation)
        {
            var matchY = FindY.Match(notation);
            return Convert.ToInt32(matchY.ToString());
        }

        public static int GetLength(string notation)
        {
            var matchLength = FindLength.Match(notation);
            return (matchLength != Match.Empty) ? matchLength.ToString()[1] - '1' + 1 : (int)BattleshipsTypes.PatrolBoat;
        }

        public static Direction GetDirection(string notation)
        {
            var matchDirection = FindDirection.Match(notation);
            return (matchDirection != Match.Empty && matchDirection.ToString()[0] == '|')
                ? Direction.Vertical
                : Direction.Horizontal;
        }
    }
}

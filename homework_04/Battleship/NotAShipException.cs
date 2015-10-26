using System;

namespace Battleship
{
    public class NotAShipException: Exception
    {
        public NotAShipException(string message): base(message)
        { }
    }
}

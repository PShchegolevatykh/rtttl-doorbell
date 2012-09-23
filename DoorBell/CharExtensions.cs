using System;
using Microsoft.SPOT;

namespace DoorBell
{
    public static class CharExtensions
    {
        public static bool IsDigit(char symbol)
        {
            return symbol >= '0' && symbol <= '9';
        }
    }
}

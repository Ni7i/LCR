using System;

namespace LCR2
{
    internal class Wuerfel
    {
        public const int MAX_NUMMER = 6;
        private readonly Random random = new Random();
        public int LetzteZahl { get; private set; }

        public void Wuerfle()
        {
            LetzteZahl = random.Next(1, MAX_NUMMER + 1);
        }
    }
}
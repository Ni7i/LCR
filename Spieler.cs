using System;
using System.Collections.Generic;

namespace LCR2
{
    internal class Spieler
    {
        private int _chips = 3;
        private readonly string _name;

        public string Name => _name;
        public int Chips => _chips;
        public bool HatNochChips => _chips > 0;
        public int AnzahlWuerfel => _chips < 3 ? _chips : 3;

        public Spieler(string name)
        {
            _name = name;
        }

        public void ErhalteChip() => _chips++;
        public void GebeChipAb() { if (_chips > 0) _chips--; }

        public string PrintNameUndChips()
        {
            return $"{_name} hat {_chips} Chips.";
        }

        public string PrintWuerfel(List<int> wuerfe)
        {
            return $"{_name} hat gewürfelt: {string.Join(", ", wuerfe)}";
        }

        public List<int> SpieleZug(Becher becher)
        {
            becher.Schuettle();
            return becher.GetZahlen(AnzahlWuerfel);
        }
    }
}
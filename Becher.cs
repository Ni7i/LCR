using System.Collections.Generic;

namespace LCR2
{
    internal class Becher
    {
        public const int ANZ_WUERFEL = 3;
        private readonly List<Wuerfel> _wuerfel = new List<Wuerfel>();

        public Becher()
        {
            for (int i = 0; i < ANZ_WUERFEL; i++)
                _wuerfel.Add(new Wuerfel());
        }

        public void Schuettle()
        {
            foreach (var w in _wuerfel)
                w.Wuerfle();
        }

        public List<int> GetZahlen(int anzahl)
        {
            var ergebnisse = new List<int>();
            for (int i = 0; i < anzahl && i < _wuerfel.Count; i++)
                ergebnisse.Add(_wuerfel[i].LetzteZahl);
            return ergebnisse;
        }
    }
}
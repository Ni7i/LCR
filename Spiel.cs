using System;
using System.Collections.Generic;

namespace LCR2

/// <summary>
/// Hauptklasse für das Spiel LCR (Left Center Right).
/// Verwaltet die Spieler, den Spielablauf und die Interaktionen.
/// </summary>  
{
    internal class Spiel
    {
        // Wird in SetzeStartSpieler() gesetzt, bevor das Spiel startet.
        private Spieler _aktuellerSpieler = null!;
        private readonly List<Spieler> _spielerListe;
        private readonly GUI _gui = new GUI();
        private readonly Becher _becher = new Becher();

        public Spiel()
        {
            _spielerListe = _gui.FrageSpielerEingabe();
        }

        public void Spielen()
        {
            if (_spielerListe.Count < 2)
            {
                Console.WriteLine("2 Spieler werden benötigt!");
                return;
            }

            SetzeStartSpieler();

            while (MehrAlsEinSpielerHatChips())
            {
                Console.WriteLine($"\nSpieler {_aktuellerSpieler.Name} ist am Zug!");
                var zahlen = _aktuellerSpieler.SpieleZug(_becher);
                Console.WriteLine(_aktuellerSpieler.PrintWuerfel(zahlen));
                GewuerfelteZahlenVerarbeiten(zahlen);

                _aktuellerSpieler = SpielerRechtsVonAktuellemSpieler();
                _gui.PrintRangliste(_spielerListe);
                Console.WriteLine("### Ende der Runde ###");
            }

            _gui.PrintGewinner(_spielerListe);
        }

        private void SetzeStartSpieler()
        {
            Random rnd = new Random();
            _aktuellerSpieler = _spielerListe[rnd.Next(_spielerListe.Count)];
            Console.WriteLine($"Startspieler: {_aktuellerSpieler.Name}");
        }

        private Spieler SpielerRechtsVonAktuellemSpieler()
        {
            int index = _spielerListe.IndexOf(_aktuellerSpieler);
            return _spielerListe[(index + 1) % _spielerListe.Count];
        }

        private Spieler SpielerLinksVonAktuellemSpieler()
        {
            int index = _spielerListe.IndexOf(_aktuellerSpieler);
            return _spielerListe[(index - 1 + _spielerListe.Count) % _spielerListe.Count];
        }

        private bool MehrAlsEinSpielerHatChips()
        {
            int count = 0;
            foreach (var s in _spielerListe)
                if (s.HatNochChips) count++;
            return count > 1;
        }

        private void GewuerfelteZahlenVerarbeiten(List<int> zahlen)
        {
            foreach (int z in zahlen)
            {
                if (z == 1) ChipNachLinksWeitergeben();
                else if (z == 2) ChipNachRechtsWeitergeben();
                else if (z == 3) ChipInDieMitteLegen();
            }
        }

        private void ChipNachLinksWeitergeben()
        {
            var links = SpielerLinksVonAktuellemSpieler();
            _aktuellerSpieler.GebeChipAb();
            links.ErhalteChip();
            Console.WriteLine($"{_aktuellerSpieler.Name} gibt 1 Chip an {links.Name}");
        }

        private void ChipNachRechtsWeitergeben()
        {
            var rechts = SpielerRechtsVonAktuellemSpieler();
            _aktuellerSpieler.GebeChipAb();
            rechts.ErhalteChip();
            Console.WriteLine($"{_aktuellerSpieler.Name} gibt 1 Chip an {rechts.Name}");
        }

        private void ChipInDieMitteLegen()
        {
            _aktuellerSpieler.GebeChipAb();
            Console.WriteLine($"{_aktuellerSpieler.Name} legt 1 Chip in die Mitte");
        }
    }
}
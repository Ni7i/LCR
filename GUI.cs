using System;
using System.Collections.Generic;

namespace LCR2
{
    internal class GUI
    {
        public List<Spieler> FrageSpielerEingabe()
        {
            var spielerListe = new List<Spieler>();

            while (true)
            {
                Console.Write("Gib den Namen ein: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    break;

                spielerListe.Add(new Spieler(name));

                if (!FrageNochEinSpieler())
                    break;
            }

            return spielerListe;
        }

        public bool FrageNochEinSpieler()
        {
            while (true)
            {
                Console.Write("Möchten Sie noch einen Spieler eingeben? (1) Ja, (2) Nein: ");
                string antwort = Console.ReadLine();

                if (antwort == "1")
                    return true;
                else if (antwort == "2")
                    return false;
                else
                    Console.WriteLine("Gebe 1 oder 2 ein, die sind oben links auf der Tastatur.");
            }
        }

        public void PrintRangliste(List<Spieler> spieler)
        {
            Console.WriteLine("###Punktestand:###");
            foreach (var s in spieler)
                Console.WriteLine($"{s.Name} hat {s.Chips} Chips.");
        }

        public void PrintGewinner(List<Spieler> spieler)
        {
            Console.WriteLine("\n###Endstand:###");
            foreach (var s in spieler)
            {
                if (s.HatNochChips)
                {
                    Console.WriteLine($"Gewonnen hat: {s.Name}");
                    return;
                }
            }
        }
    }
}
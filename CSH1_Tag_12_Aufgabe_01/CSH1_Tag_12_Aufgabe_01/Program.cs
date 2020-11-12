using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_12_Aufgabe_01
{
    class Program
    {
        static List<Klausur> alleKlausuren;
        static List<Fach> alleFaecher;
        static void Main(string[] args)
        {
            Fach cshGrundlagen = new Fach("C# Grundlagen");
            Fach dbm = new Fach("Datenbankmodellierung und SQL");

            alleKlausuren = new List<Klausur>()
            {
                new Klausur(cshGrundlagen, Noten.SehrGut),
                new Klausur(cshGrundlagen, Noten.Befriedigend),

                new Klausur(dbm, Noten.Gut)
            };

            alleFaecher = new List<Fach>()
            {
                cshGrundlagen,
                dbm
            };

            Menu();
        }

        static void Menu()
        {
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Hauptmenü - Bitte wählen");
                Console.WriteLine("1 - Von Klausur zu Fach navigieren");
                Console.WriteLine("2 - Von Fach zu Klausur navigieren");
                Console.WriteLine("3 - Beenden");
                Console.Write(">>> ");
                char c = Console.ReadKey().KeyChar;
                
                switch(c)
                {
                    case '1':
                        KlausurZuFach();
                        break;
                    case '2':
                        FachZuKlausur();
                        break;
                    case '3':
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }

            }
        }

        static void KlausurZuFach()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Bitte Klausur ID eingeben");
                Console.Write("Gültige IDs: ");
                foreach(Klausur k in alleKlausuren)
                {
                    Console.Write(k.ID + "; ");
                }
                Console.Write("\n>>> ");
                
                if(!Int32.TryParse(Console.ReadLine(), out int eingabe))
                {
                    Fehlermeldung("Eingabe muss Zahl sein!");
                    continue;
                }
                else if(!alleKlausuren.Any(k => k.ID == eingabe))
                {
                    Fehlermeldung("ID nicht vorhanden!");
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Fach-Bezeichnung: " + alleKlausuren.Find(k => k.ID == eingabe).Fach.Bezeichnung);
                Console.WriteLine("\n\nAny Key für erneute Abfrage & ESC um zum Hauptmenü zurückzukehren");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
        }

        static void FachZuKlausur()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Bitte Fach ID eingeben");
                Console.Write("Gültige IDs: ");
                foreach (Fach f in alleFaecher)
                {
                    Console.Write(f.ID + "; ");
                }
                Console.Write("\n>>> ");

                if (!Int32.TryParse(Console.ReadLine(), out int eingabe))
                {
                    Fehlermeldung("Eingabe muss Zahl sein!");
                    continue;
                }
                else if (!alleFaecher.Any(f => f.ID == eingabe))
                {
                    Fehlermeldung("ID nicht vorhanden!");
                    continue;
                }

                Console.Clear();

                Console.WriteLine("Fach:\t\t" + alleFaecher.Find(f => f.ID == eingabe).Bezeichnung);
                foreach(Klausur k in alleFaecher.Find(f => f.ID == eingabe).Klausuren)
                {
                    Console.WriteLine("Klausur ID:\t" + k.ID);
                    Console.WriteLine("Note:\t\t" + Note(k.Note));
                    Console.WriteLine("-----------------------------\n");
                }

                Console.WriteLine("\n\nAny Key für erneute Abfrage & ESC um zum Hauptmenü zurückzukehren");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
        }

        static void Fehlermeldung(string meldung)
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine(meldung);
            Console.ReadKey();
        }
        static string Note(Noten n)
        {
            switch (n)
            {
                case Noten.SehrGut:
                    return "Sehr Gut";
                case Noten.Gut:
                    return "Gut";
                case Noten.Befriedigend:
                    return "Befriedigend";
                case Noten.Ausreichend:
                    return "Ausreichend";
                case Noten.Mangelhaft:
                    return "Mangelhaft";
                case Noten.Ungenügend:
                    return "Ungenügend";
            }
            return "ERROR";
        }
    }
}

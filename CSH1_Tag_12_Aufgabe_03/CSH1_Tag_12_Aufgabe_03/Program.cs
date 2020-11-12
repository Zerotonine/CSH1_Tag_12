using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_12_Aufgabe_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Empfaenger rainer = new Empfaenger("Rainer");
            Empfaenger elsbeth = new Empfaenger("Elsbeth");

            Rechnung rainerR1 = new Rechnung(Convert.ToDateTime("01.01.2020"), 500.23, rainer);
            Rechnung rainerR2 = new Rechnung(Convert.ToDateTime("10.05.2020"), 1500.50, rainer);
            Rechnung rainerR3 = new Rechnung(Convert.ToDateTime("21.09.2020"), 100.15, rainer);
            rainerR3.Bezahlt = true;

            Rechnung elsbethR1 = new Rechnung(Convert.ToDateTime("12.12.2019"), 323.10, elsbeth);
            Rechnung elsbethR2 = new Rechnung(Convert.ToDateTime("02.10.2020"), 600.00, elsbeth);

            Console.CursorVisible = false;
            Menu();
        }

        static void Menu()
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                Headline("Hauptmenü");
                Console.WriteLine("\t1 - Rechnungen anzeigen");
                Console.WriteLine("\t2 - Rechnungen als bezahlt deklarieren");
                Console.WriteLine("\tESC - Beenden");

                ck = Console.ReadKey(true).Key;
                switch(ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        RechnungenAnzeigenMenu();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        RechnungenBezahlenMenu();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static void Fehlermeldung(string meldung)
        {
            Console.Clear();
            Console.Beep();
            Headline("!!!Fehler!!!");
            Console.WriteLine("\t" + meldung);
            Console.ReadKey();
        }

        static void Headline(string s)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(s + "\n");
            Console.ResetColor();
        }

        static void RechnungenAnzeigenMenu()
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen");
                Console.WriteLine("\t1 - Pro Rechnung");
                Console.WriteLine("\t2 - Pro Empfänger");;
                Console.WriteLine("\tESC - Zurück");
                //Console.Write("\t>>> ");
                ck = Console.ReadKey(true).Key;
                switch (ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ProRechnungMenu();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ProEmpfaengerMenu(EmpfaengerAuswahl());
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static void AlleRechnungenAnzeigen()
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Alle");
            foreach(Rechnung r in Rechnung.AlleRechnungen)
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }
        static void AlleRechnungenAnzeigen(Empfaenger e)
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Alle");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => r.Rechnungsempfaenger == e))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleBezahltenRechnungenAnzeigen()
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Bezahlt");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => r.Bezahlt))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleBezahltenRechnungenAnzeigen(Empfaenger e)
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Bezahlt");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => r.Bezahlt && r.Rechnungsempfaenger == e))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleUnbezahltenRechnungenAnzeigen()
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Unbezahlt - Ohne Schwellenwert");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => !r.Bezahlt))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleUnbezahltenRechnungenAnzeigen(Empfaenger e)
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Unbezahlt - Ohne Schwellenwert");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => !r.Bezahlt && r.Rechnungsempfaenger == e))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleUnbezahltenRechnungenAnzeigen(double wert)
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Unbezahlt - Mit Schwellenwert");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => !r.Bezahlt && r.Rechnungsbetrag >= wert))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }

        static void AlleUnbezahltenRechnungenAnzeigen(double wert, Empfaenger e)
        {
            Console.Clear();
            Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Unbezahlt - Mit Schwellenwert");
            foreach (Rechnung r in Rechnung.AlleRechnungen.Where(r => !r.Bezahlt && r.Rechnungsbetrag >= wert && r.Rechnungsempfaenger == e))
            {
                Console.WriteLine("Rechnungsnummer:\t" + r.Rechnungsnummer);
                Console.WriteLine("Rechnungsdatum:\t\t" + r.Rechnungsdatum.ToString("ddd. dd.MM.yyyy"));
                Console.WriteLine("Rechnungsbetrag:\t" + r.Rechnungsbetrag.ToString("0.00"));
                Console.WriteLine("Bezahlt:\t\t" + (r.Bezahlt ? "Ja" : "Nein"));
                Console.WriteLine("Empfänger:\t\t" + r.Rechnungsempfaenger.Name);
                Console.WriteLine("------------------------------------------\n");
            }
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
            Console.ReadKey();
        }
        static void ProRechnungMenu()
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung");
                Console.WriteLine("\t1 - Alle");
                Console.WriteLine("\t2 - Bezahlt");
                Console.WriteLine("\t3 - Unbezahlt");
                Console.WriteLine("\tESC - Zurück");
                //Console.Write("\t>>> ");
                ck = Console.ReadKey(true).Key;
                switch (ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AlleRechnungenAnzeigen();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AlleBezahltenRechnungenAnzeigen();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        UnbezahltMenu();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static void UnbezahltMenu()
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Unbezahlt");
                Console.WriteLine("\t1 - Mit Schwellenwert");
                Console.WriteLine("\t2 - Ohne Schwellenwert");
                Console.WriteLine("\tESC - Zurück");

                ck = Console.ReadKey(true).Key;
                switch (ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        double eingabe;
                        Console.CursorVisible = true;
                        do
                        {
                            Console.Clear();
                            Headline("Hauptmenü - Rechnungen anzeigen - Pro Rechnung - Unbezahlt - Mit Schwellenwert");
                            Console.Write("Bitte Schwellenwert angeben: ");
                        } while (!Double.TryParse(Console.ReadLine(), out eingabe));
                        Console.CursorVisible = false;
                        AlleUnbezahltenRechnungenAnzeigen(eingabe);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AlleUnbezahltenRechnungenAnzeigen();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static void UnbezahltMenu(Empfaenger e)
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Unbezahlt");
                Console.WriteLine("\t1 - Mit Schwellenwert");
                Console.WriteLine("\t2 - Ohne Schwellenwert");
                Console.WriteLine("\tESC - Zurück");

                ck = Console.ReadKey(true).Key;
                switch (ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        double eingabe;
                        Console.CursorVisible = true;
                        do
                        {
                            Console.Clear();
                            Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger - Unbezahlt - Mit Schwellenwert");
                            Console.Write("Bitte Schwellenwert angeben: ");
                        } while (!Double.TryParse(Console.ReadLine(), out eingabe));
                        Console.CursorVisible = false;
                        AlleUnbezahltenRechnungenAnzeigen(eingabe, e);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AlleUnbezahltenRechnungenAnzeigen(e);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static Empfaenger EmpfaengerAuswahl()
        {
            int i;
            while(true)
            {
                Console.CursorVisible = true;
                i = 1;
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger (Empfängerauswahl)");
                Console.WriteLine("\tMögliche Empfänger:");
                foreach(Empfaenger empf in Empfaenger.AlleEmpfaenger)
                {
                    Console.WriteLine("\t" + i++ + " - " + empf.Name);
                }
                Console.WriteLine("--------------------------------------\n");
                Console.Write($"\tBitte Nummer eingeben 1-{Empfaenger.AlleEmpfaenger.Count}: ");
                if(!Int32.TryParse(Console.ReadLine(), out int eingabe))
                {
                    Fehlermeldung("Bitte Zahl eingeben!");
                    continue;
                }
                else if (eingabe < 1 || eingabe > Empfaenger.AlleEmpfaenger.Count)
                {
                    Fehlermeldung("Zahl außerhalb des Gültigkeitsbereiches!");
                    continue;
                }
                Console.CursorVisible = false;
                return Empfaenger.AlleEmpfaenger[eingabe - 1];
            }
        }
        static void ProEmpfaengerMenu(Empfaenger e)
        {
            ConsoleKey ck = new ConsoleKey();
            while (true)
            {
                Console.Clear();
                Headline("Hauptmenü - Rechnungen anzeigen - Pro Empfänger");
                Console.WriteLine("\t1 - Alle");
                Console.WriteLine("\t2 - Bezahlt");
                Console.WriteLine("\t3 - Unbezahlt");
                Console.WriteLine("\tESC - Zurück");
                //Console.Write("\t>>> ");
                ck = Console.ReadKey(true).Key;
                switch (ck)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AlleRechnungenAnzeigen(e);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AlleBezahltenRechnungenAnzeigen(e);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        UnbezahltMenu(e);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Fehlermeldung("Eingabe ungültig!");
                        continue;
                }
            }
        }

        static void RechnungenBezahlenMenu()
        {
            while(true)
            {
                Console.CursorVisible = true;
                Console.Clear();
                Headline("Hauptmenü - Rechnung als bezahlt deklarieren");
                Console.WriteLine("\tMögliche Rechnungen");
                foreach(Rechnung r in Rechnung.AlleRechnungen.Where(r => !r.Bezahlt))
                {
                    Console.WriteLine($"\tR-nummer:\t{r.Rechnungsnummer}\tEmpfänger: {r.Rechnungsempfaenger.Name}\tBetrag: {r.Rechnungsbetrag:0.00}");
                }
                Console.WriteLine("---------------------------------------\n");
                Console.Write("Bitte Rechnungsnummer eingeben (0 für Zurück): ");

                if(!Int32.TryParse(Console.ReadLine(), out int eingabe))
                {
                    Fehlermeldung("Bitte Zahl eingeben!");
                    continue;
                }
                else if(eingabe == 0)
                {
                    return;
                }
                else if(eingabe < 0 || eingabe > Rechnung.AlleRechnungen.Count)
                {
                    Fehlermeldung("Eingabe außerhalb des Gültigkeitsbereiches!");
                    continue;
                }
                Console.CursorVisible = false;

                Rechnung.AlleRechnungen.Find(r => r.Rechnungsnummer == eingabe).Bezahlt = true;
                Console.WriteLine("Rechnung erfolgreich als bezahlt deklariert!");
                Console.WriteLine("Beliebige Taste zum Fortfahren oder ESC für Zurück");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    return;
            }
        }
    }
}

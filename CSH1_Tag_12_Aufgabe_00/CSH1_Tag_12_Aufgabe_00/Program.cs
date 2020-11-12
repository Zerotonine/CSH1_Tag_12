using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_12_Aufgabe_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Interpret gojira = new Interpret("Gojira");

            Song clone = new Song("Clone", 297, gojira);
            Song lizardSkin = new Song("Lizard Skin", 270, gojira);
            Song satanIsALawyer = new Song("Satan Is a Lawyer", 263, gojira);

            Interpret rezz = new Interpret("Rezz");

            Song witchingHour = new Song("Witching Hour", 192, rezz);
            Song spiderOnTheMoon = new Song("Spider On The Moon", 214, rezz);

            List<Song> alleSongs = new List<Song>()
            {
                clone,
                lizardSkin,
                satanIsALawyer,
                witchingHour,
                spiderOnTheMoon
            };

            List<Interpret> alleInterpreten = new List<Interpret>()
            {
                gojira,
                rezz
            };

            WriteHeadline("Gebe alle Songs aus");
            foreach(Song s in alleSongs)
            {
                Console.WriteLine("Interpret:\t" + s.Interpret.Name);
                Console.WriteLine("Titel:\t\t" + s.Titel);
                Console.WriteLine("Dauer: \t\t" + TrackDauer(s));
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("\n\n");
            WriteHeadline("Gebe alle Interpreten aus\n");

            foreach(Interpret i in alleInterpreten)
            {
                WriteHeadline("Interpret:\t" + i.Name);
                foreach(Song s in i.Songs)
                {
                    //Console.WriteLine("Interpret:\t" + i.Name);
                    Console.WriteLine("Titel:\t\t" + s.Titel);
                    Console.WriteLine("Dauer: \t\t" + TrackDauer(s));
                    Console.WriteLine("----------------------------");
                }
            }

            Console.ReadKey();
        }

        static string TrackDauer(Song song)
        {
            return $"{song.DauerInSekunden / 60:D2}:{song.DauerInSekunden % 60:D2}";
        }
        static void WriteHeadline(string text)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}

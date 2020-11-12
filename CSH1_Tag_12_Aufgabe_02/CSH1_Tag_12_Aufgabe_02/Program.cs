using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_12_Aufgabe_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Tierart jaguar = new Tierart("Jaguar", 3.75);
            Tierart leopard = new Tierart("Leopard", 3.10);
            Tierart schaf = new Tierart("Schaf", 4.50);

            Tier shira = new Tier("Shira", jaguar);
            Tier shari = new Tier("Shari", jaguar);
            Tier lopa = new Tier("Lopa", leopard);
            Tier shaun = new Tier("Shaun", schaf);

            Gehege k = new Gehege(2);

            k.Tierart.Add(jaguar);
            k.Tierart.Add(leopard);

            k.AddTier(shira);
            k.AddTier(shaun);
            k.AddTier(lopa);
            k.AddTier(shari);

            k.ZeigeTierListe();

            Console.WriteLine($"\nGesamtfuttermenge:\t{k.FuttermengeGesamt():0.00}");

            Console.ReadKey();
        }
    }
}

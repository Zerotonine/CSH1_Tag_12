using System;
using System.Collections.Generic;
using System.Linq;

public class Gehege
{
    public Gehege(int maximalAnzahlDerTiere)
    {
        this.maximaleAnzahlDerTiere = maximalAnzahlDerTiere;
    }

    public bool AddTier(Tier t)
    {
        if(tiere.Count < maximaleAnzahlDerTiere && tierart.Contains(t.Art))
        {
            tiere.Add(t);
            return true;
        }
        return false;
    }

    public void ZeigeTierListe()
    {
        foreach(Tier t in tiere)
        {
            Console.WriteLine("Name:\t" + t.Name);
            Console.WriteLine("Art:\t" + t.Art);
            Console.WriteLine("--------------------------\n");
        }
    }

    public double FuttermengeGesamt()
    {
        return tiere.Sum(t => t.Art.Futtermenge);
    }

    private List<Tierart> tierart = new List<Tierart>();

    public List<Tierart> Tierart
    {
        get
        {
            return tierart;
        }
    }

    private List<Tier> tiere = new List<Tier>();

    private int maximaleAnzahlDerTiere;

}
using System;
using System.Collections.Generic;

public class Tierart
{
    public Tierart(string bezeichnung, double futtermenge)
    {
        this.bezeichnung = bezeichnung;
        this.futtermenge = futtermenge;
        Tierarten.Add(this);
    }

    public static List<Tierart> Tierarten = new List<Tierart>();

    private string bezeichnung;

    public string Bezeichnung
    {
        get
        {
            return bezeichnung;
        }
        set
        {
            bezeichnung = value;
        }
    }

    private double futtermenge;

    public double Futtermenge
    {
        get
        {
            return futtermenge;
        }
        set
        {
            futtermenge = value;
        }
    }

}
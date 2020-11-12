using System;
using System.Collections.Generic;

public class Empfaenger
{
    private static List<Empfaenger> alleEmpfaenger = new List<Empfaenger>();

    public static  List<Empfaenger> AlleEmpfaenger
    {
        get
        {
            return alleEmpfaenger;
        }
    }

    public Empfaenger(string name)
    {
        this.name = name;
        alleEmpfaenger.Add(this);
    }

    private string name;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    private List<Rechnung> rechnungen = new List<Rechnung>();

    public List<Rechnung> Rechnungen
    {
        get
        {
            return rechnungen;
        }
    }

}
using System;
using System.Collections.Generic;

public class Tier
{
    public Tier(string name, Tierart art)
    {
        this.name = name;
        this.art = art;
        this.iD = ++counter;
        Tiere.Add(this);
    }

    public static List<Tier> Tiere = new List<Tier>();

    private int iD;

    public int ID
    {
        get
        {
            return iD;
        }
    }

    private static int counter = 0;

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

    private Tierart art;

    public Tierart Art
    {
        get
        {
            return art;
        }
        set
        {
            art = value;
        }
    }

}
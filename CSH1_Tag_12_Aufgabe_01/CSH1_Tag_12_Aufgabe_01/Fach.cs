using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fach
{
    private int iD;

    public int ID
    {
        get
        {
            return iD;
        }
    }

    private static int counter = 0;

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

    private List<Klausur> klausuren = new List<Klausur>();

    public List<Klausur> Klausuren
    {
        get
        {
            return klausuren;
        }
    }

    public Fach(string bezeichnung)
    {
        this.bezeichnung = bezeichnung;
        this.iD = ++counter;
    }
}
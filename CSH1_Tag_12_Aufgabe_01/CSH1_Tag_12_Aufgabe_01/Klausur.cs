using System;

public class Klausur
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

    public Klausur(Fach fach, Noten note)
    {
        this.fach = fach;
        this.note = note;
        fach.Klausuren.Add(this);
        this.iD = ++counter;
    }
    private Noten note;

    public Noten Note
    {
        get
        {
            return note;
        }
        set
        {
            note = value;
        }
    }

    private Fach fach;

    public Fach Fach
    {
        get
        {
            return fach;
        }
    }

}
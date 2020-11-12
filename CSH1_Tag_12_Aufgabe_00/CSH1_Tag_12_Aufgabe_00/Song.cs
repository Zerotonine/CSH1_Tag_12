using System;

public class Song
{
    private string titel;

    public string Titel
    {
        get
        {
            return titel;
        }
        set
        {
            titel = value;
        }
    }

    public Song(string titel, int dauerInSekunden, Interpret interpret)
    {
        this.titel = titel;
        this.dauerInSekunden = dauerInSekunden;
        this.interpret = interpret;
        this.interpret.Songs.Add(this);
    }

    private Interpret interpret;

    public Interpret Interpret
    {
        get
        {
            return interpret;
        }
        set
        {
            interpret = value;
        }
    }

    private int dauerInSekunden;

    public int DauerInSekunden
    {
        get
        {
            return dauerInSekunden;
        }
        set
        {
            dauerInSekunden = value;
        }
    }

    

}
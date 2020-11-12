using System;
using System.Collections.Generic;

public class Rechnung
{
    private static List<Rechnung> alleRechnungen = new List<Rechnung>();

    public static List<Rechnung> AlleRechnungen
    {
        get => alleRechnungen;
    }

    public Rechnung(DateTime rechnungsdatum, double rechnungsbetrag, Empfaenger rechnungsempfaenger)
    {
        this.rechnungsdatum = rechnungsdatum;
        this.rechnungsbetrag = rechnungsbetrag;
        this.rechnungsempfaenger = rechnungsempfaenger;
        this.rechnungsnummer = ++counter;
        alleRechnungen.Add(this);
    }

    private int rechnungsnummer;

    public int Rechnungsnummer
    {
        get
        {
            return rechnungsnummer;
        }
    }

    private static int counter = 0;

    private DateTime rechnungsdatum;

    public DateTime Rechnungsdatum
    {
        get
        {
            return rechnungsdatum;
        }
        set
        {
            rechnungsdatum = value;
        }
    }

    private double rechnungsbetrag;

    public double Rechnungsbetrag
    {
        get
        {
            return rechnungsbetrag;
        }
        set
        {
            rechnungsbetrag = value;
        }
    }

    private Empfaenger rechnungsempfaenger;

    public Empfaenger Rechnungsempfaenger
    {
        get
        {
            return rechnungsempfaenger;
        }
        set
        {
            rechnungsempfaenger = value;
        }
    }

    private bool bezahlt;

    public bool Bezahlt
    {
        get
        {
            return bezahlt;
        }
        set
        {
            bezahlt = value;
        }
    }



}
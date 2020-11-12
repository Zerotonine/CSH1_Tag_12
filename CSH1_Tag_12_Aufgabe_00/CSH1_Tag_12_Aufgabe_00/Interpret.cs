using System;
using System.Collections.Generic;

public class Interpret
{
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

    private List<Song> songs = new List<Song>();

    public List<Song> Songs
    {
        get
        {
            return songs;
        }
    }


    public Interpret(string name)
    {
        this.name = name;
    }
}
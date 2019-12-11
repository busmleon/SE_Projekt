using System;

public class Spielfigur
{
    private string farbe;
    private int zaehler;

    public Spielfigur(string farbe)
    {
        Farbe = farbe;
        Zaehler = 0;
    }

    public int Ziehe(int schritte)
    {
        zaehler += schritte;
        return zaehler;
    }

    public string Farbe
    {
        get
        {
            return farbe;
        }

        set
        {
            if (value == "rot" || value == "gelb" || value == "grün" || value == "blau" || value == "weiss")
            {
                farbe = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public int Zaehler
    {
        get
        {
            return zaehler;
        }

        set
        {
            zaehler = value;
        }
    }
}
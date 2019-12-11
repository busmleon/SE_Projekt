using neuesSpiel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_Spiel
{
    // GUI liefert folgende Trigger:
    // Würfeln
    // Click des ausgewählten Feldes
    class Spielbrett
    {
        private delegate string ZugHandler();
        public Spielfigur[] zugFelder;
        // Spieler erhalten ein Attribut mit der Anzahl verfügbarer SpielSpielfiguren, mit Wert 4 initialisiert
        public Spieler SpielerGrün;
        public Spieler SpielerRot;
        public Spieler SpielerBlau;
        public Spieler SpielerGelb;
        public Spielfigur[] HausGrün;
        public Spielfigur[] HausRot;
        public Spielfigur[] HausBlau;
        public Spielfigur[] HausGelb;
        public Spielfigur[] refHaus;
        bool status;

        public Spieler amZug;
        public int laufweite;

        // Startmethode, erhält von der GUI die Anzahl der Spieler
        public bool Start(int anzahl)
        {
            // Von der GUI kommt keine Angabe dazu, welcher Spieler startet
            zugFelder = new Spielfigur[40];
            switch (anzahl)
            {
                case 2:
                    SpielerGelb = new Spieler("Peter", "gelb");
                    SpielerGrün = new Spieler("Martin", "grün");
                    HausGelb = new Spielfigur[4];
                    HausGrün = new Spielfigur[4];
                    amZug = SpielerGelb;
                    refHaus = HausGelb;
                    return true;
                case 3:
                    SpielerGelb = new Spieler("Peter", "gelb");
                    SpielerGrün = new Spieler("Petet", "grün");
                    SpielerBlau = new Spieler("fldaj", "blau");
                    HausGelb = new Spielfigur[4];
                    HausGrün = new Spielfigur[4];
                    HausBlau = new Spielfigur[4];
                    amZug = SpielerGelb;
                    refHaus = HausGelb;
                    return true;
                case 4:
                    SpielerGrün = new Spieler("Petet", "grün");
                    SpielerRot = new Spieler("Hans", "rot");
                    SpielerBlau = new Spieler("fldaj", "blau");
                    SpielerGelb = new Spieler("fdsjaf", "gelb");
                    HausGelb = new Spielfigur[4];
                    HausGrün = new Spielfigur[4];
                    HausBlau = new Spielfigur[4];
                    HausRot = new Spielfigur[4];
                    status = false;
                    amZug = SpielerGelb;
                    refHaus = HausGelb;
                    return true;
                default:
                    return false;
            }
        }

        // GUI liefert Index der zu bewegenden Figur
        public bool Ziehe()
        {
            switch (amZug.Farbe)
            {
                case "grün":
                    return ZugGrün();
                case "rot":
                    return ZugRot();
                //return new NeuesSpiel().SpielerAnzahl == 4 ? false : ZugRot();
                case "blau":
                    return ZugBlau();
                //return new NeuesSpiel().SpielerAnzahl == 4 ? false : ZugBlau();
                case "gelb":
                    return ZugGelb();
            }
            return false;
        }

        private void Switch()
        {
            NeuesSpiel neuesSpiel = new NeuesSpiel();
            status = false;
            switch (amZug.Farbe)
            {
                case "grün":
                    if (NeuesSpiel.spielerAnzahl >= 3)
                    {
                        amZug = SpielerBlau;
                        refHaus = HausBlau;
                    }
                    else
                    {
                        amZug = SpielerGelb;
                        refHaus = HausGelb;
                    }

                    break;
                case "rot":
                    amZug = SpielerGelb;
                    refHaus = HausGelb;
                    break;
                case "blau":
                    if (NeuesSpiel.spielerAnzahl == 4)
                    {
                        amZug = SpielerRot;
                        refHaus = HausRot;
                    }
                    else
                    {
                        amZug = SpielerGelb;
                        refHaus = HausGelb;
                    }
                    break;
                case "gelb":
                    amZug = SpielerGrün;
                    refHaus = HausGrün;
                    break;
            }
        }

        public void GUI_Ziehe(int pos)
        {
            if (pos > 40)
            {
                ZugZulässig(pos);
            }
            // NullReferenceException vermeiden
            else if (zugFelder[pos - 1] == null || zugFelder[pos - 1].Farbe != amZug.Farbe)
            {

            }
            // Nicht aus Pott
            if (ZugZulässig(pos) && laufweite != 6 && laufweite != 0)
            {
                Switch();
                laufweite = 0;
            }
        }

        // Würfel wird geworfen
        public void GUI_Wuerfle()
        {
            if (!status)
            {
                if (amZug.Pott == 4 || amZug.Pott == (4 - AnzahlHaus(amZug.Farbe)))
                {
                    int i = 0;
                    laufweite = new Random().Next(6, 7);
                    while (i < 2 && laufweite != 6)
                    {

                        laufweite = new Random().Next(6, 7);
                        i++;
                    }
                    if (laufweite != 6)
                    {
                        laufweite = 0;
                        Switch();
                    }
                }
                else
                {
                    laufweite = new Random().Next(6, 7);
                    if (laufweite != 6)
                    {
                        status = true;
                    }
                }
                // Aut. aus Pott ??
                Ziehe();
            }
        }

        // Start bei Feld 11
        public bool ZugGrün()
        {
            // Fall: Pott besetzt und 6 gewürfelt und Zug möglich
            if (laufweite == 6 && amZug.Pott > 0)
            {
                if (zugFelder[10] == null)
                {
                    SpielerGrün.Pott -= 1;
                    zugFelder[10] = new Spielfigur("grün");
                    laufweite = 0;
                    return true;
                }
                //if (zugFelder[10].Farbe == "grün")
                //{
                //    zugFelder[10].Farbe = "weiss";
                //    zugFelder[10 + laufweite] = new Spielfigur("grün");
                //    laufweite = 0;
                //    return true;
                //}
                else if (zugFelder[10].Farbe != "grün")
                {
                    switch (zugFelder[10].Farbe)
                    {
                        case "blau":
                            SpielerBlau.Pott += 1;
                            break;
                        case "rot":
                            SpielerRot.Pott += 1;
                            break;
                        case "gelb":
                            SpielerGelb.Pott += 1;
                            break;
                    }
                    SpielerGrün.Pott -= 1;
                    zugFelder[10] = new Spielfigur("grün");
                }
            }
            return false;
            // andernfalls wird von der GUI eine Figur gewählt
        }

        // Start bei Feld 31
        public bool ZugRot()
        {
            // Fall: Pott besetzt und 6 gewürfelt und Zug möglich
            if (laufweite == 6 && amZug.Pott > 0)
            {
                if (zugFelder[30] == null)
                {
                    SpielerRot.Pott -= 1;
                    zugFelder[30] = new Spielfigur("rot");
                    laufweite = 0;
                    return true;
                }
                //if (zugFelder[30].Farbe == "rot")
                //{
                //    zugFelder[30].Farbe = "weiss";
                //    zugFelder[30 + laufweite] = new Spielfigur("rot");
                //    laufweite = 0;
                //    return true;
                //}
                else if (zugFelder[30].Farbe != "rot")
                {
                    switch (zugFelder[30].Farbe)
                    {
                        case "blau":
                            SpielerBlau.Pott += 1;
                            break;
                        case "grün":
                            SpielerGrün.Pott += 1;
                            break;
                        case "gelb":
                            SpielerGelb.Pott += 1;
                            break;
                    }
                    SpielerRot.Pott -= 1;
                    zugFelder[30] = new Spielfigur("rot");
                }
            }
            return false;
        }

        // Start bei Feld 21
        public bool ZugBlau()
        {
            // Fall: Pott besetzt und 6 gewürfelt und Zug möglich
            if (laufweite == 6 && amZug.Pott > 0)
            {
                if (zugFelder[20] == null)
                {
                    SpielerBlau.Pott -= 1;
                    zugFelder[20] = new Spielfigur("blau");
                    laufweite = 0;
                    return true;
                }
                //if (zugFelder[20].Farbe == "blau")
                //{
                //    zugFelder[20].Farbe = "weiss";
                //    zugFelder[20 + laufweite] = new Spielfigur("blau");
                //    laufweite = 0;
                //    return true;
                //}
                else if (zugFelder[20].Farbe != "blau")
                {
                    switch (zugFelder[20].Farbe)
                    {
                        case "grün":
                            SpielerGrün.Pott += 1;
                            break;
                        case "rot":
                            SpielerRot.Pott += 1;
                            break;
                        case "gelb":
                            SpielerGelb.Pott += 1;
                            break;
                    }
                    SpielerBlau.Pott -= 1;
                    zugFelder[20] = new Spielfigur("blau");
                }
            }
            return false;
        }

        // Start bei Feld 1
        public bool ZugGelb()
        {
            // Fall: Pott besetzt und 6 gewürfelt und Zug möglich
            if (laufweite == 6 && amZug.Pott > 0)
            {
                if (zugFelder[0] == null)
                {
                    SpielerGelb.Pott -= 1;
                    zugFelder[0] = new Spielfigur("gelb");
                    laufweite = 0;
                    return true;
                }

                //if (zugFelder[0].Farbe == "gelb")
                //{
                //    zugFelder[0].Farbe = "weiss";
                //    zugFelder[0 + laufweite] = new Spielfigur("gelb");
                //    laufweite = 0;
                //    return true;
                //}

                else if (zugFelder[0].Farbe != "gelb")
                {
                    switch (zugFelder[0].Farbe)
                    {
                        case "blau":
                            SpielerBlau.Pott += 1;
                            break;
                        case "rot":
                            SpielerRot.Pott += 1;
                            break;
                        case "grün":
                            SpielerGrün.Pott += 1;
                            break;
                    }
                    zugFelder[0] = new Spielfigur("gelb");
                    SpielerGelb.Pott -= 1;
                }
            }
            return false;
        }

        private void Schlagen(int index, int ziel)
        {
            if (zugFelder[ziel] != null)
            {
                switch (zugFelder[ziel].Farbe)
                {
                    case "grün":
                        SpielerGrün.Pott += 1;
                        zugFelder[ziel] = zugFelder[index];
                        zugFelder[index] = null;
                        zugFelder[ziel].Zaehler += laufweite;
                        break;
                    case "rot":
                        SpielerRot.Pott += 1;
                        zugFelder[ziel] = zugFelder[index];
                        zugFelder[index] = null;
                        zugFelder[ziel].Zaehler += laufweite;
                        break;
                    case "gelb":
                        SpielerGelb.Pott += 1;
                        zugFelder[ziel] = zugFelder[index];
                        zugFelder[index] = null;
                        zugFelder[ziel].Zaehler += laufweite;
                        break;
                    case "blau":
                        SpielerBlau.Pott += 1;
                        zugFelder[ziel] = zugFelder[index];
                        zugFelder[index] = null;
                        zugFelder[ziel].Zaehler += laufweite;
                        break;
                }
            }
            else
            {
                zugFelder[ziel] = zugFelder[index];
                zugFelder[index] = null;
            }
        }

        private bool ZugZulässig(int index)
        {
            if (laufweite == 6 && amZug.Pott > 0)
            {
                switch (amZug.Farbe)
                {
                    case "grün":
                        if (zugFelder[10].Farbe == "grün")
                        {
                            zugFelder[10 + laufweite] = new Spielfigur("grün");
                            zugFelder[10] = null;
                            Switch();
                            return true;
                        }
                        amZug.Pott -= 1;
                        zugFelder[10] = new Spielfigur("grün");
                        break;
                    case "rot":
                        if (zugFelder[30].Farbe == "rot")
                        {
                            zugFelder[30 + laufweite] = new Spielfigur("rot");
                            zugFelder[30] = null;
                            Switch();
                            return true;
                        }
                        amZug.Pott -= 1;
                        zugFelder[30] = new Spielfigur("rot");
                        break;
                    case "blau":
                        if (zugFelder[20].Farbe == "blau")
                        {
                            zugFelder[20 + laufweite] = new Spielfigur("blau");
                            zugFelder[20] = null;
                            Switch();
                            return true;
                        }
                        amZug.Pott -= 1;
                        zugFelder[20] = new Spielfigur("blau");
                        break;
                    case "gelb":
                        if (zugFelder[0].Farbe == "gelb")
                        {
                            zugFelder[0 + laufweite] = new Spielfigur("gelb");
                            zugFelder[0] = null;
                            Switch();
                            return true;
                        }
                        amZug.Pott -= 1;
                        zugFelder[0] = new Spielfigur("gelb");
                        break;
                }
                Switch();
                //laufweite = 0;
                return true;
            }
            // Figur befindet sich bereits im Haus, HÄNGT VON DER GUI AB
            if (index > 40)
            {
                // gelb
                if (index < 45)
                {
                    for (int i = index - 40; i < 4; i++)
                    {
                        if (HausGelb[i] != null)
                        {
                            return false;
                        }
                    }
                    HausGelb[index - 41 + laufweite] = HausGelb[index - 4];
                    HausGelb[index - 41] = null;
                    return true;
                }
                // grün
                else if (index < 49 && index > 44)
                {
                    for (int i = index - 44 - 1; i < 4; i++)
                    {
                        if (HausGrün[i] != null)
                        {
                            return false;
                        }
                    }
                    HausGrün[index - 45 + laufweite] = HausGrün[index - 45];
                    HausGrün[index - 45] = null;
                    return true;
                }
                // blau
                else if (index < 53 && index > 48)
                {
                    for (int i = index - 48 - 1; i < 4; i++)
                    {
                        if (HausBlau[i] != null)
                        {
                            return false;
                        }
                    }
                    HausBlau[index - 49 + laufweite] = HausBlau[index - 49];
                    HausBlau[index - 49] = null;
                    return true;
                }
                // rot
                else
                {
                    for (int i = index - 52 - 1; i < 4; i++)
                    {
                        if (HausRot[i] != null)
                        {
                            return false;
                        }
                    }
                    HausRot[index - 53 + laufweite] = HausRot[index - 53];
                    HausRot[index - 53] = null;
                    return true;
                }
            }
            if (zugFelder[index - 1] == null || zugFelder[index - 1].Farbe != amZug.Farbe)
            {
                return false;
            }
            // Müsste in Haus ziehen
            else if (zugFelder[index - 1].Zaehler + laufweite > 39 && zugFelder[index - 1].Zaehler + laufweite < 44)
            {
                MessageBox.Show("Ab ins Haus");
                switch (zugFelder[index - 1].Farbe)
                {
                    case "gelb":
                        if (HausGelb[zugFelder[index - 1].Zaehler + laufweite - 40] == null)
                        {
                            HausGelb[zugFelder[index - 1].Zaehler + laufweite - 40] = zugFelder[index - 1];
                            zugFelder[index - 1] = null;
                            return true;
                        }
                        break;
                    case "grün":
                        if (HausGrün[zugFelder[index - 1].Zaehler + laufweite - 40] == null)
                        {
                            HausGrün[zugFelder[index - 1].Zaehler + laufweite - 40] = zugFelder[index - 1];
                            zugFelder[index - 1] = null;
                            return true;
                        }
                        break;
                    case "blau":
                        if (HausBlau[zugFelder[index - 1].Zaehler + laufweite - 40] == null)
                        {
                            HausBlau[zugFelder[index - 1].Zaehler + laufweite - 40] = zugFelder[index - 1];
                            zugFelder[index - 1] = null;
                            return true;
                        }
                        break;
                    case "rot":
                        if (HausRot[zugFelder[index - 1].Zaehler + laufweite - 40] == null)
                        {
                            HausRot[zugFelder[index - 1].Zaehler + laufweite - 40] = zugFelder[index - 1];
                            zugFelder[index - 1] = null;
                            return true;
                        }
                        break;
                }
                // Ist Feld im Haus frei ?
                if (HausGelb[zugFelder[index - 1].Zaehler + laufweite - 40 - 1] == null)
                {
                    MessageBox.Show("ziehe ins gelbe Haus");
                    HausGelb[zugFelder[index - 1].Zaehler + laufweite - 40 - 1] = zugFelder[index - 1];
                    zugFelder[index - 1] = null;
                    return true;
                }
                //if (refHaus[(zugFelder[index].Zaehler + laufweite - 40 - 1)] != null)
                //{
                //    return false;
                //}
                else
                {
                    refHaus[(zugFelder[index].Zaehler + laufweite - 40 - 1)] = zugFelder[index - 1];
                    zugFelder[index - 1] = null;
                    return true;
                }
            }
            // Bewegt sich im Feld
            // überschreitet Grenze des Arrays ?
            if (index + laufweite > 40)
            {
                if (zugFelder[index + laufweite - 40] == null)
                {
                    Schlagen(index - 1, (index + laufweite) - 40 - 1);
                    return true;
                }
                else
                {
                    if (zugFelder[index - 1].Farbe == amZug.Farbe)
                    {
                        return false;
                    }
                    else
                    {
                        Schlagen(index, index + laufweite);
                        return true;
                    }
                }
            }
            if (zugFelder[index - 1 + laufweite] != null)
            {
                // Feld mit Spieler gleicher Farbe
                if (zugFelder[index - 1 + laufweite].Farbe == amZug.Farbe)
                {
                    return false;
                }
                else
                {
                    Schlagen(index - 1, index + laufweite - 1);
                    return true;
                }
            }
            else
            {
                zugFelder[index - 1 + laufweite] = zugFelder[index - 1];
                zugFelder[index - 1] = null;
                zugFelder[index - 1 + laufweite].Zaehler += laufweite;
                return true;
            }
        }

        private int AnzahlHaus(string farbe)
        {
            switch (farbe)
            {
                case "rot":
                    int i = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (HausRot[j] != null)
                        {
                            i++;
                        }
                    }
                    return i;
                case "blau":
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (HausBlau[j] != null)
                        {
                            k++;
                        }
                    }
                    return k;
                case "grün":
                    int x = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (HausGrün[j] != null)
                        {
                            x++;
                        }
                    }
                    return x;
                case "gelb":
                    int y = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (HausGelb[j] != null)
                        {
                            y++;
                        }
                    }
                    return y;
            }
            return 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Spiel
{
    class Spieler
    {
        // Attribute
        //

        private int[] spieler = new int[4] { 0, 1, 2, 3}; 
        private int aktueller_spieler=0;
        private string spieler_Farbe;
        private string name;
        private int imPott;

        public int Pott
        {
            get
            {
                return imPott;
            }
            set
            {
                if (value >= 0 && value < 5)
                {
                    imPott = value;
                }
            }
        }
         

        // Konstruktor
        //
        public Spieler()
        {

        }

        public string Farbe
        {
            set
            {
                spieler_Farbe = value;
            }
            get
            {
                return spieler_Farbe;
            }
        }
        
        public Spieler(string spieler_name, string Farbe)
        {
            name = spieler_name;
            spieler_Farbe = Farbe;
            Pott = 4;
        }


        // Methoden
        //

        public void Figur_geht_raus() // Erst wenn 6 gewürfelt wurde
        {
        }

        public void Spielerdran()
        {
            //
            if (spieler[aktueller_spieler] == 0)
            {
                //Spieler Gelb ist dran
                aktueller_spieler = Zug_gemacht(aktueller_spieler);
            }
            else if (spieler[aktueller_spieler] == 1)
            {
                //Spieler Grün ist dran
                aktueller_spieler = Zug_gemacht(aktueller_spieler);
            }
            else if (spieler[aktueller_spieler] == 2)
            {
                //Spieler Rot ist dran
                aktueller_spieler = Zug_gemacht(aktueller_spieler);
            }
            else if (spieler[aktueller_spieler] == 3)
            {
                //Spieler Schwarz ist dran
                aktueller_spieler = Zug_gemacht(aktueller_spieler);
            }

        }

        public int Zug_gemacht(int merk)
        {
            if (merk <= 2)
                return ++merk;
            else
                return 0;
        }
    }
}


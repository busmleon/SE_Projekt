using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using neuesSpiel;

namespace GUI_Spiel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Used color codes:
        Gelb:   #FFFFFF00
        Grün:   #FF1BC909
        Blau:   #FF2027B9
        Rot:    #FFF01616*/

        SolidColorBrush gelb = new SolidColorBrush();
        SolidColorBrush gruen = new SolidColorBrush();
        SolidColorBrush blau = new SolidColorBrush();
        SolidColorBrush rot = new SolidColorBrush();
        SolidColorBrush weiss = new SolidColorBrush();

        Ellipse[] ellArr = new Ellipse[40];
        Ellipse[] ellGelbHaus = new Ellipse[4];
        Ellipse[] ellBlauHaus = new Ellipse[4];
        Ellipse[] ellGruenHaus = new Ellipse[4];
        Ellipse[] ellRotHaus = new Ellipse[4];

        int index;

        bool beginnNeuesSpiel = false;

        Spielbrett spielbrett = new Spielbrett();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_neuesSpiel_Click(object sender, RoutedEventArgs e)
        {
            NeuesSpiel.spielerAnzahl = 0;
            NeuesSpiel frm = new NeuesSpiel();
            frm.ShowDialog();

            switch (NeuesSpiel.spielerAnzahl)
            {
                case 2:
                    lbl_SpielerU.Content = frm.txt_Spieler1.Text;       // Gelb
                    lbl_SpielerLi.Content = frm.txt_Spieler2.Text;      // Grün
                    lbl_SpielerO.Content = "";                          // Blau
                    lbl_SpielerRe.Content = "";                         // Rot
                    spielbrett.Start(2);
                    break;
                case 3:
                    lbl_SpielerU.Content = frm.txt_Spieler1.Text;       // Gelb
                    lbl_SpielerLi.Content = frm.txt_Spieler2.Text;      // Grün
                    lbl_SpielerO.Content = frm.txt_Spieler3.Text;       // Blau
                    lbl_SpielerRe.Content = "";                         // Rot
                    spielbrett.Start(3);
                    break;
                case 4:
                    lbl_SpielerU.Content = frm.txt_Spieler1.Text;       // Gelb
                    lbl_SpielerLi.Content = frm.txt_Spieler2.Text;      // Grün
                    lbl_SpielerO.Content = frm.txt_Spieler3.Text;       // Blau
                    lbl_SpielerRe.Content = frm.txt_Spieler4.Text;      // Rot
                    spielbrett.Start(4);
                    break;
                default:
                    break;
            }

            // Festlegen der Farben zur Überprüfung #FFCDCDCD
            gelb = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF00"));
            gruen = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1BC909"));
            blau = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF2027B9"));
            rot = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF01616"));
            weiss = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF4F4F5"));

            EllArrIni();

            PositionsPruefung();

            beginnNeuesSpiel = true;
        }

        private void btn_wuerfeln_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                spielbrett.GUI_Wuerfle();
                lbl_wurfErg.Content = spielbrett.laufweite.ToString();
                PositionsPruefung();
            }
        }

        public void EllArrIni()
        {
            ellArr[0] = e01;
            ellArr[1] = e02;
            ellArr[2] = e03;
            ellArr[3] = e04;
            ellArr[4] = e05;
            ellArr[5] = e06;
            ellArr[6] = e07;
            ellArr[7] = e08;
            ellArr[8] = e09;
            ellArr[9] = e10;
            ellArr[10] = e11;
            ellArr[11] = e12;
            ellArr[12] = e13;
            ellArr[13] = e14;
            ellArr[14] = e15;
            ellArr[15] = e16;
            ellArr[16] = e17;
            ellArr[17] = e18;
            ellArr[18] = e19;
            ellArr[19] = e20;
            ellArr[20] = e21;
            ellArr[21] = e22;
            ellArr[22] = e23;
            ellArr[23] = e24;
            ellArr[24] = e25;
            ellArr[25] = e26;
            ellArr[26] = e27;
            ellArr[27] = e28;
            ellArr[28] = e29;
            ellArr[29] = e30;
            ellArr[30] = e31;
            ellArr[31] = e32;
            ellArr[32] = e33;
            ellArr[33] = e34;
            ellArr[34] = e35;
            ellArr[35] = e36;
            ellArr[36] = e37;
            ellArr[37] = e38;
            ellArr[38] = e39;
            ellArr[39] = e40;

            ellGelbHaus[0] = hu1;
            ellGelbHaus[1] = hu2;
            ellGelbHaus[2] = hu3;
            ellGelbHaus[3] = hu4;

            ellGruenHaus[0] = hl1;
            ellGruenHaus[1] = hl2;
            ellGruenHaus[2] = hl3;
            ellGruenHaus[3] = hl4;

            ellBlauHaus[0] = ho1;
            ellBlauHaus[1] = ho2;
            ellBlauHaus[2] = ho3;
            ellBlauHaus[3] = ho4;

            ellRotHaus[0] = hr1;
            ellRotHaus[1] = hr2;
            ellRotHaus[2] = hr3;
            ellRotHaus[3] = hr4;
        }

        // Aktualisieren des Spielfeldes
        public void PositionsPruefung()
        {

            lbl_wurfErg.Visibility = System.Windows.Visibility.Visible;
            if (spielbrett.laufweite == 0)
            {
                lbl_wurfErg.Visibility = System.Windows.Visibility.Hidden;
            }
            lbl_wurfErg.Content = spielbrett.laufweite.ToString();
            NeuesSpiel neuesSpiel = new NeuesSpiel();
            for (int i = 0; i < 40; i++)
            {
                if (spielbrett.zugFelder[i] != null)
                {
                    if (spielbrett.zugFelder[i].Farbe == "gelb")
                    {
                        ellArr[i].Fill = gelb;
                    }
                    if (spielbrett.zugFelder[i].Farbe == "grün")
                    {
                        ellArr[i].Fill = gruen;
                    }
                    if (spielbrett.zugFelder[i].Farbe == "blau")
                    {
                        ellArr[i].Fill = blau;
                    }
                    if (spielbrett.zugFelder[i].Farbe == "rot")
                    {
                        ellArr[i].Fill = rot;
                    }
                }
                else if (spielbrett.zugFelder[i] == null)
                {
                    ellArr[i].Fill = weiss;
                }
            }

            for (int j = 0; j < 4; j++)
            {
                int i = 0;
                if (spielbrett.HausGelb[j] != null)
                {
                    ellGelbHaus[j].Fill = gelb;
                    i++;
                }
                if (i == 4)
                {
                    MessageBox.Show("Das Spiel ist beendet. Spieler der Farbe gelb hat gewonnen");
                    Close();
                }
            }

            for (int j = 0; j < 4; j++)
            {
                int i = 0;
                if (spielbrett.HausGrün[j] != null)
                {
                    ellGruenHaus[j].Fill = gruen;
                    i++;
                }
                if (i == 4)
                {
                    MessageBox.Show("Das Spiel ist beendet. Spieler der Farbe grün hat gewonnen");
                    Close();
                }
            }
            if (NeuesSpiel.spielerAnzahl >= 3)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = 0;
                    if (spielbrett.HausBlau[j] != null)
                    {
                        i++;
                        ellBlauHaus[j].Fill = blau;
                    }
                    if (i == 4)
                    {
                        MessageBox.Show("Das Spiel ist beendet. Spieler der Farbe blau hat gewonnen");
                        Close();
                    }
                }


            }
            if (NeuesSpiel.spielerAnzahl == 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = 0;
                    if (spielbrett.HausRot[j] != null)
                    {
                        i++;
                        ellRotHaus[j].Fill = rot;
                    }
                    if (i == 4)
                    {
                        MessageBox.Show("Das Spiel ist beendet. Spieler der Farbe rot hat gewonnen");
                        Close();
                    }
                }


            }


            if (spielbrett.SpielerGelb.Pott == 0)
            {
                bu1.Fill = weiss;
                bu2.Fill = weiss;
                bu3.Fill = weiss;
                bu4.Fill = weiss;
            }
            if (spielbrett.SpielerGelb.Pott == 1)
            {
                bu1.Fill = gelb;
                bu2.Fill = weiss;
                bu3.Fill = weiss;
                bu4.Fill = weiss;
            }
            if (spielbrett.SpielerGelb.Pott == 2)
            {
                bu1.Fill = gelb;
                bu2.Fill = gelb;
                bu3.Fill = weiss;
                bu4.Fill = weiss;
            }
            if (spielbrett.SpielerGelb.Pott == 3)
            {
                bu1.Fill = gelb;
                bu2.Fill = gelb;
                bu3.Fill = gelb;
                bu4.Fill = weiss;
            }
            if (spielbrett.SpielerGelb.Pott == 4)
            {
                bu1.Fill = gelb;
                bu2.Fill = gelb;
                bu3.Fill = gelb;
                bu4.Fill = gelb;
            }


            if (spielbrett.SpielerGrün.Pott == 0)
            {
                bl1.Fill = weiss;
                bl2.Fill = weiss;
                bl3.Fill = weiss;
                bl4.Fill = weiss;
            }
            if (spielbrett.SpielerGrün.Pott == 1)
            {
                bl1.Fill = gruen;
                bl2.Fill = weiss;
                bl3.Fill = weiss;
                bl4.Fill = weiss;
            }
            if (spielbrett.SpielerGrün.Pott == 2)
            {
                bl1.Fill = gruen;
                bl2.Fill = gruen;
                bl3.Fill = weiss;
                bl4.Fill = weiss;
            }
            if (spielbrett.SpielerGrün.Pott == 3)
            {
                bl1.Fill = gruen;
                bl2.Fill = gruen;
                bl3.Fill = gruen;
                bl4.Fill = weiss;
            }
            if (spielbrett.SpielerGrün.Pott == 4)
            {
                bl1.Fill = gruen;
                bl2.Fill = gruen;
                bl3.Fill = gruen;
                bl4.Fill = gruen;
            }

            if (NeuesSpiel.spielerAnzahl >= 3)
            {


                if (spielbrett.SpielerBlau.Pott == 0)
                {
                    bo1.Fill = weiss;
                    bo2.Fill = weiss;
                    bo3.Fill = weiss;
                    bo4.Fill = weiss;
                }
                if (spielbrett.SpielerBlau.Pott == 1)
                {
                    bo1.Fill = blau;
                    bo2.Fill = weiss;
                    bo3.Fill = weiss;
                    bo4.Fill = weiss;
                }
                if (spielbrett.SpielerBlau.Pott == 2)
                {
                    bo1.Fill = blau;
                    bo2.Fill = blau;
                    bo3.Fill = weiss;
                    bo4.Fill = weiss;
                }
                if (spielbrett.SpielerBlau.Pott == 3)
                {
                    bo1.Fill = blau;
                    bo2.Fill = blau;
                    bo3.Fill = blau;
                    bo4.Fill = weiss;
                }
                if (spielbrett.SpielerBlau.Pott == 4)
                {
                    bo1.Fill = blau;
                    bo2.Fill = blau;
                    bo3.Fill = blau;
                    bo4.Fill = blau;
                }
            }

            if (NeuesSpiel.spielerAnzahl == 4)
            {

                if (spielbrett.SpielerRot.Pott == 0)
                {
                    br1.Fill = weiss;
                    br2.Fill = weiss;
                    br3.Fill = weiss;
                    br4.Fill = weiss;
                }
                if (spielbrett.SpielerRot.Pott == 1)
                {
                    br1.Fill = rot;
                    br2.Fill = weiss;
                    br3.Fill = weiss;
                    br4.Fill = weiss;
                }
                if (spielbrett.SpielerRot.Pott == 2)
                {
                    br1.Fill = rot;
                    br2.Fill = rot;
                    br3.Fill = weiss;
                    br4.Fill = weiss;
                }
                if (spielbrett.SpielerRot.Pott == 3)
                {
                    br1.Fill = rot;
                    br2.Fill = rot;
                    br3.Fill = rot;
                    br4.Fill = weiss;
                }
                if (spielbrett.SpielerRot.Pott == 4)
                {
                    br1.Fill = rot;
                    br2.Fill = rot;
                    br3.Fill = rot;
                    br4.Fill = rot;
                }
            }

            if (spielbrett.amZug.Farbe == "rot")
            {
                lbl_AmZug.Content = "Rot ist am Zug.";
            }


            if (spielbrett.amZug.Farbe == "blau")
            {
                lbl_AmZug.Content = "Blau ist am Zug.";
            }


            // Welcher Spieler ist an der Reihe?
            if (spielbrett.amZug.Farbe == "gelb")
            {
                lbl_AmZug.Content = "Gelb ist am Zug.";
            }
            if (spielbrett.amZug.Farbe == "grün")
            {
                lbl_AmZug.Content = "Grün ist am Zug.";
            }



        }


        private void btn_e01_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 1;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();

                //if (e01.Fill == gelb && /*amZug.Farbe == "gelb"*/)
                //{
                //    //Bewege Figur
                //}
                //else if (e01.Fill == gruen && /*amZug.Farbe == "grün"*/)
                //{
                //    //Bewege Figur
                //}
                //else if (e01.Fill == blau && /*amZug.Farbe == "blau"*/)
                //{
                //    //Bewege Figur
                //}
                //else if (e01.Fill == rot && /*amZug.Farbe == "rot"*/)
                //{
                //    //Bewege Figur
                //}
            }
        }

        private void btn_e02_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 2;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();

            }
        }
        private void btn_e03_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 3;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e04_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 4;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e05_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 5;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e06_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 6;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e07_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 7;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e08_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 8;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e09_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 9;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e10_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 10;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e11_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 11;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e12_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 12;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e13_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 13;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e14_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 14;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e15_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 15;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e16_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 16;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e17_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 17;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e18_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 18;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e19_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 19;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e20_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 20;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e21_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 21;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e22_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 22;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e23_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 23;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e24_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 24;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e25_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 25;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e26_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 26;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e27_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 27;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e28_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 28;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e29_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 29;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e30_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 30;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e31_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 31;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e32_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 32;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e33_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 33;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e34_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 34;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e35_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 35;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e36_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 36;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e37_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 37;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e38_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 38;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e39_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 39;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_e40_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 40;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }

        // Haus Farbe Gelb
        private void btn_hu1_Click(object sender, RoutedEventArgs e)
        {
            ;
            if (beginnNeuesSpiel)
            {
                index = 41;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hu2_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 42;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hu3_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 43;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hu4_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 44;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }

        // Haus Farbe Grün
        private void btn_hl1_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 45;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hl2_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 46;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hl3_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 47;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hl4_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 48;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }

        //Haus Farbe Blau
        private void btn_ho1_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 49;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_ho2_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 50;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_ho3_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 51;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_ho4_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 52;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }

        // Haus Farbe Rot
        private void btn_hr1_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 53;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hr2_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 54;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hr3_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 55;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
        private void btn_hr4_Click(object sender, RoutedEventArgs e)
        {
            if (beginnNeuesSpiel)
            {
                index = 56;      // Indexnummer des Feldes
                spielbrett.GUI_Ziehe(index);

                PositionsPruefung();
            }
        }
    }
}
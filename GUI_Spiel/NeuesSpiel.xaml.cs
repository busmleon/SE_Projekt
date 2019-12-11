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
using System.Windows.Shapes;
using GUI_Spiel;

namespace neuesSpiel
{
    /// <summary>
    /// Interaktionslogik für NeuesSpiel.xaml
    /// </summary>
    public partial class NeuesSpiel : Window
    {
        public static byte spielerAnzahl = 0;
        public NeuesSpiel()
        {
            InitializeComponent();
        }

        private void cb_Anzahl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_Spieler1.Text = "";
            txt_Spieler2.Text = "";
            txt_Spieler3.Text = "";
            txt_Spieler4.Text = "";
            switch (cb_Anzahl.SelectedIndex)
            {
                case 0:
                    txt_Spieler1.IsReadOnly = false;
                    txt_Spieler2.IsReadOnly = false;
                    txt_Spieler3.IsReadOnly = true;
                    txt_Spieler4.IsReadOnly = true;
                    NeuesSpiel.spielerAnzahl = 2;
                    break;
                case 1:
                    txt_Spieler1.IsReadOnly = false;
                    txt_Spieler2.IsReadOnly = false;
                    txt_Spieler3.IsReadOnly = false;
                    txt_Spieler4.IsReadOnly = true;
                    NeuesSpiel.spielerAnzahl = 3;
                    break;
                case 2:
                    txt_Spieler1.IsReadOnly = false;
                    txt_Spieler2.IsReadOnly = false;
                    txt_Spieler3.IsReadOnly = false;
                    txt_Spieler4.IsReadOnly = false;
                    NeuesSpiel.spielerAnzahl = 4;
                    break;

                default:
                    txt_Spieler1.IsReadOnly = true;
                    txt_Spieler2.IsReadOnly = true;
                    txt_Spieler3.IsReadOnly = true;
                    txt_Spieler4.IsReadOnly = true;
                    break;
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_Anzahl.SelectedIndex)
            {
                case 0:
                    if (txt_Spieler1.Text == "" || txt_Spieler2.Text == "")
                    {
                        MessageBox.Show("Gib alle Spielernamen ein!");
                        break;
                    }
                    this.Close();
                    break;
                case 1:
                    if (txt_Spieler1.Text == "" || txt_Spieler2.Text == "" || txt_Spieler3.Text == "")
                    {
                        MessageBox.Show("Gib alle Spielernamen ein!");
                        break;
                    }
                    this.Close();
                    break;
                case 2:
                    if (txt_Spieler1.Text == "" || txt_Spieler2.Text == "" || txt_Spieler3.Text == "" || txt_Spieler4.Text == "")
                    {
                        MessageBox.Show("Gib alle Spielernamen ein!");
                        break;
                    }
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Wähle die Anzahl der Spieler aus!");
                    break;
            }

        }
    }
}

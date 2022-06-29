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
using Warsztat.Tabele;

namespace Warsztat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Klienci_Click(object sender, RoutedEventArgs e)
        {
            Klienci kl = new Klienci();
            kl.Show();
        }

        private void Samochody_Click(object sender, RoutedEventArgs e)
        {
            Samochody sm = new Samochody();
            sm.Show();
        }

        private void Naprawy_Click(object sender, RoutedEventArgs e)
        {
            Naprawy np = new Naprawy();
            np.Show();
        }

        private void Czynnosci_Click(object sender, RoutedEventArgs e)
        {
            Czynnosci_Naprawcze cn = new Czynnosci_Naprawcze();
            cn.Show();
        }

        private void Dane_Click(object sender, RoutedEventArgs e)
        {
            Dane_Kontaktowe dk = new Dane_Kontaktowe();
            dk.Show();
        }

        private void Mechanicy_Click(object sender, RoutedEventArgs e)
        {
            Mechanicy mc = new Mechanicy();
            mc.Show();
        }

        private void Cennik_Click(object sender, RoutedEventArgs e)
        {
            Cennik cn = new Cennik();
            cn.Show();
        }
    }
}

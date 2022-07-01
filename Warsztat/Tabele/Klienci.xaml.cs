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

namespace Warsztat
{
    /// <summary>
    /// Logika interakcji dla klasy Klienci.xaml
    /// </summary>
    public partial class Klienci : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Klienci()
        {
            InitializeComponent();
            KlienciTabela.ItemsSource = db.klienci.ToList();
        }

        public void Odswiez()
        {
            KlienciTabela.ItemsSource = db.klienci.ToList();
        }

        private void Dodaj_Klienci(object sender, RoutedEventArgs e)
        {
            klienci klienci = new klienci()
            {
                imie = ImieTB.Text,
                nazwisko = NazwiskoTB.Text,
                PESEL = PeselTB.Text,
                idDane = Convert.ToInt32(ID_DaneKTB.Text)
            };

            db.klienci.Add(klienci);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Klienci(object sender, RoutedEventArgs e)
        {
            var selected = KlienciTabela.SelectedItem as klienci;
            db.klienci.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Klienci(object sender, RoutedEventArgs e)
        {
            var selected = KlienciTabela.SelectedItem as klienci;
            db.klienci.Remove(selected);
            Dodaj_Klienci(sender, e);
            db.SaveChanges();
            Odswiez();
        }
    }
}

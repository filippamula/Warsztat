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

namespace Warsztat.Tabele
{
    /// <summary>
    /// Logika interakcji dla klasy Mechanicy.xaml
    /// </summary>
    public partial class Mechanicy : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Mechanicy()
        {
            InitializeComponent();
            MechanicyTabela.ItemsSource = db.mechanicy.ToList();
        }

        public void Odswiez()
        {
            MechanicyTabela.ItemsSource = db.mechanicy.ToList();
        }

        private void Dodaj_Mechanicy(object sender, RoutedEventArgs e)
        {
            mechanicy mechanicy = new mechanicy()
            {
                imie = ImieTB.Text,
                nazwisko = NazwiskoTB.Text,
                PESEL = PeselTB.Text,
                data_zatrudnienia = Convert.ToDateTime(DataTB.Text),
                idDane = Convert.ToInt32(ID_DaneKTB.Text)
            };

            db.mechanicy.Add(mechanicy);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Mechanicy(object sender, RoutedEventArgs e)
        {
            var selected = MechanicyTabela.SelectedItem as mechanicy;
            db.mechanicy.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Mechanicy(object sender, RoutedEventArgs e)
        {
            var selected = MechanicyTabela.SelectedItem as mechanicy;

            selected.imie = ImieTB.Text;
            selected.nazwisko = NazwiskoTB.Text;
            selected.PESEL = PeselTB.Text;
            selected.data_zatrudnienia = Convert.ToDateTime(DataTB.Text);
            selected.idDane = Convert.ToInt32(ID_DaneKTB.Text);

            db.SaveChanges();
            Odswiez();
        }
    }
}

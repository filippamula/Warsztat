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
            if (ImieTB.Text == "" || NazwiskoTB.Text == "" || PeselTB.Text == "" || DataTB.Text == "" || ID_DaneKTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            int idd = Convert.ToInt32(ID_DaneKTB.Text);
            var n = db.dane_kontaktowe.Where(x => x.idDane == idd).FirstOrDefault();
            if (n is null)
            {
                MessageBox.Show("Podaj poprawne id Danych kontaktowych", "Błąd");
                return;
            }

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


            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            db.mechanicy.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Mechanicy(object sender, RoutedEventArgs e)
        {
            var selected = MechanicyTabela.SelectedItem as mechanicy;


            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

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

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

            if(ImieTB.Text == "" || NazwiskoTB.Text == "" || PeselTB.Text =="" || ID_DaneKTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            if (PeselTB.Text.Length != 11)
            {
                MessageBox.Show("Podaj poprawny pesel", "Błąd");
                return;
            }


            klienci klienci = new klienci()
            {
                imie = ImieTB.Text,
                nazwisko = NazwiskoTB.Text,
                PESEL = PeselTB.Text,
                idDane = Convert.ToInt32(ID_DaneKTB.Text)
            };

            if(db.dane_kontaktowe.Where(d => d.idDane == klienci.idDane).FirstOrDefault() == null)
            {
                MessageBox.Show("Podaj istniejące id Dane Kontaktów", "Błąd");
                return;
            }

            db.klienci.Add(klienci);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Klienci(object sender, RoutedEventArgs e)
        {
            var selected = KlienciTabela.SelectedItem as klienci;

            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            db.klienci.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Klienci(object sender, RoutedEventArgs e)
        {
            var selected = KlienciTabela.SelectedItem as klienci;

            if(selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            if (ImieTB.Text == "" || NazwiskoTB.Text == "" || PeselTB.Text == "" || ID_DaneKTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            if (PeselTB.Text.Length != 11)
            {
                MessageBox.Show("Podaj poprawny pesel", "Błąd");
                return;
            }

            selected.imie = ImieTB.Text;
            selected.nazwisko = NazwiskoTB.Text;
            selected.PESEL = PeselTB.Text;
            selected.idDane = Convert.ToInt32(ID_DaneKTB.Text);

            if (db.dane_kontaktowe.Where(d => d.idDane == selected.idDane).FirstOrDefault() == null)
            {
                MessageBox.Show("Podaj istniejące id Dane Kontaktów", "Błąd");
                return;
            }

            db.SaveChanges();
            Odswiez();
        }
    }
}

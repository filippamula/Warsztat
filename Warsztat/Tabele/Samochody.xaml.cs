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
    /// Logika interakcji dla klasy Samochody.xaml
    /// </summary>
    public partial class Samochody : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Samochody()
        {
            InitializeComponent();
            SamochodyTabela.ItemsSource = db.samochody.ToList();
        }

        public void Odswiez()
        {
            SamochodyTabela.ItemsSource = db.samochody.ToList();
        }

        private void Dodaj_Samochody(object sender, RoutedEventArgs e)
        {
            if (VinTB.Text == "" || MarkaTB.Text == "" || ModelTB.Text == "" || NRrTB.Text == "" || IDklientaTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            int idk = Convert.ToInt32(IDklientaTB.Text);
            var k = db.dane_kontaktowe.Where(x => x.idDane == idk).FirstOrDefault();
            if (k is null)
            {
                MessageBox.Show("Podaj poprawne id Klienta", "Błąd");
                return;
            }

            samochody samochody = new samochody()
            {
                VIN = VinTB.Text,
                marka = MarkaTB.Text,
                model = ModelTB.Text,
                nr_rejestracji = NRrTB.Text,
                idKlienta = Convert.ToInt32(IDklientaTB.Text)
            };

            db.samochody.Add(samochody);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Samochody(object sender, RoutedEventArgs e)
        {
            var selected = SamochodyTabela.SelectedItem as samochody;
            db.samochody.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Samochody(object sender, RoutedEventArgs e)
        {
            var selected = SamochodyTabela.SelectedItem as samochody;


            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            selected.VIN = VinTB.Text;
            selected.marka = MarkaTB.Text;
            selected.model = ModelTB.Text;
            selected.nr_rejestracji = NRrTB.Text;
            selected.idKlienta = Convert.ToInt32(IDklientaTB.Text);

            db.SaveChanges();
            Odswiez();
        }
    }
}

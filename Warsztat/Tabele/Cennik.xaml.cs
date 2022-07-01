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
    /// Logika interakcji dla klasy Cennik.xaml
    /// </summary>
    public partial class Cennik : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Cennik()
        {
            InitializeComponent();
            CennikTabela.ItemsSource = db.cennik.ToList();
        }

        public void Odswiez()
        {
            CennikTabela.ItemsSource = db.cennik.ToList();
        }


        private void Dodaj_Cennik(object sender, RoutedEventArgs e)
        {
            if (NazwaTB.Text == "" || CenaTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            cennik cennik = new cennik()
            {
                nazwa = NazwaTB.Text,
                cena = Convert.ToDecimal(CenaTB.Text)
            };

            db.cennik.Add(cennik);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Cennik(object sender, RoutedEventArgs e)
        {
            var selected = CennikTabela.SelectedItem as cennik;

            if(NazwaTB.Text == "" || CenaTB.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola tekstowe", "Błąd");
                return;
            }

            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            db.cennik.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Cennik(object sender, RoutedEventArgs e)
        {
            var selected = CennikTabela.SelectedItem as cennik;

            if (selected is null)
            {
                MessageBox.Show("Zaznacz wiersz", "Błąd");
                return;
            }

            selected.nazwa = NazwaTB.Text;
            selected.cena = Convert.ToDecimal(CenaTB.Text);

            db.SaveChanges();
            Odswiez();
        }
    }
}

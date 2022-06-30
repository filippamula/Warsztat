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
    }
}

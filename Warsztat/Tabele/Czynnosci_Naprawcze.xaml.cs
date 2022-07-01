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
    /// Logika interakcji dla klasy Czynnosci_Naprawcze.xaml
    /// </summary>
    public partial class Czynnosci_Naprawcze : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Czynnosci_Naprawcze()
        {
            InitializeComponent();
            CzynnosciTabela.ItemsSource = db.czynnosci_naprawcze.ToList();
        }

        public void Odswiez()
        {
            CzynnosciTabela.ItemsSource = db.czynnosci_naprawcze.ToList();
        }

        private void Dodaj_Czynnosci(object sender, RoutedEventArgs e)
        {
            decimal? cenaNULLABLE;
            if (CenaTB.Text == "")
                cenaNULLABLE = null;
            else
                cenaNULLABLE = Convert.ToDecimal(CenaTB.Text);

            czynnosci_naprawcze czynnosci = new czynnosci_naprawcze()
            {
                cena = cenaNULLABLE,
                opis = OpisTB.Text,
                idNaprawy = Convert.ToInt32(idNaprawyTB.Text),
                idCennik = Convert.ToInt32(idCennikTB.Text)
            };

            db.czynnosci_naprawcze.Add(czynnosci);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Czynnosci(object sender, RoutedEventArgs e)
        {
            var selected = CzynnosciTabela.SelectedItem as czynnosci_naprawcze;
            db.czynnosci_naprawcze.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Czynnosci(object sender, RoutedEventArgs e)
        {
            var selected = CzynnosciTabela.SelectedItem as czynnosci_naprawcze;
            db.czynnosci_naprawcze.Remove(selected);
            Dodaj_Czynnosci(sender, e);
            db.SaveChanges();
            Odswiez();
        }
    }
}

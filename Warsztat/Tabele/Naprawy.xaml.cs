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
    /// Logika interakcji dla klasy Naprawy.xaml
    /// </summary>
    public partial class Naprawy : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Naprawy()
        {
            InitializeComponent();
            NaprawyTabela.ItemsSource = db.naprawy.ToList();
        }

        public void Odswiez()
        {
            NaprawyTabela.ItemsSource = db.naprawy.ToList();
        }

        private void Dodaj_Naprawy(object sender, RoutedEventArgs e)
        {

            DateTime? dataWy;

            if (DataWTB.Text == "")
                dataWy = null;
            else
                dataWy = Convert.ToDateTime(DataWTB.Text);

            naprawy naprawy = new naprawy()
            {
                data_przyjecia = Convert.ToDateTime(DataPTB.Text),
                termin = Convert.ToDateTime(TerminTB.Text),
                data_wydania = dataWy,
                idSamochodu = Convert.ToInt32(ID_SamochoduTB.Text)
            };

            db.naprawy.Add(naprawy);
            db.SaveChanges();
            Odswiez();
        }

        private void Usun_Naprawy(object sender, RoutedEventArgs e)
        {
            var selected = NaprawyTabela.SelectedItem as naprawy;
            db.naprawy.Remove(selected);
            db.SaveChanges();
            Odswiez();
        }

        private void Edytuj_Naprawy(object sender, RoutedEventArgs e)
        {
            var selected = NaprawyTabela.SelectedItem as naprawy;

            DateTime? dataWy;

            if (DataWTB.Text == "")
                dataWy = null;
            else
                dataWy = Convert.ToDateTime(DataWTB.Text);

            selected.data_przyjecia = Convert.ToDateTime(DataPTB.Text);
            selected.termin = Convert.ToDateTime(TerminTB.Text);
            selected.data_wydania = dataWy;
            selected.idSamochodu = Convert.ToInt32(ID_SamochoduTB.Text);

            db.SaveChanges();
            Odswiez();
        }
    }
}

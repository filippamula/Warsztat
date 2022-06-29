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
    }
}

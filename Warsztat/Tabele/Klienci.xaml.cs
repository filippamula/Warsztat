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
    }
}

﻿using System;
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
    /// Logika interakcji dla klasy Dane_Kontaktowe.xaml
    /// </summary>
    public partial class Dane_Kontaktowe : Window
    {
        WarsztatEntities db = new WarsztatEntities();
        public Dane_Kontaktowe()
        {
            InitializeComponent();
            DaneTabela.ItemsSource = db.dane_kontaktowe.ToList();
        }

        private void Dodaj_Dane_Kontaktowe(object sender, RoutedEventArgs e)
        {
            dane_kontaktowe dane = new dane_kontaktowe()
            {
                nr_telefonu = nrTelTB.Text,
                miejscowosc = MiejscowoscTB.Text,
                ulica = UlicaTB.Text,
                numer = NrTB.Text,
                kod_pocztowy = KodTB.Text
            };

            db.dane_kontaktowe.Add(dane);
            db.SaveChanges();
            DaneTabela.ItemsSource = db.dane_kontaktowe.ToList();
        }
    }
}

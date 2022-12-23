using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace suic_grabulab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
                Table1.ItemsSource = zap1;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap2 = db.Cars.Where(p => p.Name.Contains("BMW")).Select(p => p.Stock).Distinct().ToList();
                Table1.ItemsSource = zap2;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap3 = db.Cars.Where(p => p.Cost < 10000).ToList();
                Table1.ItemsSource = zap3;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap4 = db.Cars.Where(p => p.Remark != "").OrderBy(p => p.Name).ToList();
                Table1.ItemsSource = zap4;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap5 = db.Cars.Where(p => p.DataRelease >= 2000 && p.DataRelease <= 2005).GroupBy(c => c.Stock.Town)
                    .Select(g => new { Name = g.Key, Count = g.Count() }).ToList();
                Table1.ItemsSource = zap5;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var zap6 = db.Cars.Where(p => p.DataRelease < 2000).OrderBy(p => p.DataRelease).ToList();
                Table1.ItemsSource = zap6;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }

        private void Button_Click_Otchet(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                Otchet DBRep = new Otchet() { DateBase = db };
                DBRep.WriteAllReport();
                MessageBox.Show("Файл успешно создан");
            }
            else
            {
                MessageBox.Show("БД не создана");
            }
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            var stocks = new List<Stock>
            {
                new() { Town = "Rome" },
                new() { Town = "Berlin" },
                new() { Town = "Milan" },
                new() { Town = "Moscow" }
            };
            var cars = Generator.GetCars(stocks);
            ApplicationContext db = new ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Cars.AddRange(cars);
            db.Stocks.AddRange(stocks);
            db.Cars.AddRange(cars);
            db.SaveChanges();
        }

        private void Button_Click_Write(object sender, RoutedEventArgs e)
        {
            if (db.Database.GetService<IRelationalDatabaseCreator>().HasTables())
            {
                var Write = db.Cars.Include(p => p.Stock).ToList();
                Table1.ItemsSource = Write;
            }
            else
            {
                MessageBox.Show("База Данных не создана");
            }
        }
        private void Table1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}

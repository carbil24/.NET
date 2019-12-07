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

using MyTimeTracker.Models;
using System.Data.Entity;

namespace MyTimeTracker
{
    /// <summary>
    /// Interaction logic for AutoGenerate.xaml
    /// </summary>
    public partial class AutoGenerate : Window
    {
        private TimeTrackerDBContext context = new TimeTrackerDBContext();
        CollectionViewSource empViewSource;

        public AutoGenerate()
        {
            InitializeComponent();
            empViewSource = ((CollectionViewSource)(FindResource("employeeViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // employeeViewSource.Source = [generic data source]
            context.Employees.Load();
            employeeViewSource.Source = context.Employees.Local;
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            empViewSource.View.MoveCurrentToFirst();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            empViewSource.View.MoveCurrentToNext();
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            empViewSource.View.MoveCurrentToPrevious();
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            empViewSource.View.MoveCurrentToLast();
        }
    }
}
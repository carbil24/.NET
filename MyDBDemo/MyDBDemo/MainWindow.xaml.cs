using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyDBDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string to tell us where is the database
        private string dbConnection = ConfigurationManager.ConnectionStrings["MyDBDemo.Properties.Settings.ConfDBConnectionString"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            PopulateCountries();
        }

        private void BtnLoadAllData_Click(object sender, RoutedEventArgs e)
        {
            QueryVisitorTable(@"select * from Visitors");
        }

        private void QueryVisitorTable(string command)
        {
            //Command: SQL
            //string command;
            //Dataset: Class that allows me to save data extracted from DB
            DataSet ds = new DataSet();
            //DataTable to save the dataset
            DataTable dt;
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    //command = @"select * from Visitors";
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Visitors");
                    dt = ds.Tables["Visitors"];

                    gridDbData.ItemsSource = dt.DefaultView;
                    gridDbData.Items.Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error accessing DB. \nContact admin." + ex.Message, "DB Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            QueryVisitorTable(@"select * from Visitors where FullName like '%" + txtName.Text + @"%'");
        }

        private void PopulateCountries()
        {
            try
            {
                string command = @"select Name from countries";
                DataSet ds = new DataSet();

                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Countries");
                    cmbCountries.ItemsSource = ds.Tables["Countries"].Rows;
                    cmbCountries.SelectedValuePath = ".[Name]";
                    cmbCountries.DisplayMemberPath = ".[Name]";

                    cmbCountries.Items.Refresh();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void CmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            QueryVisitorTable(@"select * from Visitors where Country = '" + cmbCountries.SelectedValue.ToString() + @"'");

        }

        private void ChckIsSpeaker_Click(object sender, RoutedEventArgs e)
        {          
            QueryVisitorTable(@"select * from Visitors where speaker = '" + chckIsSpeaker.IsChecked.Value + @"'");          
        }

        private void BtnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                QueryVisitorTable(@"select * from visitors where CheckinDate BETWEEN '" +
                    dpStartDate.SelectedDate.Value + @"' AND '" +
                    dpEndDate.SelectedDate.Value + @"'");
            }
            else
            {
                MessageBox.Show("Error: please enter a date first", "Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

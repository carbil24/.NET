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
using System.Windows.Shapes;

namespace MyDBDemo
{
    /// <summary>
    /// Interaction logic for Conferences.xaml
    /// </summary>
    public partial class Conferences : Window
    {
        //string to tell us where is the database
        private string dbConnection = ConfigurationManager.ConnectionStrings["MyDBDemo.Properties.Settings.ConfDBConnectionString"].ConnectionString;

        public Conferences()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PopulateConferences();

        }

        private void PopulateConferences()
        {
            try
            {
                string command = @"select Name from Conferences";
                DataSet ds = new DataSet();

                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Conferences");
                    cmbLoadVisitorForm.ItemsSource = ds.Tables["Conferences"].Rows;
                    cmbLoadVisitorForm.SelectedValuePath = ".[Name]";
                    cmbLoadVisitorForm.DisplayMemberPath = ".[Name]";

                    cmbLoadVisitorForm.Items.Refresh();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BtnAddConference_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConferenceName.Text)
            {

            }
            else
            {

                try
                {
                    using (SqlConnection con = new SqlConnection(dbConnection))
                    {
                        string command = @"select Name from Conferences";

                        SqlCommand cmd = new SqlCommand(command, con);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(ds, "Conferences");
                        cmbLoadVisitorForm.ItemsSource = ds.Tables["Conferences"].Rows;
                        cmbLoadVisitorForm.SelectedValuePath = ".[Name]";
                        cmbLoadVisitorForm.DisplayMemberPath = ".[Name]";

                        cmbLoadVisitorForm.Items.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void CmbLoadVisitorForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Load all visitors form (MainWindow)
            MainWindow allVisitorsForm = new MainWindow(1);
            //Show dialog
            allVisitorsForm.ShowDialog();
        }
    }
}

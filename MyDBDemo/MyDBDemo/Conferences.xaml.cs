using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public Conference ConferenceInfo { get; }


        //string to tell us where is the database
        private string dbConnection = ConfigurationManager.ConnectionStrings["MyDBDemo.Properties.Settings.ConfDBConnectionString"].ConnectionString;

        public Conferences()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ConferenceInfo = new Conference();

            PopulateConferences();
        }

        private void PopulateConferences()
        {
            try
            {
                string command = @"select * from Conferences";
                DataSet ds = new DataSet();

                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Conferences");
                    cmbLoadVisitorForm.ItemsSource = ds.Tables["Conferences"].Rows;
                    cmbLoadVisitorForm.SelectedValuePath = ".[Id]";
                    cmbLoadVisitorForm.DisplayMemberPath = ".[Name]";

                    cmbLoadVisitorForm.Items.Refresh();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnAddConference_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAllInput())
            {
                ConferenceInfo.ConfName = txtConferenceName.Text;
                ConferenceInfo.ContactNumber = txtContactNumber.Text;
                ConferenceInfo.Date = dpDate.SelectedDate.Value;
                ClearForm();
                try
                {
                    using (SqlConnection con = new SqlConnection(dbConnection))
                    {
                        Conference c = ConferenceInfo;
                        string command =
                                "INSERT into Conferences" +
                                "(Name, ContactNumber, ConfDate) VALUES (" +
                                @"'" + c.ConfName + @"', " +
                                @"'" + c.ContactNumber + @"', " +
                                @"'" + c.Date + @"')";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Conference was added to the database", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }    
          
            ////Repopulate my conferences list
            PopulateConferences();
        }

        private bool CheckAllInput()
        {
            Regex contactNumberPattern = new Regex(@"^\d{10}$");
            StringBuilder msg = new StringBuilder();

            //Conference Name
            if (string.IsNullOrEmpty(txtConferenceName.Text))
                msg.AppendLine("Conference Name is a required field");

            //Contact Number
            if (string.IsNullOrEmpty(txtContactNumber.Text))
                msg.AppendLine("Contact Number is a required field");
            else if (!(contactNumberPattern.IsMatch(txtContactNumber.Text)))
                msg.AppendLine("Contact Number must be a number of 10 digits");

            //Date
            if (!dpDate.SelectedDate.HasValue)
                msg.AppendLine("Date is not selected");

            if (!string.IsNullOrEmpty(msg.ToString()))
            {
                MessageBox.Show(msg.ToString(), "Form Missing Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtConferenceName.Clear();
            txtContactNumber.Clear();
            dpDate.SelectedDate = null;
        }

        private void BtnLoadConference_Click(object sender, RoutedEventArgs e)
        {

            DataRowView r = cmbLoadVisitorForm.SelectedItem as DataRowView;
            Conference conf = GetConferencerObject(r);

            //Load all visitors form (MainWindow)
            string conferenceName = conf.ConfName;
            MainWindow allVisitorsForm = new MainWindow(conf, conferenceName);
            //Show dialog
            allVisitorsForm.ShowDialog();
        }

        private Conference GetConferencerObject(DataRowView r)
        {
            return new Conference()
            {
                Id = int.Parse(r["Id"].ToString()),
                ConfName = r["Name"].ToString(),
                ContactNumber = r["ContactNumber"].ToString(),
                Date = DateTime.Parse(r["ConfDate"].ToString())
            };
        }
    }
}

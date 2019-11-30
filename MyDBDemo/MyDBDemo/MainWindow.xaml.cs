using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        //private int conferenceID;
        private DataSet ds = new DataSet();
        public Conference ConferenceInfo { get; }


        public MainWindow(Conference conf, string _title)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ConferenceInfo = conf;
            PopulateCountries();
            LoadAllData();
            this.Title = _title + "Conference - Visitor Information";
            txttbconferenceTitle.Text = _title + "Conference";
        }

        private void LoadAllData()
        {
            string command = @"SELECT * from Visitors where conferenceId = " + ConferenceInfo.Id;
            //DataSet ds = new DataSet(); moved to class level

            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Visitors");

                    gridDbData.ItemsSource = ds.Tables["Visitors"].DefaultView;
                    gridDbData.Items.Refresh();

                    if (ds.Tables["Visitors"].Rows.Count == 0)
                    {
                        MessageBox.Show("No data available.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error accessing DB. \nContact admin." + ex.Message, "DB Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLoadAllData_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"SELECT * from Visitors");
            FilterVisitorTable("");
        }      

        private void BtnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"select * from Visitors where FullName like '%" + txtName.Text + @"%'");
            FilterVisitorTable(@"FullName LIKE'%" + txtName.Text + @"%'");
            txtName.Text = "";
        }

        private void FilterVisitorTable(string filter)
        {
            try
            {
                //ds.Tables["Visitors"].DefaultView.RowFilter = "";
                ds.Tables["Visitors"].DefaultView.RowFilter = filter;
                gridDbData.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //QueryVisitorTable(@"select * from Visitors where Country = '" + cmbCountries.SelectedValue.ToString() + @"'");
            FilterVisitorTable(@"Country = '" + cmbCountries.SelectedValue.ToString() + @"'");

        }

        private void PopulateCountries()
        {
            try
            {
                string command = @"select Name from countries";
                //DataSet ds = new DataSet(); moved to class level

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
            catch (Exception)
            {

                throw;
            }
        }

        private void ChckIsSpeaker_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"select * from Visitors where speaker = '" + chckIsSpeaker.IsChecked.Value + @"'"); 
            FilterVisitorTable(@"speaker = '" + chckIsSpeaker.IsChecked.Value + @"'");
        }

        private void BtnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                FilterVisitorTable(
                    "CheinDate >= #" + dpStartDate.SelectedDate.Value + "# AND " +
                    "CheinDate <= #" + dpEndDate.SelectedDate.Value + "#");

               //QueryVisitorTable(@"select * from visitors where CheckinDate BETWEEN '" +
                    //dpStartDate.SelectedDate.Value + @"' AND '" +
                    //dpEndDate.SelectedDate.Value + @"'");
            }
            else
            {
                MessageBox.Show("Error: please enter a date first", "Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //REMOVED
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

        private void BtnAddVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorsWindow newVisitorWindow = new VisitorsWindow(ds.Tables["Countries"].Rows);
            if (newVisitorWindow.ShowDialog().Value)
            {
                //Add to the database
                Visitor v = newVisitorWindow.VisitorInfo;
                string command =
                            "INSERT into Visitors" +
                            "(FullName, Major, Country, Status, Speaker, CheckinDate, ConferenceID) VALUES (" +
                            @"'" + v.FullName + @"', " +
                            @"'" + v.Major + @"', " +
                            @"'" + v.Country + @"', " +
                            @"'" + v.VisitorStatus.ToString() + @"', " +
                            @"'" + v.IsSpeaker + @"', " +
                            @"'" + v.CheckInDate + @"', " +
                            ConferenceInfo.Id + ")";

                ExecuteNonQuery(command);               
            }
        }

        private void BtnEditVisitorInfo_Click(object sender, RoutedEventArgs e)
        {
            if (gridDbData.SelectedIndex > 0 && gridDbData.SelectedIndex != gridDbData.Items.Count)
            {
                DataRowView r = gridDbData.SelectedItem as DataRowView;
                Visitor existing = GetVisitorObject(r);

                //MessageBox.Show(gridDbData.SelectedItem.ToString());
                VisitorsWindow modifyVisitor = new VisitorsWindow(ds.Tables["Countries"].Rows, existing);

                if (modifyVisitor.ShowDialog().Value)
                {
                    Visitor v = modifyVisitor.VisitorInfo;
                    string command =
                                "UPDATE Visitors SET " +
                                @"FullName ='" + v.FullName + @"', " +
                                @"Major ='" + v.Major + @"', " +
                                @"Country ='" + v.Country + @"', " +
                                @"Status ='" + v.VisitorStatus.ToString() + @"', " +
                                @"Speaker ='" + v.IsSpeaker + @"', " +
                                @"CheckinDate ='" + v.CheckInDate + @"' WHERE Id =" + r["Id"];

                    ExecuteNonQuery(command);                  
                }              
            }
            else
            {
                MessageBox.Show("Please select a record first");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridDbData.SelectedIndex > 0 && gridDbData.SelectedIndex != gridDbData.Items.Count)
            {
                if (MessageBox.Show("Record will be deleted permenantly.\nDo you want to proceed?", "Delete Record Alert", 
                    MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                {
                    DataRowView r = gridDbData.SelectedItem as DataRowView;
                    string command = "Delete from Visitors where Id=" + r["Id"];
                    ExecuteNonQuery(command);                  
                }              
            }
            else
            {
                MessageBox.Show("Please select a record first", "No selection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteNonQuery(string command)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Updating my grid.
                    ds.Tables["Visitors"].Clear();
                    LoadAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void SaveToCSV_Click(object sender, RoutedEventArgs e)
        {
            //Make sure there is data to save
            if(gridDbData.Items.Count == 1)
            {
                MessageBox.Show("Visitor's list is empty. \nAdd visitors to the list first.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                //First choose where to save to
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV File|*.csv";

                //Make sure chose a file name and location
                if (saveFileDialog.ShowDialog() == true)
                {
                    StringBuilder report = new StringBuilder();
                    //Adding table header
                    report.AppendLine(this.Title.ToString());
                    report.AppendLine("FullName,Major,Country,Status,Is Speaker,CheckIn Date");
                    //Extract data from the grid >> utilize the visitor's class
                    for (int i = 0; i < gridDbData.Items.Count-1; i++)
                    {
                        report.AppendLine(GetVisitorObject(gridDbData.Items[i] as DataRowView).AllData);
                    }

                    //Save to a file
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, report.ToString());

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error saving report to CSV\n" + ex.Message, "Error Saving", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //Message of confirmation
                    MessageBox.Show("File saved succesfully.\nLocation: " + saveFileDialog.FileName, "Report Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        private Visitor GetVisitorObject(DataRowView r)
        {
            return new Visitor()
            {
                FullName = r["FullName"].ToString(),
                Major = r["Major"].ToString(),
                Country = r["Country"].ToString(),
                VisitorStatus = r["Status"].ToString() == Status.Teacher.ToString() ? Status.Teacher :
                                    r["Status"].ToString() == Status.Student.ToString() ? Status.Student : Status.Proffessional,
                IsSpeaker = bool.Parse(r["Speaker"].ToString()),
                CheckInDate = DateTime.Parse(r["CheckinDate"].ToString())
            };
        }
    }
}

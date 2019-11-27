using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace MyWPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] countriesList = { "Canada", "USA", "Mexico", "France", "UK", "China" };
        private List<Visitor> visitors = new List<Visitor>();
        private bool newDocument = true;
        private string fileName;
        private int newRecordIndex = 0; 

        public MainWindow()
        {
            InitializeComponent();
            LoadCountries();
            cmbCountries.ItemsSource = countriesList;
            lstList.ItemsSource = visitors;
            //cmbCountries.SelectedIndex = 0;
        }
        private void LoadCountries()
        {
            try
            {
                string fileName = "../../CountriesList.txt";
                if (File.Exists(fileName))
                {
                    countriesList = File.ReadAllLines(fileName);
                }
                else
                {
                    MessageBox.Show("Loading Default Country List");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }


        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            if (CheckAllInput())
            {
                Visitor visitor = GetVisitoInfo();
                //Addto to list Method 1
                //lstList.Items.Add(visitor);
                //lstList.Items.Refresh();

                //Addto to list Method 2
                visitors.Add(visitor);
                lstList.Items.Refresh();
                MessageBox.Show(visitor.ToString(), "Registration Succesful", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
                if (newDocument)
                {
                    txtbStatus.Text = "Status Bar: Document Not Saved";
                }

            }
        }

        private bool CheckAllInput()
        {
            StringBuilder msg = new StringBuilder();

            //Name
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.AppendLine("Name is a required field");
            }

            //Major
            if (string.IsNullOrEmpty(txtMajor.Text))
            {
                msg.AppendLine("Major is a required field");
            }

            //Country
            if (cmbCountries.SelectedValue == null)
            {
                msg.AppendLine("No country selected");
            }

            //Status
            if(!(rbtnTeacher.IsChecked.Value || rbtnStudent.IsChecked.Value || rbtnProf.IsChecked.Value))
            {
                msg.AppendLine("Status is not chosen");
            }

            //Check in date
            if (!dpCheckIn.SelectedDate.HasValue)
            {
                msg.AppendLine("Date is not selected");
            }

            if (!string.IsNullOrEmpty(msg.ToString()))
            {
                MessageBox.Show(msg.ToString(), "Form Missing Data", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        private Visitor GetVisitoInfo()
        {
            return new Visitor()
            {
                FullName = txtName.Text,
                Major = txtMajor.Text,
                Country = cmbCountries.SelectedValue.ToString(),
                IsSpeaker = chkbSpeaker.IsChecked.Value,
                CheckInDate = dpCheckIn.SelectedDate.Value,
                //VisitorStatus = (Status)(rbtnTeacher.IsChecked.Value ? 0 : rbtnStudent.IsChecked.Value ? 1 : 2)
                VisitorStatus = (rbtnTeacher.IsChecked.Value ? Status.Teacher : rbtnStudent.IsChecked.Value ? Status.Teacher : Status.Proffessional)
            };
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtMajor.Clear();
            cmbCountries.SelectedIndex =-1;
            rbtnProf.IsChecked = false;
            rbtnStudent.IsChecked = false;
            rbtnTeacher.IsChecked = false;
            chkbSpeaker.IsChecked = false;
            dpCheckIn.SelectedDate = null;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            //check if the list has items
            if (newRecordIndex < visitors.Count)
            {
                //My file is not saved
                MessageBoxResult r = MessageBox.Show(
                    "Your file is not saved.\nWould you like to save the file first?", 
                    "Unsaved Work", MessageBoxButton.YesNoCancel);
                if (r == MessageBoxResult.Yes)
                {
                    BtnSave_Click(sender, e);
                }
                else if (r == MessageBoxResult.Cancel)
                {
                    return;
                }
                //else: NO: do not save. No action needed.
            }

            //open file dialog
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV File|*.csv";

                if (openFileDialog.ShowDialog() == true)
                {
                    visitors.Clear();
                    //set the file name
                    fileName = openFileDialog.FileName;
                    //load the data into the list and refresh
                    string[] allRecords = File.ReadAllLines(fileName);
                    foreach (string record in allRecords)
                    {
                        Visitor v = new Visitor();
                        v.AllData = record;
                        visitors.Add(v);
                    }
                    lstList.Items.Refresh();
                    newRecordIndex = visitors.Count;
                    newDocument = false;
                    txtbStatus.Text = "Status Bar: Document Loaded";

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //check if it is a new file

            //New Document: ask the user for location and save the file - maintain the location
            try
            {
                if (newDocument)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV File|*.csv";
                    if(saveFileDialog.ShowDialog() == true)
                    {
                        //Save the file name
                        fileName = saveFileDialog.FileName;
                        //Change the status document
                        newDocument = false;
                        //Save to file
                        SaveDataToFile();

                    }
                }
                else
                {
                    SaveDataToFile();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveDataToFile()
        {
            StringBuilder report = new StringBuilder();

            for (int i = newRecordIndex; i < visitors.Count; i++)
            {
                report.AppendLine(visitors[i].AllData);
            }

            //foreach (var visitor in visitors)
            //{
            //    report.AppendLine(visitor.AllData);
            //}

            File.AppendAllText(fileName, report.ToString());
            //MessageBox.Show($"Saved to {fileName}", "Saved Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            newRecordIndex = visitors.Count;
            txtbStatus.Text = "Status Bar: Document Saved";

        }

        private void LstList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //get the selected it
            Visitor v = lstList.SelectedItem as Visitor;
            //Get the data and display it in a message box
            MessageBox.Show(v.FullInfo, "Visitor's info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

//if (!string.IsNullOrEmpty(txtName.Text))
//{
//    MessageBox.Show($"Hello {txtName.Text}");
//}
//else
//{
//    MessageBox.Show("Name is not provided", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//}

//StringBuilder msg = new StringBuilder();
//msg.AppendLine(txtName.Text);
//msg.AppendLine(txtMajor.Text);
//msg.AppendLine(cmbCountries.SelectedItem.ToString());
//if (rbtnTeacher.IsChecked.Value)
//{
//    msg.AppendLine("Teacher");
//}
//else if (rbtnStudent.IsChecked.Value)
//{
//    msg.AppendLine("Student");

//}
//else
//{
//    msg.AppendLine("Professional");

//}

//if (chkbSpeaker.IsChecked.Value)
//{
//    msg.AppendLine("Guess Speaker");
//}

//msg.AppendLine(dpCheckIn.SelectedDate.Value.ToString());

//MessageBox.Show(msg.ToString(), "Registration Succesful", MessageBoxButton.OK, MessageBoxImage.Information);


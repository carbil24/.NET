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
using System.Windows.Navigation;
using System.Windows.Shapes;
//Add this
using MyTimeTracker.Models;


namespace MyTimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimeTrackerViewModel repo = new TimeTrackerViewModel();
        public MainWindow()
        {
            InitializeComponent();
            repo.AddNewEmployee(GenerateTestEmployee());

            dgEmployees.ItemsSource = repo.GetAllEmployeesData();
        }

        private Employee GenerateTestEmployee()
        {
            return new Employee()
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Department = "TEST",
                Role = "TEST",
                HireDate = DateTime.Now.AddYears(-2),
                Salary = new Random().Next(100,100000),
                DOB = DateTime.Now.AddYears(-30),
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-30),
                        MondayHours = 8, TuesdayHours = 7, WednesdayHours = 6,
                        ThursdayHours = 8, FridayHours = 5, SaturdayHours = 0, SundayHours = 0
                    },
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 0, TuesdayHours = 7, WednesdayHours = 7,
                        ThursdayHours = 7, FridayHours = 7, SaturdayHours = 7, SundayHours = 0
                    }
                }
            };
        }

        private void DgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee current = dgEmployees.SelectedItem as Employee;
            //Text block vlaue
            txtEmployeRecord.Text = string.Format("ID#{0} - {1} {2} | {3}", current.ID, current.LastName, current.FirstName, current.Role);

            //Set the timecard data grid
            dgTimeCards.ItemsSource = current.TimeCards;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {       
            if (dgEmployees.SelectedItem != null && MessageBox.Show("Are you sure you want to delete?\n" +
                            "This will delete the time card records as well", "Confirm Delete", 
                            MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                try
                {
                    repo.DeleteEmployeeRecord((dgEmployees.SelectedItem as Employee).ID);
                    dgEmployees.ItemsSource = repo.GetAllEmployeesData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSaveNewRole_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem == null || string.IsNullOrEmpty(txtRole.Text))
            {
                MessageBox.Show("Please select an employee first or fill the role");
            }
            else
            {
                Employee emp = dgEmployees.SelectedItem as Employee;
                emp.Role = txtRole.Text;
                repo.UpdateEmployee(emp);
                dgEmployees.ItemsSource = repo.GetAllEmployeesData();
                txtRole.Clear();
            }
        }

        private void BtnSearchLast_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = repo.SearchByLastName(txtLastName.Text);
        }
    }
}

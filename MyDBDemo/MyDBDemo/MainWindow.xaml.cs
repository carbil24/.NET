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
    }
}

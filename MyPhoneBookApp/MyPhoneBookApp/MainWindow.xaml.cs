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

namespace MyPhoneBookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyPhoneBookDBDataContext db = new MyPhoneBookDBDataContext();
        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Width;
            //this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UpdateContactList();
        }

        /*
         * Button used to add a new record to the database
         */
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Creating an object and reading from the form
            //Add validation: no empty entries (Name cannot be null, phone number cannot be null
            Contact c = new Contact()
            {
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            try
            {
                db.Contacts.InsertOnSubmit(c);
                db.SubmitChanges();
                //Update my grid
                UpdateContactList();
                ClearForm();
                //Close expander
                //expForm.IsExpanded = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        /* Reads the values from the form and updates the records in the database
         */
        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            Contact c = dgContacts.SelectedItem as Contact;

            //Capturing Changes
            //Add validtation similar to the add button functionality
            c.Name = txtName.Text;
            c.Phone = txtPhone.Text;
            c.Address = txtAddress.Text;

            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }

            UpdateContactList();
            ClearForm();
            //Swap the button visibilty: checks comment in btn load
            btnModify.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Visible;
        }

        /* Delete a record from the database */
        private void RightClickDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete
            Contact c = dgContacts.SelectedItem as Contact;

            try
            {
                db.Contacts.DeleteOnSubmit(c);
                db.SubmitChanges();
                UpdateContactList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
        }

        /* Double clicking on the contact in the data grid */
        private void DgContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadContactInfo();
        }

        /* Right click and edit: on the contact in the data grid */
        private void RightClickEdit_Click(object sender, RoutedEventArgs e)
        {
            LoadContactInfo();
        }

        /*
         * Get the selected contact and load all its properties into the contact form
         * Objective: to update the information there
         */
        private void LoadContactInfo()
        {
            Contact c = dgContacts.SelectedItem as Contact;
            //Open expander
            expForm.IsExpanded = true;

            //Load into the form
            txtName.Text = c.Name;
            txtPhone.Text = c.Phone;
            txtAddress.Text = c.Address;

            /*Make the update btn visible:
             * Add button and the modify button are placed on top of each other in the form
             * Once the user request to update, the Add button will be hidden and the modify will be visible
             */
            btnModify.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Hidden;
        }

        /* Helper method that reloads the contacts froms the database*/
        private void UpdateContactList()
        {
            //Update my grid
            dgContacts.ItemsSource = from contact in db.Contacts
                                     orderby contact.Name
                                     select contact;
        }

        /* Helper method to clear the textboxes in the form */
        private void ClearForm()
        {
            //Clear my form
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void SlFirstLetter_LostMouseCapture(object sender, MouseEventArgs e)
        {
            char selected;
            if (slFirstLetter.Value != 26)
            {
                selected = (char)((int)slFirstLetter.Value + 65);
                //Query the database & Update my data contacts
                dgContacts.ItemsSource = from c in db.Contacts
                                         where c.Name.StartsWith(selected.ToString())
                                         orderby c.Name
                                         select c;
            }
            else
            {
                selected = '#';
                char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                  'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                //Query the database & Update my data contacts
                dgContacts.ItemsSource = from c in db.Contacts
                                         where !(letters.Contains(c.Name[0]))
                                         orderby c.Name
                                         select c;
            }
            txtLetter.Text = selected.ToString();      
        }

        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtNameSearch.Clear();
            txtPhoneSearch.Clear();
            txtLetter.Text = "A";
            slFirstLetter.Value = 0;
            UpdateContactList();
        }

        private void TxtPhoneSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgContacts.ItemsSource = from c in db.Contacts
                                     where c.Phone.Contains(txtPhoneSearch.Text) && c.Name.Contains(txtNameSearch.Text)
                                     orderby c.Name
                                     select c;
        }
    }
}

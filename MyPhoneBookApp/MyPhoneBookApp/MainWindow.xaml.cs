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
            dgContacts.ItemsSource = from c in db.Contacts
                                     orderby c.Name
                                     select c; // new { Name = c.Name, Phone = c.Phone };
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
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

        private void DgContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact c = dgContacts.SelectedItem as Contact;
            //Open expander
            expForm.IsExpanded = true;

            //Load into the form
            txtName.Text = c.Name;
            txtPhone.Text = c.Phone;
            txtAddress.Text = c.Address;

            //Make the update button visible
            btnModify.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Hidden;

        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            ModifyContact();
        }

        private void UpdateContactList()
        {
            //Update my grid
            dgContacts.ItemsSource = from contact in db.Contacts
                                     orderby contact.Name
                                     select contact;
        }

        private void ClearForm()
        {
            //Clear my form
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void ModifyContact()
        {
            Contact c = dgContacts.SelectedItem as Contact;
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

            //Make the add button visible
            btnModify.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Visible;
        }

        private void RighClickEdit_Click(object sender, RoutedEventArgs e)
        {
            ModifyContact();
        }

        private void RighClickDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete
            Contact c = dgContacts.SelectedItem as Contact;

            try
            {
                db.Contacts.DeleteOnSubmit(c);
                db.SubmitChanges();
                UpdateContactList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

   
}

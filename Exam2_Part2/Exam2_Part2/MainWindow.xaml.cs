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

namespace Exam2_Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShoppingCart cart = new ShoppingCart();

        public MainWindow()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void BtnAddApple_Click(object sender, RoutedEventArgs e)
        {
            cart.IncrementApple();
            txtbAppleQty.Text = cart.AppleQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnSubstractApple_Click(object sender, RoutedEventArgs e)
        {
            cart.DecreaseApple();
            txtbAppleQty.Text = cart.AppleQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnAddBanana_Click(object sender, RoutedEventArgs e)
        {
            cart.IncrementBanana();
            txtbBananaQty.Text = cart.BananaQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnSubstractBanana_Click(object sender, RoutedEventArgs e)
        {
            cart.DecreaseBanana();
            txtbBananaQty.Text = cart.BananaQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnAddOrange_Click(object sender, RoutedEventArgs e)
        {
            cart.IncrementOrange();
            txtbOrangeQty.Text = cart.OrangeQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnSubstractOrange_Click(object sender, RoutedEventArgs e)
        {
            cart.DecreaseOrange();
            txtbOrangeQty.Text = cart.OrangeQty.ToString();
            txtTotal.Text = cart.UpdateTotal().ToString("c");
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            cart.Reset();
            LoadComponents();


        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnCard.IsChecked.Value)
            {
                cart.TipeOfPayment = "Credit/Debit";
            }

            if (rbtnCash.IsChecked.Value)
            {
                cart.TipeOfPayment = "Cash";

                cart.Cash = double.Parse(txtCash.Text);
            }

            MessageBox.Show(cart.Checkout().ToString(), "John Abbot College Grocery Store Receipt", MessageBoxButton.OK);
            
        }

        private void RbtnCash_Click(object sender, RoutedEventArgs e)
        {
            txtCash.IsEnabled = true;
        }

        private void RbtnCard_Click(object sender, RoutedEventArgs e)
        {
            txtCash.IsEnabled = false;

        }

        private void LoadComponents()
        {
            txtTotal.Text = cart.UpdateTotal().ToString("c");
            txtbAppleQty.Text = cart.AppleQty.ToString();
            txtbBananaQty.Text = cart.BananaQty.ToString();
            txtbOrangeQty.Text = cart.OrangeQty.ToString();
            txtCash.Text = cart.Cash.ToString();

            rbtnCard.IsChecked = false;
            rbtnCash.IsChecked = false;
            txtTotal.IsEnabled = false;
            txtCash.IsEnabled = false;
        }
    }
}

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

namespace IceCreamCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double SMALL_SIZE = 1;
        private const double MEDIUM_SIZE = 2;
        private const double LARGE_SIZE = 3;

        private const double FLV_CHOCO = 0.5;
        private const double FLV_RR = 1.5;
        private const double FLV_MINTCH = 2.5;

        private const double TOPPING_SMARTIES = 0.5;
        private const double TOPPING_OREO = 1.5;
        private const double TOPPING_SPRINKLES = 2.5;
        private const double TOPPING_CARAMEL = 2.0;

        private double selectedSizeValue = SMALL_SIZE;
        private double selectedFlvValue = FLV_CHOCO;
        private double selectedToppingValue = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


    }
}

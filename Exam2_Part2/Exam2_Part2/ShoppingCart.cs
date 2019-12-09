using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_Part2
{
    public class ShoppingCart
    {
        private const double APPLE_PRICE = 0.5;
        private const double BANANA_PRICE = 0.75;
        private const double ORANGE_PRICE = 1;

        private const double MIN_AMOUNT_FOR_CARD = 5;

        private int _appleQty;
        private int _bananaQty;
        private int _orangeQty;
        private string _typeOfPayment;
        private double _cash;

        public int AppleQty
        {
            get
            {
                return _appleQty;
            }
            set
            {
                _appleQty = value;
            }
        }
        public int BananaQty
        {
            get
            {
                return _bananaQty;
            }
            set
            {
                _bananaQty = value;
            }
        }
        public int OrangeQty
        {
            get
            {
                return _orangeQty;
            }
            set
            {
                _orangeQty = value;
            }
        }

        public string TipeOfPayment
        {
            get
            {
                return _typeOfPayment;
            }
            set
            {
                _typeOfPayment = value;
            }
        }

        public double Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
            }
        }

        private double totalApple = 0;
        private double totalBanana = 0;
        private double totalOrange = 0;

        public double IncrementApple()
        {

            if (AppleQty >= 0)
            {
                AppleQty++;
                totalApple += APPLE_PRICE;
            }
            return totalApple; 
        }

        public double DecreaseApple()
        {

            if (AppleQty > 0)
            {
                AppleQty--;
                totalApple -= APPLE_PRICE;
            }
            return totalApple;
        }

        public double IncrementBanana()
        {
            if (BananaQty >= 0)
            {
                BananaQty++;
                totalBanana += BANANA_PRICE;
            }
            return totalBanana;
        }

        public double DecreaseBanana()
        {
            if (BananaQty > 0)
            {
                BananaQty--;
                totalBanana -= BANANA_PRICE;
            }
            return totalBanana;
        }

        public double IncrementOrange()
        {
            if (OrangeQty >= 0)
            {
                OrangeQty++;
                totalOrange += ORANGE_PRICE;
            }
            return totalOrange;
        }

        public double DecreaseOrange()
        {
            if (OrangeQty > 0)
            {
                OrangeQty--;
                totalOrange -= ORANGE_PRICE;
            }
            return totalOrange;
        }

        public double UpdateTotal()
        {
            return totalApple + totalBanana + totalOrange;
        }

        public void Reset()
        {
            AppleQty = 0;
            BananaQty = 0;
            OrangeQty = 0;
            totalApple = 0;
            totalBanana = 0;
            totalOrange = 0;
            Cash = 0;
        }

        public StringBuilder Checkout()
        {
            StringBuilder msg = new StringBuilder();

            if (AppleQty == 0 && BananaQty == 0 && OrangeQty == 0 )
            {
                msg.AppendLine("Shopping cart is empty!");
            }
            else if (string.IsNullOrEmpty(TipeOfPayment))
            {
                msg.AppendLine("Please select a payment type.");
            }
            else if (TipeOfPayment.Equals("Credit/Debit"))
            {
                if (UpdateTotal() < MIN_AMOUNT_FOR_CARD)
                {
                    msg.AppendLine("Total cost must be >= $" + MIN_AMOUNT_FOR_CARD + " to use credit or debit");
                }
                else
                {
                    if (AppleQty > 0)
                        msg.AppendLine(AppleQty + " apple(s)... $" + totalApple);

                    if (BananaQty > 0)
                        msg.AppendLine(BananaQty + " banana(s)... $" + totalBanana);

                    if (OrangeQty > 0)
                        msg.AppendLine(OrangeQty + " orange(s)... $" + totalOrange);

                    msg.AppendLine("\nPayment Type: " + TipeOfPayment);

                    msg.AppendLine("\nTotal Cost: $" + UpdateTotal());

                    msg.AppendLine("\nThanks for shopping at the John Abbott Grocery Store!");

                    TipeOfPayment = "";

                }
            }
            else
            {
                if (Cash == 0)
                {
                    msg.AppendLine("Please enter an amount for cash");
                }
                else if (Cash < UpdateTotal())
                {
                    msg.AppendLine("Not enough cash provided");
                }
                else
                {
                    double change = Cash - UpdateTotal();
                    double temp;

                    if (AppleQty > 0)
                        msg.AppendLine(AppleQty + " apple(s)... $" + totalApple);

                    if (BananaQty > 0)
                        msg.AppendLine(BananaQty + " banana(s)... $" + totalBanana);

                    if (OrangeQty > 0)
                        msg.AppendLine(OrangeQty + " orange(s)... $" + totalOrange);

                    msg.AppendLine("\nPayment Type: " + TipeOfPayment);

                    msg.AppendLine("\nTotal Cost: $" + UpdateTotal());

                    msg.AppendLine("Amount received: $" + Cash);

                    msg.AppendLine("Change: $" + change);

                    msg.AppendLine("\nBreakdown:\n");

                    if (change >= 20)
                    {
                        temp = (int)change / 20;
                        change = change % 20;
                        msg.AppendLine(temp + " $20 bill(s)");
                    }

                    if (change >= 10)
                    {
                        temp = (int)change / 10;
                        change = change % 10;
                        msg.AppendLine(temp + " $10 bill(s)");
                    }

                    if (change >= 5)
                    {
                        temp = (int)change / 5;
                        change = change % 5;
                        msg.AppendLine(temp + " $5 bill(s)");
                    }

                    if (change >= 2)
                    {
                        temp = (int)change / 2;
                        change = change % 2;
                        msg.AppendLine(temp + " $2 coin(s)");
                    }

                    if (change >= 1)
                    {
                        temp = (int)change / 1;
                        change = change % 1;
                        msg.AppendLine(temp + " $1 coin(s)");
                    }

                    if (change >= .25)
                    {
                        temp = (change / .25);
                        change = change % .25;
                        msg.AppendLine(temp + " quarter(s)");
                    }

                    msg.AppendLine("\nThanks for shopping at the John Abbott Grocery Store!");

                    TipeOfPayment = "";

                }
            }
            return msg;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double lastValue = 0;
        static string lastOperator = "btnEqual";
        static StringBuilder sb = new StringBuilder();
        static List<int> number = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            double val;
            Button button = sender as Button;
            if (button.Name.Equals("btnClear"))
            {
                number.Clear();
                sb.Clear();
                txtLcdDisplay.Text = "0";

                return;
            }
            if (int.TryParse(button.Content.ToString(), out int num))
            {
                number.Add(num);
                sb.Append(num.ToString());
                txtLcdDisplay.Text = sb.ToString();
            }
            else
            {
                int result = 0;
                int counter = 1;
                int mply = 10;
                for (int i = number.Count - 1; i > -1; i--)
                {
                    result += number.ElementAt(i) * counter;
                    counter *= mply;
                }

                val = result;
                switch (lastOperator)
                {
                    case "btnPlus": lastValue += val; break;
                    case "btnMinus": lastValue -= val; break;
                    case "btnMply": lastValue *= val; break;
                    case "btnDivide": lastValue /= val; break;
                    case "btnEqual": lastValue = val; break;
                }
                txtLcdDisplay.Text = lastValue.ToString();
                lastOperator = button.Name;
                number.Clear();
                sb.Clear();
            }
        }
    }
}

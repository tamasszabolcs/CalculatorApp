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

namespace CalculatorApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            this.DataContext = this;

            OutputTextBlock.Text = "0";

            DivideBtn.Content = "\u00F7";

            SqrtBtn.Content = "\u221A";

            SquareBtn.Content = "x" + "\u00B2";

            DeleteCharacterBtn.Content = "\u232B";
        }


        string output = "";

        double temp = 0;

        string operation = "";

        double outputTemp;

        private List<double> previousResults = new List<double>();

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = "0";
            OutputTextBlock2.Text = output;
        }

        private void SquareBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(output))
            {
                double square = double.Parse(output);

                outputTemp = (square * square);
                previousResults.Add(outputTemp);

                if (previousResults.Count > 10)
                {
                    previousResults.RemoveAt(0);
                }

                output = outputTemp.ToString();
                OutputTextBlock.Text = output;
                OutputTextBlock2.Text = square.ToString() + " ^2";
                PrintPreviousResults();
            }
            else
            {
                OutputTextBlock.Text = "0";
            }
        }

        private void SqrtBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(output))
            {
                double sqrt = double.Parse(output);

                if (sqrt >= 0)
                {
                    outputTemp = Math.Sqrt(sqrt);
                    previousResults.Add(outputTemp);

                    if (previousResults.Count > 10)
                    {
                        previousResults.RemoveAt(0);
                    }

                    output = outputTemp.ToString();
                    OutputTextBlock.Text = output;
                    OutputTextBlock2.Text = "√" + sqrt;
                    PrintPreviousResults();
                }
                else
                {
                    //MessageBox.Show("Nem számolható ki a negatív négyzetgyök.");
                    CustomMessageBox customMessageBox = new CustomMessageBox("Nem számolható ki a negatív négyzetgyök");
                    customMessageBox.ShowDialog();
                }
            }
        }

        private void DeleteCH_Click(object sender, RoutedEventArgs e)
        {
            if (output.Length > 0)
            {
                output = output.Substring(0, output.Length - 1);
                OutputTextBlock.Text = output;

            }

            if (output.Length == 0)
            {
                OutputTextBlock.Text = "0";
            }
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            //if (char.IsDigit(((Button)sender).Content.ToString()[0]))
            //{

            //    int digitCount = output.Count(char.IsDigit);

            //    if (digitCount > 3 && digitCount % 3 == 0)
            //    {
            //        output += ",";
            //    }
            //}

            if (name == "MinusBtn" && string.IsNullOrEmpty(output))
            {
                output += "-";
                OutputTextBlock.Text = output;
            }

            switch (name)
            {
                case "ZeroBtn":

                    output += "0";
                    OutputTextBlock.Text = output;

                    break;
                case "OneBtn":

                    output += "1";
                    OutputTextBlock.Text = output;
                    break;
                case "TwoBtn":

                    output += "2";
                    OutputTextBlock.Text = output;
                    break;
                case "ThreeBtn":

                    output += "3";
                    OutputTextBlock.Text = output;
                    break;
                case "FourBtn":

                    output += "4";
                    OutputTextBlock.Text = output;
                    break;
                case "FiveBtn":

                    output += "5";
                    OutputTextBlock.Text = output;
                    break;
                case "SixBtn":

                    output += "6";
                    OutputTextBlock.Text = output;
                    break;
                case "SevenBtn":

                    output += "7";
                    OutputTextBlock.Text = output;
                    break;
                case "EightBtn":

                    output += "8";
                    OutputTextBlock.Text = output;
                    break;
                case "NineBtn":

                    output += "9";
                    OutputTextBlock.Text = output;
                    break;
                case "DecimalBtn":

                    if (!output.Contains("."))
                    {
                        output += ".";
                        OutputTextBlock.Text = output;

                    }
                    break;

            }
        }

        private List<double> numbers = new List<double>();
        private List<string> operators = new List<string>();
        private string currentExpression = "";


        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                numbers.Add(double.Parse(output));
                operators.Add("Plus");
                currentExpression += output + " + ";
                OutputTextBlock2.Text = currentExpression;
                OutputTextBlock.Text = output;

                output = "";
            }
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(output))
            {
                numbers.Add(double.Parse(output));
                operators.Add("Minus");
                currentExpression += output + " - ";
                OutputTextBlock2.Text = currentExpression;
                output = "";
            }
            else if (numbers.Count == 0 && string.IsNullOrEmpty(output))
            {
                output = "-";
                OutputTextBlock.Text = output;
            }
        }

        private void MultipleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                numbers.Add(double.Parse(output));
                operators.Add("Multiple");
                currentExpression += output + " * ";
                OutputTextBlock2.Text = currentExpression;
                output = "";
            }
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                numbers.Add(double.Parse(output));
                operators.Add("Divide");
                currentExpression += output + " / ";
                OutputTextBlock2.Text = currentExpression;
                output = "";
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                numbers.Add(double.Parse(output));
                output = "";
            }

            if (numbers.Count == 0 || numbers.Count < 2)
            {
                return;
            }

            double result = numbers[0];

            for (int i = 0; i < operators.Count; i++)
            {
                double nextNumber = numbers[i + 1];

                switch (operators[i])
                {
                    case "Minus":
                        result -= nextNumber;
                        break;

                    case "Plus":
                        result += nextNumber;
                        break;

                    case "Multiple":
                        result *= nextNumber;
                        break;

                    case "Divide":
                        if (nextNumber != 0)
                        {
                            result /= nextNumber;
                        }
                        break;
                }
            }

            previousResults.Add(result);

            if (previousResults.Count > 10)
            {
                previousResults.RemoveAt(0);
            }

            output = result.ToString();
            OutputTextBlock.Text = output;
            PrintPreviousResults();
            
            currentExpression = "";
            OutputTextBlock2.Text = currentExpression;

            numbers.Clear();
            operators.Clear();
        }

        public void PrintPreviousResults()
        {
            Console.WriteLine("Previous Results:");
            foreach (var result in previousResults)
            {
                Console.WriteLine(result);
            }
            previousResults.Reverse();

            PreviousResultsTextBlock.Text = string.Join(Environment.NewLine, previousResults);

            previousResults.Reverse();

        }


    }
}

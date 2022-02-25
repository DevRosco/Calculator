using System;
using System.Collections.Generic;
using System.Windows;

namespace Calc_2
{
      public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        readonly List<double> numbers = new List<double>();
        readonly List<string> ops = new List<string>();

        readonly string[] spliter = { " + ", " - ", " * ", " / " };

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.EndsWith(" + ") && !Display.Text.EndsWith(" - ") && !Display.Text.EndsWith(" * ") && !Display.Text.EndsWith(" / "))
            {
              if (ops.Contains("*") || ops.Contains("/"))
              {
                for (int j = 0; ops.Count > j; j++)
                {
                    if (j != -1)
                    {
                        if (ops[j] == "*")
                        {
                            numbers[j] = numbers[j] * numbers[j + 1];
                            numbers.RemoveAt(j + 1);
                            ops.RemoveAt(j);
                            Display.Text = "";
                            Display.Text = (numbers[j]).ToString();
                            j--;
                        }
                    }

                    if (j != -1)
                    {
                        if (ops[j] == "/")
                        {
                            numbers[j] = numbers[j] / numbers[j + 1];
                            numbers.RemoveAt(j + 1);
                            ops.RemoveAt(j);
                            Display.Text = "";
                            Display.Text += (numbers[j]).ToString();
                            j--;
                        }
                    }
                }
              }


            for (int j = 0; ops.Count > j; j++)
            {
                if (ops[j] == "+")
                {
                    numbers[j + 1] = numbers[j] + numbers[j + 1];
                    Display.Text = "";
                    Display.Text = (numbers[j + 1]).ToString();
                }
                if (ops[j] == "-")
                {
                    numbers[j + 1] = numbers[j] - numbers[j + 1];
                    Display.Text = "";
                    Display.Text = (numbers[j + 1]).ToString();
                }
            }
                    ops.Clear();
            }
        }
        private void ClearDisplay_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
            numbers.Clear();
            ops.Clear();
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "9";
            DisplayToList();
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "8";
            DisplayToList();
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "7";
            DisplayToList();
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "6";
            DisplayToList();
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "5";
            DisplayToList();
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "4";
            DisplayToList();
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "3";
            DisplayToList();
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "2";
            DisplayToList();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            CheckForZero();
            Display.Text += "1";
            DisplayToList();
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.EndsWith(" - 0") && !Display.Text.EndsWith(" + 0") && !Display.Text.EndsWith(" * 0") && !Display.Text.EndsWith(" / 0") && Display.Text != "0")
            {
                Display.Text += "0";
                DisplayToList();
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "0") LastOpsIs("+");
            
        }
          
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "0") LastOpsIs("-");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "0") LastOpsIs("*");
        }

        private void Devide_Click(object sender, RoutedEventArgs e)
        {
            if(Display.Text != "0") LastOpsIs("/");
        }

        private void DecimalPoint_Click(object sender, RoutedEventArgs e)
        {
           string decimalCheck = Display.Text;
           string[] testNumber  = decimalCheck.Split(spliter , StringSplitOptions.None);
           int tnCount = testNumber.Length - 1;
            
             if(!testNumber[tnCount].Contains(".")) 
             {
                if (Display.Text.Length != 0 && !Display.Text.EndsWith(" - ") && !Display.Text.EndsWith(" + ") && !Display.Text.EndsWith(" * ") && !Display.Text.EndsWith(" / "))
                {
                    Display.Text += ".";
                }
             }
        }

        public void LastOpsIs( string s)
        {
            if (numbers.Count != 0 && Display.Text != string.Empty)
            {
                if (Display.Text.EndsWith(" - ") || Display.Text.EndsWith(" + ") || Display.Text.EndsWith(" * ") || Display.Text.EndsWith(" / "))
                {
                    Display.Text = Display.Text.Remove(Display.Text.Length - 3, 3);
                    ops.RemoveAt(ops.Count - 1);
                    ops.Add(s);
                    Display.Text += " " + s +" ";
                }
                else
                {
                    Display.Text += " " + s + " ";
                    ops.Add(s);
                }
            }
        }

        public void DisplayToList()
        {
            string mainStr = Display.Text;
            string[] numOnly = mainStr.Split(spliter, StringSplitOptions.None);
            numbers.Clear();

            foreach (string nO in numOnly)
            {
                numbers.Add(double.Parse(nO));
            }
        }

        public void CheckForZero()
        {
            if (Display.Text == "0")
            {
                Display.Text = string.Empty;
            }
        }

        private void DeleteLast_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.EndsWith(" - ") || Display.Text.EndsWith(" + ") || Display.Text.EndsWith(" * ") || Display.Text.EndsWith(" / "))
            {
                Display.Text = Display.Text.Trim();
                Display.Text = Display.Text.Remove(Display.Text.Length - 1).Trim();
                ops.RemoveAt(ops.Count - 1);


            } else if(Display.Text != string.Empty)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length -1 );
                
            }else if(Display.Text == string.Empty)
            {
                ops.Clear();
                numbers.Clear();
            }

            if(Display.Text == "-")
            {
                Display.Text = "";
            }
                
        }

       
    }
}
































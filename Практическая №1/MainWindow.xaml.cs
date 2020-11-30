using System;
using System.Windows;
using System.Windows.Controls;
using org.mariuszgromada.math.mxparser;

namespace Практическая__1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool CanCalculate = true;
        public void GetResult(string StringToCalculate)
        {
            Label1.Content = StringToCalculate;
            MainTB.Text = Math.Calculate(StringToCalculate);
        }

        public MainWindow()
        {
            InitializeComponent();

            // Добавляем обработчик для всех кнопок на гриде
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ss = MainTB.Text;
            for (int i = 0; i < ss.Length; i++)
            {
                if(ss[i] == '=')
                { MainTB.Text = ""; }
            }
            string s = (string)((Button)e.OriginalSource).Content;

            switch(s)
            {
                case "=":
                    if (CanCalculate)
                        GetResult(MainTB.Text);
                    else MainTB.Text = MainTB.Text;
                    break;
                case "CE":
                    MainTB.Clear();
                    break;
                case "&#177;":
                    MainTB.Text = "-" + MainTB.Text;
                    break;
                default: MainTB.Text += s; Label1.Content = ""; break;
            }
         

        }

        private void LayoutRoot_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int key = (int)e.Key;
            if ((key >= 49) && (key <= 58))
            {
                if (MainTB.Text.Length == 6 && MainTB.Text.Length <= 6)
                {
                    e.Handled = true;
                }
                return;
            }
            e.Handled = true;
        }

        private void MainTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((MainTB.Text.Contains("(") && MainTB.Text.Contains(")")))
                CanCalculate = true;
            else if(MainTB.Text.Contains("(")) CanCalculate = false;

            if(MainTB.Text[MainTB.Text.Length-1] == '(' && MainTB.Text[MainTB.Text.Length-2] != '*')
            {
                MainTB.Text = MainTB.Text.Insert(MainTB.Text.Length - 1, "*");
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "D0":
                    MainTB.Text += "0";
                    break;
                case "D1":
                    MainTB.Text += "1";
                    break;
                case "D2":
                    MainTB.Text += "2";
                    break;
                case "D3":
                    MainTB.Text += "3";
                    break;
                case "D4":
                    MainTB.Text += "4";
                    break;
                case "D5":
                    MainTB.Text += "5";
                    break;
                case "D6":
                    MainTB.Text += "6";
                    break;
                case "D7":
                    MainTB.Text += "7";
                    break;
                case "D8":
                    MainTB.Text += "8";
                    break;
                case "D9":
                    MainTB.Text += "9";
                    break;
            }
        }
    }
}

        
    


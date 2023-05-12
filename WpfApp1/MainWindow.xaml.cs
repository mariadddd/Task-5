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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool _hasError = false;
        bool _isCalculationDone = false;

        private void Connect(string dictionary)
        {
            Uri uri = new Uri(dictionary, UriKind.Relative);
            ResourceDictionary res = (ResourceDictionary)Application.LoadComponent(uri);
            if (Application.Current.Resources.MergedDictionaries.Count > 1) Application.Current.Resources.MergedDictionaries.RemoveAt(Application.Current.Resources.MergedDictionaries.Count - 1);
            Application.Current.Resources.MergedDictionaries.Add(res);
        }


        private void LightRB_OnChecked(object sender, RoutedEventArgs e)
        {
            Connect("Light.xaml");
        }

        private void DarkRB_OnChecked(object sender, RoutedEventArgs e)
        {
            Connect("Dark.xaml");
        }

        private void OperandInput(object sender, RoutedEventArgs e)
        {
            //Button tmp = sender as Button;
            //if (Operand.Text == "0")
            //{
            //    Operand.Text = tmp.Content.ToString();
            //}
            //else
            //{
            //    Operand.Text += tmp.Content.ToString();
            //}

            if (e.OriginalSource is Button button)
            {
                if (Operand.Text == "0")
                {
                    Operand.Text = button.Content.ToString();
                }
                else
                {
                    Operand.Text += button.Content.ToString();
                }
            }
        }

        private void SignInput(object sender, RoutedEventArgs e)
        {
             Operand.Text += ((Button)e.OriginalSource).Content.ToString();            
        }

        private void ResultInput(object sender, RoutedEventArgs e)
        {
            if (Operand.Text != "0") 
            {
                Operand.Text += " = ";
                Result.Text = Operand.Text; 
            }
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            _isCalculationDone = _hasError = false;
            Result.Text = null;
            Clear(sender, e);
            
        }
        private void Clear(object sender, RoutedEventArgs e) => Operand.Text = "0";

        private void PointInput(object sender, RoutedEventArgs e)
        {

        }

        
    }
}

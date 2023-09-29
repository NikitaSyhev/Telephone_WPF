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

namespace Calculator
{
    
    public partial class MainWindow : Window
    {
        List<Key> allow_keys;   
        public MainWindow()
        {
            InitializeComponent();
            allow_keys = new List<Key>(){ Key.D0, Key.D1,
                Key.D2, Key.D3, Key.D4, Key.D5, Key.D6,
                Key.D7,Key.D8, Key.D9, Key.OemPlus};
            

        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            string currentText = texbBoxInput.Text;
            string buttonContent = ((Button)sender).Content.ToString();
            if (currentText.Length >= 11)
            {
                return;
            }

            if (currentText.StartsWith("+") || currentText.StartsWith("8"))
            {
                if (currentText.Length + 1 <= 11)
                {
                    texbBoxInput.Text += ((Button)sender).Content.ToString();
                }
            }

            else if (currentText.Length == 0 && (buttonContent == "+" || buttonContent == "8"))
            {
                texbBoxInput.Text = buttonContent;
            }

        }

        private string key2string(Key key) // преобразовать в строку
        {
            string result = "";
            if (allow_keys.Contains(key))
            {
                List<Key> Numbers = new List<Key>() { Key.D0, Key.D1,Key.D2, Key.D3, Key.D4, Key.D5, Key.D6,
                Key.D7,Key.D8, Key.D9};
                
                if (Numbers.Contains(key)) return key.ToString().Trim('D');

            }
            
            return result;
        }

        private void btnCALL(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИДЕТ ЗВОНОК");
        }

       

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string currentText = texbBoxInput.Text;
            var result = key2string(e.Key);

            if (e.Source == texbBoxInput)
            {
                e.Handled = true;
            }
            if (currentText.Length >= 11)
            {
                return;
            }


            if (result != "back" && (currentText.StartsWith("+") || currentText.StartsWith("8")))
            {
                if (currentText.Length + 1 <= 11)
                {
                    texbBoxInput.Text += result;
                }
            }
            else if (result != "back" && currentText.Length == 0 && (result == "+" || result == "8"))
            {
                if (currentText.Length + 1 <= 11)
                {
                    texbBoxInput.Text = result;
                }
            }
            else
            {
                if (texbBoxInput.Text.Length > 1)
                {
                    texbBoxInput.Text = texbBoxInput.Text.Remove(texbBoxInput.Text.Length - 1, 1);
                }
                
            }    
            
        }
    }
}

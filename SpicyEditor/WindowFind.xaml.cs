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
using System.Windows.Shapes;

namespace SpicyEditor
{
    /// <summary>
    /// Логика взаимодействия для WindowFind.xaml
    /// </summary>
    public partial class WindowFind : Window
    {
        public WindowFind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public string getText
        {
            get { return searchText.Text; }
        }
        public string getReplaceText
        {
            get { return replaceText.Text; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SpicyEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel(new DialogService(), new JsonFileService());

        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            //TextBox.Clear();
            
        }

        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox.SelectedText = "";
        }
        private void FindCommandHandler(object sender, ExecutedRoutedEventArgs e) // нужно окно для ввода текста
        {
            string find = "str";
            if (TextBox.Text.Contains(find))
            {
                int i = 0;
                while (i <= TextBox.Text.Length - find.Length)
                {
                    i = TextBox.Text.IndexOf(find, i);
                    if (i < 0) break;
                    TextBox.SelectionStart = i;
                    TextBox.SelectionLength = find.Length;
                    //TextBox.SelectionColor = Color.Blue;
                    TextBox.Focus();
                    i += find.Length;
                }
            }
            else
            {
                MessageBox.Show("Не найдено ни одного соответствия");
            }
        }
    }
}

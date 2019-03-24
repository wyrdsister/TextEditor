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
        }

        void CloseApp(object target, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
//            TextBox.SelectedText = "";
        }
        private void FindCommandHandler(object sender, ExecutedRoutedEventArgs e) // нужно окно для ввода текста
        {

//            string find = "";
//            SearchWindow windowFind = new SearchWindow();
//            windowFind.Owner = this;
//            if (windowFind.ShowDialog() == true)
//                find = windowFind.getText;

//            if (TextBox.Text.Contains(find))
//            {
//                int i = 0;
//                while (i <= TextBox.Text.Length - find.Length)
//                {
//                    i = TextBox.Text.IndexOf(find, i);
//                    if (i < 0) break;
//                    TextBox.SelectionStart = i;
//                    TextBox.SelectionLength = find.Length;
//                    //TextBox.SelectionColor = Color.Blue;
//                    TextBox.Focus();
//                    i += find.Length;
//                }
//            }
//            else
//            {
//                MessageBox.Show("Не найдено ни одного соответствия");
//            }
        }
        private void ReplaceCommandHandler(object sender, ExecutedRoutedEventArgs e) // нужно окно для ввода текста
        {
//            string oldStr = ""; string newStr = "";
//            SearchWindow windowFind = new SearchWindow();
//            windowFind.Owner = this;
//            windowFind.LabelSearch.Content = "Old text";
//            windowFind.Title = "Replace";
//            windowFind.searchButton.Content = "Replace";
//            windowFind.labelReplace.Content = "New text";
//            windowFind.labelReplace.IsEnabled = true;
//            windowFind.replaceText.IsEnabled = true;
//            if (windowFind.ShowDialog() == true)
//            {
//                oldStr = windowFind.getText;
//                newStr = windowFind.getReplaceText;
//            }
//            TextBox.Text = TextBox.Text.Replace(oldStr, newStr);
        }
    }
}

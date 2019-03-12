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
            DataContext =
                new ViewModel(new DialogService(), new JsonFileService());
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    ViewModel vm = new ViewModel();
        //    vm.MainText = textBox.Text;
        //    //MessageBox.Show(textBox.Text);
        //}
    }
}

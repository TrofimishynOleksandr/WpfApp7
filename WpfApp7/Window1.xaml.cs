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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly ViewModel _viewModel;

        public Window1(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                _viewModel.Window1Option = 1;
                this.DialogResult = true;
            }
            else
            {
                Task task = Task.Run(() =>
                {
                    _viewModel.Window1TextBlock = "Enter new title";
                    Thread.Sleep(1000);
                    _viewModel.Window1TextBlock = "Change title on ";
                });
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            _viewModel.Window1Option = 2;
            this.DialogResult = true;
        }
    }
}

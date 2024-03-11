using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel;
        private readonly Service _service;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new ViewModel();
            _service = new Service(_viewModel);
            DataContext = _viewModel;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _service.Task1();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _viewModel.Handle = new WindowInteropHelper(this).Handle;
            _service.Task2();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _service.Task3();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
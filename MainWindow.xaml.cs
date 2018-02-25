using FontAwesome.WPF;
using System.Windows;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(ShowLoader);
        }
        
        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}

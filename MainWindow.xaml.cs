using FontAwesome.WPF;
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

namespace Lab2
{
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(UpdateResult, ShowLoader);
        }

        private void UpdateResult()
        {
            ((MainWindowViewModel)DataContext).Name = "Your name is " + ((MainWindowViewModel)DataContext).Name;
            ((MainWindowViewModel)DataContext).LastName = "Your surname is " + ((MainWindowViewModel)DataContext).LastName;
            ((MainWindowViewModel)DataContext).Age = "You are " + ((MainWindowViewModel)DataContext).Age + " years of old";
            ((MainWindowViewModel)DataContext).WestHoroscope = "In the Western horoscope you are " + ((MainWindowViewModel)DataContext).WestHoroscope;
            ((MainWindowViewModel)DataContext).ChineseHoroscope = "In the Chinese horoscope you are " + ((MainWindowViewModel)DataContext).ChineseHoroscope;
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}

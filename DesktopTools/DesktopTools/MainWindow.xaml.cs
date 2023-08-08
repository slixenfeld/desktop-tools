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
using DesktopTools.Views;

namespace DesktopTools
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

        private void Stopwatch_Click(object sender, RoutedEventArgs e)
        {
            DesktopTools.Views.TimerApp stopwatch = new DesktopTools.Views.TimerApp();
            stopwatch.Show();
        }

        private void OpenRandomTools(object sender, RoutedEventArgs e)
        {
            DesktopTools.Views.Random randomTools = new DesktopTools.Views.Random();
            randomTools.Show();
        }
    }
}

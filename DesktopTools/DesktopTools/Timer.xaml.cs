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
using System.Threading;

namespace DesktopTools
{
    public partial class TimerApp : Window
    {
        System.Windows.Threading.DispatcherTimer tickTimer = new System.Windows.Threading.DispatcherTimer();

        string currentTime = "";
        string endTime = "";
        bool running = false;

        public TimerApp()
        {
            InitializeComponent();
            StopwatchTime1.Text = GetElapsedTime("19:00:00", "20:00:00");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            currentTime = DateTime.Now.ToString("hh:mm:ss");

            string format = "hh\\:mm\\:ss";
            endTime = (DateTime.Now + TimeSpan.ParseExact(StopwatchTime1.Text, format, null)).ToString("hh:mm:ss");

            tickTimer.Tick += new EventHandler(Tick);
            tickTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            tickTimer.Start();

            running = true;
        }

        private void StopwatchTime1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StopwatchTime1.Text = "";
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            running = false;
            tickTimer.Stop();
        }
        public void Tick(object sender, EventArgs e)
        {
            if (running)
            {
                currentTime = DateTime.Now.ToString("hh:mm:ss");
                StopwatchTime1.Text = GetElapsedTime(currentTime, endTime);
            }
        }
  
        private string GetElapsedTime(string startTime, string endTime)
        {
            string format = "hh\\:mm\\:ss";
            TimeSpan startTimeSpan = TimeSpan.ParseExact(startTime, format, null);
            TimeSpan endTimeSpan = TimeSpan.ParseExact(endTime, format, null);
            TimeSpan result = endTimeSpan - startTimeSpan;

            return string.Format("{0}:{1}:{2}", result.Hours.ToString("00"), result.Minutes.ToString("00"), result.Seconds.ToString("00"));
        }
    }
}

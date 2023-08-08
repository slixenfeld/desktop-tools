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

namespace DesktopTools.Views
{
    public partial class TimerApp : Window
    {
        System.Windows.Threading.DispatcherTimer tickTimer = new System.Windows.Threading.DispatcherTimer();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"sounds/marimba.wav");
        string currentTime = "";
        string endTime = "";
        bool running = false;
        const string FORMAT = "hh\\:mm\\:ss";

        public TimerApp()
        {
            InitializeComponent();
            InitTimer();
        }

        private void InitTimer()
        {
            tickTimer.Tick += new EventHandler(Tick);
            tickTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
        }

        private string GetStartingTime(int minute)
        {
            return (minute < 10) ? "00:0" + minute + ":01" : "00:" + minute + ":01";
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (TimerBox.Text.Length == 0) return;

            endTime = (DateTime.Now + TimeSpan.ParseExact(GetStartingTime(int.Parse(TimerBox.Text)), FORMAT, null)).ToString(FORMAT);
            tickTimer.Start();
            running = true;
            player.Load();
        }

        private void StopwatchTime1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimerBox.Text = "";
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
            player.Stop();
        }

        private void StopTimer()
        {
            running = false;
            tickTimer.Stop();
            TimerBox.Text = "";
        }

        public void Tick(object sender, EventArgs e)
        {
            if (running)
            {
                currentTime = DateTime.Now.ToString(FORMAT);
                TimerBox.Text = GetElapsedTime(currentTime, endTime);
                if (TimerBox.Text == "00:00:00")
                {
                    StopTimer();
                    player.Play();
                }
            }
        }
  
        private string GetElapsedTime(string startTime, string endTime)
        {
            TimeSpan startTimeSpan = TimeSpan.ParseExact(startTime, FORMAT, null);
            TimeSpan endTimeSpan = TimeSpan.ParseExact(endTime, FORMAT, null);
            TimeSpan result = endTimeSpan - startTimeSpan;

            return string.Format("{0}:{1}:{2}", result.Hours.ToString("00"), result.Minutes.ToString("00"), result.Seconds.ToString("00"));
        }
    }
}

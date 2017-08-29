using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;

namespace Stopwatch
{
    /// <summary>
    /// Interaction logic for Stopwatch.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime startTime;
        private readonly Timer _timer = new Timer();

        public MainWindow()
        {
            InitializeComponent();

            // Show controls, hide the timer.
            ShowControls();

            // Timer setup
            _timer.Interval = 5;
            _timer.Enabled = false;
            _timer.Tick += TimerTick;
        }


        private void TimerTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeDiff = now.Subtract(startTime);
            TimeText.Text = timeDiff.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ShowControls()
        {
            Timer.Visibility = Visibility.Hidden;
            Controls.Visibility = Visibility.Visible;
        }

        private void ShowTimer()
        {
            Timer.Visibility = Visibility.Visible;
            Controls.Visibility = Visibility.Hidden;
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowControls();
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShowTimer();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            startTime = DateTime.Now;
            _timer.Start();
            ShowTimer();
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            ShowTimer();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

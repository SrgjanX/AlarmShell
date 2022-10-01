//srgjanx

using System;
using System.Drawing;
using System.Timers;
using System.Windows;
using Forms = System.Windows.Forms;

namespace AlarmShell
{
    public partial class MainWindow : Window
    {
        private AlarmInfo? alarmInfo;
        private Timer timer;
        private Forms.NotifyIcon nIcon;
        private int snoozeMins = 5;

        public MainWindow(string[] args)
        {
            try
            {
                InitializeComponent();
                ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
                alarmInfo = argumentsProcessor.GetAlarmInfo();
                Title = alarmInfo?.Name ?? "";
                SetupAlarm(alarmInfo);
                SetupNotification();
                lblAlarmActiveTime.Content = DateTime.Now.Add(alarmInfo.TimeSpan).ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Alarm Shell", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        ~MainWindow()
        {
            timer.Dispose();
            nIcon.Dispose();
        }

        private void SetupAlarm(AlarmInfo alarmInfo)
        {
            if (alarmInfo == null)
                throw new Exception("Cannot create alarm because there is no alarm data.");
            timer = new Timer();
            timer.Interval = alarmInfo.TimeSpan.TotalMilliseconds;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void SetupNotification()
        {
            nIcon = new Forms.NotifyIcon()
            {
                Text = alarmInfo?.Name
            };
            nIcon.Icon = new Icon(AppContext.BaseDirectory + "Resources/icon.ico");
            nIcon.Visible = true;
            nIcon.Click += NIcon_Click;
        }

        private void ActivateWindow()
        {
            WindowState = WindowState.Normal;
            Activate();
            Show();
        }

        private void NIcon_Click(object? sender, EventArgs e)
        {
            ActivateWindow();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    btnSnooze.IsEnabled = true;
                    ActivateWindow();
                    nIcon.ShowBalloonTip(5000, "Alarm Shell", alarmInfo?.Name ?? "", Forms.ToolTipIcon.Info);
                    System.Media.SystemSounds.Asterisk.Play();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Alarm Shell", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSnooze_Click(object sender, RoutedEventArgs e)
        {
            if(timer != null)
            {
                timer.Interval = TimeSpan.FromMinutes(snoozeMins).TotalMilliseconds;
                timer.Start();
                lblAlarmActiveTime.Content = DateTime.Now.AddMinutes(snoozeMins).ToShortTimeString();
                WindowState = WindowState.Minimized;
                btnSnooze.IsEnabled = false;
            }
        }
    }
}   
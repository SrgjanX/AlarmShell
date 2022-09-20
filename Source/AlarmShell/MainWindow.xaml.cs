//srgjanx

using System;
using System.Windows;

namespace AlarmShell
{
    public partial class MainWindow : Window
    {
        public MainWindow(string[] args)
        {
            InitializeComponent();
            try
            {
                ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(Environment.GetCommandLineArgs());
                AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
                //Do something with alarm info.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
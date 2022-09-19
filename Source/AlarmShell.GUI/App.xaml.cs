using System.Windows;

namespace AlarmShell.GUI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new MainWindow(e.Args).Show();
        }
    }
}
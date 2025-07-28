using Scanner.Services;
using Scanner.Views;

namespace Scanner;

public partial class App : Application
{
    /// <summary>
    /// TODO:
    /// I want to give the ability to stay logged in.
    /// IsLoggenOn cookie should self destruct after a certain amount of time...
    /// </summary>
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        MainPage = Preferences.Get("IsLoggedOn", false) ? (Page)serviceProvider.GetService(typeof(AppShell)) : (Page)serviceProvider.GetService(typeof(LoginView));
    }
}
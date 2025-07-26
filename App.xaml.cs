using Scanner.Views;

namespace Scanner;

public partial class App : Application
{
    /// <summary>
    /// TODO:
    /// I want to give the ability to stay logged in.
    /// IsLoggenOn cookie should self destruct after a certain amount of time...
    /// </summary>
    public App()
    {
        InitializeComponent();

        if (Preferences.Get("IsLoggedOn", false))
        {
            MainPage = new AppShell();
        }
        else
        {
            MainPage = new NavigationPage(new LoginPage());   
        }
    }
}
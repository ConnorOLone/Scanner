namespace Scanner.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void OnTestConnectionClicked(object sender, EventArgs e)
    {
        Thread.Sleep(1000);
        TestConnectionButton.BackgroundColor = Colors.Green;
        Thread.Sleep(1000);
    }

    private void OnChangePasswordClicked(object sender, EventArgs e)
    {
    }

    private void OnClearCacheClicked(object sender, EventArgs e)
    {
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}
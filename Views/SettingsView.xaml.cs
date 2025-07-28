namespace Scanner.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void OnClearCacheClicked(object sender, EventArgs e)
    {
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}
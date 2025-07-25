namespace Scanner.Views;

public partial class MainMenuPage : ContentPage
{
    public MainMenuPage()
    {
        InitializeComponent();
    }

    private async void OnMoveItemTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//moveitem");
    }

    private async void OnCheckLocationTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//checklocation");
    }

    private async void OnDispatchItemsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//dispatchitems");
    }

    private async void OnReturnItemsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//returnitems");
    }

    private async void OnTrackBoxTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//trackboxmenu");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (result)
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}
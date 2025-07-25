namespace Scanner.Views;

public partial class TrackBoxMenuPage : ContentPage
{
    public TrackBoxMenuPage()
    {
        InitializeComponent();
        UpdateLastUpdatedTime();
    }

    private void UpdateLastUpdatedTime()
    {
        LastUpdatedLabel.Text = DateTime.Now.ToString("HH:mm");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainmenu");
    }

    private async void OnMoveBoxTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//movebox");
    }

    private async void OnCheckBoxLocationTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//checkboxlocation");
    }

    private async void OnReturnToMainClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainmenu");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateLastUpdatedTime();
    }
}
namespace Scanner.Views;

public partial class CheckLocationPage : ContentPage
{
    public CheckLocationPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainmenu");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        ItemIdEntry.Text = "ITEM-" + Random.Shared.Next(1000, 9999);
        await SearchItem();
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ItemIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter an item ID to search.", "OK");
            return;
        }

        await SearchItem();
    }

    private async Task SearchItem()
    {
        SearchButton.IsEnabled = false;
        SearchButton.Text = "⏳";

        await Task.Delay(1500);

        var random = Random.Shared;
        var locations = new[]
        {
            ("Warehouse A - Section 12 - Shelf B3", "Ground floor, near loading dock", "Available"),
            ("Storage Room C - Rack 5 - Level 2", "Climate controlled area", "Reserved"),
            ("Dispatch Zone - Bay 3", "Ready for shipment", "In Transit"),
            ("Quality Control - Station 1", "Under inspection", "On Hold")
        };

        var location = locations[random.Next(locations.Length)];
        
        ItemIdResultLabel.Text = ItemIdEntry.Text;
        LocationLabel.Text = location.Item1;
        LocationDetailsLabel.Text = location.Item2;
        StatusLabel.Text = location.Item3;

        StatusBorder.BackgroundColor = location.Item3 switch
        {
            "Available" => Color.FromArgb("#4CAF50"),
            "Reserved" => Color.FromArgb("#FF9800"),
            "In Transit" => Color.FromArgb("#2196F3"),
            "On Hold" => Color.FromArgb("#F44336"),
            _ => Color.FromArgb("#4CAF50")
        };

        LastMovedLabel.Text = DateTime.Now.AddDays(-random.Next(1, 30)).ToString("MMM dd, yyyy hh:mm tt");
        MovedByLabel.Text = $"User{random.Next(100, 999)}";
        CategoryLabel.Text = new[] { "Electronics", "Tools", "Documents", "Equipment", "Supplies" }[random.Next(5)];

        ResultsCard.IsVisible = true;
        QuickActionsSection.IsVisible = true;

        SearchButton.IsEnabled = true;
        SearchButton.Text = "🔍";
    }

    private async void OnMoveThisItemClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//moveitem?itemId={ItemIdEntry.Text}");
    }

    private void OnSearchAnotherClicked(object sender, EventArgs e)
    {
        ItemIdEntry.Text = string.Empty;
        ResultsCard.IsVisible = false;
        QuickActionsSection.IsVisible = false;
    }
}
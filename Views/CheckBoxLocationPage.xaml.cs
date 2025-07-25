namespace Scanner.Views;

public partial class CheckBoxLocationPage : ContentPage
{
    public CheckBoxLocationPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//trackboxmenu");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        BoxIdEntry.Text = "BOX-" + Random.Shared.Next(1000, 9999);
        await SearchBox();
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(BoxIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a box ID to search.", "OK");
            return;
        }

        await SearchBox();
    }

    private async Task SearchBox()
    {
        SearchButton.IsEnabled = false;
        SearchButton.Text = "⏳";

        await Task.Delay(1500);

        var random = Random.Shared;
        
        var locations = new[]
        {
            ("Storage Area A - Shelf 1 - Position 3", "Ground level, easy access"),
            ("Storage Area B - Shelf 2 - Position 1", "Second level, north wall"),
            ("Dispatch Zone - Bay 1 - Loading Area", "Ready for shipment"),
            ("Quality Control - Inspection Station 2", "Under review"),
            ("Temporary Storage - Overflow Area", "Temporary placement")
        };

        var contents = new[]
        {
            "Electronics & Components",
            "Office Supplies & Stationery",
            "Tools & Equipment",
            "Documents & Files",
            "Spare Parts & Hardware"
        };

        var sizes = new[] { "Small (30x20x15cm)", "Medium (50x30x25cm)", "Large (70x40x35cm)" };
        var weights = new[] { "2.5 kg", "5.8 kg", "12.3 kg", "8.1 kg", "15.7 kg" };

        var statuses = new[]
        {
            ("Available", Color.FromArgb("#4CAF50")),
            ("In Use", Color.FromArgb("#FF9800")),
            ("Reserved", Color.FromArgb("#2196F3")),
            ("Under Review", Color.FromArgb("#9C27B0"))
        };

        var location = locations[random.Next(locations.Length)];
        var status = statuses[random.Next(statuses.Length)];
        
        BoxIdResultLabel.Text = BoxIdEntry.Text;
        LocationLabel.Text = location.Item1;
        LocationDetailsLabel.Text = location.Item2;
        StatusLabel.Text = status.Item1;
        StatusBorder.BackgroundColor = status.Item2;

        ContentsLabel.Text = contents[random.Next(contents.Length)];
        SizeLabel.Text = sizes[random.Next(sizes.Length)];
        WeightLabel.Text = weights[random.Next(weights.Length)];
        LastMovedLabel.Text = DateTime.Now.AddDays(-random.Next(1, 30)).ToString("MMM dd, yyyy hh:mm tt");

        ResultsCard.IsVisible = true;
        QuickActionsSection.IsVisible = true;

        SearchButton.IsEnabled = true;
        SearchButton.Text = "🔍";
    }

    private async void OnMoveThisBoxClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//movebox?boxId={BoxIdEntry.Text}");
    }

    private void OnSearchAnotherClicked(object sender, EventArgs e)
    {
        BoxIdEntry.Text = string.Empty;
        ResultsCard.IsVisible = false;
        QuickActionsSection.IsVisible = false;
    }
}
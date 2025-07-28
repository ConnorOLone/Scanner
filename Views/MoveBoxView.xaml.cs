namespace Scanner.Views;

public partial class MoveBoxView : ContentPage
{
    public MoveBoxView()
    {
        InitializeComponent();
        BoxIdEntry.TextChanged += OnBoxIdChanged;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//trackboxmenu");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        BoxIdEntry.Text = "BOX-" + Random.Shared.Next(1000, 9999);
        await LoadBoxDetails();
    }

    private async void OnBoxIdChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue.Length >= 3)
        {
            await LoadBoxDetails();
        }
        else
        {
            HideDestinationCard();
        }
    }

    private async Task LoadBoxDetails()
    {
        await Task.Delay(500);
        
        var locations = new[]
        {
            "Storage Area A - Shelf 1 - Position 3",
            "Storage Area B - Shelf 2 - Position 1",
            "Dispatch Zone - Bay 1 - Loading Area",
            "Quality Control - Inspection Station 2"
        };

        var contents = new[]
        {
            "Electronics & Components",
            "Office Supplies",
            "Tools & Equipment",
            "Documents & Files",
            "Spare Parts"
        };

        var sizes = new[] { "Small (30x20x15cm)", "Medium (50x30x25cm)", "Large (70x40x35cm)" };
        var weights = new[] { "2.5 kg", "5.8 kg", "12.3 kg", "8.1 kg", "15.7 kg" };

        var random = Random.Shared;
        
        CurrentLocationLabel.Text = locations[random.Next(locations.Length)];
        ContentsLabel.Text = contents[random.Next(contents.Length)];
        SizeLabel.Text = sizes[random.Next(sizes.Length)];
        WeightLabel.Text = weights[random.Next(weights.Length)];
        
        CurrentLocationSection.IsVisible = true;
        BoxDetailsSection.IsVisible = true;
        DestinationCard.IsVisible = true;
        ActionButtonsSection.IsVisible = true;
    }

    private void HideDestinationCard()
    {
        CurrentLocationSection.IsVisible = false;
        BoxDetailsSection.IsVisible = false;
        DestinationCard.IsVisible = false;
        ActionButtonsSection.IsVisible = false;
    }

    private async void OnMoveBoxClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(BoxIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a box ID.", "OK");
            return;
        }

        if (DestinationPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a destination location.", "OK");
            return;
        }

        MoveBoxButton.IsEnabled = false;
        MoveBoxButton.Text = "Moving Box...";

        await Task.Delay(2000);

        string destination = DestinationPicker.Items[DestinationPicker.SelectedIndex];
        string moveType = UrgentMoveSwitch.IsToggled ? "urgent move" : "standard move";
        string message = $"Box {BoxIdEntry.Text} has been successfully moved to {destination} via {moveType}.";
        
        if (!string.IsNullOrWhiteSpace(MoveReasonEditor.Text))
        {
            message += $"\n\nReason: {MoveReasonEditor.Text}";
        }
        
        await DisplayAlert("Success", message, "OK");

        OnClearClicked(sender, e);
        MoveBoxButton.IsEnabled = true;
        MoveBoxButton.Text = "Move Box";
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        BoxIdEntry.Text = string.Empty;
        DestinationPicker.SelectedIndex = -1;
        MoveReasonEditor.Text = string.Empty;
        UrgentMoveSwitch.IsToggled = false;
        HideDestinationCard();
    }
}
namespace Scanner.Views;

public partial class MoveItemView : ContentPage
{
    public MoveItemView()
    {
        InitializeComponent();
        ItemIdEntry.TextChanged += OnItemIdChanged;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainmenu");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        ItemIdEntry.Text = "ITEM-" + Random.Shared.Next(1000, 9999);
        await LoadItemDetails();
    }

    private async void OnItemIdChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue.Length >= 3)
        {
            await LoadItemDetails();
        }
        else
        {
            HideDestinationCard();
        }
    }

    private async Task LoadItemDetails()
    {
        await Task.Delay(500);
        
        CurrentLocationLabel.Text = "Warehouse A - Section 12 - Shelf B3";
        CurrentLocationSection.IsVisible = true;
        DestinationCard.IsVisible = true;
        ActionButtonsSection.IsVisible = true;
    }

    private void HideDestinationCard()
    {
        CurrentLocationSection.IsVisible = false;
        DestinationCard.IsVisible = false;
        ActionButtonsSection.IsVisible = false;
    }

    private async void OnMoveItemClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ItemIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter an item ID.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(DestinationEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a destination location.", "OK");
            return;
        }

        MoveItemButton.IsEnabled = false;
        MoveItemButton.Text = "Moving Item...";

        await Task.Delay(2000);

        string transferType = ExceptionalTransferSwitch.IsToggled ? "exceptional transfer" : "standard move";
        string message = $"Item {ItemIdEntry.Text} has been successfully moved to {DestinationEntry.Text} via {transferType}.";
        
        await DisplayAlert("Success", message, "OK");

        OnClearClicked(sender, e);
        MoveItemButton.IsEnabled = true;
        MoveItemButton.Text = "Move Item";
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        ItemIdEntry.Text = string.Empty;
        DestinationEntry.Text = string.Empty;
        NotesEditor.Text = string.Empty;
        ExceptionalTransferSwitch.IsToggled = false;
        HideDestinationCard();
    }
}
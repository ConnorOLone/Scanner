using System.Collections.ObjectModel;

namespace Scanner.Views;

public partial class DispatchItemsPage : ContentPage
{
    public ObservableCollection<DispatchItem> DispatchItems { get; set; }

    public DispatchItemsPage()
    {
        InitializeComponent();
        DispatchItems = new ObservableCollection<DispatchItem>();
        BindingContext = this;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mainmenu");
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        ItemIdEntry.Text = "ITEM-" + Random.Shared.Next(1000, 9999);
    }

    private async void OnAddItemClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ItemIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter an item ID.", "OK");
            return;
        }

        if (DispatchItems.Any(item => item.ItemId == ItemIdEntry.Text))
        {
            await DisplayAlert("Duplicate", "This item is already in the dispatch list.", "OK");
            return;
        }

        var locations = new[]
        {
            "Warehouse A - Section 12",
            "Storage Room C - Rack 5",
            "Quality Control - Station 1",
            "Inventory - Zone B"
        };

        var dispatchItem = new DispatchItem
        {
            ItemId = ItemIdEntry.Text,
            Location = locations[Random.Shared.Next(locations.Length)],
            DateAdded = DateTime.Now
        };

        DispatchItems.Add(dispatchItem);
        UpdateItemCount();
        ItemIdEntry.Text = string.Empty;
    }

    private void OnRemoveItemClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is DispatchItem item)
        {
            DispatchItems.Remove(item);
            UpdateItemCount();
        }
    }

    private void UpdateItemCount()
    {
        ItemCountLabel.Text = $"{DispatchItems.Count} item{(DispatchItems.Count != 1 ? "s" : "")}";
    }

    private async void OnCreateDispatchClicked(object sender, EventArgs e)
    {
        if (!DispatchItems.Any())
        {
            await DisplayAlert("Error", "Please add at least one item to dispatch.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(DestinationEditor.Text))
        {
            await DisplayAlert("Error", "Please enter a destination address.", "OK");
            return;
        }

        if (CarrierPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a carrier service.", "OK");
            return;
        }

        CreateDispatchButton.IsEnabled = false;
        CreateDispatchButton.Text = "Creating Dispatch Order...";

        await Task.Delay(2000);

        string dispatchId = "DISP-" + Random.Shared.Next(10000, 99999);
        string urgentText = UrgentDispatchSwitch.IsToggled ? " (URGENT)" : "";
        string message = $"Dispatch order {dispatchId} has been created successfully{urgentText}.\n\n" +
                        $"Items: {DispatchItems.Count}\n" +
                        $"Carrier: {CarrierPicker.Items[CarrierPicker.SelectedIndex]}\n" +
                        $"Estimated delivery: {DateTime.Now.AddDays(UrgentDispatchSwitch.IsToggled ? 1 : 3):MMM dd, yyyy}";

        await DisplayAlert("Success", message, "OK");

        OnClearAllClicked(sender, e);
        CreateDispatchButton.IsEnabled = true;
        CreateDispatchButton.Text = "Create Dispatch Order";
    }

    private void OnClearAllClicked(object sender, EventArgs e)
    {
        DispatchItems.Clear();
        UpdateItemCount();
        DestinationEditor.Text = string.Empty;
        CarrierPicker.SelectedIndex = -1;
        UrgentDispatchSwitch.IsToggled = false;
        ItemIdEntry.Text = string.Empty;
    }
}

public class DispatchItem
{
    public string ItemId { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
}
using System.Collections.ObjectModel;

namespace Scanner.Views;

public partial class ReturnItemsView : ContentPage
{
    public ObservableCollection<ReturnItem> ReturnItems { get; set; }

    public ReturnItemsView()
    {
        InitializeComponent();
        ReturnItems = new ObservableCollection<ReturnItem>();
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

        if (ReturnItems.Any(item => item.ItemId == ItemIdEntry.Text))
        {
            await DisplayAlert("Duplicate", "This item is already in the return list.", "OK");
            return;
        }

        var locations = new[]
        {
            "Customer Location",
            "Field Service",
            "Dispatch Center",
            "Quality Control"
        };

        var statuses = new[]
        {
            ("Pending", Color.FromArgb("#FF9800")),
            ("Damaged", Color.FromArgb("#F44336")),
            ("Expired", Color.FromArgb("#9C27B0")),
            ("Defective", Color.FromArgb("#F44336"))
        };

        var status = statuses[Random.Shared.Next(statuses.Length)];

        var returnItem = new ReturnItem
        {
            ItemId = ItemIdEntry.Text,
            OriginalLocation = locations[Random.Shared.Next(locations.Length)],
            Status = status.Item1,
            StatusColor = status.Item2,
            DateAdded = DateTime.Now
        };

        ReturnItems.Add(returnItem);
        UpdateItemCount();
        ItemIdEntry.Text = string.Empty;
    }

    private void OnRemoveItemClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is ReturnItem item)
        {
            ReturnItems.Remove(item);
            UpdateItemCount();
        }
    }

    private void UpdateItemCount()
    {
        ItemCountLabel.Text = $"{ReturnItems.Count} item{(ReturnItems.Count != 1 ? "s" : "")}";
    }

    private async void OnProcessReturnsClicked(object sender, EventArgs e)
    {
        if (!ReturnItems.Any())
        {
            await DisplayAlert("Error", "Please add at least one item to process.", "OK");
            return;
        }

        if (ReturnReasonPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a return reason.", "OK");
            return;
        }

        if (DestinationPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a return destination.", "OK");
            return;
        }

        ProcessReturnsButton.IsEnabled = false;
        ProcessReturnsButton.Text = "Processing Returns...";

        await Task.Delay(2000);

        string returnId = "RET-" + Random.Shared.Next(10000, 99999);
        string reason = ReturnReasonPicker.Items[ReturnReasonPicker.SelectedIndex];
        string destination = DestinationPicker.Items[DestinationPicker.SelectedIndex];
        
        string message = $"Return batch {returnId} has been processed successfully.\n\n" +
                        $"Items: {ReturnItems.Count}\n" +
                        $"Reason: {reason}\n" +
                        $"Destination: {destination}\n" +
                        $"Processing Date: {DateTime.Now:MMM dd, yyyy hh:mm tt}";

        await DisplayAlert("Success", message, "OK");

        OnClearAllClicked(sender, e);
        ProcessReturnsButton.IsEnabled = true;
        ProcessReturnsButton.Text = "Process Returns";
    }

    private void OnClearAllClicked(object sender, EventArgs e)
    {
        ReturnItems.Clear();
        UpdateItemCount();
        ReturnReasonPicker.SelectedIndex = -1;
        DestinationPicker.SelectedIndex = -1;
        NotesEditor.Text = string.Empty;
        ItemIdEntry.Text = string.Empty;
    }
}

public class ReturnItem
{
    public string ItemId { get; set; } = string.Empty;
    public string OriginalLocation { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Color StatusColor { get; set; }
    public DateTime DateAdded { get; set; }
}